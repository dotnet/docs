' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.IO

Module Example
   Public Sub Main()
      Dim t As Type = GetType(Stream)
      Dim genericT As Type = GetType(GenericWithConstraint(Of ))
      Dim genericParam As Type = genericT.GetGenericArguments()(0)
      Console.WriteLine(t.IsAssignableFrom(genericParam))  
      ' Displays True.
   End Sub
End Module

Public Class GenericWithConstraint(Of T As Stream)
End Class
' </Snippet2>

