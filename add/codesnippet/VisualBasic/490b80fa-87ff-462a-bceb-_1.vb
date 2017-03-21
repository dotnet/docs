        ' Performs decryption.
        Public Overrides Function Decrypt( _
        ByVal encryptedNode As XmlNode) As XmlNode
            Dim decryptedData As String = _
            DecryptString(encryptedNode.InnerText)

            Dim xmlDoc As New XmlDocument()
            xmlDoc.PreserveWhitespace = True
            xmlDoc.LoadXml(decryptedData)

            Return xmlDoc.DocumentElement
        End Function 'Decrypt