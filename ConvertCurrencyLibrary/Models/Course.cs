using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertCurrencyLibrary.Models
{
    public class Course
    {
        public Guid Id { get; set; }
        public Currency Currency { get; set; }
        public decimal Count { get; set; }
    }
}
