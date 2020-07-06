'<Snippet10>
'Service.cs
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
end interface

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

Module program

    Sub Main()
        '<Snippet2>
        Dim host As WebServiceHost = New WebServiceHost(GetType(Service), New Uri("http://localhost:8000/"))
        '</Snippet2>
        Try
            '<Snippet3>
            Dim ep As ServiceEndpoint = host.AddServiceEndpoint(GetType(IService), New WebHttpBinding(), "")
            '</Snippet3>
            host.Open()
            '<Snippet6>
            Using cf As New ChannelFactory(Of IService)(New WebHttpBinding(), "http://localhost:8000")
                '</Snippet6>

                '<Snippet7>
                cf.Endpoint.Behaviors.Add(New WebHttpBehavior())
                '</Snippet7>

                '<Snippet8>
                Dim channel As IService = cf.CreateChannel()

                Dim s As String

                Console.WriteLine("Calling EchoWithGet via HTTP GET: ")
                s = channel.EchoWithGet("Hello, world")
                Console.WriteLine("   Output: {0}", s)

                Console.WriteLine("")
                Console.WriteLine("This can also be accomplished by navigating to")
                Console.WriteLine("http://localhost:8000/EchoWithGet?s=Hello, world!")
                Console.WriteLine("in a web browser while this sample is running.")

                Console.WriteLine("")

                Console.WriteLine("Calling EchoWithPost via HTTP POST: ")
                s = channel.EchoWithPost("Hello, world")
                Console.WriteLine("   Output: {0}", s)
                '</Snippet8>
                Console.WriteLine("")
            End Using

            Console.WriteLine("Press <ENTER> to terminate")
            Console.ReadLine()

            '<Snippet9>
            host.Close()
            '</Snippet9>
        Catch cex As CommunicationException
            Console.WriteLine("An exception occurred: {0}", cex.Message)
            host.Abort()
        End Try
    End Sub

End Module
' </Snippet10>
