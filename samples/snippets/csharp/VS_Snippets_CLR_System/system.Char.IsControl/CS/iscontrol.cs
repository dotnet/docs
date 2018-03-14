// <snippet3>
using System;

public class IsControlSample {
	public static void Main() {
		string str = "sample string";

		Console.WriteLine(Char.IsControl('\t'));	// Output: "True"
		Console.WriteLine(Char.IsControl(str, 7));	// Output: "False"
	}
}
// </snippet3>
