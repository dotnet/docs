      Private Sub Form1_Load(sender As Object, _
        e As EventArgs) Handles MyBase.Load
         ' Display the hand cursor when the mouse pointer
         ' is over the combo box drop-down button. 
         comboBox1.Cursor = Cursors.Hand
         
         ' Fill the combo box with all the logical 
         ' drives available to the user. 
         Try
            Dim logicalDrive As String
            For Each logicalDrive In  Environment.GetLogicalDrives()
               comboBox1.Items.Add(logicalDrive)
            Next logicalDrive
         Catch ex As Exception
            MessageBox.Show(ex.Message)
         End Try
      End Sub