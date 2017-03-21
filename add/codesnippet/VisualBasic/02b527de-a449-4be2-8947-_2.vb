        ' Display a message box parented to the main form. 
        ' The Help button opens the Mspaint.chm Help file.
        Dim r2 As DialogResult = MessageBox.Show(Me, "Message with Help file.", _
                                           "Help Caption", MessageBoxButtons.OK, _
                                           MessageBoxIcon.Question, _
                                           MessageBoxDefaultButton.Button1, _
                                           0, _
                                           "mspaint.chm")