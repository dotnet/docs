// <Snippet4>
using System;
using System.IO;

public class Example
{
   public static void Main()
   {
      Char[] buffer1 = new Char[50], buffer2 = new Char[50];
      
      using (StreamReader version1 = new StreamReader("file1.txt"),
                          version2 = new StreamReader("file2.txt")) {
         int charsRead1, charsRead2 = 0;
         while (version1.Peek() != -1 && version2.Peek() != -1) {
            charsRead1 = version1.Read(buffer1, 0, buffer1.Length);
            charsRead2 = version2.Read(buffer2, 0, buffer2.Length);
            //
            // Process characters read.
            //
         }
         version1.Close();
         version2.Close();
      }
   }
}
// </Snippet4>
