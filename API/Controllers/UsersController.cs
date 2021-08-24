using System.Collections.Generic;
// using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class UsersController : BaseApiController
    {
        public DataContext _context { get; }
        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteUser(int id)
        {
            if(!(await _context.Users.AnyAsync(x => x.Id == id))) return false;
            
            var user = await _context.Users.FindAsync(id);
            
            _context.Users.Remove(user);

            await _context.SaveChangesAsync();
            return true;
        }

    }
}