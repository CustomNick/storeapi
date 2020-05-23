using Store.DATA.Entities;
using Store.DATA.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Store.AUTH.Interfaces
{
    public interface IAuthService
    {
        Task<Response<Token>> Login(string email, string password);

        Task<Response<Token>> Register(UserDto item);

        Task<Response<Token>> RefreshToken(string token, string refreshToken);
    }
}
