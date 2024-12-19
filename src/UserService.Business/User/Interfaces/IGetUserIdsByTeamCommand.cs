using FeedbackService.Broker.Models;
using UserService.Models.Dto.Responses;

namespace UserService.Business.User.Interfaces;

public interface IGetUserIdsByTeamCommand
{
    Task<ResponseInfo<GetUserIdsByTeamResponse>> ExecuteAsync(Guid teamId, CancellationToken cancellationToken);
}
