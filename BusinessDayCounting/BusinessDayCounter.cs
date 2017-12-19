using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessDayCounting
{
    public class BusinessDayCounter
    {
        /// <summary>
        /// TASK ONE:
        /// Calculates the number of weekdays in between two dates.
        /// </summary>
        /// <remarks>
        /// Weekdays are Monday, Tuesday, Wednesday, Thursday, Friday.
        /// The returned count should not include either firstDate or secondDate - e.g. between Monday 07-Oct-2013 and Wednesday 09-Oct-2013 is one weekday.
        /// If secondDate is equal to or before firstDate, return 0.
        /// </remarks>
        /// <param name="firstDate">The first date.</param>
        /// <param name="secondDate">The second date.</param>
        /// <returns>Number of weekdays</returns>
        public static int WeekdaysBetweenTwoDates(DateTime firstDate, DateTime secondDate)
        {
            int days = 0;
            firstDate = firstDate.AddDays(1);
            while (firstDate < secondDate)
            {
                if (firstDate.DayOfWeek != DayOfWeek.Saturday && firstDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    ++days;
                }
                firstDate = firstDate.AddDays(1);
            }
            return days;
            
        }

        /// <summary>
        /// TASK TWO:
        /// Calculates the number of business days in between two dates.
        /// </summary>
        /// <remarks>
        /// Business days are Monday, Tuesday, Wednesday, Thursday, Friday, but excluding any dates which appear in the supplied list of public holidays.
        /// The returned count should not include either firstDate or secondDate - e.g. between Monday 07-Oct-2013 and Wednesday 09-Oct-2013 is one weekday.
        /// If secondDate is equal to or before firstDate, return 0.
        /// </remarks>
        /// <param name="firstDate">The first date.</param>
        /// <param name="secondDate">The second date.</param>
        /// <param name="publicHolidays">List of public holidays.</param>
        /// <returns>Number of business days</returns>
        public static int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IList<DateTime> publicHolidays)
        {
            int days = 0;
            firstDate = firstDate.AddDays(1);
            while (firstDate < secondDate)
            {
                if (firstDate.DayOfWeek != DayOfWeek.Saturday && firstDate.DayOfWeek != DayOfWeek.Sunday)
                {

                    foreach (DateTime date1 in publicHolidays)

                        if (firstDate == date1) { --days; }
                    ++days;
                }
                firstDate = firstDate.AddDays(1);
            }
            return days;
        }

        public static int BusinessDaysBetweenTwoDatesWithRules(DateTime firstDate, DateTime secondDate, IList<DateTime> publicHolidaysWithRule1, IList<DateTime> publicHolidaysWithRule2, IList<DateTime> publicHolidaysWithRule3)
        {
            int days = 0;
            firstDate = firstDate.AddDays(1);
            while (firstDate < secondDate)
            {
                if (firstDate.DayOfWeek != DayOfWeek.Saturday && firstDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    // Rule1: if public holiday is on Saturday or Sunday dount count the day
                    foreach (DateTime date1 in publicHolidaysWithRule1)
                        if (firstDate == date1) { --days; }

                    // Rule2: if public holiday is on Saturday or Sunday move it to Monday
                    foreach (DateTime date2 in publicHolidaysWithRule2)
                        if (date2.DayOfWeek == DayOfWeek.Saturday)
                        {
                            if (firstDate.AddDays(2) == date2.AddDays(2)) { --days; }
                        }
                        else if (date2.DayOfWeek == DayOfWeek.Sunday)
                        {
                            if (firstDate.AddDays(1) == date2.AddDays(1)) { --days; }
                        }

                    // Rule3: if public holiday never happens on Saturday or Sunnday
                    foreach (DateTime date3 in publicHolidaysWithRule3)
                        if (firstDate == date3) { --days; }

                    ++days;
                }
                firstDate = firstDate.AddDays(1);
            }
            return days;
        }
    }
}
