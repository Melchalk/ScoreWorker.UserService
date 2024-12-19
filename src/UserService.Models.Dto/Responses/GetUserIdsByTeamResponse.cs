namespace FeedbackService.Broker.Models;

public class GetUserIdsByTeamResponse
{
    public required List<Guid> UserIds { get; set; }
}
