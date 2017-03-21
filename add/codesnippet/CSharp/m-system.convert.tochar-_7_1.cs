		public void ConvertLongChar(long longVal) {

			char	charVal = 'a';

			try {
				charVal = System.Convert.ToChar(longVal);
				System.Console.WriteLine("{0} as a char is {1}",
					longVal, charVal);
			} 
			catch (System.OverflowException) {
				System.Console.WriteLine(
					"Overflow in long-to-char conversion.");
			}
			
			// A conversion from Char to long cannot overflow.
			longVal = System.Convert.ToInt64(charVal);
			System.Console.WriteLine("{0} as an Int64 is {1}",
				charVal, longVal);
		}