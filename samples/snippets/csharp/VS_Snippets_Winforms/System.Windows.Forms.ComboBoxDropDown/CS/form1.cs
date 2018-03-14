// This example demonstrates the ComboBox.ObjectCollection.AddRange, 
// ComboBox.DropDown, and ComboBox.Text properties and the 
// MessageBox.Show(string, string, MessageBoxButton, MessageBoxIcon) 
// method.


using System.Windows.Forms;

public class Form1: System.Windows.Forms.Form

{
	public Form1() : base()
	{        
		InitializeComponent();
		InitializeComboBox();
	}

	internal System.Windows.Forms.Label Label2;
	internal System.Windows.Forms.Label Label1;

	private void InitializeComponent()
	{
		this.Label2 = new System.Windows.Forms.Label();
		this.Label1 = new System.Windows.Forms.Label();
		this.SuspendLayout();
		this.Label1.Location = new System.Drawing.Point(24, 48);
		this.Label1.Name = "Label1";
		this.Label1.TabIndex = 3;
		this.Label1.Text = "Installation Type:";
		this.Label1.TextAlign = 
			System.Drawing.ContentAlignment.MiddleRight;
		this.ClientSize = new System.Drawing.Size(292, 266);
		this.Controls.Add(this.Label1);
		this.Controls.Add(this.Label2);
		this.Name = "Form1";
		this.Text = "Form1";
		this.ResumeLayout(false);
	}

	public static void Main()
	{
		Application.Run(new Form1());
	}
	//<snippet1>
	//<snippet2>
    
	// Declare ComboBox1.
	internal System.Windows.Forms.ComboBox ComboBox1;
    
	// Initialize ComboBox1.
	private void InitializeComboBox()
	{
		this.ComboBox1 = new ComboBox();
		this.ComboBox1.Location = new System.Drawing.Point(128, 48);
		this.ComboBox1.Name = "ComboBox1";
		this.ComboBox1.Size = new System.Drawing.Size(100, 21);
		this.ComboBox1.TabIndex = 0;
		this.ComboBox1.Text	= "Typical";
		string[] installs = new string[]{"Typical", "Compact", "Custom"};
		ComboBox1.Items.AddRange(installs);
		this.Controls.Add(this.ComboBox1);
		
		// Hook up the event handler.
		this.ComboBox1.DropDown +=  
			new System.EventHandler(ComboBox1_DropDown);
	}
	//</snippet1>

	// Handles the ComboBox1 DropDown event. If the user expands the  
	// drop-down box, a message box will appear, recommending the
	// typical installation.
	private void ComboBox1_DropDown(object sender, System.EventArgs e)
	{
		MessageBox.Show("Typical installation is strongly recommended.", 
		"Install information", MessageBoxButtons.OK, 
			MessageBoxIcon.Information);
	}
	//</snippet2>
}


