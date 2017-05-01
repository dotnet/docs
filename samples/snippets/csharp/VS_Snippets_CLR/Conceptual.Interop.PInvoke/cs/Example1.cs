// <Snippet1>
using System;
using System.Runtime.InteropServices;

public class Win32 {
     [DllImport("user32.dll", CharSet=CharSet.Auto)]
     public static extern IntPtr MessageBox(int hWnd, String text, 
                     String caption, uint type);
}

public class HelloWorld {
    public static void Main() {
       Win32.MessageBox(0, "Hello World", "Platform Invoke Sample", 0);
    }
}      
// </Snippet1>
