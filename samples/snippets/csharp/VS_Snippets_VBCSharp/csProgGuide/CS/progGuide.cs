//-----------------------------------------------------------------------------
//<Snippet21>
// A Hello World! program in C#.
using System;
namespace HelloWorld
{
    class Hello 
    {
        static void Main() 
        {
            Console.WriteLine("Hello World!");

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
//</Snippet21>

// 06-13-08 This was embedded in snippet21, but was not rendering correctly as a comment in the built html.
// Problem was possibly the quotes around Hello World. Removed quotes and un-embedded the snippet.
//<Snippet32>
// A Hello World! program in C#.
//</Snippet32>

//-----------------------------------------------------------------------------
//<Snippet33>
/* A "Hello World!" program in C#.
This program displays the string "Hello World!" on the screen. */
//</Snippet33>


//-----------------------------------------------------------------------------
class HelloAgain 
{
    static void Main() 
    {
		//<Snippet22>
        System.Console.WriteLine("Hello World!");
		//</Snippet22>

		//<Snippet23>
        Console.WriteLine("Hello World!");
		//</Snippet23>

		//<Snippet24>
        System.Console.WriteLine("Hello");
        System.Console.WriteLine("World!");
		//</Snippet24>

		//<Snippet25>
        Console.WriteLine("Hello");
        Console.WriteLine("World!");
		//</Snippet25>

		//<Snippet26>
        System.Console.WriteLine("Hello");
		//</Snippet26>

		//<Snippet27>
        Console.WriteLine("Hello");
		//</Snippet27>

		//<Snippet28>
        System.Console.WriteLine("World!");
		//</Snippet28>

		//<Snippet29>
        Console.WriteLine("World!");
		//</Snippet29>

		//<Snippet30>
        System.Console.WriteLine("Hello, World!");
		//</Snippet30>

		//<Snippet31>
        Console.WriteLine("Hello, World!");
		//</Snippet31>
    }
}
