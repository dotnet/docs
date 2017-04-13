using System;

namespace BasicSnippetC {

	class ConvertSnippet {

		static void Main(string[] args) {
			
			ConvertSnippet	snippet = new ConvertSnippet();

			double	doubleVal;
			System.Console.WriteLine("Enter the double value: ");
			doubleVal = System.Convert.ToDouble(System.Console.ReadLine());
			snippet.ConvertDoubles(doubleVal);

			long longVal;
			System.Console.WriteLine("Enter the Int64 value: ");
			longVal = System.Convert.ToInt64(System.Console.ReadLine());
			snippet.ConvertLongs(longVal);

			string stringVal;
			System.Console.WriteLine("Enter the String value: ");
			stringVal = System.Console.ReadLine();
			snippet.ConvertStrings(stringVal);

			char charVal;
			System.Console.WriteLine("Enter the char value: ");
			charVal = System.Convert.ToChar(System.Console.ReadLine());
			snippet.ConvertChars(charVal);

			byte byteVal;
			System.Console.WriteLine("Enter the byte value: ");
			byteVal = System.Convert.ToByte(System.Console.ReadLine());
			snippet.ConvertBytes(byteVal);

			snippet.ConvertBoolean();
		}

		public void ConvertDoubles(double doubleVal) {
			ConvertDoubleBool(doubleVal);
			ConvertDoubleByte(doubleVal);
			ConvertDoubleInt(doubleVal);
			ConvertDoubleDecimal((decimal) doubleVal);
			CovertDoubleFloat(doubleVal);
			ConvertDoubleString(doubleVal);
		}

		public void ConvertLongs(long longVal) {
			ConvertLongChar(longVal);
			ConvertLongByte(longVal);
			ConvertLongDecimal(longVal);
			ConvertLongFloat(longVal);
		}

		public void ConvertStrings(string stringVal) {
			ConvertStringBoolean(stringVal);
			ConvertStringByte(stringVal);
			ConvertStringChar(stringVal);
			ConvertStringDecimal(stringVal);
			ConvertStringFloat(stringVal);
		}

		public void ConvertChars(char charVal) {
			ConvertCharDecimal(charVal);
		}

		public void ConvertBytes(byte byteVal) {
			ConvertByteDecimal(byteVal);
			ConvertByteSingle(byteVal);

		}
	
		//<Snippet1>
		public void ConvertDoubleBool(double doubleVal) {
			bool	boolVal;
			// Double to bool conversion cannot overflow.
			boolVal = System.Convert.ToBoolean(doubleVal);
			System.Console.WriteLine("{0} as a Boolean is: {1}.",
				doubleVal, boolVal);

			// bool to double conversion cannot overflow.
			doubleVal = System.Convert.ToDouble(boolVal);
			System.Console.WriteLine("{0} as a double is: {1}.",
				boolVal, doubleVal);
		}
		//</Snippet1>

		//<Snippet2>
		public void ConvertDoubleByte(double doubleVal) {
			byte	byteVal = 0;

			// Double to byte conversion can overflow.
			try {
				byteVal = System.Convert.ToByte(doubleVal);
				System.Console.WriteLine("{0} as a byte is: {1}.",
					doubleVal, byteVal);
			} 
			catch (System.OverflowException) {
				System.Console.WriteLine(
					"Overflow in double-to-byte conversion.");
			}

			// Byte to double conversion cannot overflow.
			doubleVal = System.Convert.ToDouble(byteVal);
			System.Console.WriteLine("{0} as a double is: {1}.",
				byteVal, doubleVal);
		}
		//</Snippet2>

		//<Snippet3>
		public void ConvertDoubleInt(double doubleVal) {
			
			int     intVal = 0;
			// Double to int conversion can overflow.
			try {
				intVal = System.Convert.ToInt32(doubleVal);
				System.Console.WriteLine("{0} as an int is: {1}",
					doubleVal, intVal);
			} 
			catch (System.OverflowException) {
				System.Console.WriteLine(
					"Overflow in double-to-int conversion.");
			}

			// Int to double conversion cannot overflow.
			doubleVal = System.Convert.ToDouble(intVal);
			System.Console.WriteLine("{0} as a double is: {1}",
				intVal, doubleVal);
		}
		//</Snippet3>
	
