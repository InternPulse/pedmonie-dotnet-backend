using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pedmonie.Model.Enum;
using System.Transactions;
using System.Globalization;

namespace Pedmonie.Model.Entity;
/*[Table("TTransactions")]

public class Transaction
{
    [Column("transaction_id")]
    public string TransactionId { get; set; } // UUID primary key
    [Column("sn")]
    public string Sn { get; set; } // UUID primary key

    [Column("order_id")]
    public string OrderId { get; set; } // UUID not null

    [Column("merchant_id")]
    public string MerchantId { get; set; } // UUID not null

    [Column("gateway_name")]
    public string GatewayName { get; set; } // (50) not null
    [Column("payment_channel")]
    public string PaymentChannel { get; set; } // (50) not null

    [Column(name: "amount", TypeName = "decimal(18, 2)")]
    public decimal Amount { get; set; } // not null
    [Column("status")]
    public Status Status { get; set; } // enum ('pending', 'successful', 'failed')

    [Column("currency")]
    public string Currency { get; set; } // (50) not null

    [Column("createdAt")]
    public DateTime CreatedAt { get; set; }
    [Column("updatedAt")]
    public DateTime UpdatedAt { get; set; }


    #region Remove from migration
    [Required, MaxLength(50)]
    [Column("gateway_transaction_identifier")]
    [NotMapped]
    public string Reference { get; set; } // (50) not null


    [MaxLength(50)]
    [Column("gateway_transaction_identifier")]
    public string PaymentId { get; set; } // (50)

    [MaxLength(50)]
    [Column("merchant_id")]
    [NotMapped]
    public string GatewayResponse { get; set; } // (50)


    [Column("merchant_id")]
    [NotMapped]
    public DateTime? PaidAt { get; set; }
    [MaxLength(100)]
    [Column("merchant_id")]
    [NotMapped]
    public string IpAddress { get; set; } // (100)
    #endregion
}*/

[Table("transactions")]
public class Transaction
{
    // Auto-incremented primary key (optional in the model)
    [Key]
    [Column("sn")]
    public int Sn { get; set; }  // The 'sn' column is the primary key for this model, but it's auto-incremented

    // Unique transaction ID, which is a UUID represented as a string (char(36))
    [Required]
    [Column("transaction_id")]
    [StringLength(32)]
    public Guid TransactionId { get; set; }

    // Order ID represented as a UUID Guid (char(36))
    [Required]
    [Column("order_id")]
    public Guid OrderId { get; set; }

    // Merchant ID represented as a UUID Guid (char(36))
    [Required]
    [Column("merchant_id")]
    public Guid MerchantId { get; set; }

    // Name of the gateway (varchar(255))
    [Required]
    [MaxLength(255)]
    [Column("gateway_name")]
    public string GatewayName { get; set; }

    // Gateway transaction identifier (varchar(255))
    [MaxLength(255)]
    [Column("gateway_transaction_identifier")]
    public string GatewayTransactionIdentifier { get; set; }

    // Payment channel (varchar(255))
    [Required]
    [MaxLength(255)]
    [Column("payment_channel")]
    public string PaymentChannel { get; set; }

    // Amount (decimal(10,0)) without decimal places
    [Required]
    [Column("amount", TypeName = "decimal(10, 0)")]
    public decimal Amount { get; set; }

    // Transaction status (enum: pending, successful, failed)
    [Required]
    [Column("status")]
    public Status Status { get; set; }

    // Currency (varchar(255))
    [Required]
    [MaxLength(255)]
    [Column("currency")]
    public string Currency { get; set; }

    // Date and time when the transaction was created (datetime)
    [Required]
    [Column("createdAt")]
    public DateTime CreatedAt { get; set; }

    // Date and time when the transaction was last updated (datetime)
    [Required]
    [Column("updatedAt")]
    public DateTime UpdatedAt { get; set; }
}
