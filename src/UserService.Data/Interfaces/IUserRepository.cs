using UserService.Models.Db;

namespace UserService.Data.Interfaces;

public interface IUserRepository
{
    Task<DbUser> GetAsync(Guid id);
    Task CreateAsync(DbUser dbUser);
    Task UpdateAsync(DbUser dbUser);
    Task DeleteAsync(Guid id);
}
