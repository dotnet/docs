    Public Shared Sub GetProtectionProvider()

        Dim sInfo As SectionInformation = _
        GetSectionInformation()

        Dim pp _
        As ProtectedConfigurationProvider = _
        sInfo.ProtectionProvider
        If pp Is Nothing Then
            Console.WriteLine("Protection provider is null")
        Else
            Console.WriteLine("Protection provider: {0}", _
            pp.ToString())
        End If

    End Sub 'GetProtectionProvider