' C:\Program Files\Microsoft.NET\FrameworkSDK\Samples\technologies\remoting\advanced\customproxies

'<snippet1>
Imports System
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Messaging
Imports System.Runtime.Remoting.Channels
Imports System.Reflection
Imports Microsoft.VisualBasic.Constants
Imports Microsoft.VisualBasic.Interaction
'</snippet1>

'<snippet4>
Imports System.Runtime.Remoting.Channels.Tcp
Imports System.Runtime.Remoting.Lifetime
Imports System.Runtime.Remoting.Proxies
'</snippet4>

'<snippet5>
Imports System.Runtime.Remoting.Channels.Http
Imports System.Net
Imports System.IO
'</snippet5>

Imports System.Security.Permissions

'<snippet6>
' An instance of ClientApp will call an instance of this class remotely.

Public Class TcpServerApp
    Shared Sub New()

        ' Register a class over TCP at tcp:'localhost:8085/HttpHelloServer.

        Const myObjectUri As String = "TcpHelloServer"
        Const myPort As Integer = 8085

        Dim myTcpChannel As New TcpChannel(myPort)
        ChannelServices.RegisterChannel(myTcpChannel)

        RemotingConfiguration.RegisterWellKnownServiceType( _
            GetType(HelloServer), _
            myObjectUri, _
            WellKnownObjectMode.Singleton _
        )
        '</snippet6>

        '<snippet7>
        Console.WriteLine("Server type: {0}", _
                          RemotingServices.GetServerTypeForUri(myObjectUri).ToString())
        '</snippet7>

        '<snippet8>
        Console.WriteLine("Press Enter to stop the demo.")
        Console.ReadLine()
    End Sub
End Class
'</snippet8>

'<snippet9>
Public Class HttpServerApp
    Shared Sub New()
        ' Marshal an object over HTTP at http:'localhost:8090/HttpHelloServer.

        Const myObjectUri As String = "HttpHelloServer"
        Const myPort As Integer = 8090

        Dim myHttpChannel As New HttpChannel(myPort)
        ChannelServices.RegisterChannel(myHttpChannel)

        Dim myMbro As MarshalByRefObject = CType(Activator.CreateInstance(GetType(HelloServer)), MarshalByRefObject)
        RemotingServices.SetObjectUriForMarshal(myMbro, myObjectUri)
        Dim myObjRef As ObjRef = RemotingServices.Marshal(myMbro)

        Console.WriteLine("Press Enter to stop the demo.")
        Console.ReadLine()

        Dim umObj As HelloServer = CType(RemotingServices.Unmarshal(myObjRef), HelloServer)
        RemotingServices.Disconnect(myMbro)
    End Sub
End Class
'</snippet9>

'<snippet2>
Public Class HelloServer
    Inherits MarshalByRefObject

    Shared Sub New()
        Console.WriteLine("HelloServer activated.")
    End Sub

    <OneWay()> Public Sub SayHelloToServer(ByVal name As String)
        Console.WriteLine("Client invoked SayHelloToServer(""{0}"").", name)
    End Sub

    '<snippet3> 
    'IsOneWay
    ' Note the lack of the OneWayAttribute adornment on this method.
<SecurityPermission(SecurityAction.Demand)> _
    Public Function SayHelloToServerAndWait(ByVal name As String) As String
        Console.WriteLine("Client invoked SayHelloToServerAndWait(""{0}"").", name)

        Console.WriteLine( _
            "Client waiting for return? {0}", _
            IIf(RemotingServices.IsOneWay(MethodBase.GetCurrentMethod()), "No", "Yes") _
        )

        Return "Hi there, " + name + "."
    End Function
    '</snippet3>

End Class
'</snippet2>

'<snippet11>
' An instance of this class will call an instance of ServerApp remotely.

