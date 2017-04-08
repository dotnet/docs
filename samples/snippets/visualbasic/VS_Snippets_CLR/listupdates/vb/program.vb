
'<Snippet1>
Imports Microsoft.Win32

Public Class GetUpdateHistory
    Public Shared Sub Main()
        Using baseKey As RegistryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey("SOFTWARE\Microsoft\Updates")
            For Each baseKeyName As String In baseKey.GetSubKeyNames()
                If baseKeyName.Contains(".NET Framework") OrElse baseKeyName.StartsWith("KB") OrElse baseKeyName.Contains(".NETFramework") Then

                    Using updateKey As RegistryKey = baseKey.OpenSubKey(baseKeyName)
                        Dim name As String = CStr(updateKey.GetValue("PackageName", ""))
                        Console.WriteLine(baseKeyName & "  " & name)
                        For Each kbKeyName As String In updateKey.GetSubKeyNames()
                            Using kbKey As RegistryKey = updateKey.OpenSubKey(kbKeyName)
                                name = CStr(kbKey.GetValue("PackageName", ""))
                                Console.WriteLine("  " & kbKeyName & "  " & name)

                                If kbKey.SubKeyCount > 0 Then
                                    For Each sbKeyName As String In kbKey.GetSubKeyNames()
                                        Using sbSubKey As RegistryKey = kbKey.OpenSubKey(sbKeyName)
                                            name = CStr(sbSubKey.GetValue("PackageName", ""))
                                            If name = "" Then
                                                name = CStr(sbSubKey.GetValue("Description", ""))
                                            End If
                                            Console.WriteLine("    " & sbKeyName & "  " & name)

                                        End Using
                                    Next sbKeyName
                                End If
                            End Using
                        Next kbKeyName
                    End Using

                End If
            Next baseKeyName
        End Using
    End Sub
End Class
'</Snippet1>