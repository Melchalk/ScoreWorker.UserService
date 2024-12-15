using UserService.Models.Dto.Responses;

namespace UserService.Business.User.Interfaces;

public interface IGetUserCommand
{
    Task<ResponseInfo<GetUserResponse>> ExecuteAsync(Guid id, CancellationToken cancellationToken);
}
