Option Strict On

' <Snippet4>
Imports System.Windows.Forms

Public Module TestLambdaExpression
   Public Sub Main()
      Dim messageTarget As Action(Of String) 
      
      If Environment.GetCommandLineArgs().Length > 1 Then
         messageTarget = Sub(s) ShowWindowsMessage(s) 
      Else
         messageTarget = Sub(s) ShowConsoleMessage(s)
      End If
      messageTarget("Hello, World!")
   End Sub
      
   Private Function ShowWindowsMessage(message As String) As Integer
      Return MessageBox.Show(message)      
   End Function
   
   Private Function ShowConsoleMessage(message As String) As Integer
      Console.WriteLine(message)
      Return 0
   End Function
End Module
' </Snippet4>
