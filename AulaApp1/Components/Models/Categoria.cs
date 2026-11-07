using System.ComponentModel.DataAnnotations;

namespace AulaApp1.Components.Models
{
    public class Categoria
    {
        [Required(ErrorMessage = "O nome da categoria é obrigatório.")]
        [MinLength(3, ErrorMessage = "O nome deve ter no mínimo 3 letras.")]
        [CustomValidation(typeof(Categoria), nameof(ValidarNomeDiferenteDeTeste))]
        public string Nome { get; set; } = "";

        [Range(0, 100000, ErrorMessage = "A quantidade deve estar entre 0 e 100.000.")]
        public int Quantidade { get; set; }

        public static ValidationResult? ValidarNomeDiferenteDeTeste(string? valor, ValidationContext context)
        {
            if (!string.IsNullOrEmpty(valor) && valor.Equals("Teste", StringComparison.OrdinalIgnoreCase))
            {
                return new ValidationResult("A categoria não pode se chamar 'Teste'.");
            }
            return ValidationResult.Success;
        }
    }
}
