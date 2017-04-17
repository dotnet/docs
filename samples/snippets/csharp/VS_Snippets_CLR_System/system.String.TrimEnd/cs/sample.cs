//<snippet1>
using System;


namespace String_Example
{
    class Application
    {
        public static void Main()
        {
            // Create a string that will be trimmed.
            string path = "c:/temp//";

            // Create an array of characters 
            // that represent characters to trim.
            char[] charsToTrim = {'/'};

            // Thim the string.
            string trimmedPath = path.TrimEnd(charsToTrim);

            Console.WriteLine("The trimmed value is: {0}.", trimmedPath);

            // Create a string that will be trimmed.
            string pathWhitespace = "c:/temp/  ";

            // Trim whitespaces by passing null.
            string trimmedWhiteSpace = pathWhitespace.TrimEnd(null);

            Console.WriteLine("The trimmed value is: {0}.", trimmedWhiteSpace);
        }

    }
}
// This code example displays the following
// to the console:
//
// The trimmed value is: c:/temp.
// The trimmed value is: c:/temp/.
//</snippet1>