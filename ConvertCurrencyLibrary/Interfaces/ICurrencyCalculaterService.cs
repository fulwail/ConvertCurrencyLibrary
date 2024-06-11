using ConvertCurrencyLibrary.Enums;
using ConvertCurrencyLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertCurrencyLibrary.Interfaces
{
    internal interface ICurrencyCalculaterService
    {
        Remittance CalculateRemmittance(Remittance firstRemittance, Remittance secondRemittance, OperatorType operatorType, Guid currencyId);
    }
}
