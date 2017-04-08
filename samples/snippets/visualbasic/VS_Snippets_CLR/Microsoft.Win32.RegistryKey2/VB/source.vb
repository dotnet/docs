' <Snippet1>
Imports Microsoft.VisualBasic
Imports System
Imports System.Security.Permissions
Imports Microsoft.Win32

Public Class RegKey
    Shared Sub Main()

        ' Create a subkey named Test9999 under HKEY_CURRENT_USER.
        Dim test9999 As RegistryKey = _
            Registry.CurrentUser.CreateSubKey("Test9999")

        ' Create two subkeys under HKEY_CURRENT_USER\Test9999.
        test9999.CreateSubKey("TestName").Close()
        Dim testSettings As RegistryKey = _
            test9999.CreateSubKey("TestSettings")

        ' Create data for the TestSettings subkey.
        testSettings.SetValue("Language", "French")
        testSettings.SetValue("Level", "Intermediate")
        testSettings.SetValue("ID", 123)
        testSettings.Close()

        ' <Snippet2>
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
        ' </Snippet2>

        ' <Snippet3>
        ' Delete the ID value.
        testSettings = test9999.OpenSubKey("TestSettings", True)
        testSettings.DeleteValue("id")

        ' Verify the deletion.
        Console.WriteLine(CType(testSettings.GetValue( _
            "id", "ID not found."), String))
        testSettings.Close()
        ' </Snippet3>

        ' <Snippet4>
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
        ' </Snippet4>
   
    End Sub
End Class
' </Snippet1>