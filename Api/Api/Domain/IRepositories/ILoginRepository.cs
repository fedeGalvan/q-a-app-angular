using Api.Domain.Models;
using System.Threading.Tasks;

namespace Api.Domain.IRepositories
{
    public interface ILoginRepository
    {
        Task<User> ValidateUser(User user);
    }
}
