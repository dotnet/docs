' This is the implementation class for the remote object.
Imports System

Public Class MyServerImpl
   Inherits MarshalByRefObject
   
   Public Sub New()
   End Sub 'New
   
   Public Function MyMethod(name As String) As String
      Return "The string from client is " + name
   End Function 'MyMethod
End Class 'MyServerImpl
