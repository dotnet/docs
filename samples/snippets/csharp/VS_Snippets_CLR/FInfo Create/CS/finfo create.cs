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
        if (fi.Exists) 
        {
            fi.Delete();
        }

        //Create the file.
        using (FileStream fs = fi.Create()) 
        {
            Byte[] info = 
                new UTF8Encoding(true).GetBytes("This is some text in the file.");

            //Add some information to the file.
            fs.Write(info, 0, info.Length);
        }

        //Open the stream and read it back.
        using (StreamReader sr = fi.OpenText()) 
        {
            string s = "";
            while ((s = sr.ReadLine()) != null) 
            {
                Console.WriteLine(s);
            }
        }
    }
}
//This code produces output similar to the following; 
//results may vary based on the computer/file structure/etc.:
//
//This is some text in the file.
// </Snippet1>
