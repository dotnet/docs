    Public Class OrderProcessorService
        Implements IOrderProcessor

        <OperationBehavior(TransactionScopeRequired:=True, TransactionAutoComplete:=True)> _
        Public Sub SubmitPurchaseOrder(ByVal ordermsg As MsmqMessage(Of PurchaseOrder)) Implements IOrderProcessor.SubmitPurchaseOrder
            Dim po As PurchaseOrder = ordermsg.Body
            Dim statusIndexer As New Random()
            po.Status = statusIndexer.Next(3)
            Console.WriteLine("Processing {0} ", po)
        End Sub
    End Class