        ' Display a message box. The Help button opens the Mspaint.chm Help file, 
        ' and the "mspaint.chm::/paint_brush.htm" Help keyword shows the 
        ' associated topic.
        Dim r7 As DialogResult = MessageBox.Show("Message with Help file and keyword.", _
                                           "Help Caption", MessageBoxButtons.OK, _
                                           MessageBoxIcon.Question, _
                                           MessageBoxDefaultButton.Button1, 0, _
                                           "mspaint.chm", _
                                           "mspaint.chm::/paint_brush.htm")