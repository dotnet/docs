//
//This code examples shows a use of the Control.Capture property.
//
using System.Windows.Forms;

public class CaptureForm:
	System.Windows.Forms.Form

{
	public CaptureForm() : base()
	{        
		InitializeComponent();
		this.MouseDown +=new MouseEventHandler(Control_MouseDown);
		this.listbox1.MouseDown +=new MouseEventHandler(Control_MouseDown);
		this.listbox2.MouseDown +=new MouseEventHandler(Control_MouseDown);
		this.label1.MouseDown += new MouseEventHandler(Control_MouseDown);
	}

	internal System.Windows.Forms.Label label1;
	internal System.Windows.Forms.ListBox listbox1;
	internal System.Windows.Forms.ListBox listbox2;

	private void InitializeComponent()
	{
		this.label1 = new System.Windows.Forms.Label();
		this.listbox1 = new System.Windows.Forms.ListBox();
		this.listbox2 = new System.Windows.Forms.ListBox();
		this.SuspendLayout();
		//
		//Label1
		//
		this.label1.Location = new System.Drawing.Point(168, 72);
		this.label1.Name = "Label1";
		this.label1.Size = new System.Drawing.Size(104, 72);
		this.label1.TabIndex = 4;
		this.label1.Text = "Click around the form to see what control has captured  the mouse.";
		//
		//LunchBox
		//
		this.listbox2.AllowDrop = true;
		this.listbox2.Items.AddRange(new object[]{"Sandwich", "Chips", "Soda", "Soup", "Salad"});
		this.listbox2.Location = new System.Drawing.Point(296, 64);
		this.listbox2.Name = "LunchBox";
		this.listbox2.Size = new System.Drawing.Size(120, 95);
		this.listbox2.TabIndex = 5;
		//
		//BreakfastBox
		//
		this.listbox1.AllowDrop = true;
		this.listbox1.Items.AddRange(new object[]{"Bagels", "Pancakes", "Donuts", "Eggs", "Hashbrowns", "Orange Juice"});
		this.listbox1.Location = new System.Drawing.Point(24, 64);
		this.listbox1.Name = "BreakfastBox";
		this.listbox1.Size = new System.Drawing.Size(120, 95);
		this.listbox1.TabIndex = 6;
		//
		//CaptureForm
		//
		this.ClientSize = new System.Drawing.Size(440, 266);
		this.Controls.Add(this.listbox1);
		this.Controls.Add(this.listbox2);
		this.Controls.Add(this.label1);
		this.Name = "CaptureForm";
		this.Text = "CaptureForm";
		this.ResumeLayout(false);

	}
	[System.STAThreadAttribute]
	public static void Main()
	{
		Application.Run(new CaptureForm());
	}

	//<snippet1>
	// This method handles the mouse down event for all the controls on the form.  
	// When a control has captured the mouse
	// the control's name will be output on label1.
	private void Control_MouseDown(System.Object sender, 
		System.Windows.Forms.MouseEventArgs e)
	{
		Control control = (Control) sender;
		if (control.Capture)
		{
			label1.Text = control.Name+" has captured the mouse";
		}
	}
	//</snippet1>

}



