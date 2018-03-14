' <snippet4>

Imports System
Imports System.Collections.Generic
Imports System.ServiceModel
Imports System.ServiceModel.Configuration
Imports System.ServiceModel.Description
Imports System.ServiceModel.Dispatcher
Imports System.Text
Imports System.Xml

Namespace Microsoft.WCF.Documentation
  ' <snippet1>
  Public Class ObjectProviderBehavior
	  Implements IInstanceProvider

	Private message As String
	Private service As SampleService = Nothing

	Public Sub New(ByVal msg As String)
	  Console.WriteLine("The non-default constructor has been called.")
	  Me.message = msg
	  Me.service = New SampleService("Singleton sample service.")
	End Sub

	#Region "IInstanceProvider Members"

	Public Function GetInstance(ByVal instanceContext As InstanceContext, ByVal message As System.ServiceModel.Channels.Message) As Object Implements IInstanceProvider.GetInstance
	  Console.WriteLine("GetInstance is called:")
	  Return Me.service
	End Function

	Public Function GetInstance(ByVal instanceContext As InstanceContext) As Object Implements IInstanceProvider.GetInstance
	  Console.WriteLine("GetInstance is called:")
	  Return Me.service
	End Function

	Public Sub ReleaseInstance(ByVal instanceContext As InstanceContext, ByVal instance As Object) Implements IInstanceProvider.ReleaseInstance
	  Console.WriteLine("ReleaseInstance is called. The SingletonBehaviorAttribute never releases.")
	End Sub

	#End Region
  End Class
  ' </snippet1>

  ' <snippet2>
  Public Class SingletonBehaviorAttribute
	  Inherits Attribute
	  Implements IContractBehaviorAttribute, IContractBehavior

	#Region "IContractBehaviorAttribute Members"

	Public ReadOnly Property TargetContract() As Type Implements IContractBehaviorAttribute.TargetContract
	  Get
		  Return GetType(ISampleService)
	  End Get
	End Property

	#End Region

	#Region "IContractBehavior Members"

	Public Sub AddBindingParameters(ByVal description As ContractDescription, ByVal endpoint As ServiceEndpoint, ByVal parameters As System.ServiceModel.Channels.BindingParameterCollection) Implements IContractBehavior.AddBindingParameters
	  Return
	End Sub

	Public Sub ApplyClientBehavior(ByVal description As ContractDescription, ByVal endpoint As ServiceEndpoint, ByVal clientRuntime As ClientRuntime) Implements IContractBehavior.ApplyClientBehavior
	  Return
	End Sub

	Public Sub ApplyDispatchBehavior(ByVal description As ContractDescription, ByVal endpoint As ServiceEndpoint, ByVal dispatch As DispatchRuntime) Implements IContractBehavior.ApplyDispatchBehavior
	  dispatch.InstanceProvider = New ObjectProviderBehavior("Custom ObjectProviderBehavior constructor.")
	End Sub

	Public Sub Validate(ByVal description As ContractDescription, ByVal endpoint As ServiceEndpoint) Implements IContractBehavior.Validate
	  Return
	End Sub

	#End Region
  End Class
  ' </snippet2>
End Namespace
' </snippet4>
