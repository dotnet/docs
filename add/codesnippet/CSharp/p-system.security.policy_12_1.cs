    // Demonstrate the use of ResolvePolicy for passed in evidence.
    private static void CheckEvidence(Evidence evidence)
    {
        // Display the code groups to which the evidence belongs.
        Console.WriteLine("ResolvePolicy for the given evidence.");
        Console.WriteLine("\tCurrent evidence belongs to the following code groups:");
        IEnumerator policyEnumerator = SecurityManager.PolicyHierarchy();
        // Resolve the evidence at all the policy levels.
        while (policyEnumerator.MoveNext())
        {

            PolicyLevel currentLevel = (PolicyLevel)policyEnumerator.Current;	
            CodeGroup cg1 = currentLevel.ResolveMatchingCodeGroups(evidence);
            Console.WriteLine("\n\t" + currentLevel.Label + " Level");
            Console.WriteLine("\t\tCodeGroup = " + cg1.Name);
            IEnumerator cgE1 = cg1.Children.GetEnumerator();
            while (cgE1.MoveNext())
            {
                Console.WriteLine("\t\t\tGroup = " + ((CodeGroup)cgE1.Current).Name);
            }
            Console.WriteLine("\tStoreLocation = " + currentLevel.StoreLocation);

        }

        return;
    }