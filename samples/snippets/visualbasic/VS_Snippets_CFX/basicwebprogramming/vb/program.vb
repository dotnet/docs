Imports System
Imports System.Text
Imports System.ServiceModel
Imports System.ServiceModel.Web
Imports System.ServiceModel.Description

<ServiceContract()> _
Public Interface IService
    <OperationContract()> _
    <WebGet()> _
    Function EchoWithGet(ByVal s As String) As String

    <OperationContract()> _
    <WebInvoke()> _
    Function EchoWithPost(ByVal s As String) As String
End Interface

Public Class Service
    Implements IService

    Public Function EchoWithGet(ByVal s As String) As String Implements IService.EchoWithGet
        Return "You said " + s
    End Function

    Public Function EchoWithPost(ByVal s As String) As String Implements IService.EchoWithPost
        Return "You said " + s
    End Function
End Class

Module Program

    Sub Main()
        Dim baseAddress As New Uri("http://localhost:8000")
        Dim host As New WebServiceHost(GetType(Service), baseAddress)
        Try
            host.Open()

            Dim binding As New WebHttpBinding()
            Dim cf As New WebChannelFactory(Of IService)(binding, New Uri("http://localhost:8000"))
            Dim channel As IService = cf.CreateChannel()
            Dim s As String

            Console.WriteLine("Calling EchoWithGet via HTTP GET: ")
            s = channel.EchoWithGet("Hello, world")
            Console.WriteLine("   Output: {0}", s)

            Console.WriteLine("")

            Console.WriteLine("Calling EchoWithPost via HTTP POST: ")
            s = channel.EchoWithPost("Hello, world")
            Console.WriteLine("   Output: {0}", s)

            Console.WriteLine("")
        Catch ex As CommunicationException
            Console.WriteLine("An exception occurred: " + ex.Message)
        End Try

    End Sub

End Module
