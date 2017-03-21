		public void ConvertStringChar(string stringVal) {
			char charVal = 'a';

			// A string must be one character long to convert to char.
			try {
				charVal = System.Convert.ToChar(stringVal);
				System.Console.WriteLine("{0} as a char is {1}",
					stringVal, charVal);
			}
			catch (System.FormatException) {
				System.Console.WriteLine(
					"The string is longer than one character.");
			}
			catch (System.ArgumentNullException) {
				System.Console.WriteLine("The string is null.");
			}

			// A char to string conversion will always succeed.
			stringVal = System.Convert.ToString(charVal);
			System.Console.WriteLine("The character as a string is {0}",
					stringVal);
		}