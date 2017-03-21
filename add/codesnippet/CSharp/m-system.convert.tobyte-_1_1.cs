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