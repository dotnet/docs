' <snippet5>
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.ServiceModel.Configuration
Imports System.ServiceModel.Description
Imports System.ServiceModel.Dispatcher
Imports System.Text

Namespace Microsoft.WCF.Documentation
  Public Class InspectorInserter
	  Inherits BehaviorExtensionElement
	  Implements IServiceBehavior, IEndpointBehavior, IOperationBehavior
	' <snippet8>
	#Region "IServiceBehavior Members"
        Public Sub AddBindingParameters(ByVal serviceDescription As ServiceDescription, _
                       ByVal serviceHostBase As ServiceHostBase, ByVal endpoints As  _
                       System.Collections.ObjectModel.Collection(Of ServiceEndpoint), _
                       ByVal bindingParameters As BindingParameterCollection) Implements IServiceBehavior.AddBindingParameters
            Return
        End Sub

        Public Sub ApplyDispatchBehavior(ByVal serviceDescription As ServiceDescription, _
                                         ByVal serviceHostBase As ServiceHostBase) Implements _
                                         IServiceBehavior.ApplyDispatchBehavior
            For Each chDisp As ChannelDispatcher In serviceHostBase.ChannelDispatchers
                For Each epDisp As EndpointDispatcher In chDisp.Endpoints
                    epDisp.DispatchRuntime.MessageInspectors.Add(New Inspector())
                    For Each op As DispatchOperation In epDisp.DispatchRuntime.Operations
                        op.ParameterInspectors.Add(New Inspector())
                    Next op
                Next epDisp
            Next chDisp
        End Sub
	' </snippet8>

        Public Sub Validate(ByVal serviceDescription As ServiceDescription, ByVal serviceHostBase As ServiceHostBase) _
        Implements IServiceBehavior.Validate
            Return
        End Sub

	#End Region
	'<snippet2>
	#Region "IEndpointBehavior Members"
        Public Sub AddBindingParameters(ByVal endpoint As ServiceEndpoint, ByVal bindingParameters _
                                        As BindingParameterCollection) Implements IEndpointBehavior.AddBindingParameters
            Return
        End Sub

        Public Sub ApplyClientBehavior(ByVal endpoint As ServiceEndpoint, ByVal clientRuntime As ClientRuntime) _
        Implements IEndpointBehavior.ApplyClientBehavior
            clientRuntime.MessageInspectors.Add(New Inspector())
            For Each op As ClientOperation In clientRuntime.Operations
                op.ParameterInspectors.Add(New Inspector())
            Next op
        End Sub

        Public Sub ApplyDispatchBehavior(ByVal endpoint As ServiceEndpoint, ByVal endpointDispatcher As  _
                                         EndpointDispatcher) Implements IEndpointBehavior.ApplyDispatchBehavior
            endpointDispatcher.DispatchRuntime.MessageInspectors.Add(New Inspector())
            For Each op As DispatchOperation In endpointDispatcher.DispatchRuntime.Operations
                op.ParameterInspectors.Add(New Inspector())
            Next op
        End Sub

	Public Sub Validate(ByVal endpoint As ServiceEndpoint) Implements IEndpointBehavior.Validate
		Return
	End Sub
	'</snippet2>
	#End Region
	' <snippet6>
	#Region "IOperationBehavior Members"
        Public Sub AddBindingParameters(ByVal operationDescription As OperationDescription, _
                                        ByVal bindingParameters As BindingParameterCollection) Implements _
                                        IOperationBehavior.AddBindingParameters
            Return
        End Sub

        Public Sub ApplyClientBehavior(ByVal operationDescription As OperationDescription, ByVal _
                                       clientOperation As ClientOperation) Implements IOperationBehavior.ApplyClientBehavior
            clientOperation.ParameterInspectors.Add(New Inspector())
        End Sub

        Public Sub ApplyDispatchBehavior(ByVal operationDescription As OperationDescription, ByVal dispatchOperation As  _
                                         DispatchOperation) Implements IOperationBehavior.ApplyDispatchBehavior
            dispatchOperation.ParameterInspectors.Add(New Inspector())
        End Sub

	Public Sub Validate(ByVal operationDescription As OperationDescription) Implements IOperationBehavior.Validate
		Return
	End Sub
	' </snippet6>

	#End Region

	Public Overrides ReadOnly Property BehaviorType() As Type
	  Get
		  Return GetType(InspectorInserter)
	  End Get
	End Property

	Protected Overrides Function CreateBehavior() As Object
		Return New InspectorInserter()
	End Function
  End Class
End Namespace
' </snippet5>
