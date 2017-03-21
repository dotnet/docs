        Console.WriteLine(ControlChars.Lf & "Make a copy of the current evidence.")
        Dim evidenceCopy As New Evidence(myEvidence)
        Console.WriteLine(("Count of new evidence items = " & evidenceCopy.Count.ToString()))
        Console.WriteLine(("Does the copy equal the current evidence? " & myEvidence.Equals(evidenceCopy)))