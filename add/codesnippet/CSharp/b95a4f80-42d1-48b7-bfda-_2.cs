            // Display message box parented to the main form. 
            // The Help button opens the Mspaint.chm Help file
            // and shows the Help contents on the Index tab.
            DialogResult r4 = MessageBox.Show (this, 
                                               "Message with Help file and Help navigator.", 
                                               "Help Caption", MessageBoxButtons.OK,
                                               MessageBoxIcon.Question, 
                                               MessageBoxDefaultButton.Button1, 
                                               0, "mspaint.chm", 
                                               HelpNavigator.Index);
