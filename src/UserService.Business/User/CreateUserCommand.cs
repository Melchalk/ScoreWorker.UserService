using UserService.Business.User.Interfaces;
using UserService.Data.Interfaces;
using UserService.Models.Dto.Requests;
using UserService.Models.Dto.Responses;

namespace UserService.Business.User;

public class CreateUserCommand(IUserRepository repository) : ICreateUserCommand
{
    public Task<ResponseInfo<Guid>> ExecuteAsync(
        CreateUserRequest request,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
