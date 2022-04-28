using System;
using System.Threading.Tasks;
using PtfHub.Core.Dtos;

namespace PtfHub.Core.IServices
{
    public interface IUsersService
    {
        Task<UserLoginResponseDto> Login(UserLoginDto loginDto);
    }
}
