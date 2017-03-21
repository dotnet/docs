        ' Host the service within this EXE console application.
        Public Shared Sub Main()
            ' Create a ServiceHost for the CalculatorService type and use the base address from config.
            Using svcHost As New ServiceHost(GetType(CalculatorService))
                Try
                    ' Open the ServiceHost to start listening for messages.
                    svcHost.Open()

                    ' The service can now be accessed.
                    Console.WriteLine("The service is ready.")
                    Console.WriteLine("Press <ENTER> to terminate service.")
                    Console.WriteLine()
                    Console.ReadLine()

                    'Close the ServiceHost.
                    svcHost.Close()

                Catch timeout As TimeoutException
                    Console.WriteLine(timeout.Message)
                    Console.ReadLine()
                Catch commException As CommunicationException
                    Console.WriteLine(commException.Message)
                    Console.ReadLine()
                End Try
            End Using

        End Sub
