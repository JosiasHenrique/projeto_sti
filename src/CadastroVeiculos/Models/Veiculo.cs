using System.ComponentModel.DataAnnotations;

namespace CadastroVeiculos.Models;

public class Veiculo
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Informe a placa.")]
    [RegularExpression(@"^[A-Za-z]{3}-?[0-9][A-Za-z0-9][0-9]{2}$",
        ErrorMessage = "Placa inválida. Use o formato ABC1234 ou ABC1D23.")]
    public string Placa { get; set; } = string.Empty;

    [Required(ErrorMessage = "Informe a marca.")]
    [StringLength(50, ErrorMessage = "A marca deve ter no máximo 50 caracteres.")]
    public string Marca { get; set; } = string.Empty;

    [Required(ErrorMessage = "Informe o modelo.")]
    [StringLength(50, ErrorMessage = "O modelo deve ter no máximo 50 caracteres.")]
    public string Modelo { get; set; } = string.Empty;

    [Required(ErrorMessage = "Informe a cor.")]
    [StringLength(30, ErrorMessage = "A cor deve ter no máximo 30 caracteres.")]
    public string Cor { get; set; } = string.Empty;

    [Required(ErrorMessage = "Informe o ano.")]
    [Range(1900, 2100, ErrorMessage = "Informe um ano válido.")]
    public int? Ano { get; set; }

    [Required(ErrorMessage = "Selecione o porte.")]
    [StringLength(20)]
    public string Porte { get; set; } = string.Empty;

    [Required(ErrorMessage = "Informe o tipo de carga.")]
    [StringLength(30, ErrorMessage = "O tipo de carga deve ter no máximo 30 caracteres.")]
    public string TipoCarga { get; set; } = string.Empty;

    [Required(ErrorMessage = "Informe o chassi.")]
    [RegularExpression(@"^[A-HJ-NPR-Za-hj-npr-z0-9]{17}$",
        ErrorMessage = "Chassi inválido. Use 17 letras e números, sem I, O e Q.")]
    public string Chassis { get; set; } = string.Empty;
}