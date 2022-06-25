using Blog.DTO.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.DTO.Dtos.AppUserDtos
{
    public class AppUserLoginDto:IDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
