Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

Partial Class sitemapnode2avb_aspx
    Inherits System.Web.UI.Page
    Private Function LoadSiteMapData() As DataTable
        Dim dataTable As New DataTable
        Return dataTable
    End Function

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)

        ' <snippet1>
        ' The LoadSiteMapData() Function loads site navigation
        ' data from persistent storage into a DataTable.

        Dim siteMapData As DataTable
        siteMapData = LoadSiteMapData()

        ' Create a SiteMapNodeCollection.
        Dim nodes As New SiteMapNodeCollection()

        ' Create a SiteMapNode and add it to the collection.
        Dim tempNode As SiteMapNode
        Dim row As DataRow
        Dim index As Integer
        index = 0

        While (index < siteMapData.Rows.Count)

            row = siteMapData.Rows(index)

            ' Create a node based on the data in the DataRow.
            tempNode = New SiteMapNode(SiteMap.Provider, row("Key").ToString(), row("Url").ToString())

            ' Add the node to the collection.
            nodes.Add(tempNode)
            index = index + 1
        End While

        ' </snippet1>
    End Sub ' Page_Load
End Class
