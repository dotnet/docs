// The following code example demonstrates using the Keys enum,  
// and the TextBoxBase.ScrollToCaret,  and TextBox.HideSelection methods.
// It also demonstrates and handling the TextBox.Click event.


using System.Windows.Forms;

public class Form1:
	System.Windows.Forms.Form

{
	#region " Windows Form Designer generated code "

	public Form1() : base()
	{        

		//This call is required by the Windows Form Designer.
		InitializeComponent();
		InitializeTextBox();

		// Hook up the event-handling method with the
		// KeyDown Event.
		this.TextBox1.KeyDown += new KeyEventHandler(TextBox1_KeyDown);
		this.TextBox1.Click += new System.EventHandler(TextBox1_Click);
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

	//NOTE: The following procedure is required by the Windows 
	//Form Designer. It can be modified using the Windows Form Designer.  
	//Do not modify it using the code editor.
	internal System.Windows.Forms.RichTextBox RichTextBox1;

	[System.Diagnostics.DebuggerStepThrough]
	private void InitializeComponent()
	{
		this.RichTextBox1 = new System.Windows.Forms.RichTextBox();
		this.TextBox1 = new System.Windows.Forms.TextBox();
		this.SuspendLayout();
		//
		//RichTextBox1
		//
		this.RichTextBox1.Location = new System.Drawing.Point(40, 80);
		this.RichTextBox1.Name = "RichTextBox1";
		this.RichTextBox1.ReadOnly = true;
		this.RichTextBox1.TabIndex = 0;
		this.RichTextBox1.Text = "and the text will be added here.";
		//


		//Form1
		//
		this.ClientSize = new System.Drawing.Size(292, 266);
		this.Controls.Add(this.RichTextBox1);
		this.Name = "Form1";
		this.Text = "Form1";
		this.ResumeLayout(false);

	}

	#endregion
	public static void Main()
	{
		Application.Run(new Form1());
	}

	//<snippet3>
	//Declare a textbox called TextBox1.
	internal System.Windows.Forms.TextBox TextBox1;

	//Initialize TextBox1.
	private void InitializeTextBox()
	{
		this.TextBox1 = new TextBox();
		this.TextBox1.Location = new System.Drawing.Point(32, 24);
		this.TextBox1.Name = "TextBox1";
		this.TextBox1.Size = new System.Drawing.Size(136, 20);
		this.TextBox1.TabIndex = 1;
		this.TextBox1.Text = "Type and hit enter here...";

		//Keep the selection highlighted, even after textbox loses focus.
		TextBox1.HideSelection = false;
		this.Controls.Add(TextBox1);
	}
	//</snippet3>

	//<snippet2>
	//Selects everything in TextBox1.
	private void TextBox1_Click(object sender, System.EventArgs e)
	{
		TextBox1.SelectAll();
	}
	//</snippet2>

	//<snippet1>
	//Handles the Enter key being pressed while TextBox1 has focus. 
	private void TextBox1_KeyDown(object sender, KeyEventArgs e)
	{
		TextBox1.HideSelection = false;
		if (e.KeyCode==Keys.Enter)
		{
			e.Handled = true;

			// Copy the text from TextBox1 to RichTextBox1, add a CRLF after 
			// the copied text, and keep the caret in view.
			RichTextBox1.SelectedText = TextBox1.Text + "\r\n";
			RichTextBox1.ScrollToCaret();
		}
	}
	//</snippet1>

}

