using CashManiaMAUI.Models.Enums;

namespace CashManiaMAUI.Models.Transactions;

public class Transaction
{
    public int Id { get; set; }
    public TransactionType Type { get; set; }
    public decimal Amount { get; set; }
    public string? Description { get; set; }
    public DateTime Date { get; set; }
    public int CategoryId { get; set; }
}
