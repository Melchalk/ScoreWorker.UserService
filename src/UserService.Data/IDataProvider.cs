using Microsoft.EntityFrameworkCore;
using UserService.Models.Db;

namespace UserService.Data;

/// <summary>
/// Data provider with DbSets of the app.
/// </summary>
public interface IDataProvider : IBaseDataProvider
{
    DbSet<DbUser> Users { get; set; }
    DbSet<DbUserAddition> UserAddition { get; set; }
    DbSet<DbUserCredentials> UserCredentials { get; set; }
}