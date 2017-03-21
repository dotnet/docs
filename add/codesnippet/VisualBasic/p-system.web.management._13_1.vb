    ' Gets the current application information.
    Public Function GetEventAppInfo() As WebApplicationInformation
        ' Get the event message.
        Dim appImfo As WebApplicationInformation = _
        ApplicationInformation
        Return appImfo

    End Function 'GetEventAppInfo
