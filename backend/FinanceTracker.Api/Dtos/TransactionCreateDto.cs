namespace FinanceTracker.Api.Dtos
{
    public class TransactionCreateDto
    {
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; } = string.Empty; // "income" or "expense"
        public int UserId { get; set; } // ID do usuário associado ao lançamento
    }
}