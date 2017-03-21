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