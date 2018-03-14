    Private Sub AddCustomer()
        Dim theCustomer As New Customer

        With theCustomer
            .Name = "Coho Vineyard"
            .URL = "http://www.cohovineyard.com/"
            .City = "Redmond"
        End With

        With theCustomer.Comments
            .Add("First comment.")
            .Add("Second comment.")
        End With
    End Sub

    Public Class Customer
        Public Property Name As String
        Public Property City As String
        Public Property URL As String

        Public Property Comments As New List(Of String)
    End Class