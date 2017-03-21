            // Display a message box parented to the main form. 
            // The Help button opens the Mspaint.chm Help file.
            DialogResult r2 = MessageBox.Show (this, "Message with Help file.", 
                                               "Help Caption", MessageBoxButtons.OK, 
                                               MessageBoxIcon.Question, 
                                               MessageBoxDefaultButton.Button1, 
                                               0, 
                                               "mspaint.chm");