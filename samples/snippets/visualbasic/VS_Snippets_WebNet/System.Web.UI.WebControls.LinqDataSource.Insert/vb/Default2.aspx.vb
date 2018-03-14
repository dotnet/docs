
Partial Class Default2
    Inherits System.Web.UI.Page

    '<Snippet1>
    Protected Sub Add_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim listDictionary As New System.Collections.Specialized.ListDictionary()
        listDictionary.Add("ProductName", TextBox1.Text)
        listDictionary.Add("ProductCategory", "General")
        listDictionary.Add("Color", "Not assigned")
        listDictionary.Add("ListPrice", Nothing)
        LinqDataSource1.Insert(listDictionary)

        TextBox1.Text = String.Empty
        DetailsView1.DataBind()
    End Sub
    '</Snippet1>
End Class
