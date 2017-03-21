            Dim Gac3 As New GacMembershipCondition
            Dim Gac4 As New GacMembershipCondition
            Dim policyEnumerator As IEnumerator = _
                SecurityManager.PolicyHierarchy()
            While policyEnumerator.MoveNext()
                Dim currentLevel As PolicyLevel = _
                    CType(policyEnumerator.Current, PolicyLevel)
                If currentLevel.Label = "Machine" Then
                    Console.WriteLine(("Result of ToXml(level) = " & _
                        Gac3.ToXml(currentLevel).ToString()))
                    Gac4.FromXml(Gac3.ToXml(), currentLevel)
                    Console.WriteLine(("Result of FromXml(element, level) = " _
                        & Gac4.ToString()))
                End If
            End While