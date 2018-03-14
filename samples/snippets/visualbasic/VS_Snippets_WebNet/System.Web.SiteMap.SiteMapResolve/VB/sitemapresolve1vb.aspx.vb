Imports System
Imports System.Configuration
Imports System.Web

Partial Class sitemapresolve1vb_aspx 
    Inherits System.Web.UI.Page

    ' <Snippet1>
    Private Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

        ' The ExpandForumPaths method is called to handle
        ' the SiteMapResolve event.
        AddHandler SiteMap.SiteMapResolve, AddressOf Me.ExpandForumPaths

    End Sub

    Private Function ExpandForumPaths(ByVal sender As Object, ByVal e As SiteMapResolveEventArgs) As SiteMapNode
        ' The current node represents a Post page in a bulletin board forum.
        ' Clone the current node and all of its relevant parents. This
        ' returns a site map node that a developer can then
        ' walk, modifying each node.Url property in turn.
        ' Since the cloned nodes are separate from the underlying
        ' site navigation structure, the fixups that are made do not
        ' effect the overall site navigation structure.
        Dim currentNode As SiteMapNode = SiteMap.CurrentNode.Clone(True)
        Dim tempNode As SiteMapNode = currentNode

        ' Obtain the recent IDs.
        Dim forumGroupID As Integer = GetMostRecentForumGroupID()
        Dim forumID As Integer = GetMostRecentForumID(forumGroupID)
        Dim postID As Integer = GetMostRecentPostID(forumID)

        ' The current node, and its parents, can be modified to include
        ' dynamic querystring information relevant to the currently
        ' executing request.
        If Not (0 = postID) Then
            tempNode.Url = tempNode.Url & "?PostID=" & postID.ToString()
        End If

        tempNode = tempNode.ParentNode
        If Not (0 = forumID) And Not (tempNode Is Nothing) Then
            tempNode.Url = tempNode.Url & "?ForumID=" & forumID.ToString()
        End If

        tempNode = tempNode.ParentNode
        If Not (0 = ForumGroupID) And Not (tempNode Is Nothing) Then
            tempNode.Url = tempNode.Url & "?ForumGroupID=" & forumGroupID.ToString()
        End If

        Return currentNode

    End Function

    ' </Snippet1>

    ' <Snippet2>
    ' These methods are just placeholders for the example.
    ' One option is to use the HttpContext or e.Context object
    ' to obtain the ID.
    Private Function GetMostRecentForumGroupID() As Integer
        Return 24
    End Function

    Private Function GetMostRecentForumID(ByVal forumGroupId As Integer) As Integer
        Return 128
    End Function

    Private Function GetMostRecentPostID(ByVal forumId As Integer) As Integer
        Return 317424
    End Function
    ' </Snippet2>
End Class
