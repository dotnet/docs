// <Snippet1>
using System;
using System.IO;

public class Example
{
   public static void Main()
   {
      // Get all files in the current directory.
      string[] files = Directory.GetFiles(".");
      Array.Sort(files);
      
      // Display the files to the current output source to the console.
      Console.WriteLine("First display of filenames to the console:");
      Array.ForEach(files, s => Console.Out.WriteLine(s));   
      Console.Out.WriteLine();

      // Redirect output to a file named Files.txt and write file list.
      StreamWriter sw = new StreamWriter(@".\Files.txt");
      sw.AutoFlush = true;
      Console.SetOut(sw);
      Console.Out.WriteLine("Display filenames to a file:");
      Array.ForEach(files, s => Console.Out.WriteLine(s));   
      Console.Out.WriteLine();

      // Close previous output stream and redirect output to standard output.
      Console.Out.Close();
      sw = new StreamWriter(Console.OpenStandardOutput());
      sw.AutoFlush = true;
      Console.SetOut(sw);
           
      // Display the files to the current output source to the console.
      Console.Out.WriteLine("Second display of filenames to the console:");
      Array.ForEach(files, s => Console.Out.WriteLine(s));   
   }   
}
// </Snippet1>
