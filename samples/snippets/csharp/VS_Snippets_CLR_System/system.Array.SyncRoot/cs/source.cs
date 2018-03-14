using System;

public class Example
{
    public static void Main()
    {
//<Snippet1>
        Array myArray = new int[] { 1, 2, 4 };
        lock(myArray.SyncRoot) 
        {
            foreach (Object item in myArray)
                Console.WriteLine(item);
        }
//</Snippet1>
    }
}