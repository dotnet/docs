    ' Display a message box with a Help button. Show a custom Help window
    ' by handling the HelpRequested event.
    Private Function AlertMessageWithCustomHelpWindow() As DialogResult

        ' Handle the HelpRequested event for the following message.
        AddHandler Me.HelpRequested, AddressOf Me.Form1_HelpRequested

        Me.Tag = "Message with Help button."

        ' Show a message box with OK and Help buttons.
        Dim r As DialogResult = MessageBox.Show("Message with Help button.", _
                                              "Help Caption", MessageBoxButtons.OK, _
                                              MessageBoxIcon.Question, _
                                              MessageBoxDefaultButton.Button1, _
                                              0, True)

        ' Remove the HelpRequested event handler to keep the event
        ' from being handled for other message boxes.
        RemoveHandler Me.HelpRequested, AddressOf Me.Form1_HelpRequested

        ' Return the dialog box result.
        Return r
    End Function

    Private Sub Form1_HelpRequested(ByVal sender As System.Object, ByVal hlpevent As System.Windows.Forms.HelpEventArgs)

        ' Create a custom Help window in response to the HelpRequested event.
        Dim helpForm As Form = New Form

        ' Set up the form position, size, and title caption.
        With helpForm
            .StartPosition = FormStartPosition.Manual
            .Size = New Size(200, 400)
            .DesktopLocation = New Point(Me.DesktopBounds.X + _
                                         Me.Size.Width, Me.DesktopBounds.Top)
            .Text = "Help Form"
        End With

        ' Create a label to contain the Help text.
        Dim helpLabel As Label = New Label

        ' Add the label to the form and set its text.
        helpForm.Controls.Add(helpLabel)
        helpLabel.Dock = DockStyle.Fill

        ' Use the sender parameter to identify the context of the Help request.
        ' The parameter must be cast to the Control type to get the Tag property.
        Dim senderControl As Control = CType(sender, Control)

        helpLabel.Text = "Help information shown in response to user action on the '" & _
                          CStr(senderControl.Tag) & "' message."

        ' Set the Help form to be owned by the main form. This helps
        ' to ensure that the Help form is disposed of.
        Me.AddOwnedForm(helpForm)

        ' Show the custom Help window.
        helpForm.Show()

        ' Indicate that the HelpRequested event is handled.
        hlpevent.Handled = True
    End Sub