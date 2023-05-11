using System.ComponentModel.DataAnnotations;

namespace WebApplicationTeste.Models
{
    public class Filme
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required (ErrorMessage = "O campo título é obrigatório")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O campo Diretor é obrigatório")]
        public string Diretor { get; set; }
        [StringLength(30, ErrorMessage = " O gênero não pode ser maior que 30 caracteres!")]
        public string Genero { get; set; }
        [Range(1,600, ErrorMessage = "A duração deve ter no mínimo 1 e no maxumo 600 minutos")]
        public int Duracao { get; set; }
        
    }
}
