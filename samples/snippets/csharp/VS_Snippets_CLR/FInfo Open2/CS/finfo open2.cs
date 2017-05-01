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
        using (FileStream fs = fi.Open(FileMode.Open, FileAccess.Read)) 
        {
            byte[] b = new byte[1024];
            UTF8Encoding temp = new UTF8Encoding(true);
            while (fs.Read(b,0,b.Length) > 0) 
            {
                Console.WriteLine(temp.GetString(b));
            }

            try 
            {
                //Try to write to the file.
                fs.Write(b,0,b.Length);
            } 
            catch (Exception e) 
            {
                Console.WriteLine("Writing was disallowed, as expected: {0}",
                    e.ToString());
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
//Writing was disallowed, as expected: System.NotSupportedException: Stream does 
//not support writing.
//   at System.IO.__Error.WriteNotSupported()
//   at System.IO.FileStream.Write(Byte[] array, Int32 offset, Int32 count)
//   at Test.Main() in C:\Documents and Settings\My Computer\My Documents\
//Visual Studio 2005\Projects\finfo open2\finfo open2\Program.cs:line 39

// </Snippet1>
