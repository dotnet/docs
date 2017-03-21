    Public Overrides Sub InitializeNewDomain(ByVal appDomainInfo _
        As AppDomainSetup) 
        Console.Write("Initialize new domain called:  ")
        Console.WriteLine(AppDomain.CurrentDomain.FriendlyName)
        InitializationFlags = _
            AppDomainManagerInitializationOptions.RegisterWithHost   
    End Sub 'InitializeNewDomain