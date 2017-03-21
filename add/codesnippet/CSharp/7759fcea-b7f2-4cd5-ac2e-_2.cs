            // Display message box parented to the main form. 
            // The Help button opens the Mspaint.chm Help file, 
            // and the "mspaint.chm::/paint_brush.htm" Help keyword shows the 
            // associated topic.
            DialogResult r8 = MessageBox.Show (this, "Message with Help file and keyword.", 
                                               "Help Caption", MessageBoxButtons.OK, 
                                               MessageBoxIcon.Question, 
                                               MessageBoxDefaultButton.Button1, 0, 
                                               "mspaint.chm", 
                                               "mspaint.chm::/paint_brush.htm");