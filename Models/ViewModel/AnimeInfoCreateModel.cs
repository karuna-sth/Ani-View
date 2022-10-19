using System.ComponentModel.DataAnnotations;

namespace AniView.Models.ViewModel
{
    public class AnimeInfoCreateModel
    {
        [Key]
        public int AnimeId { get; set; }
        [Required(ErrorMessage = "Plese Enter Anime Name")]
        public string AnimeName { get; set; }
        public string? AnimeDescription { get; set; }
        [Required(ErrorMessage = "Plese Upload Image")]
        [Display(Name ="Choose Image")]
        public IFormFile Image { get; set; }
    }
}
