' <Snippet3>
Module LoginModule

    Sub Main()
        Dim username As String
        Dim password As String
        Dim studentid As String
        Dim answer As String
        Dim result As Boolean

        Console.Write("Enter user name:")
        username = Console.ReadLine()

        Console.Write("Enter password:")
        password = Console.ReadLine()

        Console.Write("Enter student identification number:")
        studentid = Console.ReadLine()

        Console.Write("Enter name of pet:")
        answer = Console.ReadLine()

        Dim binding As New BasicHttpBinding()
        binding.CloseTimeout = TimeSpan.MaxValue
        binding.OpenTimeout = TimeSpan.MaxValue
        binding.ReceiveTimeout = TimeSpan.MaxValue
        binding.SendTimeout = TimeSpan.MaxValue
        binding.AllowCookies = True

        Dim channelFactory As New ChannelFactory(Of AuthenticationService)(binding, New EndpointAddress("https://www.fabrikam.com/AuthSvc/Service.svc"))
        Dim clientService As AuthenticationService = channelFactory.CreateChannel()

        Try
            result = clientService.Login(username, password, studentid + "," + answer, True)
        Catch e As Exception
            Console.WriteLine("Sorry, login is currently not available.")
        End Try

        If (result) Then
            Console.WriteLine("Welcome " + username + ". You have logged in.")
        Else
            Console.WriteLine("We could not validate your credentials. Please try again.")
        End If
    End Sub

End Module
' </Snippet3>
