 ' <Snippet2>
Imports System
Imports System.Collections
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Tcp
Imports System.Runtime.Remoting.Channels.Http
Imports System.Runtime.Remoting.Lifetime
Imports System.Timers



Public Class TimerServer
    
    Public Shared Sub Main() 
        
        Dim serverProv As New BinaryServerFormatterSinkProvider()
        serverProv.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full
        Dim clientProv As New BinaryClientFormatterSinkProvider()
        
        Dim props As New Hashtable()
        props("port") = 9000
        Dim channel As New HttpChannel(props, clientProv, serverProv)
        ChannelServices.RegisterChannel(channel)
        RemotingConfiguration.RegisterWellKnownServiceType(GetType(TimerService), "MyService/TimerService.soap", WellKnownObjectMode.Singleton)
        
        Console.WriteLine("Press enter to end the server process.")
        Console.ReadLine()
    
    End Sub 'Main
End Class 'TimerServer

' </Snippet2>