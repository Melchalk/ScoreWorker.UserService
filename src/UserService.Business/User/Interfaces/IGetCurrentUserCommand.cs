using UserService.Models.Dto.Responses;

namespace UserService.Business.User.Interfaces;

public interface IGetCurrentUserCommand
{
    Task<ResponseInfo<GetUserResponse>> ExecuteAsync(CancellationToken cancellationToken);
}
