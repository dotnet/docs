//<snippet2>
using System.Windows.Forms;
using System.Security.Permissions;

public class Form1:
	System.Windows.Forms.Form

	// Declare the controls contained on the form.
{
	private MyMnemonicButton button1;
	internal System.Windows.Forms.ListBox ListBox1;

	public Form1() : base()
	{        

		// Set KeyPreview object to true to allow the form to process 
		// the key before the control with focus processes it.
		this.KeyPreview = true;

		// Add a MyMnemonicButton.  
		button1 = new MyMnemonicButton();
		button1.Text = "&Click";
		button1.Location = new System.Drawing.Point(100, 120);
		this.Controls.Add(button1);

		// Initialize a ListBox control and the form itself.
		this.ListBox1 = new System.Windows.Forms.ListBox();
		this.SuspendLayout();
		this.ListBox1.Location = new System.Drawing.Point(8, 8);
		this.ListBox1.Name = "ListBox1";
		this.ListBox1.Size = new System.Drawing.Size(120, 95);
		this.ListBox1.TabIndex = 0;
		this.ListBox1.Text = "Press a key";
		this.ClientSize = new System.Drawing.Size(292, 266);
		this.Controls.Add(this.ListBox1);
		this.Name = "Form1";
		this.Text = "Form1";
		this.ResumeLayout(false);

		// Associate the event-handling method with the
		// KeyDown event.
		this.KeyDown += new KeyEventHandler(Form1_KeyDown);

	}

	// The form will handle all key events before the control with  
	// focus handles them.  Show the keys pressed by adding the
	// KeyCode object to ListBox1. Ensure the processing is passed
	// to the control with focus by setting the KeyEventArg.Handled
	// property to false.
	private void Form1_KeyDown(object sender, KeyEventArgs e)
	{
		ListBox1.Items.Add(e.KeyCode);
		e.Handled = false;
	}

	[System.STAThreadAttribute]
	public static void Main()
	{
		Application.Run(new Form1());
	}

}


//<snippet1>
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
//</snippet1>
//</snippet2>



