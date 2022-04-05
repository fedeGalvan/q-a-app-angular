using Api.Domain.IRepositories;
using Api.Domain.Models;
using Api.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task SaveUser(User user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePassword(User user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UserAlreadyExists(User user)
        {
            var validateExistence = await _context.Users.AnyAsync(x => x.Username == user.Username);
            return validateExistence;
        }

        public async Task<User> ValidatePassword(int userId, string prevPassword)
        {
            var user = await _context.Users.Where(x => x.Id == userId && x.Password == prevPassword).FirstOrDefaultAsync();
            return user;
        }
    }
}
