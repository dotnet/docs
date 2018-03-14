    If My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\TestApp",
    "TestValue", Nothing) Is Nothing Then
      MsgBox("Value does not exist.")
    End If