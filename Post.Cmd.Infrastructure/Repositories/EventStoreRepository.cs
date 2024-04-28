using CQRS.Core.Domain;
using CQRS.Core.Events;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Post.Cmd.Infrastructure.Config;

namespace Post.Cmd.Infrastructure.Repositories;
public class EventStoreRepository : IEventStoreRepository
{
    private readonly IMongoCollection<EventModel> _eventStoreCollection;

    public EventStoreRepository(IOptions<MongoDbConfig> options)
    {
        var mongoClient = new MongoClient(options.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(options.Value.Database);

        _eventStoreCollection = mongoDatabase.GetCollection<EventModel>(options.Value.Collection);
    }

    public async Task<IEnumerable<EventModel>> FindByAggregateId(Guid AggregateId)
    {
        return await _eventStoreCollection.Find(x => x.AggregateIdentifier == AggregateId)
                                          .ToListAsync()
                                          .ConfigureAwait(false);
    }

    public async Task SaveAsync(EventModel @event)
    {
        await _eventStoreCollection.InsertOneAsync(@event).ConfigureAwait(false);
    }
}
