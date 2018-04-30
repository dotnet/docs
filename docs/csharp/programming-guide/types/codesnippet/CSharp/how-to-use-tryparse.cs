// This is one example of a time where you may need to parse a string into a number, since user input will be a string.

// Example using Parse
Console.Write("Enter a number: "); // Prompt the user to enter a number, which will be in the form of a string

var input = Console.ReadLine();    // Read the line and store the string value in a variable, input

var result = int.Parse(input);     // Parse the result into an integer

// But what if the input is not a proper string?
// For example:

string input = null;              // What would happen if the string you are trying to parse to an int is null?

var result = int.Parse(input);    // This will throw an ArgumentNullException

// ---------------------------------------------

string input = "99.999";          // Or what if the value is "99.999"?

var result = int.Parse(input);    // This will throw a FormatException


// A solution? Use TryParse

Console.Write("Enter a number: ");  // Prompt the user to enter a number, which will be in the form of a string

var input = Console.ReadLine();     // Read the line and store the string value in a variable, input

var success = int.TryParse(input, out int result);  // Try to parse the string into an int, which will output 2 variables - success, which is a boolean and 
													// will tell you whether or not the parse succeeded or failed, and result (which you are declaring in the TryParse method) 
													// which will hold the string converted to integer, given a success, or 0 given a failure

if(success)											// Check if the string was successfully parsed into an int, and do something with it after
	Console.WriteLine("Success! {0} was successfully converted!", result);
else
	Console.WriteLine("Uh oh, the conversion was not successful.");
