using UserService.Models.Dto.Requests;
using UserService.Models.Dto.Responses;

namespace UserService.Business.Credentials.Interfaces;

public interface ICreateCredentialsCommand
{
    Task<ResponseInfo<bool>> ExecuteAsync(CreateCredentialsRequest request, CancellationToken cancellationToken);
}
