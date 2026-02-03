using Joker.Controllers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
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

        public async Task DeleteJoke(int id)
        {
            Joke joke = await dbContext.Jokes.FirstOrDefaultAsync(x => x.Id == id);
            if (joke != null)
            {
                dbContext.Remove(joke);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Joke>> GetAllJokes()
        {
           return await dbContext.Jokes.ToListAsync();
        }

        public async Task<Joke> GetJokeById(int id)
        {
           return await dbContext.Jokes.FirstAsync(x=>x.Id == id);
        }

        public async Task<Joke> ModifyJokeById(int id, Joke update)
        {
            var joke = await GetJokeById(id);
            if (joke != null)
            {
                joke.Theme = update.Theme;
                joke.Content = update.Content;
                
                 dbContext.Update(joke);
                return joke;
            }
            return null;
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
