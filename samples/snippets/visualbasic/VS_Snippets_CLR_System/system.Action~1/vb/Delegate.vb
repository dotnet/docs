' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Delegate Sub DisplayMessage(message As String) 

Module TestCustomDelegate
   Public Sub Main
      Dim messageTarget As DisplayMessage 

      If Environment.GetCommandLineArgs().Length > 1 Then
         messageTarget = AddressOf ShowWindowsMessage
      Else
         messageTarget = AddressOf Console.WriteLine
      End If
      messageTarget("Hello, World!")
   End Sub
   
   Private Sub ShowWindowsMessage(message As String)
      MsgBox(message)
   End Sub   
End Module
' </Snippet1>
