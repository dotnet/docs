// <snippet11>
using System;

public class IsSurrogateSample {
	public static void Main() {
		string str = "\U00010F00"; // Unicode values between 0x10000 and 0x10FFF are represented by two 16-bit "surrogate" characters

		Console.WriteLine(Char.IsSurrogate('a'));		// Output: "False"
		Console.WriteLine(Char.IsSurrogate(str, 0));	// Output: "True"
	}
}
// </snippet11>
