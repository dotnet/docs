' This sample compiles a set of miscellaneous code snippets that demonstrate
' different levels of user input control.

' <Snippet0>
Imports System
Imports System.Drawing
Imports System.Security
Imports System.Security.Permissions
Imports System.Windows.Forms


Namespace KeyboardInput
<System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _ 
    Class Form1
        Inherits Form

        ' The following Windows message value is defined in Winuser.h.
        Private WM_KEYDOWN As Integer = &H100
        Private WithEvents CustomTextBox1 As New CustomTextBox()

        <STAThread()> _
        Public Shared Sub Main()
            Application.EnableVisualStyles()
            Application.Run(New Form1())
        End Sub

        Public Sub New()
            Me.AutoSize = True
            Me.Controls.Add(CustomTextBox1)
        End Sub

        ' <Snippet5>
        ' Consume and modify several character keys.
        Sub CustomTextBox1_KeyPress(ByVal sender As Object, _
            ByVal e As KeyPressEventArgs) Handles CustomTextBox1.KeyPress

            Select Case e.KeyChar

                ' <Snippet6>
                ' Consume 'A' and 'a'.
                Case ChrW(65), ChrW(97)
                    MessageBox.Show(("Control.KeyPress: '" + _
                        e.KeyChar.ToString() + "' consumed."))
                    e.Handled = True
                 '</Snippet6>

                 '<Snippet7>
                    ' Modify 'B' to 'A' and forward the key.
                Case ChrW(66)
                    MessageBox.Show(("Control.KeyPress: '" + _
                        e.KeyChar.ToString() + "' replaced by 'A'."))
                    e.KeyChar = ChrW(65)
                    e.Handled = False

                    ' Modify 'b' to 'a' and forward the key.
                Case ChrW(98)
                    MessageBox.Show(("Control.KeyPress: '" + _
                        e.KeyChar.ToString() + "' replaced by 'a'."))
                    e.KeyChar = ChrW(97)
                    e.Handled = False
                 '</Snippet7>
            End Select
        End Sub
        ' </Snippet5>
    End Class

<System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _ 
    Public Class CustomTextBox
        Inherits TextBox

        ' The following Windows message value is defined in Winuser.h.
        Private WM_KEYDOWN As Integer = &H100

        Public Sub New()
            Me.Size = New Size(100, 100)
            Me.AutoSize = False
        End Sub

        ' <Snippet10>
        ' <Snippet12>
        ' Detect F1 through F9 during preprocessing and modify F3.
        Public Overrides Function PreProcessMessage(ByRef m As Message) _
            As Boolean

            If m.Msg = WM_KEYDOWN Then
                Dim keyCode As Keys = CType(m.WParam, Keys) And Keys.KeyCode

                ' Detect F1 through F9.
                Select Case keyCode
                    Case Keys.F1, Keys.F2, Keys.F3, Keys.F4, Keys.F5, _
                         Keys.F6, Keys.F7, Keys.F8, Keys.F9

                        MessageBox.Show(("Control.PreProcessMessage: '" + _
                            keyCode.ToString() + "' pressed."))

                        ' Replace F3 with F1, so that ProcessKeyMessage will  
                        ' receive F1 instead of F3.
                        If keyCode = Keys.F3 Then
                            m.WParam = CType(Keys.F1, IntPtr)
                            MessageBox.Show(("Control.PreProcessMessage: '" + _
                                keyCode.ToString() + "' replaced by F1."))
                        End If
                End Select
            End If

            ' Send all other messages to the base method.
            Return MyBase.PreProcessMessage(m)
        End Function
        ' </Snippet12>

        ' Detect F1 through F9 during processing.
        Protected Overrides Function ProcessKeyMessage(ByRef m As Message) _
            As Boolean

            If m.Msg = WM_KEYDOWN Then
                Dim keyCode As Keys = CType(m.WParam, Keys) And Keys.KeyCode

                ' Detect F1 through F9.
                Select Case keyCode
                    Case Keys.F1, Keys.F2, Keys.F3, Keys.F4, Keys.F5, _
                         Keys.F6, Keys.F7, Keys.F8, Keys.F9

                        MessageBox.Show(("Control.ProcessKeyMessage: '" + _
                            keyCode.ToString() + "' pressed."))
                End Select
            End If

            ' Send all messages to the base method.
            Return MyBase.ProcessKeyMessage(m)
        End Function
        ' </Snippet10>

    End Class
End Namespace
' </Snippet0>