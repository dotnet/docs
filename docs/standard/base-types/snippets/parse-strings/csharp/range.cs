public class RangeExamples
{
    public static void Example1()
    {
        // <snippet1>
        string str = "Hello, World!";

        // Get the first 5 characters.
        string hello = str[..5];
        Console.WriteLine(hello);
        // Output: Hello

        // Get the last 6 characters.
        string world = str[^6..];
        Console.WriteLine(world);
        // Output: World!

        // Get characters from index 7 through 11 (exclusive of 12).
        string substr = str[7..12];
        Console.WriteLine(substr);
        // Output: World
        // </snippet1>
    }

    public static void Example2()
    {
        // <snippet2>
        string filePath = "C:\\Users\\user1\\bin\\fileA.cs";

        // Remove the last 3 characters (.cs extension).
        string trimmedPath = filePath[..^3];
        Console.WriteLine(trimmedPath);
        // Output: C:\Users\user1\bin\fileA
        // </snippet2>
    }
}
