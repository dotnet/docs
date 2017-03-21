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