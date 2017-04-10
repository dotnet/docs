' The following program is the supporting program for demonstration of
' 'System.Runtime.Remoting.Channels.SinkProviderData' class and its 
' properties 'Children', 'Name', 'Properties'.

Imports System

Public Class mySharedStringClass
   Inherits MarshalByRefObject

   ' Return the number of letters in the string.
   Public Function PrintString(myString As String) As Integer
      Console.WriteLine(myString)
      Return myString.Length
   End Function 'PrintString
End Class 'mySharedStringClass