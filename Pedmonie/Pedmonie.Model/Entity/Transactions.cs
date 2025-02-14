using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pedmonie.Model.Enum;

namespace Pedmonie.Model.Entity;
public class Transaction
{
    [Key]
    public int TransactionId { get; set; } // UUID primary key

    [Required]
    public int OrderId { get; set; } // UUID not null

    [Required]
    public int MerchantId { get; set; } // UUID not null

    [Required, MaxLength(50)]
    public string GatewayName { get; set; } // (50) not null

    [Required, MaxLength(50)]
    public string Reference { get; set; } // (50) not null

    [Required, MaxLength(50)]
    public string PaymentChannel { get; set; } // (50) not null

    [Required]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Amount { get; set; } // not null

    [MaxLength(50)]
    public string PaymentId { get; set; } // (50)

    [MaxLength(50)]
    public string GatewayResponse { get; set; } // (50)

    [MaxLength(10)]
    public Status Status { get; set; } // enum ('pending', 'successful', 'failed')

    public DateTime? PaidAt { get; set; }

    [Required, MaxLength(50)]
    public string Currency { get; set; } // (50) not null

    [MaxLength(100)]
    public string IpAddress { get; set; } // (100)

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

