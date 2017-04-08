Public Class Bid

    Private AmountValue As Integer
    Private BidderValue As User

#Region "Property Getters and Setters"
    Public ReadOnly Property Amount() As Integer
        Get
            Return AmountValue
        End Get
    End Property

    Public ReadOnly Property Bidder() As User
        Get
            Return BidderValue
        End Get
    End Property
#End Region

    Sub New(ByVal Amount As Integer, ByVal Bidder As User)
        Me.AmountValue = Amount
        Me.BidderValue = Bidder
    End Sub
End Class
