    ' Declare the drop-down button and the items it will contain.
    Friend WithEvents dropDownButton1 As ToolStripDropDownButton
    Friend WithEvents dropDown As ToolStripDropDown
    Friend WithEvents buttonRed As ToolStripButton
    Friend WithEvents buttonBlue As ToolStripButton
    Friend WithEvents buttonYellow As ToolStripButton
    
    Private Sub InitializeDropDownButton() 
        dropDownButton1 = New ToolStripDropDownButton()
        dropDown = New ToolStripDropDown()
        dropDownButton1.Text = "A"
        
        ' Set the drop-down on the ToolStripDropDownButton.
        dropDownButton1.DropDown = dropDown

        ' Set the drop-down direction.
        dropDownButton1.DropDownDirection = ToolStripDropDownDirection.Left

        ' Do not show a drop-down arrow.
        dropDownButton1.ShowDropDownArrow = False

        ' Declare three buttons, set their foreground color and text, 
        ' and add the buttons to the drop-down.
        buttonRed = New ToolStripButton()
        buttonRed.ForeColor = Color.Red
        buttonRed.Text = "A"
        
        buttonBlue = New ToolStripButton()
        buttonBlue.ForeColor = Color.Blue
        buttonBlue.Text = "A"
        
        buttonYellow = New ToolStripButton()
        buttonYellow.ForeColor = Color.Yellow
        buttonYellow.Text = "A"
        
        dropDown.Items.AddRange(New ToolStripItem() {buttonRed, buttonBlue, buttonYellow})
        toolStrip1.Items.Add(dropDownButton1)
    End Sub
    
    ' Handle the buttons' click event by setting the foreground color of the
    ' form to the foreground color of the button that is clicked.
    Public Sub colorButtonsClick(ByVal sender As [Object], ByVal e As EventArgs) _
        Handles buttonRed.Click, buttonBlue.Click, buttonYellow.Click
        Dim senderButton As ToolStripButton = CType(sender, ToolStripButton)
        Me.ForeColor = senderButton.ForeColor

    End Sub