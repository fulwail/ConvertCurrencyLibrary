using ConvertCurrencyLibrary.Interfaces;
using ConvertCurrencyLibrary.Models;

namespace ConvertCurrencyLibrary.Services
{
    internal class ConvertCurrencyService: IConvertCurrencyService
    {
        private ICourseHolderProvider _currencyProvider;

        internal ConvertCurrencyService( ICourseHolderProvider currencyProvider)
        {       
            _currencyProvider = currencyProvider;
        }

        public Remittance ConvertRemittance(Remittance remittance, Guid currencyId)
        {
            var convertedCourse = _currencyProvider.GetCourseByCurrencyId(currencyId);
            var convertedValue = ConvertValue(remittance, convertedCourse);
            var result = new Remittance()
            {
                Currency = convertedCourse.Currency,
                Value = convertedValue
            };
            return result;
        }

        private decimal ConvertValue(Remittance remittance, Course convertedCourse)
        {
            var remittanceCourse = _currencyProvider.GetCourseByCurrencyId(remittance.Currency.Id);
            if (convertedCourse == null || remittanceCourse == null)
                throw new ArgumentException("Курс валют для конвертации отсутсвует");
            return Math.Round(remittance.Value /remittanceCourse.Count  * convertedCourse.Count,3);
        }

        public Remittance ConvertRemittance(Remittance remittance, Course convertedCourse)
        {
            var convertedValue = ConvertValue(remittance, convertedCourse);
            var result = new Remittance()
            {
                Currency = convertedCourse.Currency,
                Value = convertedValue
            };
            return result;
        }
    }
}
