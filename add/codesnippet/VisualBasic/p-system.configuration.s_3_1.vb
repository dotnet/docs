    Public Shared Sub GetSectionType() 
        Dim sInfo As SectionInformation = _
        GetSectionInformation()
        
        Dim sectionType As String = sInfo.Type
        Console.WriteLine("Section type: {0}", _
        sectionType)
    
    End Sub 'GetSectionType