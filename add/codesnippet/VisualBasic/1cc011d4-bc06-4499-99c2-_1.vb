        ' Performs encryption.
        Public Overrides Function Encrypt( _
        ByVal node As XmlNode) As XmlNode
            Dim encryptedData As String = _
            EncryptString(node.OuterXml)

            Dim xmlDoc As New XmlDocument()
            xmlDoc.PreserveWhitespace = True
            xmlDoc.LoadXml( _
            ("<EncryptedData>" + encryptedData + _
            "</EncryptedData>"))

            Return xmlDoc.DocumentElement
        End Function 'Encrypt