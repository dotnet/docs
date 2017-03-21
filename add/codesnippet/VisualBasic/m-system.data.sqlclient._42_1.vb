    Public Sub CreateXMLReader(ByVal queryString As String, _
        ByVal connectionString As String)

        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Dim command As New SqlCommand(queryString, connection)
            Dim reader As System.Xml.XmlReader = command.ExecuteXmlReader
        End Using
    End Sub