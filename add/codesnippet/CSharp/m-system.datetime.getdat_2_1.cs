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