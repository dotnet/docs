    Public Shared Sub GetSectionName() 
        Dim sInfo As SectionInformation = _
        GetSectionInformation()
        
        Dim sectionName As String = _
        sInfo.SectionName
        Console.WriteLine("Section type: {0}", _
        sectionName)
    End Sub 'GetSectionName