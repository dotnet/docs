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
