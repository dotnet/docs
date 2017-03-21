    // Demonstrate the use of ResolvePolicy for the supplied evidence and a specified policy level.
    private static void CheckEvidence(PolicyLevel pLevel, Evidence evidence)
    {
        // Display the code groups to which the evidence belongs.
        Console.WriteLine("\tResolvePolicy for the given evidence: ");
        IEnumerator codeGroup = evidence.GetEnumerator();
        while (codeGroup.MoveNext())
        {
            Console.WriteLine("\t\t" + ((CodeGroup)codeGroup.Current).Name);
        }
        Console.WriteLine("The current evidence belongs to the following root CodeGroup:");
        // pLevel is the current PolicyLevel, evidence is the Evidence to be resolved.
        CodeGroup cg1 = pLevel.ResolveMatchingCodeGroups(evidence);
        Console.WriteLine(pLevel.Label + " Level");
        Console.WriteLine("\tRoot CodeGroup = " + cg1.Name);

        // Show how Resolve is used to determine the set of permissions that 
        // the security system grants to code, based on the evidence.

        // Show the granted permissions. 
        Console.WriteLine("\nCurrent permissions granted:");
        PolicyStatement pState = pLevel.Resolve(evidence);
        Console.WriteLine(pState.ToXml().ToString());

        return;
    }