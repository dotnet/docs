    <Extension()>
    Public Async Function ReadEndElementAsync(reader As XmlReader) As task
        If (Await reader.MoveToContentAsync() <> XmlNodeType.EndElement) Then
            Throw New InvalidOperationException()
        End If
        Await reader.ReadAsync()
    End Function