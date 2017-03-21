        Dim hostEvidence() As Object = {myGacInstalled}
        Dim assemblyEvidence() As Object
        Dim myEvidence As New Evidence(hostEvidence, assemblyEvidence)
        Dim myPerm As GacIdentityPermission = _
            CType(myGacInstalled.CreateIdentityPermission(myEvidence), _ 
            GacIdentityPermission)
        Console.WriteLine(myPerm.ToXml().ToString())