        ' Print the information from the Test9999 subkey.
        Console.WriteLine("There are {0} subkeys under Test9999.", _
            test9999.SubKeyCount.ToString())
        For Each subKeyName As String In test9999.GetSubKeyNames()
            Dim tempKey As RegistryKey = _
                test9999.OpenSubKey(subKeyName)
            Console.WriteLine(vbCrLf & "There are {0} values for " & _
                "{1}.", tempKey.ValueCount.ToString(), tempKey.Name)
            For Each valueName As String In tempKey.GetValueNames()
                Console.WriteLine("{0,-8}: {1}", valueName, _
                    tempKey.GetValue(valueName).ToString())
            Next
        Next