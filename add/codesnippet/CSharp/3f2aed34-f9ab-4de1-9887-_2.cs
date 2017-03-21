            // Display a message box with a help button. 
            // The Help button opens the Mspaint.chm Help file.
            DialogResult r1 = MessageBox.Show ("Message with Help file.", 
                                               "Help Caption", MessageBoxButtons.OK, 
                                               MessageBoxIcon.Question, 
                                               MessageBoxDefaultButton.Button1, 
                                               0, 
                                               "mspaint.chm");