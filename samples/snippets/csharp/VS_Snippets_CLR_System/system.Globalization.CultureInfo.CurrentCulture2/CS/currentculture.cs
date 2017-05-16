
// <snippet11>
using System;
using System.Globalization;
using System.Threading;

public class Example
{
   public static void Main()  
   {
      // Display the name of the current thread culture.
      Console.WriteLine("CurrentCulture is {0}.", CultureInfo.CurrentCulture.Name);

      // Change the current culture to th-TH.
      CultureInfo.CurrentCulture = new CultureInfo("th-TH", false);
      Console.WriteLine("CurrentCulture is now {0}.", CultureInfo.CurrentCulture.Name);

      // Display the name of the current UI culture.
      Console.WriteLine("CurrentUICulture is {0}.", CultureInfo.CurrentUICulture.Name);

      // Change the current UI culture to ja-JP.
      CultureInfo.CurrentUICulture = new CultureInfo( "ja-JP", false );
      Console.WriteLine("CurrentUICulture is now {0}.", CultureInfo.CurrentUICulture.Name);
   }
}
// The example displays the following output:
//       CurrentCulture is en-US.
//       CurrentCulture is now th-TH.
//       CurrentUICulture is en-US.
//       CurrentUICulture is now ja-JP.
// </snippet11>
