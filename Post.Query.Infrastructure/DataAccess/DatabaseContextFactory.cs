using Microsoft.EntityFrameworkCore;

namespace Post.Query.Infrastructure.DataAccess;
public class DatabaseContextFactory(Action<DbContextOptionsBuilder> configureDbContext)
{
    private readonly Action<DbContextOptionsBuilder> _configureDbContext = configureDbContext;

    public DatabaseContext CreateDbContext()
    {
        DbContextOptionsBuilder<DatabaseContext> optionsBuilder = new ();
        _configureDbContext(optionsBuilder);

        return new DatabaseContext(optionsBuilder.Options);
    }
}
