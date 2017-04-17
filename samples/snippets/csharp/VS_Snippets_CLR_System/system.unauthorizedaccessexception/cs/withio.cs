// <Snippet1>
using System;
using System.IO;

public class Example
{
   public static void Main()
   {
      string filePath = @".\ROFile.txt";
      if (! File.Exists(filePath))
         File.Create(filePath);
      // Keep existing attributes, and set ReadOnly attribute.
      File.SetAttributes(filePath, 
                        (new FileInfo(filePath)).Attributes | FileAttributes.ReadOnly);

      StreamWriter sw = null;
      try {
         sw = new StreamWriter(filePath);
         sw.Write("Test");
      }
      catch (UnauthorizedAccessException) {
         FileAttributes attr = (new FileInfo(filePath)).Attributes;
         Console.Write("UnAuthorizedAccessException: Unable to access file. ");
         if ((attr & FileAttributes.ReadOnly) > 0)
            Console.Write("The file is read-only."); 
       }
       finally {
         if (sw != null) sw.Close();
      }   
   }
}
// The example displays the following output:
//    UnAuthorizedAccessException: Unable to access file. The file is read-only.
// </Snippet1>
