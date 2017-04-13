
Partial Class ihd_1_aspx
    Inherits System.Web.UI.Page
    ' <Snippet3>

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ihe As IHierarchicalEnumerable = CType(SiteMap.RootNode.ChildNodes, IHierarchicalEnumerable)
        Dim enumeration As IEnumerator = ihe.GetEnumerator()

        While enumeration.MoveNext()
            'Print out SiteMapNode Titles.
            Dim hierarchicalNode As IHierarchyData = ihe.GetHierarchyData(enumeration.Current)
            PrintFullChildNodeInfo(hierarchicalNode)
        End While

    End Sub
    ' </Snippet3>

    ' <Snippet2>
    ' Print out the the current data node, then iterate through its
    ' children and do the same.

    Private Sub PrintFullChildNodeInfo(ByVal node As IHierarchyData)
        Dim whitespace As String = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"
        Dim br As String = "<BR>"

        Response.Write(Convert.ToString(node) & br)
        Response.Write(whitespace & node.Path & br)

        ' Check for specific types and perform extended functions.
        If node.Type = "SiteMapNode" Then
            ' Because SiteMapNode implements the IHierarchyData interface,
            ' the IHierarchyData object can be cast directly as a SiteMapNode,
            ' rather than accessing the Item property for the object that
            ' the Type property identifies.
            Dim siteNode As SiteMapNode = CType(node.Item, SiteMapNode)
            Response.Write(whitespace & siteNode.Url & br)
            Response.Write(whitespace & siteNode.Description & br)

        ElseIf node.Type = "SomeBusinessObject Then" Then
            ' If the IHierarchyData instance is a wrapper class on a business
            ' object of some kind, you can retrieve the business object by using
            ' the IHierarchyData.Item property.
            '          SomeBusinessObject busObj = node.Item as SomeBusinessObject;
        End If

        If node.HasChildren Then
            Dim children As IEnumerator = CType(node.GetChildren().GetEnumerator(), IHierarchicalEnumerable)
            While children.MoveNext()
                ' Print out SiteMapNode Titles recursively.
                Dim hierarchicalNode As IHierarchyData = node.GetChildren().GetHierarchyData(children.Current)
                PrintFullChildNodeInfo(hierarchicalNode)
            End While
        End If
    End Sub
    ' </Snippet2>
End Class

