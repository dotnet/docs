   ' This example assumes that the Form_Load event handling method
   ' is connected to the Load event of the form.
   Private Sub Form1_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
      ' Create the ToolTip and associate with the Form container.
      Dim toolTip1 As New ToolTip()
      
      ' Set up the delays for the ToolTip.
      toolTip1.AutoPopDelay = 5000
      toolTip1.InitialDelay = 1000
      toolTip1.ReshowDelay = 500
      ' Force the ToolTip text to be displayed whether or not the form is active.
      toolTip1.ShowAlways = True
      
      ' Set up the ToolTip text for the Button and Checkbox.
      toolTip1.SetToolTip(Me.button1, "My button1")
      toolTip1.SetToolTip(Me.checkBox1, "My checkBox1")
   End Sub