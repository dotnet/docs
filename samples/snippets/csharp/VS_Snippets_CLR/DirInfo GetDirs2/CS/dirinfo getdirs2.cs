// <Snippet1>
using System;
using System.IO;

class Test 
{
    public static void Main() 
    {
        try 
        {
            DirectoryInfo di = new DirectoryInfo(@"c:\");

            // Get only subdirectories that contain the letter "p."
            DirectoryInfo[] dirs = di.GetDirectories("*p*");
            Console.WriteLine("The number of directories containing the letter p is {0}.", dirs.Length);

            foreach (DirectoryInfo diNext in dirs) 
            {
                Console.WriteLine("The number of files in {0} is {1}", diNext, 
                    diNext.GetFiles().Length);
            }
        } 
        catch (Exception e) 
        {
            Console.WriteLine("The process failed: {0}", e.ToString());
        }
    }
}
// </Snippet1>
