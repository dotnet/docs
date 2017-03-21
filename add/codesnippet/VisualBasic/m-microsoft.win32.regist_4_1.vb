        ' Delete or close the new subkey.
        Console.Write(vbCrLf & "Delete newly created " & _
            "registry key? (Y/N) ")
        If Char.ToUpper(Convert.ToChar(Console.Read())) = "Y"C Then
            Registry.CurrentUser.DeleteSubKeyTree("Test9999")
            Console.WriteLine(vbCrLf & "Registry key {0} deleted.", _
                test9999.Name)
        Else
            Console.WriteLine(vbCrLf & "Registry key {0} closed.", _
                test9999.ToString())
            test9999.Close()
        End If