# How to explicitly throw exceptions

You can explicitly throw an exception using the **throw** statement. You can also throw a caught exception again using the **throw** statement. It is good coding practice to add information to an exception that is re-thrown to provide more information when debugging.

The following code example uses a **try**/**catch** block to catch a possible [FileNotFoundException](http://dotnet.github.io/api/System.IO.FileNotFoundException.html). Following the **try** block is a **catch** block that catches the **FileNotFoundException** and writes a message to the console if the data file is not found. The next statement is the **throw** statement that throws a new **FileNotFoundException** and adds text information to the exception.

## Example

C#
```
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
```
