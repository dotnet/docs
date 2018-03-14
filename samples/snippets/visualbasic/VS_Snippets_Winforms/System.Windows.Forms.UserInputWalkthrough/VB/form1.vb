' User Input Test Application for new Windows Forms user input conceptual topics
' in Visual Studio 2005 documentation.

' <Snippet0>
Imports System
Imports System.Drawing
Imports System.ComponentModel
Imports System.Windows.Forms

Namespace UserInputWalkthrough

    Public Class Form1
        Inherits Form

        Dim Label1 As New Label
        Dim Label2 As New Label
        Dim TextBoxOutput As New TextBox
        Dim WithEvents TextBoxInput As New TextBox
        Dim WithEvents GroupBoxEvents As New GroupBox
        Dim WithEvents ButtonClear As New Button
        Dim WithEvents LinkLabelDrag As New LinkLabel

        Dim WithEvents CheckBoxToggleAll As New CheckBox
        Dim WithEvents CheckBoxMouse As New CheckBox
        Dim WithEvents CheckBoxMouseEnter As New CheckBox
        Dim WithEvents CheckBoxMouseMove As New CheckBox
        Dim WithEvents CheckBoxMousePoints As New CheckBox
        Dim WithEvents CheckBoxMouseDrag As New CheckBox
        Dim WithEvents CheckBoxMouseDragOver As New CheckBox
        Dim WithEvents CheckBoxKeyboard As New CheckBox
        Dim WithEvents CheckBoxKeyUpDown As New CheckBox
        Dim WithEvents CheckBoxFocus As New CheckBox
        Dim WithEvents CheckBoxValidation As New CheckBox

        <STAThread()> _
        Shared Sub Main()
            Application.EnableVisualStyles()
            Application.Run(New Form1())
        End Sub

        Public Sub New()
            MyBase.New()
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, _
            ByVal e As System.EventArgs) Handles MyBase.Load

            Me.GroupBoxEvents.SuspendLayout()
            Me.SuspendLayout()

            Label1.Location = New Point(232, 12)
            Label1.Size = New Size(98, 14)
            Label1.AutoSize = True
            Label1.Text = "Generated Events:"

            Label2.Location = New Point(13, 12)
            Label2.Size = New Size(95, 14)
            Label2.AutoSize = True
            Label2.Text = "User Input Target:"

            TextBoxInput.Location = New Point(13, 34)
            TextBoxInput.Size = New Size(200, 200)
            TextBoxInput.AllowDrop = True
            TextBoxInput.AutoSize = False
            TextBoxInput.Cursor = Cursors.Cross
            TextBoxInput.Multiline = True
            TextBoxInput.TabIndex = 1

            LinkLabelDrag.AllowDrop = True
            LinkLabelDrag.AutoSize = True
            LinkLabelDrag.Location = New Point(13, 240)
            LinkLabelDrag.Size = New Size(175, 14)
            LinkLabelDrag.TabIndex = 2
            LinkLabelDrag.TabStop = True
            LinkLabelDrag.Text = "Click here to use as a drag source"
            LinkLabelDrag.Links.Add(New LinkLabel.Link(0, _
                LinkLabelDrag.Text.Length))

            GroupBoxEvents.Location = New Point(13, 281)
            GroupBoxEvents.Size = New Size(200, 302)
            GroupBoxEvents.TabIndex = 3
            GroupBoxEvents.TabStop = False
            GroupBoxEvents.Text = "Event Filter:"
            GroupBoxEvents.Controls.Add(CheckBoxMouseEnter)
            GroupBoxEvents.Controls.Add(CheckBoxToggleAll)
            GroupBoxEvents.Controls.Add(CheckBoxMousePoints)
            GroupBoxEvents.Controls.Add(CheckBoxKeyUpDown)
            GroupBoxEvents.Controls.Add(CheckBoxMouseDragOver)
            GroupBoxEvents.Controls.Add(CheckBoxMouseDrag)
            GroupBoxEvents.Controls.Add(CheckBoxValidation)
            GroupBoxEvents.Controls.Add(CheckBoxMouseMove)
            GroupBoxEvents.Controls.Add(CheckBoxFocus)
            GroupBoxEvents.Controls.Add(CheckBoxKeyboard)
            GroupBoxEvents.Controls.Add(CheckBoxMouse)

            CheckBoxToggleAll.AutoSize = True
            CheckBoxToggleAll.Location = New Point(7, 20)
            CheckBoxToggleAll.Size = New Size(122, 17)
            CheckBoxToggleAll.TabIndex = 4
            CheckBoxToggleAll.Text = "Toggle All Events"

            CheckBoxMouse.AutoSize = True
            CheckBoxMouse.Location = New Point(7, 45)
            CheckBoxMouse.Size = New Size(137, 17)
            CheckBoxMouse.TabIndex = 5
            CheckBoxMouse.Text = "Mouse and Click Events"

            CheckBoxMouseEnter.AutoSize = True
            CheckBoxMouseEnter.Location = New Point(26, 69)
            CheckBoxMouseEnter.Margin = New Padding(3, 3, 3, 1)
            CheckBoxMouseEnter.Size = New System.Drawing.Size(151, 17)
            CheckBoxMouseEnter.TabIndex = 6
            CheckBoxMouseEnter.Text = "Mouse Enter/Hover/Leave"

            CheckBoxMouseMove.AutoSize = True
            CheckBoxMouseMove.Location = New Point(26, 89)
            CheckBoxMouseMove.Margin = New Padding(3, 2, 3, 3)
            CheckBoxMouseMove.Size = New Size(120, 17)
            CheckBoxMouseMove.TabIndex = 7
            CheckBoxMouseMove.Text = "Mouse Move Events"

            CheckBoxMousePoints.AutoSize = True
            CheckBoxMousePoints.Location = New Point(26, 112)
            CheckBoxMousePoints.Margin = New Padding(3, 3, 3, 1)
            CheckBoxMousePoints.Size = New Size(141, 17)
            CheckBoxMousePoints.TabIndex = 8
            CheckBoxMousePoints.Text = "Draw Mouse Points"

            CheckBoxMouseDrag.AutoSize = True
            CheckBoxMouseDrag.Location = New Point(26, 135)
            CheckBoxMouseDrag.Margin = New Padding(3, 1, 3, 3)
            CheckBoxMouseDrag.Size = New Size(151, 17)
            CheckBoxMouseDrag.TabIndex = 9
            CheckBoxMouseDrag.Text = "Mouse Drag && Drop Events"

            CheckBoxMouseDragOver.AutoSize = True
            CheckBoxMouseDragOver.Location = New Point(44, 159)
            CheckBoxMouseDragOver.Size = New Size(142, 17)
            CheckBoxMouseDragOver.TabIndex = 10
            CheckBoxMouseDragOver.Text = "Mouse Drag Over Events"

            CheckBoxKeyboard.AutoSize = True
            CheckBoxKeyboard.Location = New Point(8, 184)
            CheckBoxKeyboard.Size = New Size(103, 17)
            CheckBoxKeyboard.TabIndex = 11
            CheckBoxKeyboard.Text = "Keyboard Events"

            CheckBoxKeyUpDown.AutoSize = True
            CheckBoxKeyUpDown.Location = New Point(26, 207)
            CheckBoxKeyUpDown.Margin = New Padding(3, 3, 3, 1)
            CheckBoxKeyUpDown.Size = New Size(133, 17)
            CheckBoxKeyUpDown.TabIndex = 12
            CheckBoxKeyUpDown.Text = "Key Up && Down Events"

            CheckBoxFocus.AutoSize = True
            CheckBoxFocus.Location = New Point(8, 233)
            CheckBoxFocus.Margin = New Padding(3, 2, 3, 3)
            CheckBoxFocus.Size = New Size(146, 17)
            CheckBoxFocus.TabIndex = 13
            CheckBoxFocus.Text = "Focus && Activation Events"

            CheckBoxValidation.AutoSize = True
            CheckBoxValidation.Location = New Point(8, 257)
            CheckBoxValidation.Size = New Size(104, 17)
            CheckBoxValidation.TabIndex = 14
            CheckBoxValidation.Text = "Validation Events"

            TextBoxOutput.Location = New Point(232, 34)
            TextBoxOutput.Size = New Size(308, 510)
            TextBoxOutput.Multiline = True
            TextBoxOutput.CausesValidation = False
            TextBoxOutput.ReadOnly = True
            TextBoxOutput.ScrollBars = ScrollBars.Vertical
            TextBoxOutput.TabIndex = 15
            TextBoxOutput.WordWrap = False

            ButtonClear.Location = New Point(232, 560)
            ButtonClear.Size = New Size(308, 23)
            ButtonClear.TabIndex = 16
            ButtonClear.Text = "Clear Event List"

            Me.ClientSize = New Size(552, 595)
            Me.Controls.Add(LinkLabelDrag)
            Me.Controls.Add(ButtonClear)
            Me.Controls.Add(GroupBoxEvents)
            Me.Controls.Add(Label1)
            Me.Controls.Add(Label2)
            Me.Controls.Add(TextBoxInput)
            Me.Controls.Add(TextBoxOutput)
            Me.Text = "User Input Events"

            Me.GroupBoxEvents.ResumeLayout(False)
            Me.GroupBoxEvents.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()
            CheckAllChildCheckBoxes(Me, True)
        End Sub

        ' Recursively search the form for all contained checkboxes and 
        ' initially check them
        Private Sub CheckAllChildCheckBoxes(ByRef parent As Control, _
            ByVal value As Boolean)

            Dim currentControl As Control
            Dim box As CheckBox
            For Each currentControl In parent.Controls
                box = TryCast(currentControl, CheckBox)
                If box IsNot Nothing Then
                    box.Checked = value
                End If

                'Recurse if control contains other controls
                If currentControl.Controls.Count > 0 Then
                    CheckAllChildCheckBoxes(currentControl, value)
                End If
            Next
        End Sub

        ' All-purpose method for displaying a line of text in one of the
        ' text boxes.
        Private Sub DisplayLine(ByRef line As String)

            TextBoxOutput.AppendText(line)
            TextBoxOutput.AppendText(ControlChars.NewLine)
        End Sub

        ' Click event handler for the button that clears the text box.
        Private Sub ButtonClear_Click(ByVal sender As Object, _
            ByVal e As System.EventArgs) Handles ButtonClear.Click

            TextBoxOutput.Invalidate()
            TextBoxOutput.Clear()
        End Sub

        Private Sub TextBoxInput_KeyDown(ByVal sender As Object, _
            ByVal e As KeyEventArgs) Handles TextBoxInput.KeyDown

            If CheckBoxKeyUpDown.Checked = True Then
                DisplayLine("KeyDown: " + e.KeyData.ToString())
            End If
        End Sub

        Private Sub TextBoxInput_KeyUp(ByVal sender As Object, _
            ByVal e As KeyEventArgs) Handles TextBoxInput.KeyUp

            If CheckBoxKeyUpDown.Checked = True Then
                DisplayLine("KeyUp: " + e.KeyData.ToString())
            End If
        End Sub

        Private Sub TextBoxInput_KeyPress(ByVal sender As Object, _
            ByVal e As KeyPressEventArgs) Handles TextBoxInput.KeyPress

            If CheckBoxKeyboard.Checked = True Then

                If Char.IsWhiteSpace(e.KeyChar) Then
                    Dim keyVal As Integer
                    keyVal = AscW(e.KeyChar)
                    DisplayLine("KeyPress: WS-" + keyVal.ToString())
                Else
                    DisplayLine("KeyPress: " + e.KeyChar.ToString())
                End If
            End If
        End Sub

        Private Sub TextBoxInput_Click(ByVal sender As Object, _
            ByVal e As EventArgs) Handles TextBoxInput.Click

            If CheckBoxMouse.Checked = True Then
                DisplayLine("Click event")
            End If
        End Sub

        Private Sub TextBoxInput_DoubleClick(ByVal sender As Object, _
            ByVal e As EventArgs) Handles TextBoxInput.DoubleClick

            If CheckBoxMouse.Checked = True Then
                DisplayLine("DoubleClick event")
            End If
        End Sub

        Private Sub TextBoxInput_MouseClick(ByVal sender As Object, _
            ByVal e As MouseEventArgs) Handles TextBoxInput.MouseClick

            If CheckBoxMouse.Checked = True Then
                DisplayLine("MouseClick: " + e.Button.ToString() + _
                    " " + e.Location.ToString())
            End If
        End Sub

        Private Sub TextBoxInput_MouseDoubleClick(ByVal sender As Object, _
            ByVal e As MouseEventArgs) Handles TextBoxInput.MouseDoubleClick

            If CheckBoxMouse.Checked = True Then
                DisplayLine("MouseDoubleClick: " + e.Button.ToString() + _
                    " " + e.Location.ToString())
            End If
        End Sub

        Private Sub TextBoxInput_MouseDown(ByVal sender As System.Object, _
            ByVal e As MouseEventArgs) Handles TextBoxInput.MouseDown

            If CheckBoxMouse.Checked = True Then
                DisplayLine("MouseDown: " + e.Button.ToString() + _
                    " " + e.Location.ToString())
            End If
        End Sub

        Private Sub TextBoxInput_MouseUp(ByVal sender As Object, _
            ByVal e As MouseEventArgs) Handles TextBoxInput.MouseUp

            If CheckBoxMouse.Checked = True Then
                DisplayLine("MouseUp: " + e.Button.ToString() + _
                    " " + e.Location.ToString())
            End If

            ' The TextBox control was designed to change focus only on  
            ' the primary click, so force focus to avoid user confusion.
            If TextBoxInput.Focused = False Then
                TextBoxInput.Focus()
            End If
        End Sub

        Private Sub TextBoxInput_MouseEnter(ByVal sender As Object, _
            ByVal e As EventArgs) Handles TextBoxInput.MouseEnter

            If CheckBoxMouseEnter.Checked = True Then
                DisplayLine("MouseEnter event")
            End If
        End Sub

        Private Sub TextBoxInput_MouseHover(ByVal sender As Object, _
            ByVal e As EventArgs) Handles TextBoxInput.MouseHover

            If CheckBoxMouseEnter.Checked = True Then
                DisplayLine("MouseHover event")
            End If
        End Sub

        Private Sub TextBoxInput_MouseLeave(ByVal sender As Object, _
            ByVal e As EventArgs) Handles TextBoxInput.MouseLeave

            If CheckBoxMouseEnter.Checked = True Then
                DisplayLine("MouseLeave event")
            End If
        End Sub

        Private Sub TextBoxInput_MouseWheel(ByVal sender As Object, _
            ByVal e As MouseEventArgs) Handles TextBoxInput.MouseWheel

            If CheckBoxMouse.Checked = True Then
                DisplayLine("MouseWheel: " + e.Delta.ToString() + _
                    " detents at " + e.Location.ToString())
            End If
        End Sub

        Private Sub TextBoxInput_MouseMove(ByVal sender As Object, _
            ByVal e As MouseEventArgs) Handles TextBoxInput.MouseMove

            If CheckBoxMouseMove.Checked = True Then
                DisplayLine("MouseMove: " + e.Button.ToString() + " " + _
                    e.Location.ToString())
            End If

            If CheckBoxMousePoints.Checked = True Then
                Dim g As Graphics = TextBoxInput.CreateGraphics()
                g.FillRectangle(Brushes.Black, e.Location.X, _
                    e.Location.Y, 1, 1)
                g.Dispose()
            End If
        End Sub

        Private Sub TextBoxInput_MouseCaptureChanged( _
            ByVal sender As Object, ByVal e As EventArgs) _
            Handles TextBoxInput.MouseCaptureChanged

            If CheckBoxMouseDrag.Checked = True Then
                DisplayLine("MouseCaptureChanged event")
            End If
        End Sub

        Private Sub TextBoxInput_DragEnter(ByVal sender As Object, _
            ByVal e As DragEventArgs) Handles TextBoxInput.DragEnter

            Dim pt As Point
            If CheckBoxMouseDrag.Checked = True Then
                pt = New Point(e.X, e.Y)
                DisplayLine("DragEnter: " + _
                    CovertKeyStateToString(e.KeyState) _
                    + " at " + pt.ToString())
            End If
        End Sub

        Private Sub TextBoxInput_DragDrop(ByVal sender As Object, _
            ByVal e As DragEventArgs) Handles TextBoxInput.DragDrop

            If CheckBoxMouseDrag.Checked = True Then
                Dim pt As Point
                pt = New Point(e.X, e.Y)

                DisplayLine("DragDrop: " + _
                    CovertKeyStateToString(e.KeyState) _
                    + " at " + pt.ToString())
            End If
        End Sub

        Private Sub TextBoxInput_DragOver(ByVal sender As Object, _
            ByVal e As DragEventArgs) Handles TextBoxInput.DragOver

            If CheckBoxMouseDragOver.Checked = True Then
                Dim pt As Point
                pt = New Point(e.X, e.Y)
                DisplayLine("DragOver: " + _
                    CovertKeyStateToString(e.KeyState) _
                    + " at " + pt.ToString())
            End If

            ' Allow if drop data is of type string.
            If Not (e.Data.GetDataPresent(GetType(String))) Then
                e.Effect = DragDropEffects.None
            Else
                e.Effect = DragDropEffects.Copy
            End If
        End Sub

        Private Sub TextBoxInput_DragLeave(ByVal sender As Object, _
            ByVal e As EventArgs) Handles TextBoxInput.DragLeave

            If CheckBoxMouseDrag.Checked = True Then
                DisplayLine("DragLeave event")
            End If
        End Sub

        Private Function CovertKeyStateToString(ByVal keyState As Integer) _
            As String

            Dim keyString As String = "None"

            ' Which button was pressed?
            If ((keyState And 1) = 1) Then
                keyString = "Left"
            ElseIf ((keyState And 2) = 2) Then
                keyString = "Right"
            ElseIf ((keyState And 16) = 16) Then
                keyString = "Middle"
            End If

            ' Are one or more modifier keys also pressed?
            If ((keyState And 4) = 4) Then
                keyString += "+SHIFT"
            End If
            If ((keyState And 8) = 8) Then
                keyString += "+CTRL"
            End If
            If ((keyState And 32) = 32) Then
                keyString += "+ALT"
            End If

            Return keyString
        End Function

        Private Sub TextBoxInput_Enter(ByVal sender As Object, _
            ByVal e As EventArgs) Handles TextBoxInput.Enter

            If CheckBoxFocus.Checked = True Then
                DisplayLine("Enter event")
            End If
        End Sub

        Private Sub TextBoxInput_Leave(ByVal sender As Object, _
            ByVal e As EventArgs) Handles TextBoxInput.Leave

            If CheckBoxFocus.Checked = True Then
                DisplayLine("Leave event")
            End If
        End Sub

        Private Sub TextBoxInput_GotFocus(ByVal sender As Object, _
            ByVal e As EventArgs) Handles TextBoxInput.GotFocus

            If CheckBoxFocus.Checked = True Then
                DisplayLine("GotFocus event")
            End If
        End Sub

        Private Sub TextBoxInput_LostFocus(ByVal sender As Object, _
            ByVal e As EventArgs) Handles TextBoxInput.LostFocus

            If CheckBoxFocus.Checked = True Then
                DisplayLine("LostFocus event")
            End If
        End Sub

        Private Sub TextBoxInput_Validated(ByVal sender As Object, _
            ByVal e As EventArgs) Handles TextBoxInput.Validated

            If CheckBoxValidation.Checked = True Then
                DisplayLine("Validated event")
            End If
        End Sub

        Private Sub TextBoxInput_Validating(ByVal sender As Object, _
            ByVal e As CancelEventArgs) _
            Handles TextBoxInput.Validating

            If CheckBoxValidation.Checked = True Then
                DisplayLine("Validating event")
            End If
        End Sub

        Private Sub CheckBoxToggleAll_CheckedChanged( _
            ByVal sender As Object, ByVal e As EventArgs) _
            Handles CheckBoxToggleAll.CheckedChanged

            Dim cb As CheckBox
            cb = TryCast(sender, CheckBox)
            If cb IsNot Nothing Then
                CheckAllChildCheckBoxes(Me, cb.Checked)
            End If
        End Sub

        Private Sub CheckBoxMouse_CheckedChanged( _
            ByVal sender As Object, ByVal e As EventArgs) _
            Handles CheckBoxMouse.CheckedChanged

            ConfigureCheckBoxSettings()
        End Sub

        Private Sub CheckBoxMouseDrag_CheckedChanged( _
            ByVal sender As Object, ByVal e As EventArgs) _
            Handles CheckBoxMouseDrag.CheckedChanged

            ConfigureCheckBoxSettings()
        End Sub

        Private Sub CheckBoxKeyboard_CheckedChanged( _
            ByVal sender As Object, ByVal e As EventArgs) _
            Handles CheckBoxKeyboard.CheckedChanged

            ConfigureCheckBoxSettings()
        End Sub

        Private Sub CheckBoxMouseMove_CheckedChanged( _
            ByVal sender As Object, ByVal e As EventArgs) _
            Handles CheckBoxMouseEnter.CheckedChanged, _
                CheckBoxMouseMove.CheckedChanged

            ConfigureCheckBoxSettings()
        End Sub

        ' Reconcile dependencies between the check box 
        ' selection choices. 
        Private Sub ConfigureCheckBoxSettings()

            ' CheckBoxMouse is a top-level check box.
            If CheckBoxMouse.Checked = False Then
                CheckBoxMouseEnter.Enabled = False
                CheckBoxMouseMove.Enabled = False
                CheckBoxMouseDrag.Enabled = False
                CheckBoxMouseDragOver.Enabled = False
                CheckBoxMousePoints.Enabled = False
            Else
                CheckBoxMouseEnter.Enabled = True
                CheckBoxMouseMove.Enabled = True
                CheckBoxMouseDrag.Enabled = True
                CheckBoxMousePoints.Enabled = True

                ' Enable children depending on the state of the parent.
                If CheckBoxMouseDrag.Checked = False Then
                    CheckBoxMouseDragOver.Enabled = False
                Else
                    CheckBoxMouseDragOver.Enabled = True
                End If
            End If

            If CheckBoxKeyboard.Checked = False Then
                CheckBoxKeyUpDown.Enabled = False
            Else
                CheckBoxKeyUpDown.Enabled = True
            End If
        End Sub

        Private Sub LinkLabelDrag_MouseDown(ByVal sender As Object, _
            ByVal e As MouseEventArgs) Handles LinkLabelDrag.MouseDown

            Dim data As String = "Sample Data"
            LinkLabelDrag.DoDragDrop(data, DragDropEffects.All)
        End Sub

        Private Sub LinkLabelDrag_GiveFeedback(ByVal sender As Object, _
            ByVal e As GiveFeedbackEventArgs) _
            Handles LinkLabelDrag.GiveFeedback

            If ((e.Effect And DragDropEffects.Copy) = _
                DragDropEffects.Copy) Then
                LinkLabelDrag.Cursor = Cursors.HSplit
            Else
                LinkLabelDrag.Cursor = Cursors.Default
            End If
        End Sub

    End Class
End Namespace
' </Snippet0>