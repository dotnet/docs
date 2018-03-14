// <Snippet1>
using System;
using System.IO;

class Test 
{
    public static void Main() 
    {
        // Specify the directory you want to manipulate.
        string path = @"c:\MyDir";

        try 
        {
            // Determine whether the directory exists.
            if (Directory.Exists(path)) 
            {
                Console.WriteLine("That path exists already.");
                return;
            }

            // Try to create the directory.
            DirectoryInfo di = Directory.CreateDirectory(path);
            Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));

            // Delete the directory.
            di.Delete();
            Console.WriteLine("The directory was deleted successfully.");
        } 
        catch (Exception e) 
        {
            Console.WriteLine("The process failed: {0}", e.ToString());
        } 
        finally {}
    }
}
// </Snippet1>