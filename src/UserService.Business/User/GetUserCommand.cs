using UserService.Business.User.Interfaces;
using UserService.Models.Dto.Responses;

namespace UserService.Business.User;

public class GetUserCommand : IGetUserCommand
{
    public Task<ResponseInfo<GetUserResponse>> ExecuteAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
