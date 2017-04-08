using System;

namespace Equals
{
	class Class1
	{
		static void Main(string[] args)
		{
			// <Snippet1>
			System.DateTime today1 = 
					new System.DateTime(System.DateTime.Today.Ticks);
			System.DateTime today2 = 
					new System.DateTime(System.DateTime.Today.Ticks);
			System.DateTime tomorrow = 
					new System.DateTime(
								System.DateTime.Today.AddDays(1).Ticks);

			// todayEqualsToday gets true.
			bool todayEqualsToday = System.DateTime.Equals(today1, today2);

			// todayEqualsTomorrow gets false.
			bool todayEqualsTomorrow = System.DateTime.Equals(today1, tomorrow);
			// </Snippet1>

			System.Console.WriteLine(todayEqualsToday);
			System.Console.WriteLine(todayEqualsTomorrow);
		}
	}
}
