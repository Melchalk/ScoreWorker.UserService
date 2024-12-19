using UserService.Models.Dto.Requests;
using UserService.Models.Dto.Responses;

namespace UserService.Business.Credentials.Interfaces;

public interface ICreateCredentialsCommand
{
    Task<ResponseInfo<Guid>> ExecuteAsync(CreateCredentialsRequest request, CancellationToken cancellationToken);
}
