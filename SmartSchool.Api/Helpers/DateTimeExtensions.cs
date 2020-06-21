using System;

namespace SmartSchool.Api.Helpers
{
    public static class DateTimeExtensions
    {
        public static int PegarIdadeAtual(this DateTime datetime)
        {
            var currentDate = DateTime.Now;
            int age = currentDate.Year - datetime.Year;

            if (currentDate < datetime.AddYears(age))
            {
                age--;
            }

            return age;
        }
    }
}