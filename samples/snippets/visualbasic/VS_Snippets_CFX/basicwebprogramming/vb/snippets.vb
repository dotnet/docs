Imports System
Imports System.Text
Imports System.ServiceModel
Imports System.ServiceModel.Web
Imports System.ServiceModel.Description

Public Class Snippets
    Public Shared Sub Snippet0()
        ' <Snippet0>
        Dim baseAddress As New Uri("http://localhost:8000")
        Dim host As New WebServiceHost(GetType(Service), baseAddress)
        Try
            host.Open()

            Dim cf As New WebChannelFactory(Of IService)(baseAddress)
            Dim channel As IService = cf.CreateChannel()
            Dim s As String

            Console.WriteLine("Calling EchoWithGet via HTTP GET: ")
            s = channel.EchoWithGet("Hello, world")
            Console.WriteLine("   Output:  0}", s)

            Console.WriteLine("")

            Console.WriteLine("Calling EchoWithPost via HTTP POST: ")
            s = channel.EchoWithPost("Hello, world")
            Console.WriteLine("   Output:  0}", s)

            Console.WriteLine("")

        Catch ex As CommunicationException
            Console.WriteLine("An exception occurred: " + ex.Message)
        End Try
        ' </Snippet0>
    End Sub

    Public Shared Sub Snippet1()
        ' <Snippet1>
        Dim baseAddress As New Uri("http://localhost:8000")
        Dim host As New WebServiceHost(GetType(Service), baseAddress)
        Try
            host.Open()
            Dim binding As New WebHttpBinding()
            Dim cf As New WebChannelFactory(Of IService)(binding)
            cf.Endpoint.Address = New EndpointAddress("http://localhost:8000")
            Dim channel As IService = cf.CreateChannel()
            Dim s As String

            Console.WriteLine("Calling EchoWithGet via HTTP GET: ")
            s = channel.EchoWithGet("Hello, world")
            Console.WriteLine("   Output:  0}", s)
        Catch ex As CommunicationException
            Console.WriteLine("An exception occurred: " + ex.Message)
        End Try

        ' </Snippet1>
    End Sub

    Public Shared Sub Snippet2()
        ' <Snippet2>
        Dim baseAddress As New Uri("http://localhost:8000")
        Dim host As New WebServiceHost(GetType(Service), baseAddress)
        Try
            host.Open()

            Dim binding As New WebHttpBinding()
            Dim desc As ContractDescription = ContractDescription.GetContract(GetType(IService))
            Dim endpointAddress As New EndpointAddress("http://localhost:8000")
            Dim endpoint As New ServiceEndpoint(desc, binding, endpointAddress)

            Dim cf As New WebChannelFactory(Of IService)(endpoint)
            Dim channel As IService = cf.CreateChannel()
            Dim s As String

            Console.WriteLine("Calling EchoWithGet via HTTP GET: ")
            s = channel.EchoWithGet("Hello, world")
            Console.WriteLine("   Output:  0}", s)
        Catch ex As CommunicationException
            Console.WriteLine("An exception occurred: " + ex.Message)
        End Try
        ' </Snippet2>
    End Sub

    Public Shared Sub Snippet3()
        ' <Snippet3>
        Dim baseAddress As New Uri("http://localhost:8000")
        Dim host As New WebServiceHost(GetType(Service), baseAddress)
        Try
            host.Open()

            ' The endpoint name passed to the constructor must match an endpoint element
            ' in the application configuration file
            Dim cf As New WebChannelFactory(Of IService)("MyEndpoint")
            Dim channel As IService = cf.CreateChannel()
            Dim s As String

            Console.WriteLine("Calling EchoWithGet via HTTP GET: ")
            s = channel.EchoWithGet("Hello, world")
            Console.WriteLine("   Output:  0}", s)
        Catch ex As CommunicationException
            Console.WriteLine("An exception occurred: " + ex.Message)
        End Try
        ' </Snippet3>
    End Sub

    Public Shared Sub Snippet4()
        ' <Snippet4>
        Dim baseAddress As New Uri("http://localhost:8000")
        Dim host As New WebServiceHost(GetType(Service), baseAddress)
        Try
            host.Open()

            Dim cf As New WebChannelFactory(Of IService)(New Uri("http://localhost:8000"))
            Dim channel As IService = cf.CreateChannel()
            Dim s As String

            Console.WriteLine("Calling EchoWithGet via HTTP GET: ")
            s = channel.EchoWithGet("Hello, world")
            Console.WriteLine("   Output:  0}", s)
        Catch ex As CommunicationException
            Console.WriteLine("An exception occurred: " + ex.Message)
        End Try
        ' </Snippet4>
    End Sub

    Public Shared Sub Snippet5()
        ' <Snippet5>
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
            Console.WriteLine("   Output:  0}", s)
        Catch ex As CommunicationException
            Console.WriteLine("An exception occurred: " + ex.Message)
        End Try
        ' </Snippet5>
    End Sub

    Public Shared Sub Snippet6()
        ' <Snippet6>
        Dim baseAddress As New Uri("http://localhost:8000")
        Dim host As New WebServiceHost(GetType(Service), baseAddress)
        Try
            host.Open()

            ' The endpoint name passed to the constructor must match an endpoint element
            ' in the application configuration file
            Dim cf As New WebChannelFactory(Of IService)("MyEndpoint", New Uri("http://localhost:8000"))
            Dim channel As IService = cf.CreateChannel()
            Dim s As String

            Console.WriteLine("Calling EchoWithGet via HTTP GET: ")
            s = channel.EchoWithGet("Hello, world")
            Console.WriteLine("   Output:  0}", s)
        Catch ex As CommunicationException
            Console.WriteLine("An exception occurred: " + ex.Message)
        End Try
        ' </Snippet6>
    End Sub
End Class
