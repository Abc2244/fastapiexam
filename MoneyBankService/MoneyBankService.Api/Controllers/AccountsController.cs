using Microsoft.AspNetCore.Mvc;
using MoneyBankService.Api.Dto;
using MoneyBankService.Application.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class AccountsController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountsController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AccountDto>>> GetAccounts([FromQuery] string accountNumber = null)
    {
        var accounts = await _accountService.GetAccounts(accountNumber);
        if (accounts == null || !accounts.Any()) { return NotFound(); }
        return Ok(accounts);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AccountDto>> GetAccount(int id)
    {
        var account = await _accountService.GetAccountById(id);
        if (account == null) { return NotFound(); }
        return Ok(account);
    }

    [HttpPost]
    public async Task<ActionResult<AccountDto>> CreateAccount(AccountDto accountDto)
    {
        var createdAccount = await _accountService.CreateAccount(accountDto);
        return CreatedAtAction(nameof(GetAccount), new { id = createdAccount.Id }, createdAccount);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAccount(int id, AccountDto accountDto)
    {
        if (id != accountDto.Id) { return BadRequest(); }
        await _accountService.UpdateAccount(accountDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAccount(int id)
    {
        await _accountService.DeleteAccount(id);
        return NoContent();
    }

   
    [HttpPost("{id}/deposit")]
    public async Task<ActionResult<AccountDto>> Deposit(int id, [FromBody] TransactionDto transactionDto)
    {
        if (id != transactionDto.AccountId) { return BadRequest("El ID de la cuenta no coincide con el ID de la transacción."); }

        var updatedAccount = await _accountService.Deposit(id, transactionDto.Amount);
        if (updatedAccount == null) { return NotFound(); }
        return Ok(updatedAccount);
    }

    [HttpPost("{id}/withdraw")]
    public async Task<ActionResult<AccountDto>> Withdraw(int id, [FromBody] TransactionDto transactionDto)
    {
        if (id != transactionDto.AccountId) { return BadRequest("El ID de la cuenta no coincide con el ID de la transacción."); }

        var updatedAccount = await _accountService.Withdraw(id, transactionDto.Amount);
        if (updatedAccount == null) { return NotFound(); }
        return Ok(updatedAccount);
    }

    

}
