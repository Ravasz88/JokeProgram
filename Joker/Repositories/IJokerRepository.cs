using Joker.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace Joker.Repositories
{
    public interface IJokerRepository
    {
        Task<IEnumerable<Joke>> GetAllJokes();
        Task<Joke> GetJokeById(int id);
        Task AddJoke(string theme, string content, string type);
        Task<Joke> RandomJoke();
        Task DeleteJoke(int id);

        Task ModifyJokeById(int id, JokeForModify update);
        Task AddStar(int id, int number);
        Task<float> GetStars(int id);
    }
}
