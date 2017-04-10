' <Snippet5>
Imports System
Imports Microsoft.Win32

Public Class RegKeyDel
    Public Shared Sub Main()
        ' Create a subkey named Test9999 under HKEY_CURRENT_USER.
        Dim test9999 As RegistryKey = _
            Registry.CurrentUser.CreateSubKey("Test9999")
        ' Create two subkeys under HKEY_CURRENT_USER\Test9999. The
        ' keys are disposed when execution exits the using statement.
        Dim testName As RegistryKey = test9999.CreateSubKey("TestName")
        Dim testSettings As RegistryKey = test9999.CreateSubKey("TestSettings")

        ' Create data for the TestSettings subkey.
        testSettings.SetValue("Language", "French")
        testSettings.SetValue("Level", "Intermediate")
        testSettings.SetValue("ID", 123)

        ' delete the subkey "TestName"
        test9999.DeleteSubKey("TestName")
        ' delete everything under and including "Test9999"
        Registry.CurrentUser.DeleteSubKeyTree("Test9999")
    End Sub
End Class
' </Snippet5>