using UserService.Business.User.Interfaces;
using UserService.Models.Dto.Responses;

namespace UserService.Business.User;

public class DeleteUserCommand : IDeleteUserCommand
{
    public Task<ResponseInfo<bool>> ExecuteAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
