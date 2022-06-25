using Blog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Business.Tools.JWTTool
{
    public interface IJWTService
    {
        JwtToken GenerateJwt(AppUser appUser);
    }
}
