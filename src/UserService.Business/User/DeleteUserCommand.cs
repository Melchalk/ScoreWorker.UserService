using System.Net;
using UserService.Business.User.Interfaces;
using UserService.Data.Interfaces;
using UserService.Models.Dto.Exceptions;
using UserService.Models.Dto.Responses;

namespace UserService.Business.User;

public class DeleteUserCommand(IUserRepository repository) : IDeleteUserCommand
{
    public async Task<ResponseInfo<bool>> ExecuteAsync(
        Guid id, CancellationToken cancellationToken)
    {
        var result = await repository.DeleteAsync(id, cancellationToken);

        if (!result)
            throw new BadRequestException($"User with id = '{id}' was not found.");

        return new ResponseInfo<bool>
        {
            Body = result,
            Status = (int)HttpStatusCode.OK,
        };
    }
}
