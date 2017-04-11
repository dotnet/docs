// <snippet1>
using System;
using System.IO;

public class AppendTextTest 
{
    public static void Main() 
    {
        FileInfo fi = new FileInfo("temp.txt");
        // Create a writer, ready to add entries to the file.
        StreamWriter sw = fi.AppendText();
        sw.WriteLine("Add as many lines as you like...");
        sw.WriteLine("Add another line to the output...");
        sw.Flush();
        sw.Close();
        // Get the information out of the file and display it.
        // Remember that the file might have other lines if it already existed.
        StreamReader sr = new StreamReader(fi.OpenRead());
        while (sr.Peek() != -1)
            Console.WriteLine( sr.ReadLine() );
    }
}
//This code produces output similar to the following; 
//results may vary based on the computer/file structure/etc.:
//Add as many lines as you like...
//Add another line to the output...
// </snippet1>