    Public Overrides Function ProvideAssemblyEvidence(ByVal loadedAssembly As [Assembly], ByVal evidence As Evidence) As Evidence
        Console.WriteLine("Provide assembly evidence for: " + IIf(loadedAssembly Is Nothing, "Unknown", loadedAssembly.ToString()) + ".") 'TODO: For performance reasons this should be changed to nested IF statements
        If evidence Is Nothing Then
            Return Nothing
        End If
        evidence.AddAssemblyEvidence(New CustomEvidenceType())
        Return evidence

    End Function 'ProvideAssemblyEvidence
