using Api.Domain.IRepositories;
using Api.Domain.Models;
using Api.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Persistence.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly AppDbContext _context;
        public LoginRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> ValidateUser(User user)
        {
            var data = await _context.Users.Where(x => x.Username == user.Username && x.Password == user.Password).FirstOrDefaultAsync();
            return data;
        }
    }
}
