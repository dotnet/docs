        ' Expected XML schema:
        '  <CustomCryptoKeyValue>
        '      <ProviderName></ProviderName>
        '      <KeyContainerName></KeyContainerName>
        '      <KeyNumber></KeyNumber>
        '      <ProviderType></ProviderType>
        '  </CustomCryptoKeyValue>
        Public Overrides Sub FromXmlString(ByVal xmlString As String)
            If Not xmlString Is Nothing Then
                Dim doc As New XmlDocument
                doc.LoadXml(xmlString)
                Dim firstNode As XmlNode = doc.FirstChild
                Dim nodeList As XmlNodeList

                ' Assemble parameters from values in each XML element.
                cspParameters = New CspParameters

                ' KeyContainerName is optional.
                nodeList = doc.GetElementsByTagName("KeyContainerName")
                Dim keyName As String = nodeList.Item(0).InnerText
                If Not keyName Is Nothing Then
                    cspParameters.KeyContainerName = keyName
                End If

                ' KeyNumber is optional.
                nodeList = doc.GetElementsByTagName("KeyNumber")
                Dim keyNumber As String = nodeList.Item(0).InnerText
                If Not keyNumber Is Nothing Then
                    cspParameters.KeyNumber = Int32.Parse(keyNumber)
                End If

                ' ProviderName is optional.
                nodeList = doc.GetElementsByTagName("ProviderName")
                Dim providerName As String = nodeList.Item(0).InnerText
                If Not providerName Is Nothing Then
                    cspParameters.ProviderName = providerName
                End If

                ' ProviderType is optional.
                nodeList = doc.GetElementsByTagName("ProviderType")
                Dim providerType As String = nodeList.Item(0).InnerText
                If Not providerType Is Nothing Then
                    cspParameters.ProviderType = Int32.Parse(providerType)
                End If
            Else
                Throw New ArgumentNullException("xmlString")
            End If
        End Sub