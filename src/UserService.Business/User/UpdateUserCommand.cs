using UserService.Business.User.Interfaces;
using UserService.Models.Dto.Requests;
using UserService.Models.Dto.Responses;

namespace UserService.Business.User;

public class UpdateUserCommand : IUpdateUserCommand
{
    public Task<ResponseInfo<bool>> ExecuteAsync(
        UpdateUserRequest request,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}