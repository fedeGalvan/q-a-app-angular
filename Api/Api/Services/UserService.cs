using Api.Domain.IRepositories;
using Api.Domain.IServices;
using Api.Domain.Models;
using System.Threading.Tasks;

namespace Api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task SaveUser(User user)
        {
            await _userRepository.SaveUser(user);
        }

        public async Task UpdatePassword(User user)
        {
            await _userRepository.UpdatePassword(user);
        }

        public async Task<bool> UserAlreadyExists(User user)
        {
            return await _userRepository.UserAlreadyExists(user);
        }

        public async Task<User> ValidatePassword(int userId, string prevPassword)
        {
            return await _userRepository.ValidatePassword(userId, prevPassword);
        }

    }
}
