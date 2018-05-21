    Dim regVersion As Microsoft.Win32.RegistryKey
    Dim keyValue = "Software\\Microsoft\\TestApp\\1.0"
    regVersion = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(keyValue, False)
    Dim intVersion As Integer = 0
    If regVersion IsNot Nothing Then
        intVersion = regVersion.GetValue("Version", 0)
        regVersion.Close()
    End If