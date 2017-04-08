// This example demonstrates overriding the OnClick method of a 
// custom TextBox control.

using System;
using System.Drawing;
using System.Windows.Forms;

public class Form1:
	System.Windows.Forms.Form

{
	public Form1() : base()
	{        
		InitializeComponent();
	}

	internal TextBox TextBox1;
	internal SingleClickTextBox TextBox2;

	private void InitializeComponent()
	{
		this.TextBox1 = new TextBox();
		this.TextBox2 = new SingleClickTextBox();
		this.SuspendLayout();
		this.TextBox1.Location = new System.Drawing.Point(40, 60);
		this.TextBox1.Name = "TextBox1";
		this.TextBox1.TabIndex = 1;
		this.TextBox1.Size = new System.Drawing.Size(150, 80);
		this.TextBox1.Text = "This textbox requires a drag motion for selection.";
		this.TextBox1.Multiline = true;
		this.TextBox1.Select(0, 0);
		this.SuspendLayout();
		this.TextBox2.Location = new System.Drawing.Point(40, 150);
		this.TextBox2.Name = "TextBox2";
		this.TextBox2.TabIndex = 2;
		this.TextBox2.Size = new System.Drawing.Size(150, 80);
		this.TextBox2.Text = "One click causes all text to be selected.";
		this.TextBox2.Multiline = true;
		this.ClientSize = new System.Drawing.Size(292, 266);
		this.Controls.Add(this.TextBox1);
		this.Controls.Add(this.TextBox2);
		this.Name = "Form1";
		this.Text = "Form1";
		this.ResumeLayout(false);

	}

	public static void Main()
	{
		Application.Run(new Form1());
	}

}

//<snippet1>
// This is a custom TextBox control that overrides the OnClick method
// to allow one-click selection of the text in the text box.

public class SingleClickTextBox: TextBox

{
	protected override void OnClick(EventArgs e)
	{
		this.SelectAll();
		base.OnClick(e);
	}


}
//</snippet1>


