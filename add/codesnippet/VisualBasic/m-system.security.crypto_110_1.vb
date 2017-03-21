        Public Overrides Function ToXmlString( _
            ByVal includePrivateParameters As Boolean) As String

            Dim keyContainerName As String = ""
            Dim keyNumber As String = ""
            Dim providerName As String = ""
            Dim providerType As String = ""

            If Not cspParameters Is Nothing Then
                keyContainerName = cspParameters.KeyContainerName
                keyNumber = cspParameters.KeyNumber.ToString()
                providerName = cspParameters.ProviderName
                providerType = cspParameters.ProviderType.ToString()
            End If

            Dim xmlBuilder As New StringBuilder
            xmlBuilder.Append("<CustomCryptoKeyValue>")

            xmlBuilder.Append("<KeyContainerName>")
            xmlBuilder.Append(keyContainerName)
            xmlBuilder.Append("</KeyContainerName>")

            xmlBuilder.Append("<KeyNumber>")
            xmlBuilder.Append(keyNumber)
            xmlBuilder.Append("</KeyNumber>")

            xmlBuilder.Append("<ProviderName>")
            xmlBuilder.Append(providerName)
            xmlBuilder.Append("</ProviderName>")

            xmlBuilder.Append("<ProviderType>")
            xmlBuilder.Append(providerType)
            xmlBuilder.Append("</ProviderType>")

            xmlBuilder.Append("</CustomCryptoKeyValue>")
            Return (xmlBuilder.ToString())
        End Function