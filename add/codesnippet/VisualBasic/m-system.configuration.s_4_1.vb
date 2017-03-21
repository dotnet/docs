    Public Shared Sub GetSectionXml()

        Dim sInfo As SectionInformation = _
        GetSectionInformation()

        Dim sectionXml As String = sInfo.GetRawXml()

        Console.WriteLine("Section xml:")
        Console.WriteLine(sectionXml)

    End Sub 'GetSectionXml
     