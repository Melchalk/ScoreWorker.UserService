using UserService.Models.Dto.Responses;

namespace UserService.Business.User.Interfaces;

public interface IDeleteUserCommand
{
    Task<ResponseInfo<bool>> ExecuteAsync(Guid id, CancellationToken cancellationToken);
}
