    Protected Sub LinqDataSource_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs)
        If (IsOnlineSale) Then
            e.SelectParameters.Add("Discount", OnlineDiscount)
        Else
            e.SelectParameters.Add("Discount", 0)
        End If
    End Sub