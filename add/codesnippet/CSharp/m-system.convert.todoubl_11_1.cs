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