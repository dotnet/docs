        // Print the information from the Test9999 subkey.
        Console.WriteLine("There are {0} subkeys under {1}.", 
            test9999.SubKeyCount.ToString(), test9999.Name);
        foreach(string subKeyName in test9999.GetSubKeyNames())
        {
            using(RegistryKey 
                tempKey = test9999.OpenSubKey(subKeyName))
            {
                Console.WriteLine("\nThere are {0} values for {1}.", 
                    tempKey.ValueCount.ToString(), tempKey.Name);
                foreach(string valueName in tempKey.GetValueNames())
                {
                    Console.WriteLine("{0,-8}: {1}", valueName, 
                        tempKey.GetValue(valueName).ToString());
                }
            }
        }