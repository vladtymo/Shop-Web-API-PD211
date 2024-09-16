using Core.Dtos;

namespace Core.Interfaces
{
    // interface vs class
    public interface IAccountsService
    {
        Task<LoginResponse> Login(LoginDto model);
        Task Register(RegisterDto model);
        Task Logout();
    }
}
