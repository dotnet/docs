
Imports System
Imports System.Diagnostics
Imports System.Reflection
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Tcp



Public Class ClientProcess
    
    Public Shared Sub Main() 
        ChannelServices.RegisterChannel(New TcpChannel())
        Dim remoteType As New WellKnownClientTypeEntry(GetType(SampleService), "tcp://localhost:9000/SampleServiceUri")
        RemotingConfiguration.RegisterWellKnownClientType(remoteType)
        
        Dim service As New SampleService()
        Console.WriteLine("Connected to SampleService")
        Dim returnValue As Boolean = service.UpdateServer(3, 3.14, "Pi")
    
    End Sub 'Main
End Class 'ClientProcess


