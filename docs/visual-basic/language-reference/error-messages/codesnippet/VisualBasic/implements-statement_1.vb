    Public Interface ICustomerInfo
        Event updateComplete()
        Property customerName() As String
        Sub updateCustomerStatus()
    End Interface

    Public Class customerInfo
        Implements ICustomerInfo
        ' Storage for the property value.
        Private customerNameValue As String
        Public Event updateComplete() Implements ICustomerInfo.updateComplete
        Public Property CustomerName() As String _
            Implements ICustomerInfo.customerName
            Get
                Return customerNameValue
            End Get
            Set(ByVal value As String)
                ' The value parameter is passed to the Set procedure
                ' when the contents of this property are modified.
                customerNameValue = value
            End Set
        End Property

        Public Sub updateCustomerStatus() _
            Implements ICustomerInfo.updateCustomerStatus
            ' Add code here to update the status of this account.
            ' Raise an event to indicate that this procedure is done.
            RaiseEvent updateComplete()
        End Sub
    End Class