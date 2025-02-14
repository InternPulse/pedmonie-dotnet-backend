using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedmonie.Model.Entity;
public class Wallet
{
    [Key]
    public int WalletId { get; set; } // UUID primary key

    [Required]
    public int MerchantId { get; set; } // UUID foreign key

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Amount { get; set; } = 0.00M; // Default: 0.00

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

