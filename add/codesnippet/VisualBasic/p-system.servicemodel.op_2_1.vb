    Private Sub Run()
        Dim b As New WSHttpBinding()
        b.Name = "HttpOrderedReliableSessionBinding"

        ' Get a reference to the OptionalreliableSession object of the 
        ' binding and set its properties to new values.
        Dim myReliableSession As OptionalReliableSession = b.ReliableSession
        myReliableSession.Enabled = True ' The default is false.
        myReliableSession.Ordered = False ' The default is true. 
        myReliableSession.InactivityTimeout = New TimeSpan(0, 15, 0)
        ' The default is 10 minutes.
        ' Create a URI for the service's base address.
        Dim baseAddress As New Uri("http://localhost:8008/Calculator")

        ' Create a service host.
        Dim sh As New ServiceHost(GetType(Calculator), baseAddress)

        ' Optional: Print out the binding information. 
        PrintBindingInfo(b)
        ' Create a URI for an endpoint, then add a service endpoint using the
        ' binding with the latered OptionalReliableSession settings.
        sh.AddServiceEndpoint(GetType(ICalculator), b, "ReliableCalculator")
        sh.Open()

        Console.WriteLine("Listening...")
        Console.ReadLine()
        sh.Close()
    End Sub

    Private Sub PrintBindingInfo(ByVal b As WSHttpBinding)
        Console.WriteLine(b.Name)
        Console.WriteLine("Enabled: {0}", b.ReliableSession.Enabled)
        Console.WriteLine("Ordered: {0}", b.ReliableSession.Ordered)
        Console.WriteLine("Inactivity in Minutes: {0}", b.ReliableSession.InactivityTimeout.TotalMinutes)

    End Sub