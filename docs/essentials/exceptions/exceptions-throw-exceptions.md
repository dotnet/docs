# How to explicitly throw exceptions

You can explicitly throw an exception using the **throw** statement. You can also throw a caught exception again using the **throw** statement. It is good coding practice to add information to an exception that is re-thrown to provide more information when debugging.

The following code example uses a try/catch block to catch a possible [FileNotFoundException](https://msdn.microsoft.com/library/system.io.filenotfoundexception). Following the try block is a catch block that catches the** FileNotFoundException** and writes a message to the console if the data file is not found. The next statement is the throw statement that throws a new **FileNotFoundException** and adds text information to the exception.

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

Visual Basic
```
Option Strict On

Imports System
Imports System.IO

Public Class ProcessFile

   Public Shared Sub Main()
      Dim fs As FileStream = Nothing
      Try
          'Opens a text file.
          fs = New FileStream("c:\temp\data.txt", FileMode.Open)
          Dim sr As New StreamReader(fs)
          Dim line As String

          'A value is read from the file and output to the console.
          line = sr.ReadLine()
          Console.WriteLine(line)
      Catch e As FileNotFoundException
          Console.WriteLine("[Data File Missing] {0}", e)
          Throw New FileNotFoundException("[data.txt not in c:\temp directory]", e)
      Finally
          If fs IsNot Nothing Then fs.Close
      End Try
   End Sub
End Class
```
