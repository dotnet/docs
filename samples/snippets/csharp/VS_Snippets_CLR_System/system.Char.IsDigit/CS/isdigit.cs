// <snippet4>
using System;

public class IsDigitSample {
	public static void Main() {
		char ch = '8';

		Console.WriteLine(Char.IsDigit(ch));					// Output: "True"
		Console.WriteLine(Char.IsDigit("sample string", 7));	// Output: "False"
	}
}
// </snippet4>
