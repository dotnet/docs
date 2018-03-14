//<snippet3>
using System;
using System.Drawing;
using System.Windows.Forms;

class Form1 : Form
{
	private BindingSource BindingSource1 = new BindingSource();
	private TextBox textBox1 = new TextBox();
	private TextBox textBox2 = new TextBox();
	private TextBox textBox3 = new TextBox();

	public Form1()
	{
		//Set up the textbox controls.
		this.textBox1.Location = new System.Drawing.Point(82, 13);
		this.textBox1.TabIndex = 1;
		this.textBox2.Location = new System.Drawing.Point(81, 47);
		this.textBox2.TabIndex = 2;
		this.textBox3.Location = new System.Drawing.Point(81, 83);
		this.textBox3.TabIndex = 3;

		// Add the textbox controls to the form
		this.Controls.Add(this.textBox2);
		this.Controls.Add(this.textBox1);
		this.Controls.Add(this.textBox3);

		// Handle the form's Load event.
		this.Load += new System.EventHandler(this.Form1_Load);
	}
	Binding partNameBinding;
	Binding partNumberBinding;

	//<snippet1>
	private void Form1_Load(object sender, EventArgs e)
	{
		// Set the DataSource of BindingSource1 to the Part type.
		BindingSource1.DataSource = typeof(Part);

		// Bind the textboxes to the properties of the Part type, 
		// enabling formatting.
		partNameBinding = textBox1.DataBindings.Add("Text",
			BindingSource1, "PartName", true);
		
		partNumberBinding = textBox2.DataBindings.Add("Text", BindingSource1, "PartNumber",
			true);

		//Bind the textbox to the PartPrice value with currency formatting.
		textBox3.DataBindings.Add("Text", BindingSource1, "PartPrice", true,
			DataSourceUpdateMode.OnPropertyChanged, 0, "C");
			

		// Handle the BindingComplete event for BindingSource1 and 
		// the partNameBinding.
		partNumberBinding.BindingComplete +=
			new BindingCompleteEventHandler(partNumberBinding_BindingComplete);
		partNameBinding.BindingComplete +=
			new BindingCompleteEventHandler(partNameBinding_BindingComplete);

		// Add a new part to BindingSource1.
		BindingSource1.Add(new Part("Widget", 1234, 12.45));
	}

	// Handle the BindingComplete event to catch errors and exceptions 
	// in binding process.
	void partNumberBinding_BindingComplete(object sender,
		BindingCompleteEventArgs e)
	{
		if (e.BindingCompleteState != BindingCompleteState.Success)
			MessageBox.Show("partNumberBinding: " + e.ErrorText);
	}		

	// Handle the BindingComplete event to catch errors and 
	// exceptions in binding process.
	void partNameBinding_BindingComplete(object sender,
		BindingCompleteEventArgs e)
	{
		if (e.BindingCompleteState != BindingCompleteState.Success)
			MessageBox.Show("partNameBinding: " + e.ErrorText);
	}
	//</snippet1>

	[STAThread]
	static void Main()
	{
		Application.EnableVisualStyles();
		Application.Run(new Form1());
	}
}

//<snippet2>
// Represents a business object that throws exceptions when invalid values are
// entered for some of its properties.
public class Part
{
	private string name;
	private int number;
	private double price;

	public Part(string name, int number, double price)
	{
		PartName = name;
		PartNumber = number;
		PartPrice = price;
	}

	public string PartName
	{
		get { return name; }
		set
		{
			if (value.Length <= 0)
				throw new Exception("Each part must have a name.");
			else
				name = value;
		}
	}
	public double PartPrice
	{
		get { return price; }
		set { price = value; }
	}

	public int PartNumber
	{
		get { return number; }
		set
		{
			if (value < 100)
				throw new Exception("Invalid part number." +
					" Part numbers must be greater than 100.");
			else
				number = value;
		}
	}
}
//</snippet2>
//</snippet3>
