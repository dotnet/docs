// <Snippet2>
using System;
using System.IO;

public class Example
{
   public static void Main()
   {
      Char[] buffer = new Char[50];
      StreamReader s = null;
      try {
         s = new StreamReader("File1.txt"); 
         int charsRead = 0;
         while (s.Peek() != -1) {
            charsRead = s.Read(buffer, 0, buffer.Length);
            //
            // Process characters read.
            //   
         }
         s.Close();    
      }
      finally {
         // If non-null, call the object's Dispose method.
         if (s != null)
            s.Dispose();
      }
   }
}
// </Snippet2>
