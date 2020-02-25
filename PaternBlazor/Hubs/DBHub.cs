using System;
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

        public async Task<Movie[]> GetMovies()
        {
            return await _context.Movies.ToArrayAsync();
        }
    }
}
