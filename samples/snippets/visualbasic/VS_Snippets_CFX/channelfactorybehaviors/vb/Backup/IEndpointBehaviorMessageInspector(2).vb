' <snippet1>


Imports System.Collections.Generic
Imports System.ServiceModel
Imports System.ServiceModel.Configuration
Imports System.ServiceModel.Description
Imports System.ServiceModel.Dispatcher
Imports System.Text

Namespace Microsoft.WCF.Documentation
    Friend Class EndpointBehaviorMessageInspector
        Inherits BehaviorExtensionElement
        Implements IEndpointBehavior, IDispatchMessageInspector, IClientMessageInspector
        '<snippet4>
        ' IEndpointBehavior Members
        Public Sub AddBindingParameters(ByVal serviceEndpoint As ServiceEndpoint, ByVal bindingParameters As System.ServiceModel.Channels.BindingParameterCollection) Implements IEndpointBehavior.AddBindingParameters
            Return
        End Sub

        Public Sub ApplyClientBehavior(ByVal serviceEndpoint As ServiceEndpoint, ByVal behavior As ClientRuntime) Implements IEndpointBehavior.ApplyClientBehavior
            behavior.MessageInspectors.Add(New EndpointBehaviorMessageInspector())
        End Sub

        Public Sub ApplyDispatchBehavior(ByVal serviceEndpoint As ServiceEndpoint, ByVal endpointDispatcher As EndpointDispatcher) Implements IEndpointBehavior.ApplyDispatchBehavior
            endpointDispatcher.DispatchRuntime.MessageInspectors.Add(New EndpointBehaviorMessageInspector())
        End Sub

        Public Sub Validate(ByVal serviceEndpoint As ServiceEndpoint) Implements IEndpointBehavior.Validate
            Return
        End Sub
        '</snippet4>

        '<snippet3>
        ' BehaviorExtensionElement members
        Public Overrides ReadOnly Property BehaviorType() As Type
            Get
                Return GetType(EndpointBehaviorMessageInspector)
            End Get
        End Property

        Protected Overrides Function CreateBehavior() As Object
            Return New EndpointBehaviorMessageInspector()
        End Function
        '</snippet3>

        '<snippet2>
        ' IDispatchMessageInspector Members

        Public Function AfterReceiveRequest(ByRef request As System.ServiceModel.Channels.Message, ByVal channel As IClientChannel, ByVal instanceContext As InstanceContext) As Object Implements IDispatchMessageInspector.AfterReceiveRequest
            Console.WriteLine("AfterReceiveRequest called.")
            Return Nothing
        End Function

        Public Sub BeforeSendReply(ByRef reply As System.ServiceModel.Channels.Message, ByVal correlationState As Object) Implements IDispatchMessageInspector.BeforeSendReply
            Console.WriteLine("BeforeSendReply called.")
        End Sub
        '</snippet2>


#Region "IClientMessageInspector Members"

        Public Sub AfterReceiveReply(ByRef reply As System.ServiceModel.Channels.Message, ByVal correlationState As Object) Implements IClientMessageInspector.AfterReceiveReply
            Console.WriteLine("AfterReceiveReply called.")
        End Sub

        Public Function BeforeSendRequest(ByRef request As System.ServiceModel.Channels.Message, ByVal channel As IClientChannel) As Object Implements IClientMessageInspector.BeforeSendRequest
            Console.WriteLine("BeforeSendRequest called.")
            Return Nothing
        End Function

#End Region
    End Class
End Namespace
' </snippet1>
