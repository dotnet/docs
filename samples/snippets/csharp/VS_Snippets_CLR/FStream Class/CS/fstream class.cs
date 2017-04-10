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
            AddText(fs, "This is some text");
            AddText(fs, "This is some more text,");
            AddText(fs, "\r\nand this is on a new line");
            AddText(fs, "\r\n\r\nThe following is a subset of characters:\r\n");

            for (int i=1;i < 120;i++)
            {
                AddText(fs, Convert.ToChar(i).ToString());

            }
        }

        //Open the stream and read it back.
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

    private static void AddText(FileStream fs, string value)
    {
        byte[] info = new UTF8Encoding(true).GetBytes(value);
        fs.Write(info, 0, info.Length);
    }
}
// </Snippet1>
