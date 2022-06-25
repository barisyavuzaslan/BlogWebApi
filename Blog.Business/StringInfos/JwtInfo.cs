using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Business.StringInfos
{
    public class JwtInfo
    {
        public const string Issuer = "http://localhost:1051";
        public const string Audience = "http://localhost:5000";
        public const string SecurityKey = "baris123baris123baris123baris123";
        public const double Expires = 40;
    }
}
