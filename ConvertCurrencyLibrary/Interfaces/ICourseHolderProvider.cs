using ConvertCurrencyLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertCurrencyLibrary.Interfaces
{
    internal interface ICourseHolderProvider
    {
        void ActualizeCourse(IEnumerable<Course> courses);
        IEnumerable<Course> GetCourses();
        Course? GetCourseByCurrencyId(Guid id);
        Course? GetCourseByCode(string code);
    }
}
