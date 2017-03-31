// <snippet8>
using System;

public class IsNumberSample {
	public static void Main() {
		string str = "non-numeric";

		Console.WriteLine(Char.IsNumber('8'));		// Output: "True"
		Console.WriteLine(Char.IsNumber(str, 3));	// Output: "False"
	}
}
// </snippet8>
