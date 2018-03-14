// The following code example demonstrates using the FontDialog.MinSize, 
// FontDialog.MaxSize, and FontDialog.ShowEffects members, and 
// handling of Apply event.

using System.Windows.Forms;

public class Form1:
	System.Windows.Forms.Form

{
	#region " Windows Form Designer generated code "

	public Form1() : base()
	{        

		//This call is required by the Windows Form Designer.
		InitializeComponent();
		//Add any initialization after the InitializeComponent() call

	}
    
	//Form overrides dispose to clean up the component list.
	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			if (components != null)
			{
				components.Dispose();
			}
		}
		base.Dispose(disposing);
	}

	//Required by the Windows Form Designer
	private System.ComponentModel.IContainer components;

	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.  
	//Do not modify it using the code editor.
	internal System.Windows.Forms.FontDialog FontDialog1;
	internal System.Windows.Forms.Button Button1;
	internal System.Windows.Forms.TextBox TextBox1;
	[System.Diagnostics.DebuggerStepThrough]
	private void InitializeComponent()
	{
		this.FontDialog1 = new System.Windows.Forms.FontDialog();
		this.Button1 = new System.Windows.Forms.Button();
		this.TextBox1 = new System.Windows.Forms.TextBox();
		this.SuspendLayout();
		//
		//FontDialog1
		//
		//
		//Button1
		//
		this.Button1.Location = new System.Drawing.Point(72, 136);
		this.Button1.Name = "Button1";
		this.Button1.Size = new System.Drawing.Size(144, 88);
		this.Button1.TabIndex = 0;
		this.Button1.Text = "Click for Font Dialog";
		this.Button1.Click += new System.EventHandler(Button1_Click);
		//
		//TextBox1
		//
		this.TextBox1.Location = new System.Drawing.Point(72, 48);
		this.TextBox1.Name = "TextBox1";
		this.TextBox1.Size = new System.Drawing.Size(152, 20);
		this.TextBox1.TabIndex = 1;
		this.TextBox1.Text = "Here is some text.";
		//
		//Form1
		//
		this.ClientSize = new System.Drawing.Size(292, 266);
		this.Controls.Add(this.TextBox1);
		this.Controls.Add(this.Button1);
		this.Name = "Form1";
		this.Text = "Form1";
		this.ResumeLayout(false);

	}

	#endregion

	public static void Main()
	{
		Application.Run(new Form1());
	}

	//<snippet1>
	private void Button1_Click(System.Object sender, System.EventArgs e)
	{
		// Set FontMustExist to true, which causes message box error
		// if the user enters a font that does not exist. 
		FontDialog1.FontMustExist = true;
		
		// Associate the method handling the Apply event with the event.
		FontDialog1.Apply += new System.EventHandler(FontDialog1_Apply);

		// Set a minimum and maximum size to be
		// shown in the FontDialog.
		FontDialog1.MaxSize = 32;
		FontDialog1.MinSize = 18;

		// Show the Apply button in the dialog.
		FontDialog1.ShowApply = true;

		// Do not show effects such as Underline
		// and Bold.
		FontDialog1.ShowEffects = false;
		
		// Save the existing font.
		System.Drawing.Font oldFont = this.Font;

		//Show the dialog, and get the result
		DialogResult result = FontDialog1.ShowDialog();
 
		// If the OK button in the Font dialog box is clicked, 
		// set all the controls' fonts to the chosen font by calling
		// the FontDialog1_Apply method.
		if (result == DialogResult.OK)
		{
			FontDialog1_Apply(this.Button1, new System.EventArgs());
		}
			// If Cancel is clicked, set the font back to
			// the original font.
		else if (result == DialogResult.Cancel)
		{
			this.Font = oldFont;
			foreach ( Control containedControl in this.Controls)
			{
				containedControl.Font = oldFont;
			}
		}
	}

	// Handle the Apply event by setting all controls' fonts to 
	// the chosen font. 
	private void FontDialog1_Apply(object sender, System.EventArgs e)
	{

		this.Font = FontDialog1.Font;
		foreach ( Control containedControl in this.Controls )
		{
			containedControl.Font = FontDialog1.Font;
		}
	}
	//</snippet1>
}

