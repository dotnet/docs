// <snippet19>
using System;

public class CompareToSample {
	public static void Main() {
		char chA = 'A';
		char chB = 'B';

		Console.WriteLine(chA.CompareTo('A'));	// Output: "0" (meaning they're equal)
		Console.WriteLine('b'.CompareTo(chB));	// Output: "32" (meaning 'b' is greater than 'B' by 32)
		Console.WriteLine(chA.CompareTo(chB));	// Output: "-1" (meaning 'A' is less than 'B' by 1)
	}
}
// </snippet19>