		//<Snippet5>
		public void ConvertDoubleDecimal(decimal decimalVal){
			
			double doubleVal;
			
			// Decimal to double conversion cannot overflow.
         doubleVal = System.Convert.ToDouble(decimalVal);
			System.Console.WriteLine("{0} as a double is: {1}",
					decimalVal, doubleVal);

			// Conversion from double to decimal can overflow.
			try 
         {
			   decimalVal = System.Convert.ToDecimal(doubleVal);
   			System.Console.WriteLine ("{0} as a decimal is: {1}",
	   			doubleVal, decimalVal);
			} 
			catch (System.OverflowException) {
				System.Console.WriteLine(
					"Overflow in double-to-double conversion.");
			}
			

		}
		//</Snippet5>

		//<Snippet6>
		public void CovertDoubleFloat(double doubleVal) {	
			float floatVal = 0;

			// Double to float conversion cannot overflow.
				floatVal = System.Convert.ToSingle(doubleVal);
				System.Console.WriteLine("{0} as a float is {1}",
					doubleVal, floatVal);

			// Conversion from float to double cannot overflow.
			doubleVal = System.Convert.ToDouble(floatVal);
			System.Console.WriteLine("{0} as a double is: {1}",
				floatVal, doubleVal);
		}
		//</Snippet6>
		
		//<Snippet7>
		public void ConvertDoubleString(double doubleVal) {
			
			string	stringVal;     

			// A conversion from Double to string cannot overflow.       
			stringVal = System.Convert.ToString(doubleVal);
			System.Console.WriteLine("{0} as a string is: {1}",
				doubleVal, stringVal);

			try {
				doubleVal = System.Convert.ToDouble(stringVal);
				System.Console.WriteLine("{0} as a double is: {1}",
					stringVal, doubleVal);
			} 
			catch (System.OverflowException) {
				System.Console.WriteLine(
					"Conversion from string-to-double overflowed.");
			}
			catch (System.FormatException) {
				System.Console.WriteLine(
					"The string was not formatted as a double.");
			}
			catch (System.ArgumentException) {
				System.Console.WriteLine(
					"The string pointed to null.");
			}
		}
		//</Snippet7>

		//<Snippet8>
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
		//</Snippet8>

		//<Snippet9>
		public void ConvertLongByte(long longVal) {

			byte	byteVal = 0;

			// A conversion from Long to byte can overflow.
			try {
				byteVal = System.Convert.ToByte(longVal);
				System.Console.WriteLine("{0} as a byte is {1}",
					longVal, byteVal);
			} 
			catch (System.OverflowException) {
				System.Console.WriteLine(
					"Overflow in long-to-byte conversion.");
			}
			
			// A conversion from Byte to long cannot overflow.
			longVal = System.Convert.ToInt64(byteVal);
			System.Console.WriteLine("{0} as an Int64 is {1}",
				byteVal, longVal);
		}
		//</Snippet9>

		//<Snippet10>
		public void ConvertLongDecimal(long longVal) {

			decimal	decimalVal;
			
			// Long to decimal conversion cannot overflow.
			decimalVal = System.Convert.ToDecimal(longVal);
			System.Console.WriteLine("{0} as a decimal is {1}", 
					longVal, decimalVal);

			// Decimal to long conversion can overflow.
			try {
				longVal = System.Convert.ToInt64(decimalVal);
				System.Console.WriteLine("{0} as a long is {1}", 
					decimalVal, longVal);
			}
			catch (System.OverflowException) {
				System.Console.WriteLine(
					"Overflow in decimal-to-long conversion.");
			}
		}
		//</Snippet10>

		//<Snippet11>
		public void ConvertLongFloat(long longVal) {

			float	floatVal;
			
			// A conversion from Long to float cannot overflow.
			floatVal = System.Convert.ToSingle(longVal);
			System.Console.WriteLine("{0} as a float is {1}", 
					longVal, floatVal);
			
			// A conversion from float to long can overflow.
			try {
				longVal = System.Convert.ToInt64(floatVal);
				System.Console.WriteLine("{0} as a long is {1}", 
					floatVal, longVal);
			}
			catch (System.OverflowException) {
				System.Console.WriteLine(
					"Overflow in float-to-long conversion.");
			}
		}
		//</Snippet11>

		//<Snippet12>
		public void ConvertStringBoolean(string stringVal) {
			
			bool boolVal = false;

			try {
				boolVal = System.Convert.ToBoolean(stringVal);
				if (boolVal) {
					System.Console.WriteLine(
						"String was equal to System.Boolean.TrueString.");
				}
				else {
					System.Console.WriteLine(
						"String was equal to System.Boolean.FalseString.");
				}
			}
			catch (System.FormatException){
				System.Console.WriteLine(
					"The string must equal System.Boolean.TrueString " +
					"or System.Boolean.FalseString.");
			}

			// A conversion from bool to string will always succeed.
			stringVal = System.Convert.ToString(boolVal);
			System.Console.WriteLine("{0} as a string is {1}",
				boolVal, stringVal);
		}
		//</Snippet12>

