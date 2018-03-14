Imports Microsoft.Win32

Public Module VersionTest
    Public Sub Main()
        GetVersionFromRegistry()
    End Sub
    
    Private Sub GetVersionFromRegistry()

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
End Module
