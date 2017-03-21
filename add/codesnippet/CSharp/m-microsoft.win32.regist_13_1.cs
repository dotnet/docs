        using(RegistryKey 
            testSettings = test9999.OpenSubKey("TestSettings", true))
        {
            // Delete the ID value.
            testSettings.DeleteValue("id");

            // Verify the deletion.
            Console.WriteLine((string)testSettings.GetValue(
                "id", "ID not found."));
        }