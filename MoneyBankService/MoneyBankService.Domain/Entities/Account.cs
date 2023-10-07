using MoneyBankService.Domain.Common;

namespace MoneyBankService.Domain.Entities
{
    public class Account : EntityBase
    {
        public char AccountType { get; set; }
        public DateTime CreationDate { get; set; }
        public string AccountNumber { get; set; }
        public string OwnerName { get; set; }
        public decimal BalanceAmount { get; set; }
        public decimal OverdraftAmount { get; set; }
    }
}
