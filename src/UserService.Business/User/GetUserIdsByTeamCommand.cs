using FeedbackService.Broker.Models;
using System.Net;
using UserService.Business.User.Interfaces;
using UserService.Data.Interfaces;
using UserService.Models.Dto.Responses;

namespace UserService.Business.User;

public class GetUserIdsByTeamCommand(IUserRepository repository) : IGetUserIdsByTeamCommand
{
    public async Task<ResponseInfo<GetUserIdsByTeamResponse>> ExecuteAsync(
        Guid teamId, CancellationToken cancellationToken)
    {
        var usersByTeam = await repository.GetUserIdsByTeamAsync(teamId, cancellationToken);

        var userIds = usersByTeam.Select(x => x.Id).ToList();

        return new ResponseInfo<GetUserIdsByTeamResponse>
        {
            Body = new GetUserIdsByTeamResponse
            {
                UserIds = userIds
            },
            Status = (int)HttpStatusCode.OK,
        };
    }
}
