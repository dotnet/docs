// <Snippet1>
using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Threading;
using System.Windows.Forms;

class Example
{
   static void Main()
   {
      // Create array of supported cultures
      string[] cultures = {"en-CA", "en-US", "fr-FR", "ru-RU"};
      Random rnd = new Random();
      int cultureNdx = rnd.Next(0, cultures.Length);
      CultureInfo originalCulture = Thread.CurrentThread.CurrentCulture;

      try {
         CultureInfo newCulture = new CultureInfo(cultures[cultureNdx]);
         Thread.CurrentThread.CurrentCulture = newCulture;
         Thread.CurrentThread.CurrentUICulture = newCulture;
         ResourceManager rm = new ResourceManager("Example.Greeting",
                                                  typeof(Example).Assembly);
         string greeting = String.Format("The current culture is {0}.\n{1}",
                                         Thread.CurrentThread.CurrentUICulture.Name,
                                         rm.GetString("HelloString"));

         MessageBox.Show(greeting);
      }
      catch (CultureNotFoundException e) {
         Console.WriteLine($"Unable to instantiate culture {e.InvalidCultureName}");
      }
      finally {
         Thread.CurrentThread.CurrentCulture = originalCulture;
         Thread.CurrentThread.CurrentUICulture = originalCulture;
      }
   }
}
// </Snippet1>
