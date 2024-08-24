using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstGabrielCampos.Entities
{
    public class Bank
    {
        public int BankId { get; set; }
        public string BankName { get; set; }
        public string Address { get; set; }

        // Navigation property
        public ICollection<Account> Accounts { get; set; }
    }
}