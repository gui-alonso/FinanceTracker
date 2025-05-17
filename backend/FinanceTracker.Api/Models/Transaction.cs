using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FinanceTracker.Api.Models;

namespace FinanceTracker.API.Models;

public class Transaction
{
    public int Id { get; set; }

    [Required]
    public string Description { get; set; } = string.Empty;

    [Required]
    public decimal Amount { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    public string Type { get; set; } = string.Empty; // "income" or "expense"
    public int UserId { get; set; } // ID do usuário associado ao lançamento
    
    [ForeignKey("UserId")]
    public User? User { get; set; } // Navegação para o usuário associado ao lançamento


    public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Data de criação do lançamento.
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow; // Data da última atualização do lançamento.
}