		//<Snippet13>
		public void ConvertStringByte(string stringVal) {
			byte byteVal = 0;
			
			try {
				byteVal = System.Convert.ToByte(stringVal);
				System.Console.WriteLine("{0} as a byte is: {1}",
					stringVal, byteVal);
			} 
			catch (System.OverflowException) {
				System.Console.WriteLine(
					"Conversion from string to byte overflowed.");
			}
			catch (System.FormatException) {
				System.Console.WriteLine(
					"The string is not formatted as a byte.");
			}
			catch (System.ArgumentNullException) {
				System.Console.WriteLine(
					"The string is null.");
			}
            
			//The conversion from byte to string is always valid.
			stringVal = System.Convert.ToString(byteVal);
			System.Console.WriteLine("{0} as a string is {1}",
				byteVal, stringVal);
		}
		//</Snippet13>
		
		//<Snippet14>
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
		//</Snippet14>
		
		//<Snippet15>
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
		//</Snippet15>

		//<Snippet16>
		public void ConvertStringFloat(string stringVal) {
			float floatVal = 0;
			
			try {
				floatVal = System.Convert.ToSingle(stringVal);
				System.Console.WriteLine(
					"The string as a float is {0}.", floatVal);
			} 
			catch (System.OverflowException){
				System.Console.WriteLine(
					"The conversion from string-to-float overflowed.");
			}
			catch (System.FormatException) {
				System.Console.WriteLine(
					"The string is not formatted as a float.");
			}
			catch (System.ArgumentNullException) {
				System.Console.WriteLine(
					"The string is null.");
			}

			// Float to string conversion will not overflow.
			stringVal = System.Convert.ToString(floatVal);
			System.Console.WriteLine(
				"The float as a string is {0}.", stringVal);
		}
		//</Snippet16>

		//<Snippet17>
		public void ConvertCharDecimal(char charVal) {
			Decimal decimalVal = 0;
			
			// Char to decimal conversion is not supported and will always
			// throw an InvalidCastException.
			try {
				decimalVal = System.Convert.ToDecimal(charVal);
			} 
			catch (System.InvalidCastException) {
				System.Console.WriteLine(
					"Char-to-Decimal conversion is not supported " +
					"by the .NET Framework.");
			}

			//Decimal to char conversion is also not supported.
			try {
				charVal = System.Convert.ToChar(decimalVal);
			} 
			catch (System.InvalidCastException) {
				System.Console.WriteLine(
					"Decimal-to-Char conversion is not supported " +
					"by the .NET Framework.");
			}
		}
		//</Snippet17>

		//<Snippet18>
		public void ConvertByteDecimal(byte byteVal) {
			decimal decimalVal;

			// Byte to decimal conversion will not overflow.
			decimalVal = System.Convert.ToDecimal(byteVal);
			System.Console.WriteLine("The byte as a decimal is {0}.",
				decimalVal);

			// Decimal to byte conversion can overflow.
			try {
				byteVal = System.Convert.ToByte(decimalVal);
				System.Console.WriteLine("The Decimal as a byte is {0}.",
					byteVal);
			}
			catch (System.OverflowException) {
				System.Console.WriteLine(
					"The decimal value is too large for a byte.");
			}
		}
		//</Snippet18>

		//<Snippet19>
		public void ConvertByteSingle(byte byteVal) {
			float floatVal;

			// Byte to float conversion will not overflow.
			floatVal = System.Convert.ToSingle(byteVal);
			System.Console.WriteLine("The byte as a float is {0}.",
				floatVal);

			// Float to byte conversion can overflow.
			try {
				byteVal = System.Convert.ToByte(floatVal);
				System.Console.WriteLine("The float as a byte is {0}.",
					byteVal);
			}
			catch (System.OverflowException) {
				System.Console.WriteLine(
					"The float value is too large for a byte.");
			}
		}
		//</Snippet19>

		//<Snippet20>
		public void ConvertBoolean() {
			const int year			= 1979;
			const int month			= 7;   
			const int day			= 28;
			const int hour			= 13;
			const int minute		= 26;
			const int second		= 15;
			const int millisecond	= 53;

			DateTime dateTime = new DateTime(year, month, day, hour,
										minute, second, millisecond);
			
			bool boolVal;

			// System.InvalidCastException is always thrown.
			try {
				boolVal = System.Convert.ToBoolean(dateTime);
			}
			catch (System.InvalidCastException) {
				System.Console.WriteLine("Conversion from DateTime to " +
					"Boolean is not supported by the .NET Framework.");
			}
		}
		//</Snippet20>
	}
}
