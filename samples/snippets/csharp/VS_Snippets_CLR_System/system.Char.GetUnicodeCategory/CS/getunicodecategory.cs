// <snippet1>
using System;

public class GetUnicodeCategorySample {
	public static void Main() {
		char ch2 = '2';
		string str = "Upper Case";

		Console.WriteLine(Char.GetUnicodeCategory('a'));		// Output: "LowercaseLetter"
		Console.WriteLine(Char.GetUnicodeCategory(ch2));		// Output: "DecimalDigitNumber"
		Console.WriteLine(Char.GetUnicodeCategory(str, 6));		// Output: "UppercaseLetter"
	}
}
// </snippet1>
