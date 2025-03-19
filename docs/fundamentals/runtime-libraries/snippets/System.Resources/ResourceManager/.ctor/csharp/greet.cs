// <Snippet3>
using System;
using System.Resources;
using System.Globalization;
using System.Threading;

[assembly: NeutralResourcesLanguage("en")]

public class Example2
{
    public static void Main()
    {
        string[] cultureNames = [ "en-US", "fr-FR", "ru-RU", "sv-SE" ];
        DateTime noon = new DateTime(DateTime.Now.Year, DateTime.Now.Month,
                                     DateTime.Now.Day, 12, 0, 0);
        DateTime evening = new DateTime(DateTime.Now.Year, DateTime.Now.Month,
                                        DateTime.Now.Day, 18, 0, 0);

        ResourceManager rm = new ResourceManager(typeof(GreetingResources));

        foreach (var cultureName in cultureNames)
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(cultureName);
            Console.WriteLine($"The current UI culture is {CultureInfo.CurrentUICulture.Name}");
            if (DateTime.Now < noon)
                Console.WriteLine("{0}!", rm.GetString("Morning"));
            else if (DateTime.Now < evening)
                Console.WriteLine("{0}!", rm.GetString("Afternoon"));
            else
                Console.WriteLine("{0}!", rm.GetString("Evening"));
            Console.WriteLine();
        }
    }

    internal class GreetingResources
    {
    }
}
// The example displays output like the following:
//       The current UI culture is en-US
//       Good afternoon!
//
//       The current UI culture is fr-FR
//       Bonjour!
//
//       The current UI culture is ru-RU
//       Добрый день!
//
//       The current UI culture is sv-SE
//       Good afternoon!
// </Snippet3>
