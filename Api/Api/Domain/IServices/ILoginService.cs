using Api.Domain.Models;
using System.Threading.Tasks;

namespace Api.Domain.IServices
{
    public interface ILoginService
    {
        Task<User> ValidateUser(User user);
    }
}
