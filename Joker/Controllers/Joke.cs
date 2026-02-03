using System.ComponentModel.DataAnnotations.Schema;

namespace Joker.Controllers
{
    [Table("jokes")]
    public class Joke
    {
        public Joke()
        {
            
        }
        public Joke(int id, string theme, string content)
        {
            Id = id;
            Theme = theme;
            Content = content;
        }
        [Column("id")]
        public int Id { get; set; }
        [Column("theme")]
        public string Theme { get; set; }
        [Column("content")]
        public string Content { get; set; }
    }
}