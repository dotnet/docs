' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Module TestAction1
   Public Sub Main
      Dim messageTarget As Action(Of String) 

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
' </Snippet2>
