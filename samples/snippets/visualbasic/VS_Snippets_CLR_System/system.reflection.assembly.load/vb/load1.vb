' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Reflection

Module Example
   Public Sub Main()
      Dim longName As String = "system, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
      Dim assem As Assembly = Assembly.Load(longName)
      If assem Is Nothing Then
         Console.WriteLine("Unable to load assembly...")
      Else
         Console.WriteLine(assem.FullName)
      End If
   End Sub
End Module
' The example displays the following output:
'       system, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
' </Snippet1>
