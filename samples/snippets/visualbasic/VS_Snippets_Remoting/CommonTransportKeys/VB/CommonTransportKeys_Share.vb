' Supporting file: Common  

Imports System
Imports MicroSoft.VisualBasic

Public Class Foo
   Inherits MarshalByRefObject
   
   ' Print the string value.
   Public Sub PrintString(str As String)
      Console.WriteLine(ControlChars.Newline + str)
   End Sub 'PrintString
End Class 'Foo