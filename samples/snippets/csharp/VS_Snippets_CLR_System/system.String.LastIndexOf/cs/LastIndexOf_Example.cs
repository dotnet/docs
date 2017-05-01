// <Snippet1>
using System;
using System.IO;

public class TestLastIndexOf
{
   public static void Main()
   {
      string filename;
      
      filename = ExtractFilename(@"C:\temp\");
      Console.WriteLine("{0}", String.IsNullOrEmpty(filename) ? "<none>" : filename);
      
      filename = ExtractFilename(@"C:\temp\delegate.txt"); 
      Console.WriteLine("{0}", String.IsNullOrEmpty(filename) ? "<none>" : filename);

      filename = ExtractFilename("delegate.txt");      
      Console.WriteLine("{0}", String.IsNullOrEmpty(filename) ? "<none>" : filename);
      
      filename = ExtractFilename(@"C:\temp\notafile.txt");
      Console.WriteLine("{0}", String.IsNullOrEmpty(filename) ? "<none>" : filename);
   }

   public static string ExtractFilename(string filepath)
   {
      // If path ends with a "\", it's a path only so return String.Empty.
      if (filepath.Trim().EndsWith(@"\"))
         return String.Empty;
      
      // Determine where last backslash is.
      int position = filepath.LastIndexOf('\\');
      // If there is no backslash, assume that this is a filename.
      if (position == -1)
      {
         // Determine whether file exists in the current directory.
         if (File.Exists(Environment.CurrentDirectory + Path.DirectorySeparatorChar + filepath)) 
            return filepath;
         else
            return String.Empty;
      }
      else
      {
         // Determine whether file exists using filepath.
         if (File.Exists(filepath))
            // Return filename without file path.
            return filepath.Substring(position + 1);
         else
            return String.Empty;
      }
   }
}
// </Snippet1>
