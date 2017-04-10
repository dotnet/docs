' This sample can go in TextBoxRenderer class overview.
' - Snippet2 can go in IsSupported and DrawTextBox
' - Snippet4 could go in TextFormatFlags

' This sample is a custom control that displays a static string and allows
' the user to select the TextFormatFlag to apply to the text.

' For simplicity, this sample does not handle run-time switching of visual styles.

'<Snippet0>
Imports System
Imports System.Text
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles

Namespace TextBoxRendererSample

    Class Form1
        Inherits Form

        Public Sub New()
            Me.Size = New Size(350, 200)
            Dim TextBox1 As New CustomTextBox()
            Controls.Add(TextBox1)
        End Sub

        <STAThread()> _
        Shared Sub Main()
            ' The call to EnableVisualStyles below does not affect whether 
            ' TextBoxRenderer draws the text box; as long as visual styles 
            ' are enabled by the operating system, TextBoxRenderer will 
            ' draw the text box.
            Application.EnableVisualStyles()
            Application.Run(New Form1())
        End Sub
    End Class

    Public Class CustomTextBox
        Inherits Control

        Private textFlags As TextFormatFlags = TextFormatFlags.Default
        Private WithEvents comboBox1 As New ComboBox()
        Private textBorder As New Rectangle()
        Private textRectangle As New Rectangle()
        Private textMeasurements As New StringBuilder()

        Public Sub New()

            With Me
                .Location = New Point(10, 10)
                .Size = New Size(300, 200)
                .Font = SystemFonts.IconTitleFont
                .Text = "This is a long sentence that will exceed " + _
                    "the text box bounds"
            End With

            textBorder.Location = New Point(10, 10)
            textBorder.Size = New Size(200, 50)
            textRectangle.Location = New Point(textBorder.X + 2, _
                textBorder.Y + 2)
            textRectangle.Size = New Size(textBorder.Size.Width - 4, _
                textBorder.Height - 4)

            comboBox1.Location = New Point(10, 100)
            comboBox1.Size = New Size(150, 20)

            ' Populate the combo box with the TextFormatFlags value names.
            Dim name As String
            For Each name In [Enum].GetNames(GetType(TextFormatFlags))
                comboBox1.Items.Add(name)
            Next name

            comboBox1.SelectedIndex = 0
            Me.Controls.Add(comboBox1)
        End Sub

        '<Snippet2>
        '<Snippet4>
        ' Use DrawText with the current TextFormatFlags.
        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            MyBase.OnPaint(e)

            If TextBoxRenderer.IsSupported Then
                TextBoxRenderer.DrawTextBox(e.Graphics, textBorder, Me.Text, _
                    Me.Font, textRectangle, textFlags, TextBoxState.Normal)
                Me.Parent.Text = "CustomTextBox Enabled"
            Else
                Me.Parent.Text = "CustomTextBox Disabled"
            End If
        End Sub
        '</Snippet2>

        ' Assign the combo box selection to the display text.
        Private Sub comboBox1_SelectedIndexChanged(ByVal sender As Object, _
            ByVal e As EventArgs) Handles comboBox1.SelectedIndexChanged

            Me.textFlags = CType([Enum].Parse(GetType(TextFormatFlags), _
                CStr(comboBox1.Items(comboBox1.SelectedIndex))), _
                TextFormatFlags)
            Invalidate()
        End Sub
        '</Snippet4>

    End Class
End Namespace
'</Snippet0>
