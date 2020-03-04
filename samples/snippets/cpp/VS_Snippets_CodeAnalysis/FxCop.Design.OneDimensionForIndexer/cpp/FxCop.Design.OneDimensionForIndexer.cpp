//<Snippet1>
using namespace System;

namespace DesignLibrary
{
    public ref class DayOfWeek03
    {
        array<String^, 2>^ dayOfWeek;

    public:
        property String^ default[int,  int]
        {
            String^ get(int month, int day)
            {
                return dayOfWeek[month - 1, day - 1];
            }
        }

        DayOfWeek03()
        {
            dayOfWeek = gcnew array<String^, 2>(12, 7);
            dayOfWeek[0,0] = "Wed";
            dayOfWeek[0,1] = "Thu";
            // ...
            dayOfWeek[1,0] = "Sat";
            dayOfWeek[1,1] = "Sun";
            // ...
        }
    };

    public ref class RedesignedDayOfWeek03
    {
        static array<String^>^ dayOfWeek = 
            {"Tue", "Wed", "Thu", "Fri", "Sat", "Sun", "Mon"};

        static array<int>^ daysInPreviousMonth = 
            {0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30};

    public:
        String^ GetDayOfWeek(int month, int day)
        {
            return dayOfWeek[(daysInPreviousMonth[month - 1] + day) % 7];
        }
    };
}
//</Snippet1>
