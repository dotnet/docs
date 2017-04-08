
Imports System
Imports System.Configuration
Imports System.Collections.Generic
Imports System.ServiceModel
Imports System.ServiceModel.Description


Namespace Microsoft.WCF.Documentation
  Friend Class HostApplication

	Shared Sub Main()
	  Dim app As New HostApplication()
	  app.Run()
	End Sub

	' <snippet1>
	Private Sub Run()
	  ' Create a ServiceHost for the service type and use the base address from configuration.
	  Using serviceHost As New ServiceHost(GetType(SampleService))
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
			Console.Read()
		  Catch commProblem As CommunicationException
			Console.WriteLine("There was a communication problem. " & commProblem.Message)
			Console.Read()
		  End Try
	  End Using
	  ' </snippet1>
	End Sub
  End Class
End Namespace
