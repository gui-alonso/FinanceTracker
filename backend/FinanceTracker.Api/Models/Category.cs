using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FinanceTracker.API.Models;

namespace FinanceTracker.Api.Models
{
    public class Category
    {
        public int Id { get; set; } // ID da categoria.
        public string Name { get; set; } = string.Empty; // Nome da categoria.
        public string Description { get; set; } = string.Empty; // Descrição da categoria.

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Data de criação da categoria.
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow; // Data da última atualização da categoria.

        // Transactions: Uma categoria pode ter muitos lançamentos.
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>(); // Inicializa a coleção de lançamentos.
    }
}