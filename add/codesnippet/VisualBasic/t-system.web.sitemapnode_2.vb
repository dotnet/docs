    Protected Overridable Sub LoadSiteMapFromStore()
      Dim pathToOpen As String
      SyncLock Me
        ' If a root node exists, LoadSiteMapFromStore has already
        ' been called, and the method can return.
        If Not (aRootNode Is Nothing) Then
          Return
        Else
          pathToOpen = HttpContext.Current.Server.MapPath("~" & "\\" & sourceFilename)
          If File.Exists(pathToOpen) Then
            ' Open the file to read from.
            Dim sr As StreamReader = File.OpenText(pathToOpen)
            Try

              ' Clear the state of the collections and aRootNode
              aRootNode = Nothing
              siteMapNodes.Clear()
              childParentRelationship.Clear()

              ' Parse the file and build the site map
              Dim s As String = ""
              Dim nodeValues As String() = Nothing
              Dim temp As SiteMapNode = Nothing

              Do
                s = sr.ReadLine()

                If Not s Is Nothing Then
                  ' Build the various SiteMapNode objects and add
                  ' them to the ArrayList collections. The format used
                  ' is: URL,TITLE,DESCRIPTION,PARENTURL
                  nodeValues = s.Split(","c)

                  temp = New SiteMapNode(Me, _
                      HttpRuntime.AppDomainAppVirtualPath & "/" & nodeValues(0), _
                      HttpRuntime.AppDomainAppVirtualPath & "/" & nodeValues(0), _
                      nodeValues(1), _
                      nodeValues(2))

                  ' Is this a root node yet?
                  If aRootNode Is Nothing AndAlso _
                    (nodeValues(3) Is Nothing OrElse _
                     nodeValues(3) = String.Empty) Then
                    aRootNode = temp

                    ' If not the root node, add the node to the various collections.
                  Else

                    siteMapNodes.Add(New DictionaryEntry(temp.Url, temp))

                    ' The parent node has already been added to the collection.
                    Dim parentNode As SiteMapNode = _
                        FindSiteMapNode(HttpRuntime.AppDomainAppVirtualPath & "/" & nodeValues(3))

                    If Not (parentNode Is Nothing) Then
                      childParentRelationship.Add(New DictionaryEntry(temp.Url, parentNode))
                    Else
                      Throw New Exception("Parent node not found for current node.")
                    End If
                  End If
                End If
              Loop Until s Is Nothing
            Finally
              sr.Close()
            End Try
          Else
            Throw New Exception("File not found")
          End If
        End If
      End SyncLock
      Return
    End Sub 'LoadSiteMapFromStore
  End Class 'SimpleTextSiteMapProvider