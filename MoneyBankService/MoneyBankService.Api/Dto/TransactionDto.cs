namespace MoneyBankService.Api.Dto
{
    public class TransactionDto
    {
        public int Id { get; set; }

        public string AccountNumber { get; set; }

        public decimal ValueAmount { get; set; }
    }
}
