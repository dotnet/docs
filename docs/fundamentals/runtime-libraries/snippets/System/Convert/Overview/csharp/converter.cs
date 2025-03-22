using System;

namespace ConvertSnippet		
{
	//This class is the snippet for the class System.Convert
	class Converter
	{
		static void Main(string[] args)
		{
			// <Snippet1>
			double dNumber = 23.15;

			try {
				// Returns 23
				int    iNumber = System.Convert.ToInt32(dNumber);
			}
			catch (System.OverflowException) {
				System.Console.WriteLine(
							"Overflow in double to int conversion.");
			}
			// Returns True
			bool   bNumber = System.Convert.ToBoolean(dNumber);
			
			// Returns "23.15"
			string strNumber = System.Convert.ToString(dNumber);

			try {
				// Returns '2'
				char chrNumber = System.Convert.ToChar(strNumber[0]);
			}
			catch (System.ArgumentNullException) {
				System.Console.WriteLine("String is null");
			}
			catch (System.FormatException) {
				System.Console.WriteLine("String length is greater than 1.");
			}

			// System.Console.ReadLine() returns a string and it
			// must be converted.
			int newInteger = 0;
			try {
				System.Console.WriteLine("Enter an integer:");
				newInteger = System.Convert.ToInt32(
									System.Console.ReadLine());
			}
			catch (System.ArgumentNullException) {
				System.Console.WriteLine("String is null.");
			}
			catch (System.FormatException) {
				System.Console.WriteLine("String does not consist of an " +
								"optional sign followed by a series of digits.");
			}
			catch (System.OverflowException) {
				System.Console.WriteLine(
				"Overflow in string to int conversion.");
			}

			System.Console.WriteLine($"Your integer as a double is {System.Convert.ToDouble(newInteger)}");
			//</Snippet1>
		}
	}
}
