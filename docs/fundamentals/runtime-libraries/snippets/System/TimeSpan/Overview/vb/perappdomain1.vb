' Visual Basic .NET Document
Option Strict On
' <Snippet1>
Module Example3
    Public Sub Main()
        Dim appSetup As New AppDomainSetup()
        appSetup.SetCompatibilitySwitches({"NetFx40_TimeSpanLegacyFormatMode"})
        Dim legacyDomain As AppDomain = AppDomain.CreateDomain("legacyDomain",
                                                             Nothing, appSetup)
        legacyDomain.ExecuteAssembly("ShowTimeSpan.exe")
    End Sub
End Module
' </Snippet1>
