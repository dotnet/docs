    Public Overrides Function ProvideAppDomainEvidence(ByVal evidence As Evidence) As Evidence
        Console.WriteLine("Provide evidence for the " + AppDomain.CurrentDomain.FriendlyName + " AppDomain.")
        If evidence Is Nothing Then
            Return Nothing
        End If
        evidence.AddHostEvidence(New CustomEvidenceType())
        Return evidence

    End Function 'ProvideAppDomainEvidence
