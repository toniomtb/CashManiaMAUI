namespace CashManiaMAUI.Services.DTOs.Transactions;

public class TransactionDto
{
    public int id { get; set; }
    public int type { get; set; }
    public decimal amount { get; set; }
    public string? description { get; set; }
    public DateTime date { get; set; }
    public int categoryId { get; set; }
}