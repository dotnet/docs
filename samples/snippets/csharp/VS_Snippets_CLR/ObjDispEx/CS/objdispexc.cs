//<Snippet1>
using System;
using System.IO;

public class ObjectDisposedExceptionTest 
{
   public static void Main()
   {     
      MemoryStream ms = new MemoryStream(16);
      ms.Close();
      try 
      {
         ms.ReadByte();
      } 
      catch (ObjectDisposedException e) 
      {
         Console.WriteLine("Caught: {0}", e.Message);
      }
   }
}
//</Snippet1>