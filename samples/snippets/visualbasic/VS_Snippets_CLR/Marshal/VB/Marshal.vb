'<snippet1>
Imports System
Imports System.Text
Imports System.Runtime.InteropServices
Imports System.Security.Permissions



Public Structure Point
    Public x, y As Int32
End Structure



Public NotInheritable Class App

    <SecurityPermission(SecurityAction.LinkDemand, Unrestricted:=True)> _
    Shared Sub Main()
        '<snippet2> 
        ' Demonstrate the use of public static fields of the Marshal class.
        Console.WriteLine("SystemDefaultCharSize={0}, SystemMaxDBCSCharSize={1}", Marshal.SystemDefaultCharSize, Marshal.SystemMaxDBCSCharSize)
        '</snippet2>
        '<snippet3> 
        ' Demonstrate the use of the SizeOf method of the Marshal class.
        Console.WriteLine("Number of bytes needed by a Point object: {0}", Marshal.SizeOf(GetType(Point)))
        Dim p As New Point()
        Console.WriteLine("Number of bytes needed by a Point object: {0}", Marshal.SizeOf(p))
        '</snippet3>
        '<snippet4>
        ' Demonstrate how to call GlobalAlloc and 
        ' GlobalFree using the Marshal class.
        Dim hglobal As IntPtr = Marshal.AllocHGlobal(100)
        Marshal.FreeHGlobal(hglobal)
        '</snippet4>
        '<snippet5>
        ' Demonstrate how to use the Marshal class to get the Win32 error 
        ' code when a Win32 method fails.
        Dim f As [Boolean] = CloseHandle(New IntPtr(-1))
        If Not f Then
            Console.WriteLine("CloseHandle call failed with an error code of: {0}", Marshal.GetLastWin32Error())
        End If

    End Sub


    ' This is a platform invoke prototype. SetLastError is true, which allows 
    ' the GetLastWin32Error method of the Marshal class to work correctly.    
    <DllImport("Kernel32", ExactSpelling:=True, SetLastError:=True)> _
    Shared Function CloseHandle(ByVal h As IntPtr) As [Boolean]

    End Function
    '</snippet5>
End Class


' This code produces the following output.
' 
' SystemDefaultCharSize=2, SystemMaxDBCSCharSize=1
' Number of bytes needed by a Point object: 8
' Number of bytes needed by a Point object: 8
' CloseHandle call failed with an error code of: 6
'</snippet1>