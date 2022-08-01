using AniView.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AniView.Models
{
    public class Review
    {
        public string? ReviewDes { get; set; }

        [Required]
        public int Rating { get; set; }

        [ForeignKey("AnimeInfos")]
        public int AnimeId { get; set; }

        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }

        public ApplicationUser User { get; set; }
        public AnimeInfo? AnimeInfos { get; set; }
    }
}
