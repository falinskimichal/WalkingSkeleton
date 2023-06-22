﻿using BlazorEcommerce.Server.Services.AuthService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

namespace BlazorEcommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegister user)
        {
            var response = await _service.Register(new User
            {
                Email = user.Email,
            },
            user.Password);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(UserLogin request)
        {
            var resposne = await _service.Login(request.Email, request.Password);
            if (!resposne.Success)
            {
                return BadRequest(resposne);
            }
            return Ok(resposne);
        }
    }
}