        Console.WriteLine("Adding assembly evidence.");
        myEvidence.AddAssembly("SN01");
        myEvidence.AddAssembly(new Version("0.0.0.0"));
        myEvidence.AddAssembly(mSN);
        Console.WriteLine("Count of evidence items = " + myEvidence.Count.ToString());