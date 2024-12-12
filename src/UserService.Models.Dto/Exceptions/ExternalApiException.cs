using System.Net;
using Microsoft.Extensions.Primitives;

namespace UserService.Models.Dto.Exceptions;

public class ExternalApiException : BaseException
{
    public ExternalApiException(StringValues message, Exception innerException) : base(message, StatusCode, innerException)
    {
    }

    public ExternalApiException(StringValues message) : base(message, StatusCode)
    {
    }

    private new const HttpStatusCode StatusCode = HttpStatusCode.GatewayTimeout;
}