Imports System

Public Class HelloServer
   Inherits MarshalByRefObject

   Public Sub New(myString As String)
      Console.WriteLine("HelloServer activated")
      Console.WriteLine("Paramater passed to the constructor is " + myString)
   End Sub 'New

   Public Function HelloMethod(myName As String) As String
      Console.WriteLine("HelloMethod : {0}", myName)
      Return "Hi there " + myName
   End Function 'HelloMethod
End Class 'HelloServer