// <Snippet1>
using System;
using System.IO;
using System.Text;

class Test 
{
    public static void Main() 
    {
        string path = @"c:\Temp\MyTest.txt";
        FileInfo fi = new FileInfo(path);

        // Open the stream for writing.
        using (FileStream fs = fi.OpenWrite()) 
        {
            Byte[] info = 
                new UTF8Encoding(true).GetBytes("This is to test the OpenWrite method.");

            // Add some information to the file.
            fs.Write(info, 0, info.Length);
        }

        // Open the stream and read it back.
        using (FileStream fs = fi.OpenRead()) 
        {
            byte[] b = new byte[1024];
            UTF8Encoding temp = new UTF8Encoding(true);

            while (fs.Read(b,0,b.Length) > 0) 
            {
                Console.WriteLine(temp.GetString(b));
            }
        }
    }
}
//This code produces output similar to the following; 
//results may vary based on the computer/file structure/etc.:
//
//This is to test the OpenWrite method.
//
//
//
//
//
//
//
//
//
//
//
// </Snippet1>
