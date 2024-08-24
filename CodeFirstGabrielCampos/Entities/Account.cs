using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CodeFirstGabrielCampos.Entities
{
    public class Account
    {
        public int AccountId { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public int CustomerId { get; set; }
        public int BankId { get; set; }

        // Foreign key relationships
        public Customer Customer { get; set; }
        public Bank Bank { get; set; }

        // Navigation property
        public ICollection<Transaction> Transactions { get; set; }
    }
}