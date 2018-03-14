//Types:System.Runtime.InteropServices.Marshal Vendor: Richter
//<snippet1>
using System;
using System.Text;
using System.Runtime.InteropServices;

public struct Point
{
    public Int32 x, y;
}


public sealed class App
{
    static void Main()
    {
        //<snippet2> 
        // Demonstrate the use of public static fields of the Marshal class.
        Console.WriteLine("SystemDefaultCharSize={0}, SystemMaxDBCSCharSize={1}",
            Marshal.SystemDefaultCharSize, Marshal.SystemMaxDBCSCharSize);
	//</snippet2>

        //<snippet3> 
        // Demonstrate the use of the SizeOf method of the Marshal class.
        Console.WriteLine("Number of bytes needed by a Point object: {0}", 
            Marshal.SizeOf(typeof(Point)));
        Point p = new Point();
        Console.WriteLine("Number of bytes needed by a Point object: {0}",
            Marshal.SizeOf(p));
        //</snippet3>
        
        //<snippet4>
        // Demonstrate how to call GlobalAlloc and 
        // GlobalFree using the Marshal class.
        IntPtr hglobal = Marshal.AllocHGlobal(100);
        Marshal.FreeHGlobal(hglobal);
        //</snippet4>

        //<snippet5>
        // Demonstrate how to use the Marshal class to get the Win32 error 
        // code when a Win32 method fails.
        Boolean f = CloseHandle(new IntPtr(-1));
        if (!f)
        {
            Console.WriteLine("CloseHandle call failed with an error code of: {0}", 
                Marshal.GetLastWin32Error());
        }  
    }

    // This is a platform invoke prototype. SetLastError is true, which allows 
    // the GetLastWin32Error method of the Marshal class to work correctly.    
    [DllImport("Kernel32", ExactSpelling = true, SetLastError = true)]
    static extern Boolean CloseHandle(IntPtr h);
    //</snippet5>
    
}

// This code produces the following output.
// 
// SystemDefaultCharSize=2, SystemMaxDBCSCharSize=1
// Number of bytes needed by a Point object: 8
// Number of bytes needed by a Point object: 8
// CloseHandle call failed with an error code of: 6
//</snippet1>