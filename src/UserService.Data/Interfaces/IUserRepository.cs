using UserService.Models.Db;

namespace UserService.Data.Interfaces;

public interface IUserRepository
{
    Task<DbUser> GetAsync(Guid id, CancellationToken cancellationToken);
    Task CreateAsync(DbUser dbUser, CancellationToken cancellationToken);
    Task<bool> UpdateAsync(DbUser dbUser, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken);
}
