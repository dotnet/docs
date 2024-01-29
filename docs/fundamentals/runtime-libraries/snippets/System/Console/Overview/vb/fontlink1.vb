' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports Microsoft.Win32

Module Example2
    Public Sub Main()
        Dim valueName As String = "Lucida Console"
        Dim newFont As String = "simsun.ttc,SimSun"
        Dim fonts() As String = Nothing
        Dim kind As RegistryValueKind
        Dim toAdd As Boolean

        Dim key As RegistryKey = Registry.LocalMachine.OpenSubKey(
                 "Software\Microsoft\Windows NT\CurrentVersion\FontLink\SystemLink",
                 True)
        If key Is Nothing Then
            Console.WriteLine("Font linking is not enabled.")
        Else
            ' Determine if the font is a base font.
            Dim names() As String = key.GetValueNames()
            If Array.Exists(names, Function(s) s.Equals(valueName,
                                                     StringComparison.OrdinalIgnoreCase)) Then
                ' Get the value's type.
                kind = key.GetValueKind(valueName)

                ' Type should be RegistryValueKind.MultiString, but we can't be sure.
                Select Case kind
                    Case RegistryValueKind.String
                        fonts = {CStr(key.GetValue(valueName))}
                    Case RegistryValueKind.MultiString
                        fonts = CType(key.GetValue(valueName), String())
                    Case RegistryValueKind.None
                        ' Do nothing.
                        fonts = {}
                End Select
                ' Determine whether SimSun is a linked font.
                If Array.FindIndex(fonts, Function(s) s.IndexOf("SimSun",
                                      StringComparison.OrdinalIgnoreCase) >= 0) >= 0 Then
                    Console.WriteLine("Font is already linked.")
                    toAdd = False
                Else
                    ' Font is not a linked font.
                    toAdd = True
                End If
            Else
                ' Font is not a base font.
                toAdd = True
                fonts = {}
            End If

            If toAdd Then
                Array.Resize(fonts, fonts.Length + 1)
                fonts(fonts.GetUpperBound(0)) = newFont
                ' Change REG_SZ to REG_MULTI_SZ.
                If kind = RegistryValueKind.String Then
                    key.DeleteValue(valueName, False)
                End If
                key.SetValue(valueName, fonts, RegistryValueKind.MultiString)
                Console.WriteLine("SimSun added to the list of linked fonts.")
            End If
        End If

        If key IsNot Nothing Then key.Close()
    End Sub
End Module
' </Snippet2>
