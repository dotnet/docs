        ' Display a message box. The Help button opens 
        ' the Mspaint.chm Help file and shows the Help contents 
        ' on the Index tab.
        Dim r3 As DialogResult = MessageBox.Show("Message with Help file and Help navigator.", _
                                           "Help Caption", MessageBoxButtons.OK, _
                                           MessageBoxIcon.Question, _
                                           MessageBoxDefaultButton.Button1, _
                                           0, "mspaint.chm", _
                                           HelpNavigator.Index)
