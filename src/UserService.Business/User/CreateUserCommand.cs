﻿using UserService.Business.User.Interfaces;
using UserService.Models.Dto.Requests;
using UserService.Models.Dto.Responses;

namespace UserService.Business.User;

public class CreateUserCommand : ICreateUserCommand
{
    public Task<ResponseInfo<bool>> ExecuteAsync(
        CreateUserRequest request,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}