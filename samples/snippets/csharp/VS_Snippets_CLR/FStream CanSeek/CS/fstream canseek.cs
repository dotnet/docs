// <Snippet1>
using System;
using System.IO;
using System.Text;

class Test 
{
	
    public static void Main() 
    {
        string path = @"c:\temp\MyTest.txt";

        // Delete the file if it exists.
        if (File.Exists(path)) 
        {
            File.Delete(path);
        }

        //Create the file.
        using (FileStream fs = File.Create(path)) 
        {
            if (fs.CanSeek) 
            {
                Console.WriteLine("The stream connected to {0} is seekable.", path);
            } 
            else 
            {
                Console.WriteLine("The stream connected to {0} is not seekable.", path);
            }
        }
    }
}
// </Snippet1>
