        Console.WriteLine("\nCopy the evidence to an array using CopyTo, then display the array.");
        object[] evidenceArray = new object[myEvidence.Count];
        myEvidence.CopyTo(evidenceArray, 0);
        foreach (object obj in evidenceArray)
        {
            Console.WriteLine(obj.ToString());
        }