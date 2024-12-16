using UserService.Business.User.Interfaces;
using UserService.Data.Interfaces;

namespace UserService.Business.User;

public class GetUsersByTeamCommand(IUserRepository repository) : IGetUsersByTeamCommand
{
}
