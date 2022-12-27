namespace WalletDemo;

public class Transaction
{
    public string? TransactionId { get; set; }
    public decimal RequestAmount { get; set; }
    public DateTime DateCreated { get; set; }
    public string? CurrencyCode { get; set; }
    public string? CountryCode { get; set; }
    public int StatusId { get; set; }
    public string? StatusName { get; set; }
    public string? VendorResponse { get; set; }
    public decimal VendorFee { get; set; }
    public string? VendorReference { get; set; }
    public DateTime? CompletedDate { get; set; }
    public int Type { get; set; }
}

