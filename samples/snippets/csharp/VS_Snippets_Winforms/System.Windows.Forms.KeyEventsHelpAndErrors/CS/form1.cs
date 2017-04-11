//<snippet1>
   
using System.Drawing;
using System.Windows.Forms;
using System;
using Microsoft.VisualBasic;

public class Form1:
	System.Windows.Forms.Form

{

	public Form1() : base()
	{        

		InitializeComponent();
		AddHandlers();
		InitializeFormHelp();

	}

	internal System.Windows.Forms.Label Label1;
	internal System.Windows.Forms.Label Label2;
	internal System.Windows.Forms.Label Label3;
	internal System.Windows.Forms.TextBox withdrawal;
	internal System.Windows.Forms.TextBox deposit;
	internal System.Windows.Forms.ErrorProvider ErrorProvider1;
	internal System.Windows.Forms.Label balance;
	internal System.Windows.Forms.HelpProvider HelpProvider1;
	
[System.Diagnostics.DebuggerStepThrough]
	private void InitializeComponent()
	{
		this.withdrawal = new System.Windows.Forms.TextBox();
		this.deposit = new System.Windows.Forms.TextBox();
		this.Label1 = new System.Windows.Forms.Label();
		this.Label2 = new System.Windows.Forms.Label();
		this.Label3 = new System.Windows.Forms.Label();
		this.ErrorProvider1 = new 		System.Windows.Forms.ErrorProvider();
		this.balance = new System.Windows.Forms.Label();
		this.HelpProvider1 = new 		System.Windows.Forms.HelpProvider();
		this.SuspendLayout();
		
		this.withdrawal.Location = new System.Drawing.Point(32, 200);
		this.withdrawal.Name = "withdrawal";
		this.withdrawal.Size = new System.Drawing.Size(88, 20);
		this.withdrawal.TabIndex = 0;
		this.withdrawal.Text = "";
		
		this.deposit.Location = new System.Drawing.Point(168, 200);
		this.deposit.Name = "deposit";
		this.deposit.TabIndex = 1;
		this.deposit.Text = "";
		
		this.Label1.Location = new System.Drawing.Point(56, 88);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(96, 24);
		this.Label1.TabIndex = 2;
		this.Label1.Text = "Account Balance:";
		
		this.Label2.Location = new System.Drawing.Point(168, 168);
		this.Label2.Name = "Label2";
		this.Label2.Size = new System.Drawing.Size(96, 24);
		this.Label2.TabIndex = 4;
		this.Label2.Text = "Deposit:";
		
		this.Label3.Location = new System.Drawing.Point(32, 168);
		this.Label3.Name = "Label3";
		this.Label3.Size = new System.Drawing.Size(96, 24);
		this.Label3.TabIndex = 5;
		this.Label3.Text = "Withdrawal:";
		
		this.ErrorProvider1.ContainerControl = this;
		
		this.balance.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		this.balance.Location = new System.Drawing.Point(152, 88);
		this.balance.Name = "balance";
		this.balance.TabIndex = 6;
		this.balance.Text = "345.65";
		this.balance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		
		this.ClientSize = new System.Drawing.Size(292, 266);
		this.Controls.Add(this.balance);
		this.Controls.Add(this.Label3);
		this.Controls.Add(this.Label2);
		this.Controls.Add(this.Label1);
		this.Controls.Add(this.deposit);
		this.Controls.Add(this.withdrawal);
		this.Name = "Form1";
		this.Text = "Form1";
		this.ResumeLayout(false);

	}

	private void AddHandlers()
	{
		// Add the event-handler delegates to handled the KeyDown
		// events.
		deposit.KeyDown +=new KeyEventHandler(ProcessEntry);  
		withdrawal.KeyDown += new KeyEventHandler(ProcessEntry);

		// Add the event-handler delegates to handled the KeyPress 
		// events.
		deposit.KeyPress += new KeyPressEventHandler(CheckForDigits);
		withdrawal.KeyPress += 
			new KeyPressEventHandler(CheckForDigits);
	}

	//<snippet2>
	private void InitializeFormHelp()
	{

		// Set the form's border to the FixedDialog style.
		this.FormBorderStyle = FormBorderStyle.FixedDialog;

		// Remove the Maximize and Minimize buttons from the form.
		this.MaximizeBox = false;
		this.MinimizeBox = false;

		// Add the Help button to the form.
		this.HelpButton = true;

		// Set the Help string for the deposit textBox.
		HelpProvider1.SetHelpString(deposit, 
			"Enter an amount in the format xxx.xx" +
			"and press Enter to deposit.");

		// Set the Help string for the withdrawal textBox.
		HelpProvider1.SetHelpString(withdrawal, 
			"Enter an amount in the format xxx.xx" +
			"and press Enter to withdraw.");

	}
	//</snippet2>

	private void ProcessEntry(object sender, KeyEventArgs e)
	{

		// Cast the sender back to a TextBox.
		Control textBoxSender = (TextBox) sender;

		// Set the error description to an empty string ().
		ErrorProvider1.SetError(textBoxSender, "");

		// Declare the variable to hold the new balance.
		double newBalance = 0;

		// Wrap the code in a Try/Catch block to catch 
		// errors that can occur when converting the string 
		// to a double.

		try
		{
			if (e.KeyCode==Keys.Enter)

				// Switch on the text box that received
				// the KeyPress event. Convert the text to type double,
				// and compute the new balance.
			{
				switch(textBoxSender.Name)
				{
					case "withdrawal":
						newBalance = Double.Parse(balance.Text) 
							- Double.Parse(withdrawal.Text);
						withdrawal.Text = "";
						break;
					case "deposit":
						newBalance = Double.Parse(balance.Text) 
							+ Double.Parse(deposit.Text);
						deposit.Text = "";
						break;
				}

				// Check the value of new balance and set the
				// Forecolor property accordingly.
				if (newBalance < 0)
				{
					balance.ForeColor = Color.Red;
				}
				else
				{
					balance.ForeColor = Color.Black;
				}

				// Set the text of the balance text box
				// to the newBalance value.
				balance.Text = newBalance.ToString();
			}

		}
		catch(FormatException)
		{

			// If a FormatException is thrown, set the
			// error string to the HelpString message for 
			// the control.
			ErrorProvider1.SetError(textBoxSender, 
				HelpProvider1.GetHelpString(textBoxSender));
		}
	}


	private void CheckForDigits(object sender, KeyPressEventArgs e)
	{

		// If the character is not a digit, period, or backspace then
		// ignore it by setting the KeyPressEventArgs.Handled
		// property to true.
		if (!(Char.IsDigit(e.KeyChar) || e.KeyChar == '.' || 
			e.KeyChar == (char)(Keys.Back)))
		{
			e.Handled = true;
		}
	}
	

	public static void Main()
	{
		Application.Run(new Form1());
	}


}
//</snippet1>
   


