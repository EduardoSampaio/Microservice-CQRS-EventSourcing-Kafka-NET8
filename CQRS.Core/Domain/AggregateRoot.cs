using CQRS.Core.Events;

namespace CQRS.Core.Domain;
public abstract class AggregateRoot
{
    protected Guid _id;
    private readonly List<BaseEvent> _changes = [];

    public Guid Id { get { return _id; } }

    public int Version { get; set; } = -1;

    public IEnumerable<BaseEvent> GetUncommittedChanges()
    {
        return _changes;
    }

    public void MarkChangesAsComitted()
    {
        _changes.Clear();
    }

    private void ApplyChange(BaseEvent @event, bool isNew)
    {
        var method = this.GetType().GetMethod("Apply", [@event.GetType()]);
        if(method is null)
        {
            throw new ArgumentNullException(nameof(method), $"The Apply Method was not found in the aggregate for {@event.GetType().Name}");
        }
        method.Invoke(this, [@event]);

        if(isNew)
        {
            _changes.Add(@event);
        }
    }

    protected void RaiseEvent(BaseEvent @event)
    {
        ApplyChange(@event, true);
    }

    public void ReplayEvents(IEnumerable<BaseEvent> events)
    {
        foreach(var @event in events)
        {
            ApplyChange(@event, false);
        }
    }
}
