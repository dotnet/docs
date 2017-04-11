// <Snippet1>
using System;
using System.IO;

class Test 
{
    public static void Main() 
    {
        try 
        {
            // Create an instance of StreamReader to read from a file.
            // The using statement also closes the StreamReader.
            using (StreamReader sr = new StreamReader("TestFile.txt")) 
            {
                string line;
                // Read and display lines from the file until the end of 
                // the file is reached.
                while ((line = sr.ReadLine()) != null) 
                {
                    Console.WriteLine(line);
                }
            }
        }
        catch (Exception e) 
        {
            // Let the user know what went wrong.
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }
    }
}
// </Snippet1>