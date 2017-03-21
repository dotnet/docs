        ' Build an in-memory representation from persistent
        ' storage, and return the root node of the site map.
        Public Overrides Function BuildSiteMap() As SiteMapNode

            ' Since the SiteMap class is static, make sure that it is
            ' not modified while the site map is built.
            SyncLock Me

                ' If there is no initialization, this method is being
                ' called out of order.
                If Not IsInitialized Then
                    Throw New Exception("BuildSiteMap called incorrectly.")
                End If

                ' If there is no root node, then there is no site map.
                If aRootNode Is Nothing Then
                    ' Start with a clean slate
                    Clear()

                    ' Select the root node of the site map from Microsoft Access.
                    Dim rootNodeId As Integer = -1

                    If accessConnection.State = ConnectionState.Closed Then
                        accessConnection.Open()
                    End If
                    Dim rootNodeCommand As New OleDbCommand("SELECT nodeid, url, name FROM SiteMap WHERE parentnodeid IS NULL", accessConnection)
                    Dim rootNodeReader As OleDbDataReader = rootNodeCommand.ExecuteReader()

                    If rootNodeReader.HasRows Then
                        rootNodeReader.Read()
                        rootNodeId = rootNodeReader.GetInt32(0)
                        ' Create a SiteMapNode that references the current StaticSiteMapProvider.
                        aRootNode = New SiteMapNode(Me, rootNodeId.ToString(), rootNodeReader.GetString(1), rootNodeReader.GetString(2))
                    Else
                        Return Nothing
                    End If
                    rootNodeReader.Close()
                    ' Select the child nodes of the root node.
                    Dim childNodesCommand As New OleDbCommand("SELECT nodeid, url, name FROM SiteMap WHERE parentnodeid = ?", accessConnection)
                    Dim rootParam As New OleDbParameter("parentid", OleDbType.Integer)
                    rootParam.Value = rootNodeId
                    childNodesCommand.Parameters.Add(rootParam)

                    Dim childNodesReader As OleDbDataReader = childNodesCommand.ExecuteReader()

                    If childNodesReader.HasRows Then

                        Dim childNode As SiteMapNode = Nothing
                        While childNodesReader.Read()
                            childNode = New SiteMapNode(Me, _
                            childNodesReader.GetInt32(0).ToString(), _
                            childNodesReader.GetString(1), _
                            childNodesReader.GetString(2))

                            ' Use the SiteMapNode AddNode method to add
                            ' the SiteMapNode to the ChildNodes collection.
                            AddNode(childNode, aRootNode)
                        End While
                    End If

                    childNodesReader.Close()
                    accessConnection.Close()
                End If
                Return aRootNode
            End SyncLock

        End Function 'BuildSiteMap