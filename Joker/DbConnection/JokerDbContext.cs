using Joker.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Joker
{
    public class JokerDbContext : DbContext
    {
        public JokerDbContext(DbContextOptions<JokerDbContext> options) :base(options)
        {
                
        }
        public DbSet<Joke> Jokes { get; set; }
       
    }
}
