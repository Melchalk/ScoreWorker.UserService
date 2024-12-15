using UserService.Models.Dto.Responses;

namespace UserService.Business.User.Interfaces;

public class GetCurrentUserCommand : IGetCurrentUserCommand
{
    public Task<ResponseInfo<GetUserResponse>> ExecuteAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
