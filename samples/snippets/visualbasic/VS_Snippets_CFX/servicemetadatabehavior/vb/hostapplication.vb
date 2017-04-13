
Imports System
Imports System.Configuration
Imports System.Collections.Generic
Imports System.ServiceModel
Imports System.Text

Namespace Microsoft.WCF.Documentation

  Class HostApplication
    Shared Sub Main()
      Dim app As New HostApplication()
      app.Run()
    End Sub 'Main

    Private Sub Run()
      ' Create a ServiceHost for the service type and use the base address from configuration.
      Using serviceHost As ServiceHost = New ServiceHost(GetType(SampleService))
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
          Console.WriteLine("The service operation timed out. " + timeProblem.Message)
          Console.Read()
        Catch commProblem As CommunicationException
          Console.WriteLine("There was a communication problem. " + commProblem.Message)
          Console.Read()
        Finally
          serviceHost.Close()
        End Try
      End Using
    End Sub 'Run
  End Class 'HostApplication
End Namespace
