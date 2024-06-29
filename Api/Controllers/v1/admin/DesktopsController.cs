using AutoMapper;
using Data.Contracts;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using WebFramework.Api;

namespace Api.Controllers.v1.admin;

[ApiVersion("1")]
public class DesktopsController(IRepository<Desktop> repository, IMapper mapper) : CrudController<DesktopDto, Desktop>(repository, mapper)
{
    
}