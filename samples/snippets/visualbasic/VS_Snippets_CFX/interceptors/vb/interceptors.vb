Imports System.ServiceModel
Imports System.ServiceModel.Description
Imports System.ServiceModel.Dispatcher
Imports System.Text

Namespace Microsoft.WCF.Documentation
    Public Class Inspector
        Implements IDispatchMessageInspector, IParameterInspector, IClientMessageInspector
        ' <snippet7>
#Region "IDispatchMessageInspector Members"
        Public Function AfterReceiveRequest(ByRef request As System.ServiceModel.Channels.Message, _
                           ByVal channel As IClientChannel, ByVal instanceContext As InstanceContext) _
                           As Object Implements IDispatchMessageInspector.AfterReceiveRequest
            Console.WriteLine("IDispatchMessageInspector.AfterReceiveRequest called.")
            Return Nothing
        End Function

        Public Sub BeforeSendReply(ByRef reply As System.ServiceModel.Channels.Message, ByVal correlationState As Object) _
        Implements IDispatchMessageInspector.BeforeSendReply
            Console.WriteLine("IDispatchMessageInspector.BeforeSendReply called.")
        End Sub
#End Region
        ' </snippet7>

        ' <snippet4>
#Region "IParameterInspector Members"
        Public Sub AfterCall(ByVal operationName As String, ByVal outputs() As Object, ByVal returnValue As Object, _
                             ByVal correlationState As Object) Implements IParameterInspector.AfterCall
            Console.WriteLine("IParameterInspector.AfterCall called for {0} with return value {1}.", _
                              operationName, returnValue.ToString())
        End Sub

        Public Function BeforeCall(ByVal operationName As String, ByVal inputs() As Object) As Object Implements _
        IParameterInspector.BeforeCall
            Console.WriteLine("IParameterInspector.BeforeCall called for {0}.", operationName)
            Return Nothing
        End Function
        ' </snippet4>

#End Region

        '<snippet1>
#Region "IClientMessageInspector Members"
        Public Sub AfterReceiveReply(ByRef reply As System.ServiceModel.Channels.Message, _
                           ByVal correlationState As Object) Implements IClientMessageInspector.AfterReceiveReply
            Console.WriteLine("IClientMessageInspector.AfterReceiveReply called.")
            Console.WriteLine("Message: {0}", reply.ToString())
        End Sub

        Public Function BeforeSendRequest(ByRef request As System.ServiceModel.Channels.Message, _
                ByVal channel As IClientChannel) As Object Implements IClientMessageInspector.BeforeSendRequest
            Console.WriteLine("IClientMessageInspector.BeforeSendRequest called.")
            Return Nothing
        End Function
        '</snippet1>
#End Region
    End Class
End Namespace
