using System;

namespace OpOverloads
{
	class Class1
	{
		static void Main(string[] args)
		{
			// Addition operator
			// <Snippet1>
			System.DateTime dTime = new System.DateTime(1980, 8, 5);

			// tSpan is 17 days, 4 hours, 2 minutes and 1 second.
			System.TimeSpan tSpan 
				= new System.TimeSpan(17, 4, 2, 1); 

			// Result gets 8/22/1980 4:02:01 AM.
			System.DateTime result = dTime + tSpan;
			// </Snippet1>			

			System.Console.WriteLine(result);

			// Equality operator.
			// <Snippet2>
			System.DateTime april19 = new DateTime(2001, 4, 19);
			System.DateTime otherDate = new DateTime(1991, 6, 5);

			// areEqual gets false.
			bool areEqual = april19 == otherDate;
				
			otherDate = new DateTime(2001, 4, 19);
			// areEqual gets true.
			areEqual = april19 == otherDate;
			// </Snippet2>
		}
	}
}
