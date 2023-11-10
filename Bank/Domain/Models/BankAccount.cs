namespace Domain.Models
{
    public class BankAccount
    {
        public Guid IdAccount { get; set; }
        public string Holder {  get; set; }
        public decimal Balance { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
