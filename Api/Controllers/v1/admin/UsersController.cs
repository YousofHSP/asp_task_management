using AutoMapper;
using Common.Exceptions;
using Data.Contracts;
using DTO;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.Services;
using WebFramework.Api;
using Api.Models;

namespace Api.Controllers.v1.admin;

[ApiVersion("1")]
public class UsersController(IUserRepository repository, IMapper mapper, UserManager<User> userManager, IJwtService jwtService)
    : CrudController<UserDto, UserResDto, User>(repository, mapper)
{
    private readonly UserManager<User> _userManager = userManager;
    private readonly IJwtService _jwtService = jwtService;

    [HttpPost("[action]")]
    [AllowAnonymous]
    public async Task<ActionResult> Token([FromForm]TokenRequest tokenRequest, CancellationToken cancellationToken)
    {
        var user = await repository.GetByMobileAndPass(tokenRequest.username, tokenRequest.password, cancellationToken);
        if (user is null)
            throw new BadRequestException("نام کاربری یا رمز عبور اشتباه است");
        await _userManager.UpdateSecurityStampAsync(user);
        var jwt = await _jwtService.GenerateAsync(user);
        return new JsonResult(jwt);

    }
}