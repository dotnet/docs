// <Snippet1>
using System;
using System.IO;

public class Example
{
   public static void Main()
   {
      Char[] buffer = new Char[50];
      using (StreamReader s = new StreamReader("File1.txt")) {
         int charsRead = 0;
         while (s.Peek() != -1) {
            charsRead = s.Read(buffer, 0, buffer.Length);
            //
            // Process characters read.
            //   
         }
         s.Close();    
      }

   }
}
// </Snippet1>
