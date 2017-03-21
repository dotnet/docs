// This button is a simple extension of the button class that overrides
// the ProcessMnemonic method.  If the mnemonic is correctly entered,  
// the message box will appear and the click event will be raised.  
public class MyMnemonicButton:Button

	// This method makes sure the control is selectable and the 
	// mneumonic is correct before displaying the message box
	// and triggering the click event.
{
	[UIPermission(
        SecurityAction.Demand, Window = UIPermissionWindow.AllWindows)]
        protected override bool ProcessMnemonic(char inputChar)
	{

		if (CanSelect&&IsMnemonic(inputChar, this.Text))
		{
			MessageBox.Show("You've raised the click event " +
				"using the mnemonic.");
			this.PerformClick();
			return true;
		}
		return false;
	}

}