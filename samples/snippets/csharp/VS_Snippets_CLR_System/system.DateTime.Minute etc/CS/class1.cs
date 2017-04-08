using System;

namespace Minute_Etc
{
	class Class1
	{
		static void Main(string[] args)
		{
			// <Snippet1>
			System.DateTime moment = new System.DateTime(
											1999, 1, 13, 3, 57, 32, 11);
			// Year gets 1999.
			int year = moment.Year;
			
			// Month gets 1 (January).
			int month = moment.Month;
			
			// Day gets 13.
			int day = moment.Day;
			
			// Hour gets 3.
			int hour = moment.Hour;
			
			// Minute gets 57.
			int minute = moment.Minute;
			
			// Second gets 32.
			int second = moment.Second;
			
			// Millisecond gets 11.
			int millisecond = moment.Millisecond;
			// </Snippet1>
		}
	}
}
