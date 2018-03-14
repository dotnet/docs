Imports System.Collections.Specialized

Partial Class Default3
    Inherits System.Web.UI.Page

    '<Snippet1>
    Protected Sub Add_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim keyValues As New ListDictionary()
        Dim newValues As New ListDictionary()
        Dim oldValues As New ListDictionary()

        keyValues.Add("ProductID", Int32.Parse(CType(DetailsView1.FindControl("IDLabel"), Label).Text))

        oldValues.Add("ProductName", CType(DetailsView1.FindControl("NameLabel"), Label).Text)
        oldValues.Add("ProductCategory", CType(DetailsView1.FindControl("CategoryLabel"), Label).Text)
        oldValues.Add("Color", CType(DetailsView1.FindControl("ColorLabel"), Label).Text)

        newValues.Add("ProductName", "New Product")
        newValues.Add("ProductCategory", "General")
        newValues.Add("Color", "Not assigned")

        LinqDataSource1.Update(keyValues, newValues, oldValues)

        DetailsView1.DataBind()
    End Sub
    '</Snippet1>
End Class
