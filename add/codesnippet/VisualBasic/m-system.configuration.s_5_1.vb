    Public Shared Sub GetParentSection() 

        Dim sInfo As SectionInformation = _
        GetSectionInformation()
        
        Dim parentSection _
        As ConfigurationSection = _
        sInfo.GetParentSection()
        
        Console.WriteLine("Parent section : {0}", _
        parentSection.SectionInformation.Name)
    
    End Sub 'GetParentSection