// <snippet7>
using System;

public class IsLowerSample {
	public static void Main() {
		char ch = 'a';

		Console.WriteLine(Char.IsLower(ch));				// Output: "True"
		Console.WriteLine(Char.IsLower("upperCase", 5));	// Output: "False"
	}
}
// </snippet7>
