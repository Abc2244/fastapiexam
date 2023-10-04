using System.ComponentModel.DataAnnotations;

namespace MoneyBankMVC.Models;

public partial class Account
{
    [Key]

    [Required]
    public int Id { get; set; }
    [Required]

    public string AccountType { get; set; } = null!;
    [Required]

    public DateTime CreationDate { get; set; }
    [Required]

    public string AccountNumber { get; set; } = null!;
    [Required]

    public string OwnerName { get; set; } = null!;
    [Required]

    public decimal BalanceAmount { get; set; }
    [Required]


    public decimal OverdraftAmount { get; set; }
    

}
