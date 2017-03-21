Dim myEvidence As Evidence = Me.GetType().Assembly.Evidence
Dim myResolver As XmlSecureResolver
myResolver = New XmlSecureResolver(New XmlUrlResolver(), myEvidence)