using Api.Domain.Models;
using System.Threading.Tasks;

namespace Api.Domain.IRepositories
{
    public interface IUserRepository
    {
        Task SaveUser(User user);
        Task<bool> UserAlreadyExists(User user);
        Task<User> ValidatePassword(int userId, string prevPassword);
        Task UpdatePassword(User user);
    }
}
