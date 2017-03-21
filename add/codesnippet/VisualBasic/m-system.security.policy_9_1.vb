        Console.WriteLine(ControlChars.Lf & "Merge new evidence with the current evidence.")
        Dim oa1() As [Object]
        Dim site As New Site("www.wideworldimporters.com")
        Dim oa2 As [Object]() = {url, site}
        Dim newEvidence As New Evidence(oa1, oa2)
        myEvidence.Merge(newEvidence)

        Console.WriteLine(("Evidence count = " & PrintEvidence(myEvidence).ToString()))