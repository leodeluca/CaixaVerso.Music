
using System.ComponentModel.DataAnnotations;

namespace CaixaVerso.MusicApp.Data
{
    public class Music
    {
        [Display(Name = "Identificação da Música")]
        public Guid? Id { get; set; }

        [Required]
        [Display(Name = "Título")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Artista")]
        public Guid? ArtistId { get; set; }

        [Display(Name = "Artista")]
        public Artist? Artist { get; set; }
    }
}

