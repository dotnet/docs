// <snippet9>
using System;

public class IsPunctuationSample {
	public static void Main() {
		char ch = '.';

		Console.WriteLine(Char.IsPunctuation(ch));						// Output: "True"
		Console.WriteLine(Char.IsPunctuation("no punctuation", 3));		// Output: "False"
	}
}
// </snippet9>
