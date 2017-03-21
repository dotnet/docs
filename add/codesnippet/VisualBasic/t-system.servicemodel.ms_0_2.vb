    <ServiceContract(Namespace:="http:'Microsoft.ServiceModel.Samples")> _
    <ServiceKnownType(GetType(PurchaseOrder))> _
    Public Interface IOrderProcessor
        <OperationContract(IsOneWay:=True, Action:="*")> _
        Sub SubmitPurchaseOrder(ByVal msg As MsmqMessage(Of PurchaseOrder))
    End Interface