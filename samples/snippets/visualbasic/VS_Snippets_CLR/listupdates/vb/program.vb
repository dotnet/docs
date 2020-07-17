
Imports Microsoft.Win32

Public Class GetUpdateHistory
    Public Shared Sub Main()
        Using baseKey As RegistryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey("SOFTWARE\Microsoft\Updates")
            For Each baseKeyName As String In baseKey.GetSubKeyNames()
                If baseKeyName.Contains(".NET Framework") Then
                    Using updateKey As RegistryKey = baseKey.OpenSubKey(baseKeyName)
                        Console.WriteLine(baseKeyName)
                        For Each kbKeyName As String In updateKey.GetSubKeyNames()
                            Using kbKey As RegistryKey = updateKey.OpenSubKey(kbKeyName)
                                Console.WriteLine("  " & kbKeyName)
                            End Using
                        Next
                    End Using
                End If
            Next
        End Using
    End Sub
End Class
