Dim myEvidence As Evidence = XmlSecureResolver.CreateEvidenceForUrl(sourceURI)
Dim myResolver As New XmlSecureResolver(New XmlUrlResolver(), myEvidence)