namespace MoneyBankService.Api.Dto
{
    public class AccountDto
    {
        public int Id { get; set; }
        public char AccountType { get; set; }
        public DateTime CreationDate { get; set; }
        public string AccountNumber { get; set; }
        public string OwnerName { get; set; }
        public decimal BalanceAmount { get; set; }
        public decimal OverdraftAmount { get; set; }
    }
}
