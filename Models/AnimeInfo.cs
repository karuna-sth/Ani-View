using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AniView.Models
{
    public class AnimeInfo
    {
        [Key]
        public int AnimeId { get; set; }
        [Required]
        public string AnimeName { get; set; }
        public string? AnimeDescription { get; set; }
        public string? Image { get; set; }

        public List<Review> ReviewList { get; set; }
    }
}
