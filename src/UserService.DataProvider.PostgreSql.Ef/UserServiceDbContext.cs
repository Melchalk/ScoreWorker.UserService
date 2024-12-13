using Microsoft.EntityFrameworkCore;
using System.Reflection;
using UserService.Data.Provider;
using UserService.Models.Db;

namespace UserService.DataProvider.PostgreSql.Ef;

public class UserServiceDbContext(DbContextOptions<UserServiceDbContext> options) : DbContext(options), IDataProvider
{
    public DbSet<DbUser> Users { get; set; }
    public DbSet<DbUserAddition> UserAdditions { get; set; }
    public DbSet<DbUserCredentials> UserCredentials { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.Load(typeof(DbUser).Assembly.FullName!));
    }

    public object MakeEntityDetached(object obj)
    {
        Entry(obj).State = EntityState.Detached;
        return Entry(obj).State;
    }

    async Task IBaseDataProvider.SaveAsync(CancellationToken cancellationToken)
    {
        await SaveChangesAsync(cancellationToken);
    }

    void IBaseDataProvider.Save()
    {
        SaveChanges();
    }

    public void EnsureDeleted()
    {
        Database.EnsureDeleted();
    }

    public bool IsInMemory()
    {
        return Database.IsInMemory();
    }
}