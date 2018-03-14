// <Snippet1>
using System;
using System.Runtime.InteropServices;

public class Example
{
   [DllImport("user32.dll")]
   public static extern int GetMyNumber();
   
   public static void Main()
   {
      try {
         int number = GetMyNumber();
      }
      catch (EntryPointNotFoundException e) {
         Console.WriteLine("{0}:\n   {1}", e.GetType().Name,  
                           e.Message);
      } 
   }
}
// The example displays the following output:
//    EntryPointNotFoundException:
//       Unable to find an entry point named 'GetMyNumber' in DLL 'User32.dll'.
// </Snippet1>
