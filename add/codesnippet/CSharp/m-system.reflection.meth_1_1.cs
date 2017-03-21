// Define a class with a generic method.
public class Example
{
    public static void Generic<T>(T toDisplay)
    {
        Console.WriteLine("\r\nHere it is: {0}", toDisplay);
    }
}