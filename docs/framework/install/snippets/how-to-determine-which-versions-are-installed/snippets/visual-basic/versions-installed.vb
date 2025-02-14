Imports Microsoft.Win32

Module Program
    Sub Main()
        GetVersionFromRegistry()
        Get45PlusFromRegistry()
    End Sub

    Private Sub GetVersionFromRegistry()
        '<snippet1>
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
                    If String.IsNullOrEmpty(install) Then
                        ' No install info; it must be in a child subkey.
                        Console.WriteLine($"{versionKeyName}  {name}")
                    ElseIf install = "1" Then

                        If Not String.IsNullOrEmpty(sp) Then
                            Console.WriteLine($"{versionKeyName}  {name}  SP{sp}")
                        Else
                            Console.WriteLine($"{versionKeyName}  {name}")
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
                        If String.IsNullOrEmpty(install) Then
                            ' No install info; it must be later.
                            Console.WriteLine($"  {versionKeyName}  {name}")
                        ElseIf install = "1" Then

                            If Not String.IsNullOrEmpty(sp) Then
                                Console.WriteLine($"  {subKeyName}  {name}  SP{sp}")
                            Else
                                Console.WriteLine($"  {subKeyName}  {name}")
                            End If

                        End If
                    Next
                End If
            Next
        End Using
        '</snippet1>
    End Sub

    '<snippet2>
    Private Sub Get45PlusFromRegistry()
        Const subkey As String = "SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\"

        Using baseKey As RegistryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32),
            ndpKey As RegistryKey = baseKey.OpenSubKey(subkey)
            If ndpKey IsNot Nothing AndAlso ndpKey.GetValue("Release") IsNot Nothing Then
                Console.WriteLine($".NET Framework Version: {CheckFor45PlusVersion(ndpKey.GetValue("Release"))}")
            Else
                Console.WriteLine(".NET Framework Version 4.5 or later is not detected.")
            End If
        End Using
    End Sub

    ' Checking the version using >= enables forward compatibility.
    Private Function CheckFor45PlusVersion(releaseKey As Integer) As String
        If releaseKey >= 533320 Then
            Return "4.8.1 or later"
        ElseIf releaseKey >= 528040 Then
            Return "4.8"
        ElseIf releaseKey >= 461808 Then
            Return "4.7.2"
        ElseIf releaseKey >= 461308 Then
            Return "4.7.1"
        ElseIf releaseKey >= 460798 Then
            Return "4.7"
        ElseIf releaseKey >= 394802 Then
            Return "4.6.2"
        ElseIf releaseKey >= 394254 Then
            Return "4.6.1"
        ElseIf releaseKey >= 393295 Then
            Return "4.6"
        ElseIf releaseKey >= 379893 Then
            Return "4.5.2"
        ElseIf releaseKey >= 378675 Then
            Return "4.5.1"
        ElseIf releaseKey >= 378389 Then
            Return "4.5"
        End If
        ' This code should never execute. A non-null release key should mean
        ' that 4.5 or later is installed.
        Return "No 4.5 or later version detected"
    End Function
    '</snippet2>

End Module
