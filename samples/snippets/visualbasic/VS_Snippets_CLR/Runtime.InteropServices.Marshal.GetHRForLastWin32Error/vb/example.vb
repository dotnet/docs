'<snippet1>
Imports System.Runtime.InteropServices

Module Win32
    ' Use DllImportAttribute to inport the Win32 MessageBox
    ' function.  Set the SetLastError flag to true to allow
    ' the function to set the Win32 error.
    <DllImportAttribute("user32.dll", SetLastError:=True, CharSet:=CharSet.Unicode)> _
    Function MessageBox(ByVal hwnd As IntPtr, ByVal text As String, ByVal caption As String, ByVal type As UInt32) As Integer
    End Function

End Module

Module Program


    Sub Run()



        ' Call the MessageBox with an invalid window handle to
        ' produce a Win32 error.

        Console.WriteLine("Calling Win32 MessageBox with error...")

        Win32.MessageBox(New IntPtr(123132), "Press OK...", "Press OK Dialog", 0)

        ' Get the last error and display it.
        Dim HRESULT As Integer

        HRESULT = Marshal.GetHRForLastWin32Error()

        Console.WriteLine("The last Win32 Error was: " + HRESULT)

    End Sub

    Sub Main(ByVal args() As String)

        Run()

    End Sub

End Module

' This code example displays the following to the console: 
'
' Calling Win32 MessageBox with error...
' The last Win32 Error was: -2147023496
'</snippet1>