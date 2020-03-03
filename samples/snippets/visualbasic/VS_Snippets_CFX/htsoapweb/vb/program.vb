'<Snippet13>
Imports System.Collections.Generic
Imports System.ServiceModel
Imports System.ServiceModel.Description
Imports System.ServiceModel.Web
Imports System.Text

'<Snippet0>
<ServiceContract()> _
Public Interface IService

    <OperationContract()> _
    <WebGet()> _
    Function EchoWithGet(ByVal s As String) As String

    <OperationContract()> _
    <WebInvoke()> _
    Function EchoWithPost(ByVal s As String) As String
End Interface
'</Snippet0>

'<Snippet1>
Public Class Service
    Implements IService
    Public Function EchoWithGet(ByVal s As String) As String Implements IService.EchoWithGet
        Return "You said " + s
    End Function

    Public Function EchoWithPost(ByVal s As String) As String Implements IService.EchoWithPost
        Return "You said " + s
    End Function
End Class
'</Snippet1>
Module Program

    Sub Main()
        '<Snippet2>
        Dim host As New ServiceHost(GetType(Service), New Uri("http://localhost:8000"))
        '</Snippet2>
        '<Snippet3>
        host.AddServiceEndpoint(GetType(IService), New BasicHttpBinding(), "Soap")
        '</Snippet3>
        '<Snippet4>
        Dim endpoint As ServiceEndpoint
        endpoint = host.AddServiceEndpoint(GetType(IService), New WebHttpBinding(), "Web")
        endpoint.Behaviors.Add(New WebHttpBehavior())
        '</Snippet4>

        Try
            '<Snippet5>
            host.Open()
            '</Snippet5>

            '<Snippet6>
            Using wcf As New WebChannelFactory(Of IService)(New Uri("http://localhost:8000/Web"))
                '</Snippet6>

                '<Snippet8>
                Dim channel As IService = wcf.CreateChannel()

                Dim s As String

                Console.WriteLine("Calling EchoWithGet by HTTP GET: ")
                s = channel.EchoWithGet("Hello, world")
                Console.WriteLine("   Output:  {0}", s)

                Console.WriteLine("")
                Console.WriteLine("This can also be accomplished by navigating to")
                Console.WriteLine("http://localhost:8000/Web/EchoWithGet?s=Hello, world!")
                Console.WriteLine("in a web browser while this sample is running.")

                Console.WriteLine("")

                Console.WriteLine("Calling EchoWithPost by HTTP POST: ")
                s = channel.EchoWithPost("Hello, world")
                Console.WriteLine("   Output:  {0}", s)
                '</Snippet8>
                Console.WriteLine("")
            End Using
            '<Snippet10>
            Using scf As New ChannelFactory(Of IService)(New BasicHttpBinding(), "http://localhost:8000/Soap")
                '</Snippet10>

                '<Snippet11>
                Dim channel As IService = scf.CreateChannel()

                Dim s As String

                Console.WriteLine("Calling EchoWithGet on SOAP endpoint: ")
                s = channel.EchoWithGet("Hello, world")
                Console.WriteLine("   Output:  {0}", s)

                Console.WriteLine("")

                Console.WriteLine("Calling EchoWithPost on SOAP endpoint: ")
                s = channel.EchoWithPost("Hello, world")
                Console.WriteLine("   Output:  {0}", s)
                '</Snippet11>
                Console.WriteLine("")
            End Using


            Console.WriteLine("Press <Enter> to terminate")
            Console.ReadLine()
            '<Snippet9>
            host.Close()
            '</Snippet9>
        Catch cex As CommunicationException
            Console.WriteLine("An exception occurred:  {0}", cex.Message)
            host.Abort()
        End Try

    End Sub
End Module
' </Snippet13>
