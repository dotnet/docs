    <Extension()>
    Public Async Function ReadStartElementAsync(reader As XmlReader, localname As String, ns As String) As Task
        If (Await reader.MoveToContentAsync() <> XmlNodeType.Element) Then
            Throw New InvalidOperationException(reader.NodeType.ToString() + " is an invalid XmlNodeType")
        End If

        If ((reader.LocalName = localname) And (reader.NamespaceURI = ns)) Then
            Await reader.ReadAsync()
        Else
            Throw New InvalidOperationException("localName or namespace doesn’t match")
        End If
    End Function