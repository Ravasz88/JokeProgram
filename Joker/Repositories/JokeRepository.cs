using Joker.Controllers;
using Microsoft.EntityFrameworkCore;

namespace Joker.Repositories
{
    public class JokeRepository : IJokerRepository
    {
        private readonly JokerDbContext dbContext;

        public JokeRepository(JokerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddJoke(string theme, string content)
        {
            Joke joke = new Joke();
            joke.Theme = theme;
            joke.Content = content;

            dbContext.Add(joke);
           await dbContext.SaveChangesAsync();    
        }

        public async Task<IEnumerable<Joke>> GetAllJokes()
        {
           return await dbContext.Jokes.ToListAsync();
        }

        public async Task<Joke> GetJokeById(int id)
        {
           return await dbContext.Jokes.FirstAsync(x=>x.Id == id);
        }

        public async Task<Joke> RandomJoke()
        {
            var jokes = await dbContext.Jokes.ToListAsync();
            Random r = new Random();
            var choosen = r.Next(0,jokes.Count);
            return jokes[choosen];
        }


    }
}
