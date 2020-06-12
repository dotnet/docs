Imports System.Configuration
Imports System.ServiceModel
Imports System.Text

Namespace Microsoft.WCF.Documentation
    Friend Class HostApplication

        Shared Sub Main()
            Dim app As New HostApplication()
            app.Run()
        End Sub

        Private Sub Run()
            ' Create a ServiceHost for the service type and use the base address from config.
            Using serviceHost As New ServiceHost(GetType(MessagingHello))
                Try
                    ' Open the ServiceHostBase to create listeners and start listening for messages.
                    serviceHost.Open()

                    ' The service can now be accessed.
                    Console.WriteLine("The service is ready.")
                    Console.WriteLine("Press <ENTER> to terminate service.")
                    Console.WriteLine()
                    Console.ReadLine()

                    ' Close the ServiceHostBase to shutdown the service.
                    serviceHost.Close()
                Catch timeProblem As TimeoutException
                    Console.WriteLine("The service operation timed out. " & timeProblem.Message)
                Catch commProblem As CommunicationException
                    Console.WriteLine("There was a communication problem. " & commProblem.Message)
                End Try
            End Using
        End Sub
    End Class
End Namespace
