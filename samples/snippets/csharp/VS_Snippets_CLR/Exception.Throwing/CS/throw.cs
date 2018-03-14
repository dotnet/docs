// <Snippet1>
using System;
using System.IO;

public class ProcessFile
{
   public static void Main()
      {
      FileStream fs = null;
      try   
      {
         //Opens a text tile.
         fs = new FileStream(@"C:\temp\data.txt", FileMode.Open);
         StreamReader sr = new StreamReader(fs);
         string line;
         
         //A value is read from the file and output to the console.
         line = sr.ReadLine();
         Console.WriteLine(line);
      }
      catch(FileNotFoundException e)
      {
         Console.WriteLine("[Data File Missing] {0}", e);
         throw new FileNotFoundException(@"[data.txt not in c:\temp directory]",e);
      }
      finally
      {
         if (fs != null) 
            fs.Close();
      }
   }
}
// </Snippet1>
