' Visual Basic .NET Document
Option Strict On

Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      ' <Snippet1>
      Dim MyString As String = "Jan 1, 2009"
      Dim MyDateTime As DateTime = DateTime.Parse(MyString)
      Console.WriteLine(MyDateTime)
      ' Displays the following output on a system whose culture is en-US:
      '       1/1/2009 12:00:00 AM
      ' </Snippet1>
   End Sub
End Module

