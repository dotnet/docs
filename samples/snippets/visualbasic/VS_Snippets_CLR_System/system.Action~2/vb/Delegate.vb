' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.IO

Delegate Sub ConcatStrings(string1 As String, string2 As String)

Module TestDelegate
   Public Sub Main()
      
      Dim message1 As String = "The first line of a message."
      Dim message2 As String = "The second line of a message."
      Dim concat As ConcatStrings
      
      If Environment.GetCommandLineArgs().Length > 1 Then
         concat = AddressOf WriteToFile
      Else
         concat = AddressOf WriteToConsole
      End If   
      concat(message1, message2)         
   End Sub
   
   Private Sub WriteToConsole(string1 As String, string2 As String)
      Console.WriteLine("{0}{1}{2}", string1, vbCrLf, string2)
   End Sub
   
   Private Sub WriteToFile(string1 As String, string2 As String)
      Dim writer As StreamWriter = Nothing  
      Try
         writer = New StreamWriter(Environment.GetCommandLineArgs(1), False)
         writer.WriteLine("{0}{1}{2}", string1, vbCrLf, string2)
      Catch
         Console.WriteLine("File write operation failed...")
      Finally
         If writer IsNot Nothing Then writer.Close
      End Try      
   End Sub
End Module
' </Snippet1>

