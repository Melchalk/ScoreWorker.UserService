using UserService.Business.Credentials.Interfaces;
using UserService.Models.Dto.Requests;
using UserService.Models.Dto.Responses;

namespace UserService.Business.Credentials;

public class CreateCredentialsCommand : ICreateCredentialsCommand
{
    public Task<ResponseInfo<bool>> ExecuteAsync(
        CreateCredentialsRequest request,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
