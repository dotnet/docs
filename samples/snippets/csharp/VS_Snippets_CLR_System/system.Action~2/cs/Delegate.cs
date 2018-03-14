// <Snippet1>
using System;
using System.IO;

delegate void ConcatStrings(string string1, string string2);

public class TestDelegate
{
   public static void Main()
   {
      string message1 = "The first line of a message.";
      string message2 = "The second line of a message.";
      ConcatStrings concat;
      
      if (Environment.GetCommandLineArgs().Length > 1)
         concat = WriteToFile;
      else
         concat = WriteToConsole;
         
      concat(message1, message2);
   }
  
   private static void WriteToConsole(string string1, string string2)
   {
      Console.WriteLine("{0}\n{1}", string1, string2);            
   }

   private static void WriteToFile(string string1, string string2)
   {
      StreamWriter writer = null;  
      try
      {
         writer = new StreamWriter(Environment.GetCommandLineArgs()[1], false);
         writer.WriteLine("{0}\n{1}", string1, string2);
      }
      catch
      {
         Console.WriteLine("File write operation failed...");
      }
      finally
      {
         if (writer != null) writer.Close();
      }      
   }
}
// </Snippet1>
