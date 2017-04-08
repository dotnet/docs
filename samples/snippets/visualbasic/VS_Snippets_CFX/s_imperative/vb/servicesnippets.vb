
Imports System

Imports System.ServiceModel.Channels
Imports System.ServiceModel
Imports System.ServiceModel.Description
Imports System.Collections.Generic

Namespace Microsoft.ServiceModel.Samples
	Public Class serviceSnippets
		Public Shared Sub Snippet3()
			' <Snippet3>
			 Dim baseAddress As New Uri("http://localhost:8000/servicemodelsamples/service")

			' Create a ServiceHost for the CalculatorService type and provide the base address.
			 Dim serviceHost As New ServiceHost(GetType(CalculatorService), baseAddress)

			' Create a custom binding that contains two binding elements.
			Dim reliableSession As New ReliableSessionBindingElement()
			reliableSession.Ordered = True

			Dim httpTransport As New HttpTransportBindingElement()
			httpTransport.AuthenticationScheme = System.Net.AuthenticationSchemes.Anonymous
			httpTransport.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard

			Dim elements(1) As BindingElement
			elements(0) = reliableSession
			elements(1) = httpTransport

			Dim binding As New CustomBinding(elements)
			' </Snippet3>

		   ' Add an endpoint using that binding.
			serviceHost.AddServiceEndpoint(GetType(ICalculator), binding, "")

			' Add a MEX endpoint.
			Dim smb As New ServiceMetadataBehavior()
			smb.HttpGetEnabled = True
			smb.HttpGetUrl = New Uri("http://localhost:8001/servicemodelsamples")
			serviceHost.Description.Behaviors.Add(smb)

			' Open the ServiceHostBase to create listeners and start listening for messages.
			serviceHost.Open()

			' The service can now be accessed.
			Console.WriteLine("The service is ready.")
			Console.WriteLine("Press <ENTER> to terminate service.")
			Console.WriteLine()
			Console.ReadLine()

			' Close the ServiceHostBase to shutdown the service.
			serviceHost.Close()
		End Sub

		Public Shared Sub Snippet4()
			' <Snippet4>
			Dim baseAddress As New Uri("http://localhost:8000/servicemodelsamples/service")

			' Create a ServiceHost for the CalculatorService type and provide the base address.
			Dim serviceHost As New ServiceHost(GetType(CalculatorService), baseAddress)

			' Create a custom binding that contains two binding elements.
			Dim reliableSession As New ReliableSessionBindingElement()
			reliableSession.Ordered = True

			Dim httpTransport As New HttpTransportBindingElement()
			httpTransport.AuthenticationScheme = System.Net.AuthenticationSchemes.Anonymous
			httpTransport.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard

			Dim coll As New SynchronizedCollection(Of BindingElement)()
			coll.Add(reliableSession)
			coll.Add(httpTransport)

			Dim binding As New CustomBinding(coll)
			' </Snippet4>

			' Add an endpoint using that binding.
			serviceHost.AddServiceEndpoint(GetType(ICalculator), binding, "")

			' Add a MEX endpoint.
			Dim smb As New ServiceMetadataBehavior()
			smb.HttpGetEnabled = True
			smb.HttpGetUrl = New Uri("http://localhost:8001/servicemodelsamples")
			serviceHost.Description.Behaviors.Add(smb)

			' Open the ServiceHostBase to create listeners and start listening for messages.
			serviceHost.Open()

			' The service can now be accessed.
			Console.WriteLine("The service is ready.")
			Console.WriteLine("Press <ENTER> to terminate service.")
			Console.WriteLine()
			Console.ReadLine()

			' Close the ServiceHostBase to shutdown the service.
			serviceHost.Close()
		End Sub

		Public Shared Sub Snippet5()
			' <Snippet5>
			Dim baseAddress As New Uri("http://localhost:8000/servicemodelsamples/service")

			' Create a ServiceHost for the CalculatorService type and provide the base address.
			Dim serviceHost As New ServiceHost(GetType(CalculatorService), baseAddress)

			' Create a custom binding that contains two binding elements.
			Dim reliableSession As New ReliableSessionBindingElement()
			reliableSession.Ordered = True

			Dim httpTransport As New HttpTransportBindingElement()
			httpTransport.AuthenticationScheme = System.Net.AuthenticationSchemes.Anonymous
			httpTransport.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard

			Dim elements(1) As BindingElement
			elements(0) = reliableSession
			elements(1) = httpTransport

			Dim binding As New CustomBinding("MyCustomBinding", "http://localhost/service", elements)
			' </Snippet5>

			' Add an endpoint using that binding.
			serviceHost.AddServiceEndpoint(GetType(ICalculator), binding, "")

			' Add a MEX endpoint.
			Dim smb As New ServiceMetadataBehavior()
			smb.HttpGetEnabled = True
			smb.HttpGetUrl = New Uri("http://localhost:8001/servicemodelsamples")
			serviceHost.Description.Behaviors.Add(smb)

			' Open the ServiceHostBase to create listeners and start listening for messages.
			serviceHost.Open()

			' The service can now be accessed.
			Console.WriteLine("The service is ready.")
			Console.WriteLine("Press <ENTER> to terminate service.")
			Console.WriteLine()
			Console.ReadLine()

			' Close the ServiceHostBase to shutdown the service.
			serviceHost.Close()
		End Sub

	End Class
End Namespace
