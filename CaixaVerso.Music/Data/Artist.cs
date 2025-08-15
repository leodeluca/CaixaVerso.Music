using System.ComponentModel.DataAnnotations;

namespace CaixaVerso.MusicApp.Data
{
    public class Artist
    {
        [Display(Name = "Identificação do Artista")]
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "O nome do Artista é obrigatório")]
        [Display(Name = "Nome")]
        [MinLength(3, ErrorMessage = "O nome do Artista deve conter no mínimo 3 caracteres")]
        [MaxLength(15, ErrorMessage = "O nome da Artista deve conter no máximo 15 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O tipo de estilo é obrigatório")]
        [Display(Name = "Estilo Musical")]
        [MinLength(3, ErrorMessage = "O tipo de estilo deve conter no mínimo 3 caracteres")]
        public string Style { get; set; }
    }
}
