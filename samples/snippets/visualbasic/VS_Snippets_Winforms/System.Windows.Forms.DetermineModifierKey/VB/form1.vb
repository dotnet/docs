' <Snippet0>
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Namespace DetermineModifierKey

    Class Form1
        Inherits Form

        Private WithEvents TextBox1 As New TextBox()

        <STAThread()> _
        Shared Sub Main()
            Application.EnableVisualStyles()
            Application.Run(New Form1())
        End Sub

        Public Sub New()
            Me.Controls.Add(TextBox1)
        End Sub

        ' <Snippet5>
        Public Sub TextBox1_KeyPress(ByVal sender As Object, _
            ByVal e As KeyPressEventArgs) Handles TextBox1.KeyPress

            If ((Control.ModifierKeys And Keys.Shift) = Keys.Shift) Then
                MsgBox("Pressed " + Keys.Shift.ToString())
            End If
        End Sub
        ' </Snippet5>

    End Class
End Namespace
' </Snippet0>