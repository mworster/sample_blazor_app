using StockReader.Models;
using Microsoft.EntityFrameworkCore;

namespace StockReader.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<RegisteredUser>> GetRegisteredUsersAsync()
        {
            return await _context.RegisteredUsers.ToListAsync();
        }

        public async Task AddUserAsync(RegisteredUser user)
        {
            _context.RegisteredUsers.Add(user);
            await _context.SaveChangesAsync();
        }
    }
}