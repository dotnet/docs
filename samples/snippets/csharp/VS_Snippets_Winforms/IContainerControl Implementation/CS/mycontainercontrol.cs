// <snippet1>
using System;
using System.Windows.Forms;
using System.Drawing;

	public class MyContainer : ScrollableControl, IContainerControl
	{
		private Control activeControl;
		public MyContainer() 
		{
			// Make the container control Blue so it can be distinguished on the form.
			this.BackColor = Color.Blue;
			
			// Make the container scrollable.
			this.AutoScroll = true;
		}

		// Add implementation to the IContainerControl.ActiveControl property.
		public Control ActiveControl
		{
			get
			{
				return activeControl;
			}

			set
			{
				// Make sure the control is a member of the ControlCollection.
				if(this.Controls.Contains(value))
				{
					activeControl = value;
				}
			}
		}

		// Add implementations to the IContainerControl.ActivateControl(Control) method.
		public bool ActivateControl(Control active)
		{
			if(this.Controls.Contains(active))
			{
				// Select the control and scroll the control into view if needed.
				active.Select();
				this.ScrollControlIntoView(active);
				this.activeControl = active;
				return true;
			}
			return false;
		}
	}
// </snippet1>