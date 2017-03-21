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