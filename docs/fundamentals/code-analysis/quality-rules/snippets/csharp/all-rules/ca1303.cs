
using System;
using System.Globalization;
using System.Reflection;
using System.Resources;

[assembly: NeutralResourcesLanguageAttribute("en-US")]
namespace GlobalizationLibrary
{
    //<snippet1>
    public class DoNotPassLiterals
    {
        ResourceManager stringManager;
        public DoNotPassLiterals()
        {
            stringManager = new ResourceManager("en-US", Assembly.GetExecutingAssembly());
        }

        public void TimeMethod(int hour, int minute)
        {
            if (hour < 0 || hour > 23)
            {
                // CA1303 fires because a literal string
                // is passed as the 'value' parameter.
                Console.WriteLine("The valid range is 0 - 23.");
            }

            if (minute < 0 || minute > 59)
            {
                Console.WriteLine(stringManager.GetString(
                "minuteOutOfRangeMessage", CultureInfo.CurrentUICulture));
            }
        }
    }
    //</snippet1>
}
