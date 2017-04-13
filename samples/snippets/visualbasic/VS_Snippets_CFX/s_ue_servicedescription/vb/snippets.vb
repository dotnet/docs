
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ServiceModel
Imports System.ServiceModel.Description

Namespace ServiceDescriptionSnippet
	Friend Class MyCustomBehavior
		Implements IServiceBehavior
		#Region "IServiceBehavior Members"

		Public Sub AddBindingParameters(ByVal serviceDescription As ServiceDescription, ByVal serviceHostBase As ServiceHostBase, ByVal endpoints As System.Collections.ObjectModel.Collection(Of ServiceEndpoint), ByVal bindingParameters As System.ServiceModel.Channels.BindingParameterCollection) Implements IServiceBehavior.AddBindingParameters
			Throw New Exception("The method or operation is not implemented.")
		End Sub

		Public Sub ApplyDispatchBehavior(ByVal serviceDescription As ServiceDescription, ByVal serviceHostBase As ServiceHostBase) Implements IServiceBehavior.ApplyDispatchBehavior
			Throw New Exception("The method or operation is not implemented.")
		End Sub

		Public Sub Validate(ByVal serviceDescription As ServiceDescription, ByVal serviceHostBase As ServiceHostBase) Implements IServiceBehavior.Validate
			Throw New Exception("The method or operation is not implemented.")
		End Sub

		#End Region
	End Class

	Friend Class Snippets
		Public Sub Snippet3()
			' <Snippet3>
			Dim baseAddress As New Uri("http://localhost:8001/Simple")
			Dim serviceHost As New ServiceHost(GetType(CalculatorService), baseAddress)

			serviceHost.AddServiceEndpoint(GetType(ICalculator), New WSHttpBinding(), "CalculatorServiceObject")

			' Enable Mex
			Dim smb As New ServiceMetadataBehavior()
			smb.HttpGetEnabled = True
			serviceHost.Description.Behaviors.Add(smb)

			Dim sd As ServiceDescription = serviceHost.Description
			sd.Behaviors.Add(New MyCustomBehavior())

			serviceHost.Open()
			' </Snippet3>

		End Sub

		Public Sub Snippet9()
			' <Snippet9>
			Dim d As ServiceDescription = ServiceDescription.GetService(GetType(CalculatorService))
			For Each isb As IServiceBehavior In d.Behaviors
				Console.WriteLine(CType(isb, Object).GetType())
			Next isb
			Console.WriteLine()
			' </Snippet9>
		End Sub

		Public Sub Snippet10()
			' <Snippet10>
			Dim d As ServiceDescription = ServiceDescription.GetService(New CalculatorService())
			For Each isb As IServiceBehavior In d.Behaviors
				Console.WriteLine(CType(isb, Object).GetType())
			Next isb
			Console.WriteLine()
			' </Snippet10>
		End Sub
	End Class
End Namespace
