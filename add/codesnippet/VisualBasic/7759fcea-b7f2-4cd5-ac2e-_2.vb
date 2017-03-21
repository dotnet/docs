        ' Display message box parented to the main form. 
        ' The Help button opens the Mspaint.chm Help file, 
        ' and the "mspaint.chm::/paint_brush.htm" Help keyword shows the 
        ' associated topic.
        Dim r8 As DialogResult = MessageBox.Show(Me, "Message with Help file and keyword.", _
                                           "Help Caption", MessageBoxButtons.OK, _
                                           MessageBoxIcon.Question, _
                                           MessageBoxDefaultButton.Button1, 0, _
                                           "mspaint.chm", _
                                           "mspaint.chm::/paint_brush.htm")