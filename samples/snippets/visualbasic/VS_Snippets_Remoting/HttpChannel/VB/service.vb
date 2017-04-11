
Imports System
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Tcp
Imports System.Runtime.Remoting.Channels.Http
Imports System.Runtime.Remoting.Lifetime

Namespace SampleNamespace

' Define the event arguments
<Serializable()>  _
Public Class SampleServiceEventArgs
    Inherits EventArgs
    Private m_Message As String
    
    
    Public Sub New(ByVal message As String) 
        m_Message = message
    
    End Sub 'New
    
    
    Public ReadOnly Property Message() As String 
        Get
            Return m_Message
        End Get
    End Property
End Class 'SampleServiceEventArgs


' Define the delegate for the event
Public Delegate Sub SomethingHappenedEventHandler(ByVal sender As Object, ByVal e As SampleServiceEventArgs) 

' Define the remote service class

Public Class SampleService
    Inherits MarshalByRefObject
    
    ' The client will subscribe and unsubscribe to this event
    Public Event SomethingHappened As SomethingHappenedEventHandler
    
    
    Public Function SampleMethod() As Boolean 
        
        Console.WriteLine("Hello, you have called SampleMethod().")
        
        ' Fire Event
        If Not (SomethingHappenedEvent Is Nothing) Then
            ' Package String in TimerServiceEventArgs
            Dim sampleEventArgs As New SampleServiceEventArgs("Something happened")
            Console.WriteLine("Firing SomethingHappened Event")
            RaiseEvent SomethingHappened(Me, sampleEventArgs)
        End If
        Return True
    
    End Function 'SampleMethod
End Class 'SampleService

End Namespace