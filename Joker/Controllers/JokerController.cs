using Joker.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Joker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JokerController : ControllerBase
    {
        private readonly IJokerRepository _context;

        public JokerController(IJokerRepository context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.GetAllJokes());
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id) 
        {
            var outcome = await _context.GetJokeById(Id);
           return outcome is null ? NotFound() : Ok(outcome);
        }
        [HttpGet("random")]
        public async Task<IActionResult> GetRandomJoke()
        {
            return Ok(await _context.RandomJoke());
        }
        [HttpPost]
        public async Task<IActionResult> Create(string theme, string content)
        {
            await _context.AddJoke(theme, content);
            return Ok();
        }
        [HttpDelete("delete/{Id}")]
        public async Task<IActionResult> DeleteJoke(int Id)
        {
            await _context.DeleteJoke(Id);
            return Ok();
        }
        [HttpPatch("modify/{Id}")]
        public async Task<IActionResult> ModifyAJoke(int Id, [FromBody] JokeForModify update)
        {
            
            await _context.ModifyJokeById(Id, update);
            return Ok();
        }
    }
}
