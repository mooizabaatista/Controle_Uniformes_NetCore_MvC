using System.ComponentModel.DataAnnotations;

namespace Requisicao_RSS.Application.DTOs
{
    public class FuncionarioDTO
    {
        // Id
        public int FuncionarioId { get; set; }

        // Registro
        [Required(ErrorMessage = "Registro Inválido. O Registro é obrigatório.")]
        [MinLength(1, ErrorMessage = "Registro Inválido. O Registro deve conter no mínimo 1 caracteres.")]
        [MaxLength(10, ErrorMessage = "Registro Inválido. O Registro deve conter no máximo 10 caracteres.")]
        public string Registro { get; set; }

        // Nome
        [Required(ErrorMessage = "Nome Inválido. O Nome é obrigatório.")]
        [MinLength(3, ErrorMessage = "Nome Inválido. O Nome deve conter no mínimo 3 caracteres.")]
        [MaxLength(100, ErrorMessage = "Nome Inválido. O Nome deve conter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        // Função
        [Required(ErrorMessage = "Função Inválida. A Função é obrigatória.")]
        [MinLength(7, ErrorMessage = "Função Inválida. A Função deve conter no mínimo 7 caracteres.")]
        [MaxLength(10, ErrorMessage = "Função Inválida. A Função deve conter no máximo 10 caracteres.")]
        public string Funcao { get; set; }

        // Turno
        [Required(ErrorMessage = "Turno Inválido. O Turno é obrigatório.")]
        [MinLength(6, ErrorMessage = "Turno Inválido. O Turno deve conter no mínimo 6 caracteres.")]
        [MaxLength(7, ErrorMessage = "Turno Inválido. O Turno deve conter no máximo 7 caracteres.")]
        public string Turno { get; set; }

        // Base da camiseta
        [Required(ErrorMessage = "Base Camiseta Inválida. A Base Camiseta é obrigatória.")]
        public string BaseCamisa { get; set; }

        // Base da calça
        [Required(ErrorMessage = "Base Calça Inválida. A Base Calça é obrigatória.")]
        public string BaseCalca { get; set; }
    }
}
