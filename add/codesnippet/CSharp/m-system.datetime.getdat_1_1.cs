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