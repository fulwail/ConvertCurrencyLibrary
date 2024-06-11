using ConvertCurrencyLibrary.Interfaces;
using ConvertCurrencyLibrary.Models;

namespace ConvertCurrencyLibrary.Providers
{
    internal class CurrencyHolderProvider: ICourseHolderProvider
    {
        private IEnumerable<Course> _currencies;

        public CurrencyHolderProvider(IEnumerable<Course> currencies)
        {
            _currencies = currencies;  
        }
           
        public void ActualizeCourse(IEnumerable<Course> currencies)
        {
            _currencies = currencies;
        }

        public IEnumerable<Course> GetCourses()
        {
            return _currencies;
        }
        public Course? GetCourseByCurrencyId(Guid id)
        {
            return _currencies.FirstOrDefault(x=>x.Currency.Id== id);
        }
        public Course? GetCourseByCode(string code)
        {
            return _currencies.FirstOrDefault(x => x.Currency?.Code == code);
        }
    }
}
