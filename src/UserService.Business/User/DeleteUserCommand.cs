using UserService.Business.User.Interfaces;
using UserService.Data.Interfaces;
using UserService.Models.Dto.Responses;

namespace UserService.Business.User;

public class DeleteUserCommand(IUserRepository repository) : IDeleteUserCommand
{
    public Task<ResponseInfo<bool>> ExecuteAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
