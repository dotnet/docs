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