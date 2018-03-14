// <Snippet1>
using System;
using System.IO;
using System.Text;

class Test 
{
    public static void Main() 
    {
        string path = @"c:\temp\MyTest.txt";

        // Create the file if it does not exist.
        if (!File.Exists(path)) 
        {
            // Create the file.
            using (FileStream fs = File.Create(path)) 
            {
                Byte[] info = new UTF8Encoding(true).GetBytes("This is some text in the file.");

                // Add some information to the file.
                fs.Write(info, 0, info.Length);
            }
        }

        // Open the stream and read it back.
        using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.None)) 
        {
            byte[] b = new byte[1024];
            UTF8Encoding temp = new UTF8Encoding(true);

            while (fs.Read(b,0,b.Length) > 0) 
            {
                Console.WriteLine(temp.GetString(b));
            }

            try 
            {
                // Try to get another handle to the same file.
                using (FileStream fs2 = File.Open(path, FileMode.Open)) 
                {
                    // Do some task here.
                }
            } 
            catch (Exception e) 
            {
                Console.Write("Opening the file twice is disallowed.");
                Console.WriteLine(", as expected: {0}", e.ToString());
            }
        }
    }
}
// </Snippet1>
