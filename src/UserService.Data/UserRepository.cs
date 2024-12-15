using UserService.Data.Interfaces;
using UserService.Data.Provider;
using UserService.Models.Db;

namespace UserService.Data;

public class UserRepository(IDataProvider provider) : IUserRepository
{
    public Task CreateAsync(DbUser dbUser)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<DbUser> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(DbUser dbUser)
    {
        throw new NotImplementedException();
    }
}
