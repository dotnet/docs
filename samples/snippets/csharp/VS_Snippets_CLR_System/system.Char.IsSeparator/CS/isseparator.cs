// <snippet10>
using System;

public class IsSeparatorSample {
	public static void Main() {
		string str = "twain1 twain2";

		Console.WriteLine(Char.IsSeparator('a'));		// Output: "False"
		Console.WriteLine(Char.IsSeparator(str, 6));	// Output: "True"
	}
}
// </snippet10>
