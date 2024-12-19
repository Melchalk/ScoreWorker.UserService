using AutoMapper;
using System.Net;
using UserService.Business.User.Interfaces;
using UserService.Data.Interfaces;
using UserService.Models.Dto.Exceptions;
using UserService.Models.Dto.Responses;

namespace UserService.Business.User;

public class GetUserCommand(
    IMapper mapper,
    IUserRepository repository) : IGetUserCommand
{
    public async Task<ResponseInfo<GetUserResponse>> ExecuteAsync(
        Guid id, CancellationToken cancellationToken)
    {
        var dbUser = await repository.GetAsync(id, cancellationToken)
            ?? throw new BadRequestException($"User with id = '{id}' was not found.");

        var user = mapper.Map<GetUserResponse>(dbUser);

        return new ResponseInfo<GetUserResponse>
        {
            Body = user,
            Status = (int)HttpStatusCode.OK,
        };
    }
}
