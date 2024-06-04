using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class BooksModel
    {
        public int bid { get; set; }
        public string? author { get; set; }
        public string? title { get; set; }
        public DateTime year { get; set; }
        public string? status { get; set; }
    }
}
