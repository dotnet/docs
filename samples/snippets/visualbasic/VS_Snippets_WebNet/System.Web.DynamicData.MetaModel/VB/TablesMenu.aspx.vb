' <Snippet6> 
Imports System
Imports System.Collections
Imports System.Configuration
Imports System.Data
Imports System.Linq
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Xml.Linq
Imports System.Web.DynamicData
Imports System.Text

Partial Public Class _TablesMenu
    Inherits System.Web.UI.Page

    'Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
    '    GetVisibleTables()
    '    GetTables()
    'End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

        'Dim visibleTables As System.Collections.IList = MetaModel.Default.VisibleTables
        'If (visibleTables.Count = 0) Then
        '    Throw New InvalidOperationException("There are no accessible tables. Make sure that at least one data model is registered in Global.asax a" & _
        '        "nd scaffolding is enabled or implement custom pages.")
        'End If
        'Menu1.DataSource = visibleTables
        'Menu1.DataBind()

        GetVisibleTables()
        GetTables()

    End Sub

    ' <Snippet61> 
    ' Gets all the tables in the data model.
    Protected Sub GetTables()
        Dim tables As System.Collections.IList = MetaModel.[Default].Tables
        If tables.Count = 0 Then
            Throw New InvalidOperationException("There are no tables in the data model.")
        End If
        Menu2.DataSource = tables
        Menu2.DataBind()
    End Sub
    ' </Snippet61> 

    ' <Snippet62> 
    ' Gets only the visible tables in the data model.
    Protected Sub GetVisibleTables()
        Dim visibleTables As System.Collections.IList = MetaModel.[Default].VisibleTables
        If visibleTables.Count = 0 Then
            Throw New InvalidOperationException("There are no accessible tables. Make sure that at least one data model is registered in Global.asax and scaffolding is enabled or implement custom pages.")
        End If
        Menu1.DataSource = visibleTables
        Menu1.DataBind()
    End Sub
    ' </Snippet62> 
End Class
' </Snippet6> 
