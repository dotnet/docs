// <Snippet2>
using System;
using System.Runtime.InteropServices;

public class Example
{
   [DllImport("user32.dll", CharSet = CharSet.Unicode, ExactSpelling = true )]
   public static extern int MessageBox(IntPtr hwnd, String text, String caption, uint type);
 
   [DllImport("user32.dll", CharSet = CharSet.Unicode, ExactSpelling = true )]
   public static extern int MessageBoxW(IntPtr hwnd, String text, String caption, uint type);

   public static void Main()
   {
      try {
         MessageBox(new IntPtr(0), "Calling the MessageBox Function", "Example", 0);
      }
      catch (EntryPointNotFoundException e) {
         Console.WriteLine("{0}:\n   {1}", e.GetType().Name,  
                           e.Message);
      }

      try {
         MessageBoxW(new IntPtr(0), "Calling the MessageBox Function", "Example", 0);
      }
      catch (EntryPointNotFoundException e) {
         Console.WriteLine("{0}:\n   {1}", e.GetType().Name,  
                           e.Message);
      }
   }
}
// </Snippet2>
