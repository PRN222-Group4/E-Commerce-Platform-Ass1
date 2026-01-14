using System.Threading.Tasks;

namespace E_Commerce_Platform_Ass1.Service.Services.IServices
{
    public interface IUserService
    {
        Task<bool> RegisterAsync(string name, string email, string password);

        Task<AuthenticatedUser?> ValidateUserAsync(string email, string password);
    }
}

