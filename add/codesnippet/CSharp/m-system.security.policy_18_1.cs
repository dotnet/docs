        Assembly assembly = typeof(Members).Assembly;
        Evidence executingEvidence = assembly.Evidence;

        PolicyStatement policy = fileCodeGroup.Resolve(executingEvidence);