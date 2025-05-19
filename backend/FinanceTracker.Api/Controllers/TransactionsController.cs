using Microsoft.AspNetCore.Mvc;                          // Fornece os atributos e classes para criar APIs REST
using Microsoft.EntityFrameworkCore;
using FinanceTracker.API.Models;
using FinanceTracker.API.Data;
using FinanceTracker.Api.Dtos;                     // Permite o uso de EF Core (consultas, tracking etc)

namespace FinanceTracker.Api.Controllers
{
    // Indica que esse controller será usado como API (sem suporte a Views)
    [ApiController]

    // Define a rota base: api/transactions
    [Route("api/[controller]")]
    public class TransactionsController : ControllerBase
    {
        // Injeção de dependência do contexto do banco
        private readonly FinanceContext _context;

        public TransactionsController(FinanceContext context)
        {
            _context = context;
        }

        // GET: api/transactions
        // Retorna a lista de todas as transações
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactions()
        {
            return await _context.Transactions.ToListAsync();
        }

        // GET: api/transactions/{id}
        // Retorna uma transação específica pelo ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Transaction>> GetTransaction(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);

            if (transaction == null)
                return NotFound(); // Retorna 404 se não encontrar

            return transaction;
        }



        // POST: api/transactions
        // Cria uma nova transação
        [HttpPost]
        public async Task<ActionResult<Transaction>> PostTransaction(TransactionCreateDto dto)
        {
            var transaction = new Transaction
            {
                Description = dto.Description,
                Amount = dto.Amount,
                Date = dto.Date,
                Type = dto.Type,
                UserId = dto.UserId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTransaction), new { id = transaction.Id }, transaction);
        }



        // PUT: api/transactions/{id}
        // Atualiza uma transação existente
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransaction(int id, Transaction transaction)
        {
            if (id != transaction.Id)
                return BadRequest(); // ID da rota e do corpo precisam coincidir

            _context.Entry(transaction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Transactions.Any(e => e.Id == id))
                    return NotFound(); // Se não existir no banco, retorna 404
                else
                    throw;
            }

            return NoContent(); // Retorna 204 (sem conteúdo)
        }

        // DELETE: api/transactions/{id}
        // Remove uma transação pelo ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null)
                return NotFound();

            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();

            return NoContent(); // Retorna 204
        }
    }
}
