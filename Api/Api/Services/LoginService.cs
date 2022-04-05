using Api.Domain.IRepositories;
using Api.Domain.IServices;
using Api.Domain.Models;
using System.Threading.Tasks;

namespace Api.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public async Task<User> ValidateUser(User user)
        {
            return await _loginRepository.ValidateUser(user);
        }
    }
}
