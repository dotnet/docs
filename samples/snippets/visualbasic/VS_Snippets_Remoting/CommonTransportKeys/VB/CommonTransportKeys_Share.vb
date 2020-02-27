' Supporting file: Common  

Public Class Foo
   Inherits MarshalByRefObject
   
   ' Print the string value.
   Public Sub PrintString(str As String)
      Console.WriteLine(ControlChars.Newline + str)
   End Sub
End Class