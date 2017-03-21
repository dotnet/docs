        Console.WriteLine("\nMerge new evidence with the current evidence.");
        Object [] oa1 = {};
        Site site = new Site("www.wideworldimporters.com");
        Object [] oa2 = { url, site };
        Evidence newEvidence = new Evidence(oa1, oa2);
        myEvidence.Merge(newEvidence);
        Console.WriteLine("Evidence count = " + PrintEvidence(myEvidence).ToString());