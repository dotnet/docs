    
    ' This method initializes ColorDialog1 to allow any colors, 
    ' and combination colors on systems with 256 colors or less, 
    ' but will not allow the user to set custom colors.  The
    ' dialog will contain the help button.
    Private Sub InitializeColorDialog()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog
        Me.ColorDialog1.AllowFullOpen = False
        Me.ColorDialog1.AnyColor = True
        Me.ColorDialog1.SolidColorOnly = False
        Me.ColorDialog1.ShowHelp = True
    End Sub
  

    ' This method opens the dialog and checks the DialogResult value. 
    ' If the result is OK, the text box's background color will be changed 
    ' to the user-selected color.
    Private Sub Button1_Click(ByVal sender As System.Object,  _
        ByVal e As System.EventArgs) Handles Button1.Click
        Dim result As DialogResult = ColorDialog1.ShowDialog()
        If (result.Equals(DialogResult.OK)) Then
            TextBox1.BackColor = ColorDialog1.Color
        End If
    End Sub
 
  
    ' This method is called when the HelpRequest event is raised, 
    'which occurs when the user clicks the Help button on the ColorDialog object.
    Private Sub ColorDialog1_HelpRequest(ByVal sender As Object, _ 
        ByVal e As System.EventArgs) Handles ColorDialog1.HelpRequest

        MessageBox.Show("Please select a color by clicking it." _
        & "This will change the BackColor property of the TextBox.")
    End Sub