    <Extension()>
    Public Async Function ReadToDescendantAsync(reader As XmlReader, localName As String, namespaceURI As String) As Task(Of Boolean)
        If (localName = Nothing Or localName.Length = 0) Then
            Throw New ArgumentException("localName is empty or null")
        End If

        If (namespaceURI = Nothing) Then
            Throw New ArgumentNullException("namespaceURI")
        End If

        ' save the element or root depth
        Dim parentDepth As Integer = reader.Depth
        If (reader.NodeType <> XmlNodeType.Element) Then
            ' adjust the depth if we are on root node
            If (reader.ReadState = ReadState.Initial) Then
                parentDepth -= 1
            Else
                Return False
            End If
        ElseIf (reader.IsEmptyElement) Then
            Return False
        End If
        ' atomize local name and namespace
        localName = reader.NameTable.Add(localName)
        namespaceURI = reader.NameTable.Add(namespaceURI)

        ' find the descendant
        While (Await reader.ReadAsync() And reader.Depth > parentDepth)
            If (reader.NodeType = XmlNodeType.Element And
               (CObj(localName) = CObj(reader.LocalName)) And
               (CObj(namespaceURI) = CObj(reader.NamespaceURI))) Then
                Return True
            End If
        End While

        Return False
    End Function