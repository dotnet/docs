//<Snippet1>
using System;

namespace DesignLibrary
{
    public class DayOfWeek03
    {
        string[,] dayOfWeek = {{"Wed", "Thu", "..."}, 
                               {"Sat", "Sun", "..."}};
                               // ...

        public string this[int month, int day]
        {
            get
            {
                return dayOfWeek[month - 1, day - 1];
            }
        }
    }

    public class RedesignedDayOfWeek03
    {
        string[] dayOfWeek = 
            {"Tue", "Wed", "Thu", "Fri", "Sat", "Sun", "Mon"};

        int[] daysInPreviousMonth = 
            {0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30};

        public string GetDayOfWeek(int month, int day)
        {
            return dayOfWeek[(daysInPreviousMonth[month - 1] + day) % 7];
        }
    }
}
//</Snippet1>
