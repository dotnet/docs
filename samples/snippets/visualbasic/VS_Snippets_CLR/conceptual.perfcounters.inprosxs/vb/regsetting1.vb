' Visual Basic .NET Document
Option Strict On

Module modMain
    Public Sub Main()
        ' <Snippet1>
        ' Create or open registry key.
        Dim key As Microsoft.Win32.RegistryKey
        key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey( _
                    "System\CurrentControlSet\Services\.NETFramework\Performance")
        ' Create or overwrite value.
        key.SetValue("ProcessNameFormat", 1, _
                     Microsoft.Win32.RegistryValueKind.DWord)
        key.Close()
        ' </Snippet1>
    End Sub
End Module

