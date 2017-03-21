        Dim myProfile As MyCustomProfile = CType(ProfileBase.Create("username"), MyCustomProfile)
        myProfile.ZipCode = "98052"
        myProfile.Save()