    Dim regVersion = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(
                      "SOFTWARE\\Microsoft\\TestApp\\1.0", True)
    If regVersion Is Nothing Then
        ' Key doesn't exist; create it.
        regVersion = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(
                     "SOFTWARE\\Microsoft\\TestApp\\1.0")
    End If

    Dim intVersion As Integer = 0
    If regVersion IsNot Nothing Then
        intVersion = regVersion.GetValue("Version", 0)
        intVersion = intVersion + 1
        regVersion.SetValue("Version", intVersion)
        regVersion.Close()
    End If