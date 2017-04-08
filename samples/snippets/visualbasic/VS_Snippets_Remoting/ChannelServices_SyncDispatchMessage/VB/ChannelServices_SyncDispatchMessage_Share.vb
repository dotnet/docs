' The class 'PrintServer' is derived from 'MarshalByRefObject' to 
' make it remotable.  

Imports System
Imports System.Runtime.Remoting

Public Class PrintServer
   Inherits MarshalByRefObject
   
   Public Function MyPrintMethod(myString As String, fValue As Double, iValue As Integer) As Integer
      Console.WriteLine("PrintServer.MyPrintMethod {0} {1} {2}", myString, fValue, iValue)
      Return iValue
   End Function 'MyPrintMethod
End Class 'PrintServer
