        Dim Gac1 As New GacMembershipCondition
        Try
            Console.WriteLine( _
                ("Result of GetHashCode for a GacMembershipCondition = " _
                & Gac1.GetHashCode().ToString() & ControlChars.Lf))
        Catch e As Exception
            Console.WriteLine(("GetHashCode failed : " & _
                Gac1.ToString() & e.ToString()))
            Return False
        End Try
