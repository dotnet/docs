// <Snippet1>
using System;
using System.IO;

class Test
{

    public static void Main()
    {
        string path = @"c:\SoureFile.txt";
        string path2 = @"c:\NewFile.txt";
        FileInfo fi1 = new FileInfo(path);
        FileInfo fi2 = new FileInfo(path2);

        try
        {
            // Create the source file.
            using (FileStream fs = fi1.Create()) { }

            //Ensure that the target file does not exist.
            if (File.Exists(path2))
            {
                fi2.Delete();
            }

            //Copy the file.f
            fi1.CopyTo(path2);
            Console.WriteLine("{0} was copied to {1}.", path, path2);
        }
        catch (IOException ioex)
        {
            Console.WriteLine(ioex.Message);
        }
    }
}
// </Snippet1>