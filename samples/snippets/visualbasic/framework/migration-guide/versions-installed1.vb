Imports Microsoft.Win32

Public Module VersionTest
    Public Sub Main()
        GetVersionFromRegistry()
    End Sub
    
    Private Sub GetVersionFromRegistry()

        ' Opens the registry key for the .NET Framework entry.
        Using ndpKey As RegistryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32). 
            OpenSubKey("SOFTWARE\Microsoft\NET Framework Setup\NDP\")

            For Each versionKeyName In ndpKey.GetSubKeyNames()
                ' Skip .NET Framework 4.5 and later.
                If versionKeyName = "v4" Then Continue For

                If versionKeyName.StartsWith("v") Then
                    Dim versionKey As RegistryKey = ndpKey.OpenSubKey(versionKeyName)
                    ' Get the .NET Framework version value.
                    Dim name = DirectCast(versionKey.GetValue("Version", ""), String)
                    ' Get the service pack (SP) number.
                    Dim sp = versionKey.GetValue("SP", "").ToString()
                   
                    Dim install = versionKey.GetValue("Install", "").ToString()
                    If String.IsNullOrEmpty(install) Then  ' No install info; it must be in a child subkey.
                        Console.WriteLine($"{versionKeyName}  {name}")
                    Else
                        If Not String.IsNullOrEmpty(sp) AndAlso install = "1" Then
                            Console.WriteLine($"{versionKeyName}  {name}  SP{sp}")
                        End If
                    End If
                    If Not String.IsNullOrEmpty(name) Then
                        Continue For
                    End If
                    For Each subKeyName In versionKey.GetSubKeyNames()
                        Dim subKey As RegistryKey = versionKey.OpenSubKey(subKeyName)
                        name = DirectCast(subKey.GetValue("Version", ""), String)
                        If Not String.IsNullOrEmpty(name) Then
                            sp = subKey.GetValue("SP", "").ToString()
                        End If
                        install = subKey.GetValue("Install", "").ToString()
                        If String.IsNullOrEmpty(install) Then  ' No install info; it must be later.
                            Console.WriteLine($"{versionKeyName}  {name}")
                        Else
                            If Not String.IsNullOrEmpty(sp) AndAlso install = "1" Then
                                Console.WriteLine($"{subKeyName}  {name}  SP{sp}")
                            ElseIf install = "1" Then
                                Console.WriteLine($"  {subKeyName}  {name}")
                            End If
                        End If
                    Next
                End If
            Next
        End Using
    End Sub
End Module
' The example displays output similar to the following:
'        v2.0.50727  2.0.50727.4927  SP2
'        v3.0  3.0.30729.4926  SP2
'        v3.5  3.5.30729.4926  SP1
'        v4.0
'        Client  4.0.0.0