// <Snippet1>
using System;
using System.IO;

class Test 
{
    public static void Main() 
    {
        string path = @"c:\temp\MyTest.txt";
        string path2 = @"c:\temp2\MyTest.txt";
        try 
        {
            if (!File.Exists(path)) 
            {
                // This statement ensures that the file is created,
                // but the handle is not kept.
                using (FileStream fs = File.Create(path)) {}
            }

            // Ensure that the target does not exist.
            if (File.Exists(path2))	
            File.Delete(path2);

            // Move the file.
            File.Move(path, path2);
            Console.WriteLine("{0} was moved to {1}.", path, path2);

            // See if the original exists now.
            if (File.Exists(path)) 
            {
                Console.WriteLine("The original file still exists, which is unexpected.");
            } 
            else 
            {
                Console.WriteLine("The original file no longer exists, which is expected.");
            }			

        } 
        catch (Exception e) 
        {
            Console.WriteLine("The process failed: {0}", e.ToString());
        }
    }
}
// </Snippet1>