Public Class TcpClientApp
    Shared Sub New()
        Const myHelloServerUrl As String = "tcp:'localhost:8085/TcpHelloServer"

        Dim obj As HelloServer = CType( _
            RemotingServices.Connect( _
                GetType(HelloServer), _
                myHelloServerUrl _
            ), _
            HelloServer _
        )
        '</snippet11>

        '<snippet12> 
        'IsTransparentProxy, IsObjectOutOfAppDomain, IsObjectOutOfContext
        Console.WriteLine("Proxy transparent? {0}", _
            IIf(RemotingServices.IsTransparentProxy(obj), "Yes", "No") _
        )

        Console.WriteLine("Object outside app domain? {0}", _
            IIf(RemotingServices.IsObjectOutOfAppDomain(obj), "Yes", "No") _
        )

		Console.WriteLine("Object out of context? {0}", _
			iif(RemotingServices.IsObjectOutOfContext(obj), "Yes",   "No") _
		)
        '</snippet12>

        '<snippet18> 
        ' GetRealProxy, GetObjectUri, GetEnvoyChainForProxy
        Dim proxy As RealProxy = RemotingServices.GetRealProxy(obj)
        Console.WriteLine("Real proxy type: {0}", proxy.GetProxiedType().ToString())

        Console.WriteLine("Object URI: {0}", RemotingServices.GetObjectUri(obj).ToString())

        Dim msgSink As IMessageSink = RemotingServices.GetEnvoyChainForProxy(obj).NextSink
        '</snippet18>

        '<snippet21> 
        ' GetLifetimeService
        Dim lease As ILease = CType(RemotingServices.GetLifetimeService(obj), ILease)
		Console.WriteLine("Object lease time remaining: {0}.", _
            lease.CurrentLeaseTime.ToString() _
		)
        '</snippet21>

        '<snippet16>
        Dim twoWayMethodArg As String = "John"

        Console.WriteLine("Invoking SayHelloToServerAndWait(""{0}"").", twoWayMethodArg)
        Console.WriteLine("Server returned: {0}", obj.SayHelloToServerAndWait(twoWayMethodArg))
        '</snippet16>

        '<snippet17>
        Dim oneWayMethodArg As String = "Mary"

        Console.WriteLine("Invoking SayHelloToServer(""{0}"").", oneWayMethodArg)
        obj.SayHelloToServer(oneWayMethodArg)
        '</snippet17>

        '<snippet23>
    End Sub
    '</snippet23>

    '<snippet13>
End Class
'</snippet13>

'<snippet22>
Public Class HttpClientApp
    Shared Sub New()
        Const myHelloServerUrl As String = "http:'localhost:8090/HttpHelloServer"

        ' Output the WSDL for the marshalled object.

        Dim myWebClient As New WebClient()
        Dim myStream As Stream = myWebClient.OpenRead(myHelloServerUrl + "?wsdl")

        Dim b As Integer = myStream.ReadByte()
        While b <> -1
            Console.Write(CChar(b.ToString()))
            b = myStream.ReadByte()
        End While
    End Sub
End Class
'</snippet22>

'<snippet14>
Class EntryPoint
    Shared Sub Main()
        Dim args() As String = Environment.GetCommandLineArgs
        '</snippet14>

        If args.Length = 1 OrElse args(1).ToLower() <> "s" Then
            Console.WriteLine("Run this program in another window," + vbCrLf + "passing the letter 's' as an argument." + vbCrLf + "Press Enter here when the server has been activated.")
            Console.ReadLine()
            Console.WriteLine("Running TCP client.")
        End If

        '<snippet19>
        If args.Length > 1 AndAlso args(1).ToLower() = "s" Then
            Dim a As New TcpServerApp()
        Else
            Dim b As New TcpClientApp()
        End If
        '</snippet19>

        If args.Length = 1 OrElse args(1).ToLower() <> "s" Then
            Console.WriteLine(vbCrLf + "Press Enter in the other window to continue to the next demo." + vbCrLf + "Then press Enter here.")
            Console.ReadLine()
        End If

        '<snippet20>
        If args.Length > 1 AndAlso args(1).ToLower() = "s" Then
            Dim c As New HttpServerApp()
        Else
            Dim d As New HttpClientApp()
        End If
        '</snippet20>

        '<snippet15>
    End Sub
End Class
'</snippet15>