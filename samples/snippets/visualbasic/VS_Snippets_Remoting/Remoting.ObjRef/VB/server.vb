
Imports System
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Tcp
Imports System.Runtime.Remoting.Channels.Http
Imports System.Runtime.Remoting.Lifetime

Namespace SampleNamespace

Public Class SampleServer
    
    Public Shared Sub Main() 
        Dim channel As New HttpChannel(9000)
        ChannelServices.RegisterChannel(channel)
        RemotingConfiguration.ApplicationName = "MySampleService"
        RemotingConfiguration.RegisterActivatedServiceType(GetType(SampleService))
        
        Console.WriteLine("Press enter to end the server process.")
        Console.ReadLine()
    
    End Sub 'Main
End Class 'SampleServer

End Namespace