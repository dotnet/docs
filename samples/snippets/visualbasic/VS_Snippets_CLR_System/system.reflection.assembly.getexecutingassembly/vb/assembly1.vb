' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Reflection

Module Example
   Public Sub Main()
      Dim assem As Assembly = GetType(Example).Assembly
      Console.WriteLine("Assembly name: {0}", assem.FullName)
   End Sub
End Module
' The example displays the following output:
'   Assembly name: Assembly1, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
' </Snippet1>
