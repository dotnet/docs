
' <Snippet0>
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles

Namespace VisualStyleStateSample

    Class Form1
        Inherits Form
        Private WithEvents button1 As New Button()
        Private radioButton1 As New RadioButton()
        Private radioButton2 As New RadioButton()
        Private radioButton3 As New RadioButton()
        Private radioButton4 As New RadioButton()

        Public Sub New()
            With button1
                .AutoSize = True
                .Location = New Point(10, 10)
                .Text = "Update VisualStyleState"
            End With

            With radioButton1
                .Location = New Point(10, 50)
                .AutoSize = True
                .Text = "Apply styles to client area only"
            End With

            With radioButton2
                .Location = New Point(10, 70)
                .AutoSize = True
                .Text = "Apply styles to nonclient area only"
            End With

            With radioButton3
                .Location = New Point(10, 90)
                .AutoSize = True
                .Text = "Apply styles to client and nonclient areas"
            End With

            With radioButton4
                .Location = New Point(10, 110)
                .AutoSize = True
                .Text = "Disable styles in all areas"
            End With

            Me.Text = "VisualStyleState Test"
            Me.Controls.AddRange(New Control() {button1, radioButton1, _
                radioButton2, radioButton3, radioButton4})
        End Sub

        <STAThread()> _
        Shared Sub Main()
            Application.EnableVisualStyles()
            Application.Run(New Form1())
        End Sub

        ' <Snippet10>
        Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) _
            Handles button1.Click

            If radioButton1.Checked Then
                Application.VisualStyleState = _
                    VisualStyleState.ClientAreaEnabled
            ElseIf radioButton2.Checked Then
                Application.VisualStyleState = _
                    VisualStyleState.NonClientAreaEnabled
            ElseIf radioButton3.Checked Then
                Application.VisualStyleState = _
                    VisualStyleState.ClientAndNonClientAreasEnabled
            ElseIf radioButton4.Checked Then
                Application.VisualStyleState = _
                    VisualStyleState.NoneEnabled
            End If

            ' Repaint the form and all child controls.
            Me.Invalidate(True)
        End Sub
        ' </Snippet10>

    End Class
End Namespace
' </Snippet0>