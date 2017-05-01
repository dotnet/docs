
// <Snippet1>
using System;
using System.Runtime.InteropServices;

public class Example
{
   private const int GW_OWNER = 4;
    
   [DllImport("user32", CharSet=CharSet.Auto, SetLastError=true, ExactSpelling=true)]
   public static extern IntPtr GetWindow(IntPtr hwnd, int wFlag);   
   
   public static void Main()
   {
      IntPtr hwnd = new IntPtr(3);
      IntPtr hOwner = GetWindow(hwnd, GW_OWNER);
      if (hOwner == IntPtr.Zero)
         Console.WriteLine("Window not found.");
   }
}
// The example displays the following output:
//        Window not found.
// </Snippet1>
