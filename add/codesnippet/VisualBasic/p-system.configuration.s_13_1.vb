    Public Shared Sub GetInheritInChildApps() 

        Dim sInfo As SectionInformation = _
        GetSectionInformation()
        
        Dim inheritInChildApps As Boolean = _
        sInfo.InheritInChildApplications
        Console.WriteLine("Inherit in child apps: {0}", _
        inheritInChildApps.ToString())

    End Sub 'GetInheritInChildApps    