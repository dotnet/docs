' <Snippet1>
Imports System
Imports System.IO
Imports System.Text

Public Class Test
  Public Shared Sub Main()
    Dim path As String = "c:\temp\MyTest.txt"

    If Not File.Exists(path) Then
      ' Create a file to write to. 
      Using sw As StreamWriter = File.CreateText(path)
        sw.WriteLine("Hello")
        sw.WriteLine("And")
        sw.WriteLine("Welcome")
      End Using
    End If

    ' Open the file to read from. 
    Using sr As StreamReader = File.OpenText(path)
      Do While sr.Peek() >= 0
        Console.WriteLine(sr.ReadLine())
      Loop
    End Using

  End Sub
End Class
' </Snippet1>
