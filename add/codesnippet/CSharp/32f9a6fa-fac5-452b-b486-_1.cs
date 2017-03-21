        Assembly assembly = typeof(Members).Assembly;
        Evidence evidence = assembly.Evidence;
        CodeGroup codeGroup = 
            fileCodeGroup.ResolveMatchingCodeGroups(evidence);