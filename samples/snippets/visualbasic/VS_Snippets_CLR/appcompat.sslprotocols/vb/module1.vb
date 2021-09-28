Module Module1

    Sub Main()
        ' <Snippet1>
        Const DisableCachingName As String = "TestSwitch.LocalAppContext.DisableCaching"
        Const DontEnableSchUseStrongCryptoName As String = "Switch.System.Net.DontEnableSchUseStrongCrypto"
        AppContext.SetSwitch(DisableCachingName, True)
        AppContext.SetSwitch(DontEnableSchUseStrongCryptoName, True)
        ' </Snippet1>
    End Sub

End Module
