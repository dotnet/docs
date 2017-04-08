'<Snippet3>
Imports System
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
Imports System.Xml.Linq
Imports System.Web.DynamicData


Partial Public Class QueryableFilterRepeaterSample
    Inherits System.Web.UI.Page
    Protected table As MetaTable

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
        'setSelectionFromUrl
        DynamicDataManager1.RegisterControl(GridView1, True)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        table = GridDataSource.GetTable()
        Title = table.DisplayName

        ' Disable various options if the table is readonly
        If table.IsReadOnly Then
            GridView1.Columns(0).Visible = False
        End If
    End Sub

    ' Handle the filter change event.
    ' This function resets the index of the page to display.
    Protected Sub OnFilterSelectionChanged(ByVal sender As Object, ByVal e As EventArgs)
        GridView1.PageIndex = 0
    End Sub
End Class
'</Snippet3>

