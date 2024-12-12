using UserService.Data.Interfaces;
using UserService.Data.Provider;

namespace UserService.Data;

public class UserRepository(IDataProvider provider) : IUserRepository
{
}
