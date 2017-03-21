        Dim executingAssembly As [Assembly] = Me.GetType().Assembly
        Dim evidence As Evidence = executingAssembly.Evidence
        Dim resolvedCodeGroup As CodeGroup
        resolvedCodeGroup = codegroup.ResolveMatchingCodeGroups(Evidence)