using System;
using System.Collections;
using System.IO;

public class Test
{
   // <Snippet10>
   const int initialTableCapacity = 100;
   Hashtable h;
   
   public void PopulateFileTable(string directory)
   {
      h = new Hashtable(initialTableCapacity, 
                        StringComparer.OrdinalIgnoreCase);
            
      foreach (string file in Directory.GetFiles(directory))
            h.Add(file, File.GetCreationTime(file));
   }
   
   public void PrintCreationTime(string targetFile)
   {
      Object dt = h[targetFile];
      if (dt != null)
      {
         Console.WriteLine("File {0} was created at time {1}.",
            targetFile, 
            (DateTime) dt);
      }
      else
      {
         Console.WriteLine("File {0} does not exist.", targetFile);
      }
   }
   // </Snippet10>
}
