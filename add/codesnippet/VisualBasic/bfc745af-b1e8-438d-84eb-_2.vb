        ' Display message box parented to the main form. 
        ' The Help button opens the Mspaint.chm Help file, 
        ' shows index with the "ovals" keyword selected, and displays the
        ' associated topic.
        Dim r6 As DialogResult = MessageBox.Show(Me, _
                                           "Message with Help file and Help navigator with additional parameter.", _
                                           "Help Caption", MessageBoxButtons.OK, _
                                           MessageBoxIcon.Question, _
                                           MessageBoxDefaultButton.Button1, _
                                           0, "mspaint.chm", _
                                           HelpNavigator.KeywordIndex, "ovals")
