﻿using System.Net;
using Microsoft.Extensions.Primitives;

namespace UserService.Models.Dto.Exceptions;

public class UnauthorizedException(StringValues message) : BaseException(message, StatusCode)
{
    private new const HttpStatusCode StatusCode = HttpStatusCode.Unauthorized;
}