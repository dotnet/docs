// The following example demonstrates using the 
// RichTextBox.GetLineFromCharIndex method.
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
	internal System.Windows.Forms.Button Button1;
	internal System.Windows.Forms.RichTextBox RichTextBox1;
	internal System.Windows.Forms.TextBox TextBox1;
	internal System.Windows.Forms.TextBox TextBox2;
	[System.Diagnostics.DebuggerStepThrough]
	private void InitializeComponent()
	{
		this.Button1 = new System.Windows.Forms.Button();
		this.RichTextBox1 = new System.Windows.Forms.RichTextBox();
		this.TextBox1 = new System.Windows.Forms.TextBox();
		this.TextBox2 = new System.Windows.Forms.TextBox();
		this.SuspendLayout();
		//
		//Button1
		//
		this.Button1.Location = new System.Drawing.Point(40, 32);
		this.Button1.Name = "Button1";
		this.Button1.Size = new System.Drawing.Size(80, 40);
		this.Button1.TabIndex = 1;
		this.Button1.Text = "Find line numbers.";
		this.Button1.Click += new System.EventHandler(Button1_Click);
		//
		//RichTextBox1
		//
		this.RichTextBox1.Location = new System.Drawing.Point(40, 88);
		this.RichTextBox1.Name = "RichTextBox1";
		this.RichTextBox1.TabIndex = 2;
		this.RichTextBox1.Text = "This text will contain name several times." 
			+ "Here is name again, and again: name";
		//
		//TextBox1
		//
		this.TextBox1.Location = new System.Drawing.Point(168, 104);
		this.TextBox1.Multiline = true;
		this.TextBox1.Name = "TextBox1";
		this.TextBox1.Size = new System.Drawing.Size(88, 64);
		this.TextBox1.TabIndex = 3;
		this.TextBox1.Text = "";
		//
		//TextBox2
		//
		this.TextBox2.Location = new System.Drawing.Point(152, 48);
		this.TextBox2.Name = "TextBox2";
		this.TextBox2.TabIndex = 4;
		this.TextBox2.Text = "name";
		//
		//Form1
		//
		this.ClientSize = new System.Drawing.Size(292, 266);
		this.Controls.Add(this.TextBox2);
		this.Controls.Add(this.TextBox1);
		this.Controls.Add(this.RichTextBox1);
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
	// This method demonstrates retrieving line numbers that 
	// indicate the location of a particular word
	// contained in a RichTextBox. The line numbers are zero-based.

	private void Button1_Click(System.Object sender, System.EventArgs e)
	{

		// Reset the results box.
		TextBox1.Text = "";

		// Get the word to search from from TextBox2.
		string searchWord = TextBox2.Text;

		int index = 0;

		//Declare an ArrayList to store line numbers.
		System.Collections.ArrayList lineList = new System.Collections.ArrayList();
		do
		{
			// Find occurrences of the search word, incrementing  
			// the start index. 
			index = RichTextBox1.Find(searchWord, index+1, RichTextBoxFinds.MatchCase);
			if (index!=-1)

				// Find the word's line number and add the line 
				// number to the arrayList. 
			{
				lineList.Add(RichTextBox1.GetLineFromCharIndex(index));
			}
		}
		while((index!=-1));

		// Iterate through the list and display the line numbers in TextBox1.
		System.Collections.IEnumerator myEnumerator = lineList.GetEnumerator();
		if (lineList.Count<=0)
        {
            TextBox1.Text = searchWord+" was not found";
        }
        else
        {
            TextBox1.SelectedText = searchWord+" was found on line(s):";
            while (myEnumerator.MoveNext())
            {
                TextBox1.SelectedText = myEnumerator.Current+" ";
            }
        }
	}
	//</snippet1>

}

