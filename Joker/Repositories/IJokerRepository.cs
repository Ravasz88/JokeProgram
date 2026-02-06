using Joker.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Joker.Repositories
{
    public interface IJokerRepository
    {
        Task<IEnumerable<Joke>> GetAllJokes();
        Task<Joke> GetJokeById(int id);
        Task AddJoke(string theme, string content);
        Task<Joke> RandomJoke();
        Task DeleteJoke(int id);

        Task ModifyJokeById(int id, JokeForModify update);
    }
}
