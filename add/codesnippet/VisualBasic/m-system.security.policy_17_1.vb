            Dim Gac1 As New GacMembershipCondition
            Dim Gac2 As New GacMembershipCondition

            ' Roundtrip a GacMembershipCondition to and from an XML encoding.
            Gac2.FromXml(Gac1.ToXml())
            Dim result As Boolean = Gac2.Equals(Gac1)
            If result Then
                Console.WriteLine(("Result of ToXml() = " & _ 
                    Gac2.ToXml().ToString()))
                Console.WriteLine(("Result of ToFromXml roundtrip = " & _ 
                    Gac2.ToString()))
            Else
                Console.WriteLine(Gac2.ToString())
                Console.WriteLine(Gac1.ToString())
                Return False
            End If