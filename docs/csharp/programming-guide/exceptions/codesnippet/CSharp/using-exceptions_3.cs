using System;
using System.IO;

public class ExceptionExample
{
    static void Main()
    {
        try
        {
            using (var sw = new StreamWriter(@"C:\test\test.txt"))
            {
                sw.WriteLine("Hello");
            }   
        }
        // Put the more specific exceptions first.
        catch (DirectoryNotFoundException ex)
        {
            Console.WriteLine(ex);  
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine(ex);  
        }
        // Put the least specific exception last.
        catch (IOException ex)
        {
            Console.WriteLine(ex);  
        }

        Console.WriteLine("Done"); 
    }
}