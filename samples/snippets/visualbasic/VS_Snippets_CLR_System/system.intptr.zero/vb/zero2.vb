' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Private Const GW_OWNER As Integer = 4

   Private Declare Function GetWindow Lib "user32" (hWnd As IntPtr, 
                            wFlag As Integer) As IntPtr 

   Public Sub Main()
      Dim hwnd = new IntPtr(3)
      Dim hOwner As IntPtr = GetWindow(hwnd, GW_OWNER)
      If hOwner = IntPtr.Zero Then
         Console.WriteLine("Window not found.")
      End If   
   End Sub
End Module
' The example displays the following output:
'       Window not found.
' </Snippet1>
