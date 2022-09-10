namespace PaymentAPI.Models
{
    public class PaymentModel
    {
        public string? Name { get; set; }
        public string? TaxRoll{ get; set; }
        public string? Mail { get; set; }
        public string? Cellphone { get; set; }
        public string[]? SaledItems { get; set; }
        public DateTime Date { get; set; }
    }
}
