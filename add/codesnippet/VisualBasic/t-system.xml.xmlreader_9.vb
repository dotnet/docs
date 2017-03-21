    <Extension()>
    Public Async Function ReadToNextSiblingAsync(reader As XmlReader, localName As String, namespaceURI As String) As Task(Of Boolean)
        If (localName = Nothing Or localName.Length = 0) Then
            Throw New ArgumentException("localName is empty or null")
        End If

        If (namespaceURI = Nothing) Then
            Throw New ArgumentNullException("namespaceURI")
        End If

        ' atomize local name and namespace
        localName = reader.NameTable.Add(localName)
        namespaceURI = reader.NameTable.Add(namespaceURI)

        ' find the next sibling
        Dim nt As XmlNodeType
        Do

            Await reader.SkipAsync()
            If (reader.ReadState <> ReadState.Interactive) Then
                Exit Do
            End If
            nt = reader.NodeType
            If ((nt = XmlNodeType.Element) And
               ((CObj(localName) = CObj(reader.LocalName))) And
               (CObj(namespaceURI) = CObj(reader.NamespaceURI))) Then
                Return True
            End If
        Loop While (nt <> XmlNodeType.EndElement And (Not reader.EOF))

        Return False

    End Function