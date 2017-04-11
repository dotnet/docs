// <snippet1>
using System;
using System.Windows.Forms;
using System.Drawing;

public class MyButton : ButtonBase, IButtonControl
{
	private DialogResult myDialogResult;

	public MyButton()
	{
		// Make the button White and a Popup style
		// so it can be distinguished on the form.
		this.FlatStyle = FlatStyle.Popup;
		this.BackColor = Color.White;
	}
		
	// Add implementation to the IButtonControl.DialogResult property.
	public DialogResult DialogResult
	{
		get
		{
			return this.myDialogResult;
		}

		set
		{
			if(Enum.IsDefined(typeof(DialogResult), value))				
			{
				this.myDialogResult = value;
			}
		}	
	}

	// Add implementation to the IButtonControl.NotifyDefault method.
	public void NotifyDefault(bool value)
	{
		if(this.IsDefault != value)
		{
			this.IsDefault = value;
		}
	}

	// Add implementation to the IButtonControl.PerformClick method.
	public void PerformClick()
	{
		if(this.CanSelect)
		{
			this.OnClick(EventArgs.Empty);
		}
	}
}
// </snippet1>