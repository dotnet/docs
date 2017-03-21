            // Display a message box. The Help button opens 
            // the Mspaint.chm Help file and shows the Help contents 
            // on the Index tab.
            DialogResult r3 = MessageBox.Show ("Message with Help file and Help navigator.", 
                                               "Help Caption", MessageBoxButtons.OK,
                                               MessageBoxIcon.Question, 
                                               MessageBoxDefaultButton.Button1, 
                                               0, "mspaint.chm", 
                                               HelpNavigator.Index);
