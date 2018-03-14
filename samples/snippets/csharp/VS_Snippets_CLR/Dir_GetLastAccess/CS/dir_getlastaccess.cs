// <Snippet1>
using System;
using System.IO;

class Test 
{
    public static void Main() 
    {
        try 
        {
            string path = @"c:\MyDir";
            if (!Directory.Exists(path)) 
            {
                Directory.CreateDirectory(path);
            }
            Directory.SetLastAccessTime(path, new DateTime(1985,5,4));

            // Get the creation time of a well-known directory.
            DateTime dt = Directory.GetLastAccessTime(path);
            Console.WriteLine("The last access time for this directory was {0}", dt);
			
            // Update the last access time.
            Directory.SetLastAccessTime(path, DateTime.Now);
            dt = Directory.GetLastAccessTime(path);
            Console.WriteLine("The last access time for this directory was {0}", dt);
        } 

        catch (Exception e) 
        {
            Console.WriteLine("The process failed: {0}", e.ToString());
        }
    }
}
// </Snippet1>