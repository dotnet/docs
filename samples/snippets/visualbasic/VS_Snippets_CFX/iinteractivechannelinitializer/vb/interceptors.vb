
Imports System
Imports System.Collections.Generic
Imports System.ServiceModel
Imports System.ServiceModel.Description
Imports System.ServiceModel.Dispatcher
Imports System.Text

Namespace Microsoft.WCF.Documentation
  Public Class Inspector
	  Implements IDispatchMessageInspector, IParameterInspector, IClientMessageInspector
	#Region "IDispatchMessageInspector Members"

        Public Function AfterReceiveRequest(ByRef request As System.ServiceModel.Channels.Message, ByVal channel As IClientChannel, _
                                            ByVal instanceContext As InstanceContext) As Object Implements IDispatchMessageInspector.AfterReceiveRequest
            Console.WriteLine("IDispatchMessageInspector.AfterReceiveRequest called.")
            Return Nothing
        End Function

	Public Sub BeforeSendReply(ByRef reply As System.ServiceModel.Channels.Message, ByVal correlationState As Object) Implements IDispatchMessageInspector.BeforeSendReply
	  Console.WriteLine("IDispatchMessageInspector.BeforeSendReply called.")
	End Sub

	#End Region

	' <snippet4>
	#Region "IParameterInspector Members"
        Public Sub AfterCall(ByVal operationName As String, ByVal outputs() As Object, ByVal returnValue As Object, ByVal correlationState As Object) _
        Implements IParameterInspector.AfterCall
            Console.WriteLine("IParameterInspector.AfterCall called for {0} with return value {1}.", operationName, returnValue.ToString())
        End Sub

	Public Function BeforeCall(ByVal operationName As String, ByVal inputs() As Object) As Object Implements IParameterInspector.BeforeCall
	  Console.WriteLine("IParameterInspector.BeforeCall called for {0}.", operationName)
	  Return Nothing
	End Function
	' </snippet4>

	#End Region

	'<snippet1>
	#Region "IClientMessageInspector Members"
        Public Sub AfterReceiveReply(ByRef reply As System.ServiceModel.Channels.Message, ByVal correlationState As Object) _
        Implements IClientMessageInspector.AfterReceiveReply
            Console.WriteLine("IClientMessageInspector.AfterReceiveReply called.")
            Console.WriteLine("Message: {0}", reply.ToString())
        End Sub

        Public Function BeforeSendRequest(ByRef request As System.ServiceModel.Channels.Message, ByVal channel As IClientChannel) As Object _
        Implements IClientMessageInspector.BeforeSendRequest
            Console.WriteLine("IClientMessageInspector.BeforeSendRequest called.")
            Return Nothing
        End Function
	'</snippet1>
	#End Region
  End Class
End Namespace
