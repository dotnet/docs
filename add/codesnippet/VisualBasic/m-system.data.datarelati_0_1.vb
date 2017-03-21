Public Shared Sub AddRelations(dataSet As DataSet)
	Dim customerOrders As DataRelation = _
        New DataRelation("CustomerOrders", _
	    dataSet.Tables("Customers").Columns("customerId"), _
	    dataSet.Tables("Orders").Columns("customerId"))
	Dim orderDetails As DataRelation = _
        New DataRelation("OrderDetail", _
	    dataSet.Tables("Orders").Columns("orderId"), _
	    dataSet.Tables("OrderDetails").Columns("orderId"))

	dataSet.Relations.AddRange(New DataRelation() _
        {customerOrders, orderDetails})

	' Display names of all relations.
	Dim relation As DataRelation
	For Each relation In dataSet.Relations
	  Console.WriteLine(relation.RelationName.ToString())
	Next
End Sub