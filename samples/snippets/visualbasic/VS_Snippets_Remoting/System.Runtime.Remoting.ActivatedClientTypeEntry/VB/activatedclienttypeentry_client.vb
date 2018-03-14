'<snippet1>
Imports System
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Tcp

Public Class MyClient
    
    Public Shared Sub Main()
        ' Register TCP Channel.
        ChannelServices.RegisterChannel(New TcpChannel())

        '<snippet2>
        ' Create activated client type entry.
        Dim myActivatedClientTypeEntry As _
            New ActivatedClientTypeEntry(GetType(HelloServer), _
            "tcp://localhost:8082")
        '</snippet2>

        ' Register type on client to activate it on the server.
        RemotingConfiguration.RegisterActivatedClientType( _
            myActivatedClientTypeEntry)

        ' Activate a client activated object type.
        Dim myHelloServer As New HelloServer("ParameterString")

        '<snippet3>
        ' Print the object type.
        Console.WriteLine("Object type of client activated object: " + _
            myActivatedClientTypeEntry.ObjectType.ToString())
        '</snippet3>

        '<snippet4>
        ' Print the application URL.
        Console.WriteLine("Application url where the type is activated: " + _
            myActivatedClientTypeEntry.ApplicationUrl)
        '</snippet4>

        '<snippet5>
        ' Print the string representation of the type entry.
        Console.WriteLine( _
            "Type name, assembly name and application URL " + _
            "of the remote object: " + _
            myActivatedClientTypeEntry.ToString())
        '</snippet5>

        ' Print a blank line.
        Console.WriteLine()

        ' Check that server was located.
        If myHelloServer Is Nothing Then
            Console.WriteLine("Could not locate server")
        Else
            Console.WriteLine("Calling remote object")
            Console.WriteLine(myHelloServer.HelloMethod("Bill"))
        End If
    End Sub 'Main
End Class 'MyClient
'</snippet1>
