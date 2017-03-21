    ' Demonstrate the use of ResolvePolicy for the supplied evidence and a specified policy level.
    Private Overloads Shared Sub CheckEvidence(ByVal pLevel As PolicyLevel, ByVal evidence As Evidence)
        ' Display the code groups to which the evidence belongs.
        Console.WriteLine(ControlChars.Tab + "ResolvePolicy for the given evidence: ")
        Dim codeGroup As IEnumerator = evidence.GetEnumerator()
        While codeGroup.MoveNext()
            Console.WriteLine((ControlChars.Tab + ControlChars.Tab + CType(codeGroup.Current, CodeGroup).Name))
        End While
        Console.WriteLine("The current evidence belongs to the following root CodeGroup:")
        ' pLevel is the current PolicyLevel, evidence is the Evidence to be resolved.
        Dim cg1 As CodeGroup = pLevel.ResolveMatchingCodeGroups(evidence)
        Console.WriteLine((pLevel.Label + " Level"))
        Console.WriteLine((ControlChars.Tab + "Root CodeGroup = " + cg1.Name))

        ' Show how Resolve is used to determine the set of permissions that 
        ' the security system grants to code, based on the evidence.
        ' Show the granted permissions. 
        Console.WriteLine(ControlChars.Lf + "Current permissions granted:")
        Dim pState As PolicyStatement = pLevel.Resolve(evidence)
        Console.WriteLine(pState.ToXml().ToString())

        Return
    End Sub 'CheckEvidence
