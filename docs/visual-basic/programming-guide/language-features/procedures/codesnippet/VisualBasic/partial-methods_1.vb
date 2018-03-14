Partial Class Product

    Private _Quantity As Integer

    Property Quantity() As Integer
        Get
            Return _Quantity
        End Get
        Set(ByVal value As Integer)
            _Quantity = value
            QuantityChanged()
        End Set
    End Property

    ' Provide a signature for the partial method.
    Partial Private Sub QuantityChanged()
    End Sub
End Class