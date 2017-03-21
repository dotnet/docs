        Dim executingAssembly As [Assembly]
        executingAssembly = Me.GetType().Assembly

        Dim evidence As Evidence = executingAssembly.Evidence

        Dim codeGroup As CodeGroup
        codeGroup = fileCodeGroup.ResolveMatchingCodeGroups(evidence)