'<snippet0>
Imports Microsoft.Win32
'</snippet0>

Public Class GetDotNetVersion
    Public Shared Sub Main()
        GetVersionFromRegistry()
        GetVersionFromEnvironment()
        Get45or451FromRegistry()
    End Sub

    '<snippet2>
    Private Shared Sub GetVersionFromEnvironment()
        Console.WriteLine("Version: " & Environment.Version.ToString())
    End Sub
    '</snippet2>

    '<snippet3>
    Private Shared Sub Get45or451FromRegistry()
        Using ndpKey As RegistryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine,
                    RegistryView.Registry32).OpenSubKey("SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\")

            If ndpKey IsNot Nothing AndAlso ndpKey.GetValue("Release") IsNot Nothing Then
                Console.WriteLine("Version: " & CheckFor45DotVersion(CInt(ndpKey.GetValue("Release"))))
            Else
                Console.WriteLine("Version 4.5 or later is not detected.")
            End If
        End Using
    End Sub
    '</snippet3>

    '<snippet4>
    ' Checking the version using >= will enable forward compatibility, 
    ' however you should always compile your code on newer versions of
    ' the framework to ensure your app works the same.
    Private Shared Function CheckFor45DotVersion(releaseKey As Integer) As String
        If releaseKey >= 393295 Then
            Return "4.6 or later"
        End If
        If releaseKey >= 379893 Then
            Return "4.5.2 or later"
        End If
        If releaseKey >= 378675 Then
            Return "4.5.1 or later"
        End If
        If releaseKey >= 378389 Then
            Return "4.5 or later"
        End If
        ' This line should never execute. A non-null release key should mean
        ' that 4.5 or later is installed.
        Return "No 4.5 or later version detected"
    End Function
    '</snippet4>


    '<snippet1>
    Private Shared Sub GetVersionFromRegistry()

        ' Opens the registry key for the .NET Framework entry.
        Using ndpKey As RegistryKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, ""). _
            OpenSubKey("SOFTWARE\Microsoft\NET Framework Setup\NDP\")
            ' As an alternative, if you know the computers you will query are running .NET Framework 4.5 
            ' or later, you can use:

            ' As an alternative, if you know the computers you will query are running .NET Framework 4.5 
            ' or later, you can use:
            '  Using ndpKey As RegistryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine,  _
            '  RegistryView.Registry32).OpenSubKey("SOFTWARE\Microsoft\NET Framework Setup\NDP\")

            For Each versionKeyName As String In ndpKey.GetSubKeyNames()
                If versionKeyName.StartsWith("v") Then
                    Dim versionKey As RegistryKey = ndpKey.OpenSubKey(versionKeyName)
                    Dim name As String = DirectCast(versionKey.GetValue("Version", ""), String)
                    Dim sp As String = versionKey.GetValue("SP", "").ToString()
                    Dim install As String = versionKey.GetValue("Install", "").ToString()
                    If install = "" Then
                        'no install info, ust be later
                        Console.WriteLine(versionKeyName & "  " & name)
                    Else
                        If sp <> "" AndAlso install = "1" Then
                            Console.WriteLine(versionKeyName & "  " & name & "  SP" & sp)

                        End If
                    End If
                    If name <> "" Then
                        Continue For
                    End If
                    For Each subKeyName As String In versionKey.GetSubKeyNames()
                        Dim subKey As RegistryKey = versionKey.OpenSubKey(subKeyName)
                        name = DirectCast(subKey.GetValue("Version", ""), String)
                        If name <> "" Then
                            sp = subKey.GetValue("SP", "").ToString()
                        End If
                        install = subKey.GetValue("Install", "").ToString()
                        If install = "" Then
                            'no install info, ust be later
                            Console.WriteLine(versionKeyName & "  " & name)
                        Else
                            If sp <> "" AndAlso install = "1" Then
                                Console.WriteLine("  " & subKeyName & "  " & name & "  SP" & sp)
                            ElseIf install = "1" Then
                                Console.WriteLine("  " & subKeyName & "  " & name)

                            End If
                        End If
                    Next
                End If
            Next
        End Using
    End Sub
    '</snippet1>
End Class
