using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertCurrencyLibrary.Models
{
    public class Remittance
    {
        public decimal Value { get; set; }
        public Currency Currency { get; set; }
    }
}
