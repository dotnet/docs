        // Display a message box with a Help button. Show a custom Help window
        // by handling the HelpRequested event.
        private DialogResult AlertMessageWithCustomHelpWindow ()
        {
            // Handle the HelpRequested event for the following message.
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler (this.Form1_HelpRequested);

            this.Tag = "Message with Help button.";

            // Show a message box with OK and Help buttons.
            DialogResult r = MessageBox.Show ("Message with Help button.", 
                                              "Help Caption", MessageBoxButtons.OK, 
                                              MessageBoxIcon.Question, 
                                              MessageBoxDefaultButton.Button1, 
                                              0, true);

            // Remove the HelpRequested event handler to keep the event
            // from being handled for other message boxes.
            this.HelpRequested -= new System.Windows.Forms.HelpEventHandler (this.Form1_HelpRequested);

            // Return the dialog box result.
            return r;
        }

        private void Form1_HelpRequested (System.Object sender, System.Windows.Forms.HelpEventArgs hlpevent)
        {
            // Create a custom Help window in response to the HelpRequested event.
            Form helpForm = new Form ();

            // Set up the form position, size, and title caption.
            helpForm.StartPosition = FormStartPosition.Manual;
            helpForm.Size = new Size (200, 400);
            helpForm.DesktopLocation = new Point (this.DesktopBounds.X + 
                                                  this.Size.Width, 
                                                  this.DesktopBounds.Top);
            helpForm.Text = "Help Form";

            // Create a label to contain the Help text.
            Label helpLabel = new Label ();

            // Add the label to the form and set its text.
            helpForm.Controls.Add (helpLabel);
            helpLabel.Dock = DockStyle.Fill;

            // Use the sender parameter to identify the context of the Help request.
            // The parameter must be cast to the Control type to get the Tag property.
            Control senderControl = sender as Control;

            helpLabel.Text = "Help information shown in response to user action on the '" + 
                              (string)senderControl.Tag + "' message.";

            // Set the Help form to be owned by the main form. This helps
            // to ensure that the Help form is disposed of.
            this.AddOwnedForm (helpForm);

            // Show the custom Help window.
            helpForm.Show ();

            // Indicate that the HelpRequested event is handled.
            hlpevent.Handled = true;
        }