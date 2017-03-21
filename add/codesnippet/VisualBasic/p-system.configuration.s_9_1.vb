    Public Shared Sub GetSectionNameProperty() 

        Dim sInfo As SectionInformation = _
        GetSectionInformation()
        
        Dim sectionNameProperty _
        As String = sInfo.Name
        Console.WriteLine("Section name: {0}", _
        sectionNameProperty)
    
    End Sub 'GetSectionNameProperty