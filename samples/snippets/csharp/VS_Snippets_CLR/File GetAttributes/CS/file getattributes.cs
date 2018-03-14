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
            File.Create(path);
        }

        FileAttributes attributes = File.GetAttributes(path);

        if ((attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
        {
            // Show the file.
            attributes = RemoveAttribute(attributes, FileAttributes.Hidden);
            File.SetAttributes(path, attributes);
            Console.WriteLine("The {0} file is no longer hidden.", path);
        } 
        else 
        {
            // Hide the file.
            File.SetAttributes(path, File.GetAttributes(path) | FileAttributes.Hidden);
            Console.WriteLine("The {0} file is now hidden.", path);
        }
    }

    private static FileAttributes RemoveAttribute(FileAttributes attributes, FileAttributes attributesToRemove)
    {
        return attributes & ~attributesToRemove;
    }
}
// </Snippet1>
