// <snippet12>
using System;

public class IsSymbolSample {
	public static void Main() {
		string str = "non-symbolic characters"; 

		Console.WriteLine(Char.IsSymbol('+'));		// Output: "True"
		Console.WriteLine(Char.IsSymbol(str, 8));	// Output: "False"
	}
}
// </snippet12>
