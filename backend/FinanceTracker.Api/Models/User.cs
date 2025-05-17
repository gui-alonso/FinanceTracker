using System.ComponentModel.DataAnnotations;
using FinanceTracker.API.Models;

namespace FinanceTracker.Api.Models
{
    public class User
    {
        public int Id { get; set; } // ID do usuário.
       // [Required]
        public required string Name { get; set; } // Nome do usuário.
        //[Required, EmailAddress]
        public required string Email { get; set; } // E-mail do usuário.
       // [Required]
        public required string PasswordHash { get; set; } // Hash da senha do usuário.
        //public string Role { get; set; } // e.g., "Admin", "User"
       // public string? Role { get; set; } // e.g., "Admin", "User"
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Data de criação do usuário.
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow; // Data da última atualização do usuário.
        //public DateTime? LastLogin { get; set; }

        // Transactions: relacionamento 1:N com lançamentos.
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}