// <Snippet1>
using System;
using System.IO;
using System.Text;

class Test 
{
	
    public static void Main() 
    {
        string path = @"c:\temp\MyTest.txt";

        // Ensure that the file is readonly.
        File.SetAttributes(path, File.GetAttributes(path) | FileAttributes.ReadOnly);

        //Create the file.
        using (FileStream fs = new FileStream (path, FileMode.OpenOrCreate, FileAccess.Read)) 
        {
            if (fs.CanWrite) 
            {
                Console.WriteLine("The stream for file {0} is writable.", path);
            } 
            else 
            {
                Console.WriteLine("The stream for file {0} is not writable.", path);
            }
        }
    }
}
// </Snippet1>
