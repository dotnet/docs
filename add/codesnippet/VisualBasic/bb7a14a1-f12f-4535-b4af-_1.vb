        Dim executingAssembly As [Assembly] = Me.GetType().Assembly
        Dim executingEvidence As Evidence
        executingEvidence = executingAssembly.Evidence

        Dim policy As PolicyStatement = codeGroup.Resolve(executingEvidence)