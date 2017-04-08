// <snippet1>
using System;
using System.IO;

public class FileInfoMainTest 
{
    public static void Main() 
    {
        // Open an existing file, or create a new one.
        FileInfo fi = new FileInfo("temp.txt");
        // Create a writer, ready to add entries to the file.
        StreamWriter sw = fi.AppendText();
        sw.WriteLine("This is a new entry to add to the file");
        sw.WriteLine("This is yet another line to add...");
        sw.Flush();
        sw.Close();
        // Get the information out of the file and display it.
        StreamReader sr = new StreamReader( fi.OpenRead() );
        while (sr.Peek() != -1)
            Console.WriteLine( sr.ReadLine() );
    }
}
//This code produces output similar to the following; 
//results may vary based on the computer/file structure/etc.:
//
//Add as many lines as you like...
//Add another line to the output...
//This is a new entry to add to the file
//This is yet another line to add...
// </snippet1>