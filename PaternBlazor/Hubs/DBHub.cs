using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using PaternBlazor.Model;

namespace PaternBlazor.Hubs
{
    public class DBHub : Hub
    {
        private readonly SQLLiteContext _context;

        internal DBHub(SQLLiteContext context)
        {
            _context = context;
        }

        public async Task<Movie[]> GetMovies(User user)
        {
            if (_context.Users.Contains(user))
                return await _context.Movies.ToArrayAsync();
            return null;
        }

        public async Task<Movie[]> GetMovies()
        {
            return await _context.Movies.ToArrayAsync();    
        }
    }
}
