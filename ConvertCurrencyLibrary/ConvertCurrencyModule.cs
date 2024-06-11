
using ConvertCurrencyLibrary.Enums;
using ConvertCurrencyLibrary.Interfaces;
using ConvertCurrencyLibrary.Models;
using ConvertCurrencyLibrary.Providers;
using ConvertCurrencyLibrary.Services;

namespace ConvertCurrencyLibrary
{
    public class ConvertCurrencyModule 
    {
       
        private readonly IConvertCurrencyService _convertCurrencyService;
        private readonly ICurrencyCalculaterService _calculaterService;
        private readonly ICourseHolderProvider _currencyProvider;
        public ConvertCurrencyModule(IEnumerable<Course> currencies)
        {
         
            _currencyProvider = new CurrencyHolderProvider(currencies);
            _convertCurrencyService = new ConvertCurrencyService(_currencyProvider);
            _calculaterService = new CurrencyCalculaterService(_currencyProvider, _convertCurrencyService);
        }
        public void ActualizeCourse(IEnumerable<Course> currencies)
        {
            _currencyProvider.ActualizeCourse(currencies);
        }

        public IEnumerable<Course> GetCourses()
        {
          return  _currencyProvider.GetCourses();
        }

        public Remittance CalculateRemmittance(Remittance firstRemittance, Remittance secondRemittance,
            OperatorType operatorType, Guid currencyId)
        {
            return  _calculaterService.CalculateRemmittance(firstRemittance,secondRemittance,operatorType,currencyId);
        }

        public Remittance ConvertRemittance(Remittance remittance, Guid currencyId)
        {
            return _convertCurrencyService.ConvertRemittance(remittance, currencyId);
        }
      

    }
}