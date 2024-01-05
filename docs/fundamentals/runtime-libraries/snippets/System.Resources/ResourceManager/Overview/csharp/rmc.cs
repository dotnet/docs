//<snippet1>
using System;
using System.Globalization;
using System.Resources;

class Example2
{
    public static void Main()
    {
        string day;
        string year;
        string holiday;
        string celebrate = "{0} will occur on {1} in {2}.\n";

        // Create a resource manager.
        ResourceManager rm = new ResourceManager("rmc",
                                 typeof(Example).Assembly);

        Console.WriteLine("Obtain resources using the current UI culture.");

        // Get the resource strings for the day, year, and holiday
        // using the current UI culture.
        day = rm.GetString("day");
        year = rm.GetString("year");
        holiday = rm.GetString("holiday");
        Console.WriteLine(celebrate, holiday, day, year);

        // Obtain the es-MX culture.
        CultureInfo ci = new CultureInfo("es-MX");

        Console.WriteLine("Obtain resources using the es-MX culture.");

        // Get the resource strings for the day, year, and holiday
        // using the specified culture.
        day = rm.GetString("day", ci);
        year = rm.GetString("year", ci);
        holiday = rm.GetString("holiday", ci);
        // ---------------------------------------------------------------
        // Alternatively, comment the preceding 3 code statements and
        // uncomment the following 4 code statements:
        // ----------------------------------------------------------------
        // Set the current UI culture to "es-MX" (Spanish-Mexico).
        //    Thread.CurrentThread.CurrentUICulture = ci;

        // Get the resource strings for the day, year, and holiday
        // using the current UI culture. Use those strings to
        // display a message.
        //    day  = rm.GetString("day");
        //    year = rm.GetString("year");
        //    holiday = rm.GetString("holiday");
        // ---------------------------------------------------------------

        // Regardless of the alternative that you choose, display a message
        // using the retrieved resource strings.
        Console.WriteLine(celebrate, holiday, day, year);
    }
}
/*
This example displays the following output:

   Obtain resources using the current UI culture.
   "5th of May" will occur on Friday in 2006.

   Obtain resources using the es-MX culture.
   "Cinco de Mayo" will occur on Viernes in 2006.
*/
//</snippet1>
