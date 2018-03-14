'<Snippet1>
Imports System
Imports Microsoft.Win32
Imports Microsoft.VisualBasic

Public Class Example
    Public Shared Sub Main()
        ' Delete and recreate the test key.
        Registry.CurrentUser.DeleteSubKey("RegistryOpenSubKeyExample", False)
        Dim rk As RegistryKey = Registry.CurrentUser.CreateSubKey("RegistryOpenSubKeyExample")
        rk.Close

        ' Obtain an instance of RegistryKey for the CurrentUser registry 
        ' root. 
        Dim rkCurrentUser As RegistryKey = Registry.CurrentUser

        ' Obtain the test key (read-only) and display it.
        Dim rkTest As RegistryKey = rkCurrentUser.OpenSubKey("RegistryOpenSubKeyExample")
        Console.WriteLine("Test key: {0}", rkTest)
        rkTest.Close
        rkCurrentUser.Close

        ' Obtain the test key in one step, using the CurrentUser registry 
        ' root.
        rkTest = Registry.CurrentUser.OpenSubKey("RegistryOpenSubKeyExample")
        Console.WriteLine("Test key: {0}", rkTest)
        rkTest.Close

        ' Obtain the test key in read/write mode.
        rkTest = Registry.CurrentUser.OpenSubKey("RegistryOpenSubKeyExample", True)
        rkTest.SetValue("TestName", "TestValue")
        Console.WriteLine("Test value for TestName: {0}", rkTest.GetValue("TestName"))
        rkTest.Close
    End Sub 'Main
End Class 'Example
'</Snippet1>
