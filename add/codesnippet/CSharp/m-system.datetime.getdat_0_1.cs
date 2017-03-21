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