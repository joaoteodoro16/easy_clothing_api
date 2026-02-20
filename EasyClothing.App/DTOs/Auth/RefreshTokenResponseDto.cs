using System;
using System.Collections.Generic;
using System.Text;

namespace EasyClothing.App.DTOs.Auth
{
    public class RefreshTokenResponseDto
    {
        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }
    }
}
