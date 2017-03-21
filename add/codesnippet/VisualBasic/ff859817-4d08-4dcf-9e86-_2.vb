        ' Display a message box. The Help button opens the Mspaint.chm Help file, 
        ' shows index with the "ovals" keyword selected, and displays the
        ' associated topic.
        Dim r5 As DialogResult = MessageBox.Show("Message with Help file and Help navigator with additional parameter.", _
                                           "Help Caption", MessageBoxButtons.OK, _
                                           MessageBoxIcon.Question, _
                                           MessageBoxDefaultButton.Button1, _
                                           0, "mspaint.chm", _
                                           HelpNavigator.KeywordIndex, "ovals")
