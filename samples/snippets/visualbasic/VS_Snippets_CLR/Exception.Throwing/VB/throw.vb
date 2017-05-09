' Visual Basic .NET Document

' <Snippet1>
Option Strict On

Imports System
Imports System.IO

Public Class ProcessFile
   
   Public Shared Sub Main()
      Dim fs As FileStream = Nothing
      Try
          'Opens a text file.
          fs = New FileStream("c:\temp\data.txt", FileMode.Open)
          Dim sr As New StreamReader(fs)
          Dim line As String

          'A value is read from the file and output to the console.
          line = sr.ReadLine()
          Console.WriteLine(line)
      Catch e As FileNotFoundException
          Console.WriteLine("[Data File Missing] {0}", e)
          Throw New FileNotFoundException("[data.txt not in c:\temp directory]", e)
      Finally
          If fs IsNot Nothing Then fs.Close
      End Try
   End Sub 
End Class 
' </Snippet1>
