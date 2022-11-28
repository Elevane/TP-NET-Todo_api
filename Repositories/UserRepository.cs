using Todo.Persistence;
using Todo.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace randomVerse.Repositories
{
    public class UserRepository
    {
        private readonly TodoContext _context;

        public UserRepository(TodoContext context) => _context = context;

        public async Task Create(User obj)
        {
            _context.Users.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task Update(User obj)
        {
            _context.Users.Update(obj);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(User obj)
        {
            _context.Users.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<User> Find(int Id)
        {
            return await _context.Users.FindAsync(Id);
        }

        public async Task<User> FindWhere(Func<User, bool> expression)
        {
            return await _context.Users.FindAsync(expression);
        }

        public async Task<List<User>> FindAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> FindUser(string Email, string Password)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.Email == Email && user.Password == Password);
        }

        public async Task<User> FindByEmail(string Email)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.Email == Email);
        }
    }
}