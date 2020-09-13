namespace MiniBank.Entities
{
    public class BankAccount
    {
        public int AccountNumber { get; set; } //This will be the primary key and It should be identity
        public string Name { get; set; }
        public double Money { get; set; }
        public Client Client { get; set; }
    }
}