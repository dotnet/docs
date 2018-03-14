using System;

class Class1
{
   static void Main(string[] args)
	{
	  ShowDefaultFormats();
	  ShowDefaultFrenchFormats();
	  Console.WriteLine("\nDefault 'D' Format:\n");
	  ShowDefaultDFormat();
	  Console.WriteLine("\nFrench 'D' Format:\n");
	  ShowFrenchDFormat();
	}

   private static void ShowDefaultFormats()
   {
		// <Snippet1>
		DateTime july28 = new DateTime(2009, 7, 28, 5, 23, 15, 16);

		string[] july28Formats = july28.GetDateTimeFormats();

		// Print out july28 in all DateTime formats using the default culture.
		foreach (string format in july28Formats) {
			Console.WriteLine(format);
		}
		// </Snippet1>
   }

   private static void ShowDefaultFrenchFormats()
   {
      // <Snippet2>
		DateTime july28 = new DateTime(2009, 7, 28, 5, 23, 15, 16);
		
		IFormatProvider culture = 
			new System.Globalization.CultureInfo("fr-FR", true);
		// Get the short date formats using the "fr-FR" culture.
		string [] frenchJuly28Formats = 
					july28.GetDateTimeFormats(culture);

		// Display july28 in various formats using "fr-FR" culture.
		foreach (string format in frenchJuly28Formats) {
			Console.WriteLine(format);
		}
		// </Snippet2>
	}

   private static void ShowDefaultDFormat()
   {
      // <Snippet3>
		DateTime july28 = new DateTime(2009, 7, 28, 5, 23, 15);
		
		// Get the long date formats using the current culture.
		string [] longJuly28Formats = 
					july28.GetDateTimeFormats('D');

		// Display july28 in all long date formats.
		foreach (string format in longJuly28Formats) {
			Console.WriteLine(format);
		}
      // The example displays the following output:
      //       Tuesday, July 28, 2009
      //       July 28, 2009
      //       Tuesday, 28 July, 2009
      //       28 July, 2009
		// </Snippet3>
   }

   private static void ShowFrenchDFormat()
   {
      // <Snippet4>
		DateTime july28 = new DateTime(2009, 7, 28, 5, 23, 15);
		
		IFormatProvider culture = 
			new System.Globalization.CultureInfo("fr-FR", true);
		// Get the short date formats using the "fr-FR" culture.
		string [] frenchJuly28Formats = 
					july28.GetDateTimeFormats('d', culture);

		// Display july28 in short date formats using "fr-FR" culture.
		foreach (string format in frenchJuly28Formats) {
			Console.WriteLine(format);
		}
      // The example displays the following output:
      //       28/07/2009
      //       28/07/09
      //       28.07.09
      //       28-07-09
      //       2009-07-28
		// </Snippet4>
   }
}
