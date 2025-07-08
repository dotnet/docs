// <Snippet1>
using System;
using System.Globalization;
using System.Resources;
using System.Threading;

public class Example
{
    public static void Main()
    {
        // Create array of supported cultures
        string[] cultures = { "en-CA", "en-US", "fr-FR", "ru-RU" };
        Random rnd = new Random();
        int cultureNdx = rnd.Next(0, cultures.Length);
        CultureInfo originalCulture = Thread.CurrentThread.CurrentCulture;
        ResourceManager rm = new ResourceManager("Greetings", typeof(Example).Assembly);
        try
        {
            CultureInfo newCulture = new CultureInfo(cultures[cultureNdx]);
            Thread.CurrentThread.CurrentCulture = newCulture;
            Thread.CurrentThread.CurrentUICulture = newCulture;
            string greeting = String.Format("The current culture is {0}.\n{1}",
                                            Thread.CurrentThread.CurrentUICulture.Name,
                                            rm.GetString("HelloString"));
            Console.WriteLine(greeting);
        }
        catch (CultureNotFoundException e)
        {
            Console.WriteLine($"Unable to instantiate culture {e.InvalidCultureName}");
        }
        finally
        {
            Thread.CurrentThread.CurrentCulture = originalCulture;
            Thread.CurrentThread.CurrentUICulture = originalCulture;
        }
    }
}
// The example displays output like the following:
//       The current culture is ru-RU.
//       Всем привет!
// </Snippet1>
