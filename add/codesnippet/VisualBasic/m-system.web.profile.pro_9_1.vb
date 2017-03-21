        Dim profile As MyCustomProfile = CType(ProfileBase.Create("username", True), MyCustomProfile)
        profile.ZipCode = "98052"
        profile.Save()