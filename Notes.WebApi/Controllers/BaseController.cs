﻿using Microsoft.AspNetCore.Mvc;
using MediatR;
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using System.Security.Claims;
namespace Notes.WebApi.Controllers
{
    [ApiController]
    [Route("api/controller]/[action]")]
    public abstract class BaseController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService < IMediator>();

        internal Guid UserId => User.Identity.IsAuthenticated
            ?Guid.Empty:Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
    }
}