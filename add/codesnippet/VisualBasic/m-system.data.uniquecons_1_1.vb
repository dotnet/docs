Private Sub CompareConstraints()
    Dim constraintCustomerOrders As UniqueConstraint
    Dim constraintOrderDetails As UniqueConstraint
    Dim relationCustomerOrders As DataRelation
    Dim relationOrderDetails As DataRelation

    ' Get a DataRelation from a DataSet.
    relationCustomerOrders = DataSet1.Relations("CustomerOrders")

    '  Get a constraint.
    constraintCustomerOrders = relationCustomerOrders.ParentKeyConstraint

    ' Get a second relation and constraint.
    relationOrderDetails = DataSet1.Relations("OrderDetails")
    constraintOrderDetails = relationOrderDetails.ParentKeyConstraint

    ' Compare the two.
    Console.WriteLine( _
        constraintCustomerOrders.Equals(constraintOrderDetails).ToString())
 End Sub