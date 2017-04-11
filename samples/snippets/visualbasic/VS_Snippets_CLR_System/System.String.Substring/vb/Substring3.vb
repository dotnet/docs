' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Module Example
   Public Sub Main()
      Dim s As String = "<term>extant<definition>still in existence</definition></term>"
      Dim searchString As String = "<definition>"
      Dim startindex As Integer = s.IndexOf(searchString)
      searchString = "</" + searchString.Substring(1)
      Dim endIndex As Integer = s.IndexOf(searchString)
      Dim substring As String = s.Substring(startIndex, endIndex + searchString.Length - StartIndex)
      Console.WriteLine("Original string: {0}", s)
      Console.WriteLine("Substring;       {0}", substring) 
   End Sub
End Module
' The example displays the following output:
'   Original string: <term>extant<definition>still in existence</definition></term>
'   Substring;       <definition>still in existence</definition>
' </Snippet3>

