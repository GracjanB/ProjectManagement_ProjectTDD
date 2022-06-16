namespace TDDProject.Application.Models
{
    public class Transaction
    {
        public string SourceBankAccount { get; set; }

        public Owner SourceOwner { get; set; }

        public string DestinationBankAccount { get; set; }

        public Owner DestinationOwner { get; set; }

        public string TransactionType { get; set; }

        public decimal Amount { get; set; }
    }
}
