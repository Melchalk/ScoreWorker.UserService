using UserService.Models.Dto.Requests;
using UserService.Models.Dto.Responses;

namespace UserService.Business.User.Interfaces;

public interface IUpdateUserCommand
{
    Task<ResponseInfo<bool>> ExecuteAsync(UpdateUserRequest request, CancellationToken cancellationToken);
}
