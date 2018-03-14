// <snippet14>
using System;

public class IsWhiteSpaceSample {
	public static void Main() {
		string str = "black matter"; 

		Console.WriteLine(Char.IsWhiteSpace('A'));		// Output: "False"
		Console.WriteLine(Char.IsWhiteSpace(str, 5));	// Output: "True"
	}
}
// </snippet14>
