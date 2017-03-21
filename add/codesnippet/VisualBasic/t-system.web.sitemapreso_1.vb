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
