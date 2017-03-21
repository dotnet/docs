        Console.WriteLine(ControlChars.Lf & "Remove URL evidence.")
        myEvidence.RemoveType(url.GetType())
        Console.WriteLine(("Evidence count is now: " & myEvidence.Count.ToString()))