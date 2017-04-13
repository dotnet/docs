'<Snippet1>
Imports Microsoft.VisualBasic
Imports System.Xml
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Web.UI.Design

Public Class XmlDocumentSchemaSample

    ' This method fills a TreeView Web control from an XML file.
    Public Sub FillTreeView(ByVal treeVw As TreeView, ByVal fileName As String)
        ' Get a reference to the current HttpContext
        Dim currentContext As HttpContext = HttpContext.Current
        Dim i, j, k As Integer
        Dim CurNode, NewNode As TreeNode

        ' Create and load an XML document
        Dim XDoc As New XmlDocument()
        XDoc.Load(currentContext.Server.MapPath(fileName))

        ' Get a map of the XML Document
        Dim xSchema As New XmlDocumentSchema(XDoc, "")

        ' Get a list of the root child views
        Dim RootViews As IDataSourceViewSchema() = xSchema.GetViews()

        ' Add each child to the TreeView
        For i = 0 To RootViews.Length - 1
            NewNode = New TreeNode(RootViews(i).Name)
            treeVw.Nodes.Add(NewNode)
            CurNode = treeVw.Nodes(i)

            ' Get a list of children of this child
            Dim ChildViews As IDataSourceViewSchema() = RootViews(i).GetChildren()

            ' Add each child to the child node of the TreeView
            For j = 0 To ChildViews.Length - 1
                NewNode = New TreeNode(ChildViews(j).Name)
                CurNode.ChildNodes.Add(NewNode)
                CurNode = CurNode.ChildNodes(j)

                ' Get a list of children of this child
                Dim ChildVws As IDataSourceViewSchema() = ChildViews(j).GetChildren()
                ' Add each child to the child node
                For k = 0 To ChildVws.Length - 1
                    NewNode = New TreeNode(ChildVws(k).Name)
                    CurNode.ChildNodes.Add(NewNode)
                Next
                ' Select the parent of the current child
                CurNode = CurNode.Parent
            Next
            ' Select the parent of the current child
            CurNode = CurNode.Parent
        Next
    End Sub
End Class
'</Snippet1>
