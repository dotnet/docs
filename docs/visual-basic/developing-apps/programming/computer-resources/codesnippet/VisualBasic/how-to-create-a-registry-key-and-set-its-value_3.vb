    My.Computer.Registry.CurrentUser.CreateSubKey("MyTestKey")
    ' Change MyTestKeyValue to This is a test value. 
    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\MyTestKey",
      "MyTestKeyValue", "This is a test value.")