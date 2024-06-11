using ConvertCurrencyLibrary.Enums;
using ConvertCurrencyLibrary.Interfaces;
using ConvertCurrencyLibrary.Models;
using ConvertCurrencyLibrary.Providers;

namespace ConvertCurrencyLibrary.Services
{
    internal class CurrencyCalculaterService : ICurrencyCalculaterService
    {
        private ICourseHolderProvider _currencyProvider;
        private IConvertCurrencyService _convertCurrencyService;

        internal CurrencyCalculaterService(ICourseHolderProvider currencyProvider, IConvertCurrencyService convertCurrencyService)
        {
            _currencyProvider = currencyProvider;
            _convertCurrencyService = convertCurrencyService;
        }

        public Remittance CalculateRemmittance(Remittance firstRemittance, Remittance secondRemittance, OperatorType operatorType, Guid currencyId)
        {
            var course =_currencyProvider.GetCourseByCurrencyId(currencyId);
            
            var result = new Remittance()
            {
                Currency= course.Currency
            };
            var convertedFirstRemittance = _convertCurrencyService.ConvertRemittance(firstRemittance,course); 
            var convertedSecondRemittance = _convertCurrencyService.ConvertRemittance(secondRemittance, currencyId);
            var resultValue = 0m;
            switch (operatorType)
            {
                case OperatorType.Plus:
                    resultValue = convertedFirstRemittance.Value + convertedSecondRemittance.Value;
                    break;
                case OperatorType.Minus:
                    resultValue = convertedFirstRemittance.Value - convertedSecondRemittance.Value;
                    break;
                default:
                    throw new ArgumentException("Данный тип операции не реализован");
            }

            result.Value = resultValue;
            return result;
        }
    }
}
