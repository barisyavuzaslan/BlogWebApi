using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Business.Interfaces;
using Blog.Business.Tools.JWTTool;
using Blog.DTO.Dtos.AppUserDtos;
using Blog.WebApi.CustomFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAppUserService _appUserService;
        private readonly IJWTService _jWTService;
        public AuthController(IAppUserService appUserService, IJWTService jWTService)
        {
            _appUserService = appUserService;
            _jWTService = jWTService;
        }
        [HttpPost("[action]")]
        [ValidModel]
        public async Task<IActionResult> SignIn(AppUserLoginDto appUserLoginDto)
        {
            var user = await _appUserService.CheckUserAsync(appUserLoginDto);

            if (user != null)
            {
                return Created("", _jWTService.GenerateJwt(user));
            }
            
            return BadRequest("Kullanıcı Adı veya Şifre Hatalıdır.");
        }
        [HttpGet("[action]")]
        [Authorize]
        public async Task<IActionResult> ActiveUser()
        {
            var user = await _appUserService.FindByNameAsync(User.Identity.Name);
            return Ok(new AppUserDto {Id=user.Id ,Name = user.Name, SurName = user.Surname });
        }
    }

}