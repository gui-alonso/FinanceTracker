using Microsoft.EntityFrameworkCore;
using FinanceTracker.API.Models;
using FinanceTracker.Api.Models;

namespace FinanceTracker.API.Data;

public class FinanceContext : DbContext
{
    public FinanceContext(DbContextOptions<FinanceContext> options)
        : base(options) {} // O construtor recebe as opções de configuração do DbContext, que são passadas para a classe base.

    public DbSet<Transaction> Transactions => Set<Transaction>(); // Isso é uma propriedade que retorna um DbSet<Transaction>, que representa a tabela de transações no banco de dados.
}
