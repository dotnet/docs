// <Snippet1>
using System;
using System.IO;

class Example
{
   static void Main()
   {
      var buffer = new char[50];
      using var streamReader = new StreamReader("file1.txt"));
      
      var charsRead = 0;
      while (streamReader.Peek() != -1)
      {
         charsRead = streamReader.Read(buffer, 0, buffer.Length);
         //
         // Process characters read.
         //
      }
   }
}
// </Snippet1>
