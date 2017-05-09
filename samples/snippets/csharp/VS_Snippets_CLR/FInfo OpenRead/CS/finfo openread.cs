// <Snippet1>
using System;
using System.IO;
using System.Text;

class Test 
{
	
    public static void Main() 
    {
        string path = @"c:\MyTest.txt";
        FileInfo fi = new FileInfo(path);

        // Delete the file if it exists.
        if (!fi.Exists) 
        {
            //Create the file.
            using (FileStream fs = fi.Create()) 
            {
                Byte[] info = new UTF8Encoding(true).GetBytes("This is some text in the file.");
                //Add some information to the file.
                fs.Write(info, 0, info.Length);
            }
        }

        //Open the stream and read it back.
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
//This is some text in the file.
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
//
// </Snippet1>
