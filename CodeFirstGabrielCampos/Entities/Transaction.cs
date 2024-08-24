using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstGabrielCampos.Entities
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; } // e.g., "Credit", "Debit"
        public int AccountId { get; set; }

        // Foreign key relationship
        public Account Account { get; set; }
    }
}