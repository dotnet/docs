
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
    
    
    Public Function GetManuallyMarshaledObject() As ObjRef 
        Dim objectTwo As New SampleTwo()
        Dim objRefTwo As ObjRef = RemotingServices.Marshal(objectTwo)
        Return objRefTwo
    
    End Function 'GetManuallyMarshaledObject
End Class 'SampleService


Public Class SampleTwo
    Inherits MarshalByRefObject
    
    Public Sub PrintMessage(ByVal s As String) 
        Console.WriteLine("This message was received from the client:")
        Console.WriteLine(vbTab + "{0}", s)
    
    End Sub 'PrintMessage
End Class 'SampleTwo

End Namespace