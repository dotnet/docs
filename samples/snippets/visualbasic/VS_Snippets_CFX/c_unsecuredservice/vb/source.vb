'<snippet0>
Imports System.Collections.Generic
Imports System.ServiceModel
'<snippet0>
Imports System.ServiceModel.Description
Imports System.Security.Principal

Class Service

    Shared Sub Main(ByVal args() As String)
        Dim s As New Service()
        s.UnsecuredHttp()

    End Sub

    Private Sub UnsecuredHttp()

        '<snippet1>
        Dim httpUri As New Uri("http://localhost/Calculator")

        ' Create the ServiceHost.
        Dim myServiceHost As New ServiceHost(GetType(Calculator), httpUri)

        ' Create a binding that uses HTTP. By default, 
        ' this binding has no security.
        Dim b As New BasicHttpBinding()

        ' Add an endpoint to the service.
        myServiceHost.AddServiceEndpoint(GetType(ICalculator), b, "")
        ' Open the service and wait for calls.
        AddMexEndpoint(myServiceHost)
        myServiceHost.Open()
        Console.Write("Listening....")
        Console.ReadLine()
        ' Close the service when a key is pressed.
        myServiceHost.Close()
        '</snippet1>

    End Sub

    Private Sub UnsecuredTcp()

        '<snippet2>
        Dim tcpUri As New Uri("net.tcp://localhost:8008/Calculator")

        ' Create the ServiceHost.
        Dim sh As New ServiceHost(GetType(Calculator), tcpUri)

        ' Create a binding that uses TCP and set the security mode to none.
        Dim b As New NetTcpBinding()
        b.Security.Mode = SecurityMode.None

        ' Add an endpoint to the service.
        sh.AddServiceEndpoint(GetType(ICalculator), b, "")
        ' Open the service and wait for calls.
        sh.Open()

        Dim listenUri As String = sh.Description.Endpoints(0).ListenUri.AbsoluteUri
        Console.WriteLine("Listening on: {0}", listenUri)
        Console.Write("Press Enter to end the service")
        Console.ReadLine()
        ' Close the service when a key is pressed.
        '</snippet2>

    End Sub

    Private Sub AddMexEndpoint(ByRef sv As ServiceHost)
        ' Add an endpoint to return metadata.
        Dim sb As New ServiceMetadataBehavior()
        sb.HttpGetEnabled = True
        sb.HttpGetUrl = New Uri("http://localhost:8008/metadata")
        sv.Description.Behaviors.Add(sb)

    End Sub
End Class

<ServiceContract()> _
Interface ICalculator
    <OperationContract()> _
    Function Add(ByVal a As Double, ByVal b As Double) As Double
End Interface



Public Class Calculator
    Implements ICalculator

    Public Function Add(ByVal a As Double, ByVal b As Double) As Double _
    Implements ICalculator.Add
        Return a + b

    End Function
End Class
