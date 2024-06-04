using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TransactionsModel
    {
        public int tid { get; set; }
        public int cid { get; set; }
        public int bid { get; set; }
        public string? type { get; set; }
        public DateTime date { get; set; }
    }
}
