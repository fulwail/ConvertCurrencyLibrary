using ConvertCurrencyLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertCurrencyLibrary.Interfaces
{
    internal interface IConvertCurrencyService
    {
        Remittance ConvertRemittance(Remittance remittance,  Guid currencyId);
        Remittance ConvertRemittance(Remittance firstRemittance, Course currency);
    }
}
