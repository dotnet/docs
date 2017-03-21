        Console.WriteLine("\nMake a copy of the current evidence.");
        Evidence evidenceCopy = new Evidence(myEvidence);
        Console.WriteLine("Count of new evidence items = " + evidenceCopy.Count);
        Console.WriteLine("Does the copy equal the current evidence? " + myEvidence.Equals(evidenceCopy));