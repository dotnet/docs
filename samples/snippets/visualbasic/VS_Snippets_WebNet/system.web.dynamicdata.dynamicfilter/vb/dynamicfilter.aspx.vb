'<Snippet2> 
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


Partial Public Class ForeignKeyFilter
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

    ' <Snippet3> 
    ' Handle the filter change event.
    Protected Sub OnFilterSelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        ' Reset the index of the page to display after 
        ' the data filter value has been changed.
        GridView1.PageIndex = 0

    End Sub
   ' </Snippet3> 

End Class
'</Snippet2> 
