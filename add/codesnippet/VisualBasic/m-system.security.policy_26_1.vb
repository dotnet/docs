        Dim Gac1 As New GacMembershipCondition
        Console.WriteLine("Original membership condition = ")
        Console.WriteLine(Gac1.ToXml().ToString())
        Try
            Dim membershipCondition As IMembershipCondition = Gac1.Copy()
            Console.WriteLine("Result of Copy = ")
            Console.WriteLine(CType(membershipCondition, _
                GacMembershipCondition).ToXml().ToString())
        Catch e As Exception
            Console.WriteLine(("Copy failed : " & Gac1.ToString() & _
                e.ToString()))
            Return False
        End Try
