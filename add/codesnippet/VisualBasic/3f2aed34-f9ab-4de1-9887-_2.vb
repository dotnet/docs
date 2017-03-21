        ' Display a message box with a help button. 
        ' The Help button opens the Mspaint.chm Help file.
        Dim r1 As DialogResult = MessageBox.Show("Message with Help file.", _
                                           "Help Caption", MessageBoxButtons.OK, _
                                           MessageBoxIcon.Question, _
                                           MessageBoxDefaultButton.Button1, _
                                           0, _
                                           "mspaint.chm")