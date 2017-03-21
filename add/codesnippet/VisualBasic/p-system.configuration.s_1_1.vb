    Public Shared Sub RestartOnExternalChanges()

        Dim sInfo As SectionInformation = _
        GetSectionInformation()

        Dim restartOnChange As Boolean = _
        sInfo.RestartOnExternalChanges
        Console.WriteLine("Section type: {0}", _
        restartOnChange.ToString())

    End Sub 'RestartOnExternalChanges