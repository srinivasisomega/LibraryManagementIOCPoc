using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementIOCPoc.models
{
    

        public class Transaction
        {
            public int TransactionId { get; set; }
            public int UserId { get; set; }
            public int BookId { get; set; }
            public string TransactionType { get; set; }
            public DateTime TransactionDate { get; set; }
            public User User { get; set; }
            public Book Book { get; set; }
        }
    

}
