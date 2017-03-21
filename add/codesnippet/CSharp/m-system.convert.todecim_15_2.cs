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