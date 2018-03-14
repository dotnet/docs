// <snippet1>
using System;

public class GetNumericValueSample {
	public static void Main() {
		string str = "input: 1";

		Console.WriteLine(Char.GetNumericValue('8'));		// Output: "8"
		Console.WriteLine(Char.GetNumericValue(str, 7));	// Output: "1"
	}
}
// </snippet1>
