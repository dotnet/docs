        ' Delete the ID value.
        testSettings = test9999.OpenSubKey("TestSettings", True)
        testSettings.DeleteValue("id")

        ' Verify the deletion.
        Console.WriteLine(CType(testSettings.GetValue( _
            "id", "ID not found."), String))
        testSettings.Close()