        Assembly assembly = typeof(Members).Assembly;
        Evidence executingEvidence = assembly.Evidence;

        PolicyStatement policy = codeGroup.Resolve(executingEvidence);