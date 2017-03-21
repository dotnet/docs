		DateTime july28 = new DateTime(2009, 7, 28, 5, 23, 15, 16);

		string[] july28Formats = july28.GetDateTimeFormats();

		// Print out july28 in all DateTime formats using the default culture.
		foreach (string format in july28Formats) {
			Console.WriteLine(format);
		}