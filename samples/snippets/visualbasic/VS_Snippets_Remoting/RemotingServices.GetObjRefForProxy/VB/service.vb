
Imports System
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Tcp
Imports System.Runtime.Remoting.Channels.Http
Imports System.Runtime.Remoting.Lifetime

Namespace SampleNamespace

' Define the remote service class

Public Class SampleService
    Inherits MarshalByRefObject
    
    Public Function SampleMethod() As Boolean 
        Console.WriteLine("Hello, you have called SampleMethod().")
        Return True
    
    End Function 'SampleMethod
End Class 'SampleService

End Namespace