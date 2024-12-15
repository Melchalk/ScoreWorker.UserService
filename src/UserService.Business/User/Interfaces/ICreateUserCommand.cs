using UserService.Models.Dto.Requests;
using UserService.Models.Dto.Responses;

namespace UserService.Business.User.Interfaces;

public interface ICreateUserCommand
{
    Task<ResponseInfo<bool>> ExecuteAsync(CreateUserRequest request, CancellationToken cancellationToken);
}
