Class CustomerInfo

    Private p_CustomerID As Integer

    Public ReadOnly Property CustomerID() As Integer
        Get
            Return p_CustomerID
        End Get
    End Property

    ' Allow friend access to the empty constructor.
    Friend Sub New()

    End Sub

    ' Require that a customer identifier be specified for the public constructor.
    Public Sub New(ByVal customerID As Integer)
        p_CustomerID = customerID
    End Sub

    ' Allow friend programming elements to set the customer identifier.
    Friend Sub SetCustomerID(ByVal customerID As Integer)
        p_CustomerID = customerID
    End Sub
End Class