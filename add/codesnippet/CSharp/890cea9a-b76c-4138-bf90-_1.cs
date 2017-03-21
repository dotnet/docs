        Assembly assembly = typeof(Members).Assembly;
        Evidence evidence = assembly.Evidence;
        CodeGroup resolvedCodeGroup = 
            codeGroup.ResolveMatchingCodeGroups(evidence);