﻿using cqrssssinside.web.common.Utils;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;

namespace cqrssssinside.web.common.Controllers
{
    public class BaseController : ControllerBase
    {
        protected new IActionResult Ok()
        {
            return base.Ok(Envelope.Ok());
        }

        protected IActionResult Ok<T>(T result)
        {
            return base.Ok(Envelope.Ok(result));
        }

        protected IActionResult Error(string errorMessage)
        {
            return BadRequest(Envelope.Error(errorMessage));
        }

        protected IActionResult FromResult(Result result)
        {
            return result.IsSuccess ? Ok() : Error(result.Error);
        }
    }
}
