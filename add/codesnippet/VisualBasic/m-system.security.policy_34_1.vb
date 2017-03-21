        Dim myGacInstalledCopy As GacInstalled = _
            CType(myGacInstalled.Copy(), GacInstalled)
        Dim result As Boolean = myGacInstalled.Equals(myGacInstalledCopy)