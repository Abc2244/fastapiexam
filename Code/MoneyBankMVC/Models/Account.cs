using System;
using System.Collections.Generic;

namespace MoneyBankMVC.Models;

public partial class Account
{
    public int Id { get; set; }

    public string AccountType { get; set; } = null!;

    public DateTime CreationDate { get; set; }

    public string AccountNumber { get; set; } = null!;

    public string OwnerName { get; set; } = null!;

    public decimal BalanceAmount { get; set; }

    public decimal OverdraftAmount { get; set; }
}
