// <Snippet1>
using System;
using System.IO;
using System.Text;

class Test 
{
    public static void Main() 
    {
        string path = @"c:\temp\MyTest.txt";

        // Open the stream and write to it.
        using (FileStream fs = File.OpenWrite(path)) 
        {
            Byte[] info = 
                new UTF8Encoding(true).GetBytes("This is to test the OpenWrite method.");

            // Add some information to the file.
            fs.Write(info, 0, info.Length);
        }

        // Open the stream and read it back.
        using (FileStream fs = File.OpenRead(path)) 
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
// </Snippet1>
