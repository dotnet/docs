' <Snippet2>
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.DynamicData

Partial Public Class DocSamples_DynamicDataDynamicHyperlink
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If Not IsPostBack Then
            ' Get the list of visible tables.
            Dim tables As System.Collections.IList = _
            ASP.global_asax.model.VisibleTables

            ' Throw an exception if there are no visible tables.
            If tables.Count = 0 Then
                Throw New InvalidOperationException()
            End If

            ' Bind the data-bound control to 
            ' the list of tables.
            GridView2.DataSource = tables
            GridView2.DataBind()
        End If
    End Sub

    Protected Sub DynamicHyperLink_DataBinding( _
    ByVal sender As Object,ByVal e As EventArgs)
        Dim table As MetaTable = DirectCast(GetDataItem(), MetaTable)
        Dim dynamicHyperLink As DynamicHyperLink = _
        DirectCast(sender, DynamicHyperLink)
        ' Set the context type name for the DynamicHyperLink.
        dynamicHyperLink.ContextTypeName = _
        table.DataContextType.AssemblyQualifiedName
    End Sub
End Class
' </Snippet2>
