using Core.Dtos;

namespace Core.Interfaces
{
    public interface IAccountsService
    {
        Task Login(LoginDto model);
        Task Register(RegisterDto model);
        Task Logout();
    }
}
