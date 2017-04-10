// <Snippet1>
using System;
using System.Globalization;
using System.Threading;

public class Example
{
   public static void Main()
   {
      DateTime dateToDisplay = new DateTime(2009, 6, 1, 8, 42, 50);
      CultureInfo originalCulture = Thread.CurrentThread.CurrentCulture;
      // Change culture to en-US.
      Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
      Console.WriteLine("Displaying short date for {0} culture:", 
                        Thread.CurrentThread.CurrentCulture.Name);
      Console.WriteLine("   {0} (Short Date String)", 
                        dateToDisplay.ToShortDateString());
      // Display using 'd' standard format specifier to illustrate it is
      // identical to the string returned by ToShortDateString.
      Console.WriteLine("   {0} ('d' standard format specifier)", 
                        dateToDisplay.ToString("d"));
      Console.WriteLine();
      
      // Change culture to fr-FR.
      Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");
      Console.WriteLine("Displaying short date for {0} culture:", 
                        Thread.CurrentThread.CurrentCulture.Name);
      Console.WriteLine("   {0}", dateToDisplay.ToShortDateString());
      Console.WriteLine();
  
      // Change culture to nl-NL.    
      Thread.CurrentThread.CurrentCulture = new CultureInfo("nl-NL");
      Console.WriteLine("Displaying short date for {0} culture:", 
                        Thread.CurrentThread.CurrentCulture.Name);
      Console.WriteLine("   {0}", dateToDisplay.ToShortDateString());
      
      // Restore original culture.
      Thread.CurrentThread.CurrentCulture = originalCulture;
   }
}
// The example displays the following output:
//       Displaying short date for en-US culture:
//          6/1/2009 (Short Date String)
//          6/1/2009 ('d' standard format specifier)
//       
//       Displaying short date for fr-FR culture:
//          01/06/2009
//       
//       Displaying short date for nl-NL culture:
//          1-6-2009
// </Snippet1>   
