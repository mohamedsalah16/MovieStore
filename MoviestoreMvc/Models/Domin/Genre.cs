using System.ComponentModel.DataAnnotations;

namespace MovieStoreMvc.Models.Domin
{
    public class Genre
    {
        public int Id { get; set; }
        [Required]
        public string? GenreName { get; set; }
    }
}
