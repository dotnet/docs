' Visual Basic .NET Document
Option Strict On

' <Snippet11>
Imports System.Text

Module Example
   Public Sub Main()
      Dim MyStringBuilder As New StringBuilder("Hello World!")
      MyStringBuilder.Replace("!"c, "?"c)
      Console.WriteLine(MyStringBuilder)
   End Sub
End Module
' The example displays the following output:
'       Hello World?
' </Snippet11>
