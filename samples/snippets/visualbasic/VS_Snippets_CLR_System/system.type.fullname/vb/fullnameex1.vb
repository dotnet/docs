' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Collections.Generic

Module Example
   Public Sub Main()
      Dim t As Type = GetType(List(Of))
      Console.WriteLine(t.FullName)
      Console.WriteLine()

      Dim list As New List(Of String)()
      t = list.GetType()
      Console.WriteLine(t.FullName)
   End Sub
End Module
' The example displays the following output:
'    System.Collections.Generic.List`1
'
'    System.Collections.Generic.List`1[[System.String, mscorlib,
'             Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]
' </Snippet2>
