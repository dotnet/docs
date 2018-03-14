' <Snippet1>
Imports System
Imports Microsoft.Win32
Imports Microsoft.VisualBasic

Public Class Example
    Public Shared Sub Main()
        ' Delete and recreate the test key.
        Registry.CurrentUser.DeleteSubKey("RegistryValueOptionsExample", False)
        Dim rk As RegistryKey = _
            Registry.CurrentUser.CreateSubKey("RegistryValueOptionsExample")

        ' Add a value that contains an environment variable.
        rk.SetValue("ExpandValue", "The path is %PATH%", _
            RegistryValueKind.ExpandString)

        ' Retrieve the value, first without expanding the environment 
        ' variable and then expanding it.
        Console.WriteLine("Unexpanded: ""{0}""", _
            rk.GetValue("ExpandValue", "No Value", _
            RegistryValueOptions.DoNotExpandEnvironmentNames))
        Console.WriteLine("Expanded: ""{0}""", rk.GetValue("ExpandValue"))
    End Sub 'Main
End Class 'Example
' </Snippet1>