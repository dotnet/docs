// <Snippet1>
using System;
using System.IO;

public class ViewTextFile
{
   public static void Main()
   {
      String[] args = Environment.GetCommandLineArgs();
      String errorOutput = "";
      // Make sure that there is at least one command line argument.
      if (args.Length <= 1)
         errorOutput += "You must include a filename on the command line.\n";

      for (int ctr = 1; ctr <= args.GetUpperBound(0); ctr++)  {
         // Check whether the file exists.
         if (! File.Exists(args[ctr])) {
            errorOutput += String.Format("'{0}' does not exist.\n", args[ctr]);
         }
         else {
            // Display the contents of the file.
            StreamReader sr = new StreamReader(args[ctr]);
            String contents = sr.ReadToEnd();
            sr.Close();
            Console.WriteLine("*****Contents of file '{0}':\n\n",
                              args[ctr]);
            Console.WriteLine(contents);
            Console.WriteLine("*****\n");
         }
      }

      // Check for error conditions.
      if (! String.IsNullOrEmpty(errorOutput)) {
         // Write error information to a file.
         Console.SetError(new StreamWriter(@".\ViewTextFile.Err.txt"));
         Console.Error.WriteLine(errorOutput);
         Console.Error.Close();
         // Reacquire the standard error stream.
         var standardError = new StreamWriter(Console.OpenStandardError());
         standardError.AutoFlush = true;
         Console.SetError(standardError);
         Console.Error.WriteLine("\nError information written to ViewTextFile.Err.txt");
      }
   }
}
// If the example is compiled and run with the following command line:
//     ViewTextFile file1.txt file2.txt
// and neither file1.txt nor file2.txt exist, it displays the
// following output:
//     Error information written to ViewTextFile.Err.txt
// and writes the following text to ViewFileText.Err.txt:
//     'file1.txt' does not exist.
//     'file2.txt' does not exist.
// </Snippet1>
