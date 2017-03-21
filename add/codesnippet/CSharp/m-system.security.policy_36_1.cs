        Console.WriteLine("\nRemove URL evidence.");
        myEvidence.RemoveType(url.GetType());
        Console.WriteLine("Evidence count is now: " + myEvidence.Count.ToString());