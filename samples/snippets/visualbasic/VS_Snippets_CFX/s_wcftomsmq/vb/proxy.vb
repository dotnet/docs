
'  Copyright (c) Microsoft Corporation.  All Rights Reserved.

Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.ServiceModel.MsmqIntegration


' <Snippet6>
<System.ServiceModel.ServiceContractAttribute(Namespace:="http:'Microsoft.ServiceModel.Samples")> _
Public Interface IOrderProcessor
    <OperationContract(IsOneWay:=True, Action:="*")> _
    Sub SubmitPurchaseOrder(ByVal msg As MsmqMessage(Of PurchaseOrder))
end interface

Public Interface IOrderProcessorChannel
    Inherits IOrderProcessor, System.ServiceModel.IClientChannel
End Interface
' </Snippet6>

' <Snippet7>
Partial Public Class OrderProcessorProxy
    Inherits System.ServiceModel.ClientBase(Of IOrderProcessor)
    Implements IOrderProcessor

    Public Sub New()
    End Sub


    Public Sub New(ByVal configurationName As String)
        MyBase.New(configurationName)
    End Sub


    Public Sub New(ByVal binding As System.ServiceModel.Channels.Binding, ByVal address As System.ServiceModel.EndpointAddress)
        MyBase.New(binding, address)
    End Sub

    Public Sub SubmitPurchaseOrder(ByVal msg As MsmqMessage(Of PurchaseOrder)) Implements IOrderProcessor.SubmitPurchaseOrder
        MyBase.Channel.SubmitPurchaseOrder(msg)
    End Sub
End Class
' </Snippet7>

