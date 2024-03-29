﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportsHub.AppService.Authentication;
using SportsHub.AppService.Authentication.Models.DTOs;
using SportsHub.Domain.Constants;


namespace SportsHub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private IAuthenticationService _authenticationService;

        public RegisterController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserRegisterDTO userInput)
        {
            bool registerSuccesful = await _authenticationService.RegisterUserAsync(userInput);

            if (registerSuccesful)
            {
                return Ok(ValidationMessages.RegisterSuccessful);
            }

            return BadRequest(ValidationMessages.RegisterNotSuccessful);
        }
    }
}
