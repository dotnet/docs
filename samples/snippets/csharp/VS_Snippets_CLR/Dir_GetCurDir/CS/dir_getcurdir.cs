// <Snippet1>
using System;
using System.IO;

class Test 
{
    public static void Main() 
    {
        try 
        {
            // Get the current directory.
            string path = Directory.GetCurrentDirectory();
            string target = @"c:\temp";
            Console.WriteLine("The current directory is {0}", path);
            if (!Directory.Exists(target)) 
            {
                Directory.CreateDirectory(target);
            }

            // Change the current directory.
            Environment.CurrentDirectory = (target);
            if (path.Equals(Directory.GetCurrentDirectory())) 
            {
                Console.WriteLine("You are in the temp directory.");
            } 
            else 
            {
                Console.WriteLine("You are not in the temp directory.");
            }
        } 
        catch (Exception e) 
        {
            Console.WriteLine("The process failed: {0}", e.ToString());
        }
    }
}
// </Snippet1>