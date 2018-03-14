// <Snippet1>
using System;
using System.IO;

class Test 
{
    public static void Main() 
    {
        try 
        {
            // Only get files that begin with the letter "c."
            string[] dirs = Directory.GetFiles(@"c:\", "c*");
            Console.WriteLine("The number of files starting with c is {0}.", dirs.Length);
            foreach (string dir in dirs) 
            {
                Console.WriteLine(dir);
            }
        } 
        catch (Exception e) 
        {
            Console.WriteLine("The process failed: {0}", e.ToString());
        }
    }
}
// </Snippet1>