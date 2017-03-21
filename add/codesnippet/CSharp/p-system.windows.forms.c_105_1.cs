	// This method handles the mouse down event for all the controls on the form.  
	// When a control has captured the mouse
	// the control's name will be output on label1.
	private void Control_MouseDown(System.Object sender, 
		System.Windows.Forms.MouseEventArgs e)
	{
		Control control = (Control) sender;
		if (control.Capture)
		{
			label1.Text = control.Name+" has captured the mouse";
		}
	}