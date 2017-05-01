//<Snippet1>
using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;



[assembly: NeutralResourcesLanguageAttribute("en-US")]
namespace GlobalizationLibrary
{
    public class DoNotPassLiterals
    {
        ResourceManager stringManager;
        public DoNotPassLiterals()
        {
            stringManager =
            new ResourceManager("en-US", Assembly.GetExecutingAssembly());
        }

        public void TimeMethod(int hour, int minute)
        {
            if (hour < 0 || hour > 23)
            {
                MessageBox.Show(
                "The valid range is 0 - 23."); //CA1303 fires because the parameter for method Show is Text
            }

            if (minute < 0 || minute > 59)
            {
                MessageBox.Show(
                stringManager.GetString(
                "minuteOutOfRangeMessage", CultureInfo.CurrentUICulture));
            }
        }
    }

}


//</Snippet1>
