        Dim executingAssembly As [Assembly]
        executingAssembly = Me.GetType().Assembly

        Dim executingEvidence As Evidence = executingAssembly.Evidence

        Dim policy As PolicyStatement
        policy = fileCodeGroup.Resolve(executingEvidence)