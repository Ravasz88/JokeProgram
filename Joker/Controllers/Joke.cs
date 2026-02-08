using System.ComponentModel.DataAnnotations.Schema;

namespace Joker.Controllers
{
    [Table("jokes")]
    public class Joke
    {
        public Joke()
        {
            
        }
        public Joke(int id, string theme, string content, string type, int sumStarts, float averageStars)
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
        [Column("type")]
        public string Type { get; set; }
        [Column("sumstars")]
        public int SumStarts { get; set; }
        [Column("averagestars")]
        public float AverageStars { get; set; } 
    }
}