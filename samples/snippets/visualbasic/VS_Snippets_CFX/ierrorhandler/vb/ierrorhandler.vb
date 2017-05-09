' <snippet5>

Imports System
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.ServiceModel.Configuration
Imports System.ServiceModel.Description
Imports System.ServiceModel.Dispatcher

Namespace Microsoft.WCF.Documentation

  Public Class EnforceGreetingFaultBehavior
	  Inherits BehaviorExtensionElement
	  Implements IErrorHandler, IServiceBehavior
	Public Sub New()
		Console.WriteLine("EnforceGreetingFaultBehavior created.")
	End Sub

	Protected Overrides Function CreateBehavior() As Object
		Return Me
	End Function

	Public Overrides ReadOnly Property BehaviorType() As Type
	  Get
		  Return GetType(EnforceGreetingFaultBehavior)
	  End Get
	End Property

	' <snippet6>
	#Region "IErrorHandler Members"
	Public Function HandleError(ByVal [error] As Exception) As Boolean Implements IErrorHandler.HandleError
	  Console.WriteLine("HandleError called.")
	  ' Returning true indicates you performed your behavior.
	  Return True
	End Function

	' This is a trivial implementation that converts Exception to FaultException<GreetingFault>.
	Public Sub ProvideFault(ByVal [error] As Exception, ByVal ver As MessageVersion, ByRef msg As Message) Implements IErrorHandler.ProvideFault
	  Console.WriteLine("ProvideFault called. Converting Exception to GreetingFault....")
	  Dim fe As New FaultException(Of GreetingFault)(New GreetingFault([error].Message))
	  Dim fault As MessageFault = fe.CreateMessageFault()
	  msg = Message.CreateMessage(ver, fault, "http://microsoft.wcf.documentation/ISampleService/SampleMethodGreetingFaultFault")
	End Sub
	#End Region
	' </snippet6>

	' <snippet7>
	' This behavior modifies no binding parameters.
	#Region "IServiceBehavior Members"
	Public Sub AddBindingParameters(ByVal description As ServiceDescription, ByVal serviceHostBase As ServiceHostBase, ByVal endpoints As System.Collections.ObjectModel.Collection(Of ServiceEndpoint), ByVal parameters As System.ServiceModel.Channels.BindingParameterCollection) Implements IServiceBehavior.AddBindingParameters
	  Return
	End Sub

	' This behavior is an IErrorHandler implementation and 
	' must be applied to each ChannelDispatcher.
	Public Sub ApplyDispatchBehavior(ByVal description As ServiceDescription, ByVal serviceHostBase As ServiceHostBase) Implements IServiceBehavior.ApplyDispatchBehavior
	  Console.WriteLine("The EnforceGreetingFaultBehavior has been applied.")
	  For Each chanDisp As ChannelDispatcher In serviceHostBase.ChannelDispatchers
		chanDisp.ErrorHandlers.Add(Me)
	  Next chanDisp
	End Sub

	' This behavior requires that the contract have a SOAP fault with a detail type of GreetingFault.
	Public Sub Validate(ByVal description As ServiceDescription, ByVal serviceHostBase As ServiceHostBase) Implements IServiceBehavior.Validate
	  Console.WriteLine("Validate is called.")
	  For Each se As ServiceEndpoint In description.Endpoints
		' Must not examine any metadata endpoint.
		If se.Contract.Name.Equals("IMetadataExchange") AndAlso se.Contract.Namespace.Equals("http://schemas.microsoft.com/2006/04/mex") Then
		  Continue For
		End If
		For Each opDesc As OperationDescription In se.Contract.Operations
		  If opDesc.Faults.Count = 0 Then
			Throw New InvalidOperationException(String.Format("EnforceGreetingFaultBehavior requires a " & "FaultContractAttribute(typeof(GreetingFault)) in each operation contract.  " & "The ""{0}"" operation contains no FaultContractAttribute.", opDesc.Name))
		  End If
		  Dim gfExists As Boolean = False
		  For Each fault As FaultDescription In opDesc.Faults
			If fault.DetailType.Equals(GetType(GreetingFault)) Then
			  gfExists = True
			  Continue For
			End If
		  Next fault
		  If gfExists = False Then
			Throw New InvalidOperationException("EnforceGreetingFaultBehavior requires a FaultContractAttribute(typeof(GreetingFault)) in an operation contract.")
		  End If
		Next opDesc
	  Next se
	End Sub
	#End Region
	' </snippet7>
  End Class
End Namespace
' </snippet5>
