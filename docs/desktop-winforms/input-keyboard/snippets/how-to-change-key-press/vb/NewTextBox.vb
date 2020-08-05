Imports System.Windows.Forms

Public Class NewTextBox
    Inherits TextBox

    '<PreProcessMessage>
    Public Overrides Function PreProcessMessage(ByRef m As Message) As Boolean

        Const WM_KEYDOWN = &H100

        If m.Msg = WM_KEYDOWN Then
            Dim keyCode As Keys = CType(m.WParam, Keys) And Keys.KeyCode

            Select Case keyCode
                Case Keys.F1 : m.WParam = CType(Keys.D1, IntPtr)
                Case Keys.F2 : m.WParam = CType(Keys.D2, IntPtr)
                Case Keys.F3 : m.WParam = CType(Keys.D3, IntPtr)
                Case Keys.F4 : m.WParam = CType(Keys.D4, IntPtr)
                Case Keys.F5 : m.WParam = CType(Keys.D5, IntPtr)
                Case Keys.F6 : m.WParam = CType(Keys.D6, IntPtr)
                Case Keys.F7 : m.WParam = CType(Keys.D7, IntPtr)
                Case Keys.F8 : m.WParam = CType(Keys.D8, IntPtr)
                Case Keys.F9 : m.WParam = CType(Keys.D9, IntPtr)
                Case Keys.F10 : m.WParam = CType(Keys.D0, IntPtr)
            End Select
        End If

        Return MyBase.PreProcessMessage(m)
    End Function
    '</PreProcessMessage>

End Class
