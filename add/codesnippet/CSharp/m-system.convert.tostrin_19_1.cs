		public void ConvertStringDecimal(string stringVal) {
			decimal decimalVal = 0;
			
			try {
				decimalVal = System.Convert.ToDecimal(stringVal);
				System.Console.WriteLine(
					"The string as a decimal is {0}.", decimalVal);
			} 
			catch (System.OverflowException){
				System.Console.WriteLine(
					"The conversion from string to decimal overflowed.");
			}
			catch (System.FormatException) {
				System.Console.WriteLine(
					"The string is not formatted as a decimal.");
			}
			catch (System.ArgumentNullException) {
				System.Console.WriteLine(
					"The string is null.");
			}

			// Decimal to string conversion will not overflow.
			stringVal = System.Convert.ToString(decimalVal);
			System.Console.WriteLine(
				"The decimal as a string is {0}.", stringVal);
		}	