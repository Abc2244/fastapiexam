using MoneyBankService.Application.Interfaces;
using MoneyBankService.Domain.Entities;
using MoneyBankService.Domain.Interfaces.Repositories;

namespace MoneyBankService.Application.Services;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IMapper _mapper;

    public AccountService(IAccountRepository accountRepository, IMapper mapper)
    {
        _accountRepository = accountRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AccountDto>> GetAccounts(string accountNumber = null)
    {
        var accounts = string.IsNullOrEmpty(accountNumber)
            ? await _accountRepository.GetAllAccounts()
            : await _accountRepository.GetAccountsByNumber(accountNumber);

        return _mapper.Map<IEnumerable<AccountDto>>(accounts);
    }

    public async Task<AccountDto> GetAccountById(int id)
    {
        var account = await _accountRepository.GetAccountById(id);
        return _mapper.Map<AccountDto>(account);
    }

    public async Task<AccountDto> CreateAccount(AccountDto accountDto)
    {
        var account = _mapper.Map<Account>(accountDto);
        var createdAccount = await _accountRepository.CreateAccount(account);
        return _mapper.Map<AccountDto>(createdAccount);
    }

    public async Task UpdateAccount(AccountDto accountDto)
    {
        var account = _mapper.Map<Account>(accountDto);
        await _accountRepository.UpdateAccount(account);
    }

    public async Task DeleteAccount(int id)
    {
        await _accountRepository.DeleteAccount(id);
    }

    public async Task<AccountDto> Deposit(int accountId, decimal amount)
    {
        // Lógica de negocio para depositar
        var account = await _accountRepository.GetAccountById(accountId);
        if (account == null)
        {
            throw new Exception("Cuenta no encontrada.");
        }

        account.Balance += amount;

        var updatedAccount = await _accountRepository.UpdateAccount(account);
        return _mapper.Map<AccountDto>(updatedAccount);
    }

    public async Task<AccountDto> Withdraw(int accountId, decimal amount)
    {
        

        // Lógica de negocio para retirar
        var account = await _accountRepository.GetAccountById(accountId);
        if (account == null)
        {
            throw new Exception("Cuenta no encontrada.");
        }

        if (account.Balance < amount)
        {
            throw new Exception("Saldo insuficiente para el retiro.");
        }

        account.Balance -= amount;

        // Opcional: Puedes querer registrar esta transacción en una tabla de transacciones
        // await _transactionRepository.Add(new Transaction { AccountId = accountId, Amount = amount, Type = TransactionType.Withdrawal });

        var updatedAccount = await _accountRepository.UpdateAccount(account);
        return _mapper.Map<AccountDto>(updatedAccount);
    }
}
