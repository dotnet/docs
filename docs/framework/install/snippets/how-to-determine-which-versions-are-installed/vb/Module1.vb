Imports Microsoft.Win32

Module Module1

    Sub Main()
        GetVersionFromRegistry()
        Get45PlusFromRegistry()
    End Sub

    Private Sub GetVersionFromRegistry()
        '<GetVersionFromRegistry>
        ' Open the registry key for the .NET Framework entry. Dispose this object when done.
        Dim ndpKey As RegistryKey =
            RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32) _
                .OpenSubKey("SOFTWARE\Microsoft\NET Framework Setup\NDP\")

        For Each versionKeyName In ndpKey.GetSubKeyNames()
            ' Skip .NET Framework 4.5 and later.
            If versionKeyName = "v4" Then Continue For

            If versionKeyName.StartsWith("v") Then

                Dim versionKey As RegistryKey = ndpKey.OpenSubKey(versionKeyName)

                ' Get the .NET Framework version value.
                Dim name = versionKey.GetValue("Version", "").ToString()

                ' Get the service pack (SP) number.
                Dim sp = versionKey.GetValue("SP", "").ToString()

                Dim install = versionKey.GetValue("Install", "").ToString()

                If String.IsNullOrEmpty(install) Then

                    ' No install info; it must be in a child subkey.
                    Console.WriteLine($"{versionKeyName}  {name}")

                ElseIf install = "1" Then

                    ' Install = 1 means the version is installed.
                    If Not String.IsNullOrEmpty(sp) Then
                        Console.WriteLine($"{versionKeyName}  {name}  SP{sp}")
                    Else
                        Console.WriteLine($"{versionKeyName}  {name}")
                    End If

                End If

                If Not String.IsNullOrEmpty(name) Then

                    versionKey.Dispose()
                    Continue For

                End If

                ' Iterate through the subkeys of the version subkey.
                For Each subKeyName In versionKey.GetSubKeyNames()

                    Dim subKey As RegistryKey = versionKey.OpenSubKey(subKeyName)
                    name = subKey.GetValue("Version", "").ToString()

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

                    ' Clean up the subkey object.
                    subKey.Dispose()

                Next

                versionKey.Dispose()

            End If
        Next

        ndpKey.Dispose()
        '</GetVersionFromRegistry>
    End Sub

    '<Get45PlusFromRegistry>
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
        Select Case releaseKey
            Case >= 533320 : Return "4.8.1 or later"
            Case >= 528040 : Return "4.8"
            Case >= 461808 : Return "4.7.2"
            Case >= 461308 : Return "4.7.1"
            Case >= 460798 : Return "4.7"
            Case >= 394802 : Return "4.6.2"
            Case >= 394254 : Return "4.6.1"
            Case >= 393295 : Return "4.6"
            Case >= 379893 : Return "4.5.2"
            Case >= 378675 : Return "4.5.1"
            Case >= 378389 : Return "4.5"
            Case Else
                Return "No 4.5 or later version detected"
        End Select
    End Function
    '</Get45PlusFromRegistry>


End Module
