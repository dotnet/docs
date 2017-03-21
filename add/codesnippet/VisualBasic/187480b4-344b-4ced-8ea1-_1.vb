        Dim Gac1 As New GacMembershipCondition
        Dim myGac As New GacInstalled
        Try
            Dim hostEvidence() As Object = {myGac}
            Dim assemblyEvidence() As Object

            Dim myEvidence As New Evidence(hostEvidence, assemblyEvidence)
            Dim retCode As Boolean = Gac1.Check(myEvidence)
            Console.WriteLine(("Result of Check = " & retCode.ToString() _
                & ControlChars.Lf))
        Catch e As Exception
            Console.WriteLine(("Check failed : " & Gac1.ToString() & _ 
                e.ToString()))
            Return False
        End Try