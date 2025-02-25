using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedmonie.Model.Entity;
[Table("wallets")]
public class Wallet
{
    [Key]
    [Column("wallet_id", TypeName = "char(32)")]
    public string WalletId { get; set; } // UUID primary key

    [Required]
    [Column("merchant_id")]
    public Guid MerchantId { get; set; } // UUID foreign key

    [Column(name: "amount", TypeName = "decimal(18, 2)")]
    public decimal Amount { get; set; } = 0.00M; // Default: 0.00

    [Column("createdAt")]
    public DateTime CreatedAt { get; set; }
    [Column("updatedAt")]
    public DateTime UpdatedAt { get; set; }
}

