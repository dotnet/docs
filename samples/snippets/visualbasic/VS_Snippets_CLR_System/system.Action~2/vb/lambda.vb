Option Strict On

' <Snippet4>
Imports System.IO

Public Module TestLambdaExpression

   Public Sub Main()
      Dim message1 As String = "The first line of a message."
      Dim message2 As String = "The second line of a message."
      Dim concat As Action(Of String, String)
      
      If Environment.GetCommandLineArgs().Length > 1 Then
         concat = Sub(s1, s2) WriteToFile(s1, s2)
      Else
         concat = Sub(s1, s2) WriteToConsole(s1, s2)
      End If
         
      concat(message1, message2)
   End Sub
  
   Private Function WriteToConsole(string1 As String, string2 As String) As Integer
      Dim message As String = String.Format("{0}{1}{2}", string1, vbCrLf, string2)
      Console.WriteLine(message)
      Return message.Length
   End Function

   Private Function WriteToFile(string1 As String, string2 As String) As Integer
      Dim writer As StreamWriter = Nothing  
      Dim message As String = String.Format("{0}{1}{2}", string1, vbCrLf, string2)
      Dim charsWritten As Integer
      Try
         writer = New StreamWriter(Environment.GetCommandLineArgs()(1), False)
         writer.WriteLine(message)
      Catch
         Console.WriteLine("File write operation failed...")
      Finally
         If writer IsNot Nothing Then 
            writer.Close()
            charsWritten = message.Length
         Else
            charsWritten = 0
         End If
      End Try      
      Return charsWritten
   End Function
End Module
' </Snippet4>
