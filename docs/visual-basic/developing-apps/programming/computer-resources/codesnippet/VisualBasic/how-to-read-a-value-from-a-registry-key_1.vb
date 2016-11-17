    Dim readValue = My.Computer.Registry.GetValue(
        "HKEY_CURRENT_USER\Software\MyApp", "Name", Nothing)
    MsgBox("The value is " & readValue)