namespace MoneyBankService.Application.Interfaces;


public interface IAccountService
{
    Task<IEnumerable<AccountDto>> GetAccounts(string accountNumber = null);
    Task<AccountDto> GetAccountById(int id);
    Task<AccountDto> CreateAccount(AccountDto accountDto);
    Task UpdateAccount(AccountDto accountDto);
    Task DeleteAccount(int id);
    Task<AccountDto> Deposit(int accountId, decimal amount);
    Task<AccountDto> Withdraw(int accountId, decimal amount);
   
}
