    <Extension()>
    Public Async Function ReadToFollowingAsync(reader As XmlReader, localName As String, namespaceURI As String) As Task(Of Boolean)
        If (localName = Nothing Or localName.Length = 0) Then
            Throw New ArgumentException("localName is empty or null")
        End If

        If (namespaceURI = Nothing) Then
            Throw New ArgumentNullException("namespaceURI")
        End If

        ' atomize local name and namespace
        localName = reader.NameTable.Add(localName)
        namespaceURI = reader.NameTable.Add(namespaceURI)

        ' find element with that name
        While (Await reader.ReadAsync())
            If ((reader.NodeType = XmlNodeType.Element) And
               (CObj(localName) = CObj(reader.LocalName)) And
               (CObj(namespaceURI) = CObj(reader.NamespaceURI))) Then
                Return True
            End If
        End While

        Return False
    End Function