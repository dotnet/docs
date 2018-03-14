Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Linq
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

Partial Public Class Default2
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs)

    End Sub

    '<Snippet2>
    Protected Sub LinqDataSource_Selecting(sender As Object, e As LinqDataSourceSelectEventArgs)
        Dim exampleContext As New ExampleDataContext()

        e.Result = From p In exampleContext.Products Where p.Category = "Beverages"
                   Select New With { _
                        Key .ID = p.ProductID, _
                        Key .Name = p.Name _
        }
    End Sub
    '</Snippet2>
End Class
