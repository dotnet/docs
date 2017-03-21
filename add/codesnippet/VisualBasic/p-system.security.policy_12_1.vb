    ' Demonstrate the use of ResolvePolicy for passed in evidence.
    Private Overloads Shared Sub CheckEvidence(ByVal evidence As Evidence)
        ' Display the code groups to which the evidence belongs.
        Console.WriteLine("ResolvePolicy for the given evidence.")
        Console.WriteLine(ControlChars.Tab + "Current evidence belongs to the following code groups:")
        Dim policyEnumerator As IEnumerator = SecurityManager.PolicyHierarchy()
        ' Resolve the evidence at all the policy levels.
        While policyEnumerator.MoveNext()
            Dim currentLevel As PolicyLevel = CType(policyEnumerator.Current, PolicyLevel)
            Dim cg1 As CodeGroup = currentLevel.ResolveMatchingCodeGroups(evidence)
            Console.WriteLine((ControlChars.Lf + ControlChars.Tab + currentLevel.Label + " Level"))
            Console.WriteLine((ControlChars.Tab + ControlChars.Tab + "CodeGroup = " + cg1.Name))
            Dim cgE1 As IEnumerator = cg1.Children.GetEnumerator()
            While cgE1.MoveNext()
                Console.WriteLine((ControlChars.Tab + ControlChars.Tab + ControlChars.Tab + "Group = " + CType(cgE1.Current, CodeGroup).Name))
            End While
            Console.WriteLine((ControlChars.Tab + "StoreLocation = " + currentLevel.StoreLocation))
        End While

        Return
    End Sub 'CheckEvidence
