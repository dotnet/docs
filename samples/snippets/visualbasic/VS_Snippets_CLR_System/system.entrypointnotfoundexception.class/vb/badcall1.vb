' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Module Example
   Declare Unicode Function MessageBox Lib "User32.dll" Alias "MessageBox" (
      ByVal hWnd As IntPtr, ByVal txt As String, ByVal caption As String, 
      ByVal typ As UInteger) As Integer  

   Declare Unicode Function MessageBox2 Lib "User32.dll" Alias "MessageBoxW" (  
      ByVal hWnd As IntPtr, ByVal txt As String, ByVal caption As String, 
      ByVal typ As UInteger) As Integer  
      
   Public Sub Main()
      Try
         MessageBox(IntPtr.Zero, "Calling the MessageBox Function", "Example", 0 )
      Catch e As EntryPointNotFoundException
         Console.WriteLine("{0}:{2}   {1}", e.GetType().Name,  
                           e.Message, vbCrLf)
      End Try

      Try
         MessageBox2(IntPtr.Zero, "Calling the MessageBox Function", "Example", 0 )
      Catch e As EntryPointNotFoundException
         Console.WriteLine("{0}:{2}   {1}", e.GetType().Name,  
                           e.Message, vbCrLf)
      End Try

   End Sub
End Module
' </Snippet2>
