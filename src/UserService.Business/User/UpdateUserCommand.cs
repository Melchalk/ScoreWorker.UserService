using UserService.Business.User.Interfaces;
using UserService.Data.Interfaces;
using UserService.Models.Dto.Requests;
using UserService.Models.Dto.Responses;

namespace UserService.Business.User;

public class UpdateUserCommand(IUserRepository repository) : IUpdateUserCommand
{
    public Task<ResponseInfo<bool>> ExecuteAsync(
        UpdateUserRequest request,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}