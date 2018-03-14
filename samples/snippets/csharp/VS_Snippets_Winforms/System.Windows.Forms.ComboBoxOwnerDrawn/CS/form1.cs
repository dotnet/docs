// This example demonstrates creating an owner-drawn ComboBox control. 
// The DrawMode property is set to OwnerDrawnVariable. It also demonstrates
// using the ComboBox.DropDownWidth and ComboBox.DropDownStyle properties
// and handling the ComboBox.MeasureItem and ComboBox.DrawItem events for
// an owner-drawn ComboBox with variable item size.

using System.Windows.Forms;
using System.Drawing;

public class Form1:
	System.Windows.Forms.Form

{
	public Form1() : base()
	{        
		InitializeComponent();
		InitializeComboBox();
	}

	public static void Main()
	{
		Application.Run(new Form1());
	}

	private void InitializeComponent()
	{
		this.SuspendLayout();
		this.ClientSize = new System.Drawing.Size(292, 266);
		this.Name = "Form1";
		this.Text = "Form1";
		this.ResumeLayout(false);

	}

	//<snippet1>

	internal System.Windows.Forms.ComboBox ComboBox1;
	private string[] animals;
  
	// This method initializes the owner-drawn combo box.
	// The drop-down width is set much wider than the size of the combo box
	// to accomodate the large items in the list.  The drop-down style is set to 
	// ComboBox.DropDown, which requires the user to click on the arrow to 
	// see the list.
	private void InitializeComboBox()
	{
		this.ComboBox1 = new ComboBox();
		this.ComboBox1.DrawMode = 
			System.Windows.Forms.DrawMode.OwnerDrawVariable;
		this.ComboBox1.Location = new System.Drawing.Point(10, 20);
		this.ComboBox1.Name = "ComboBox1";
		this.ComboBox1.Size = new System.Drawing.Size(100, 120);
		this.ComboBox1.DropDownWidth = 250;
		this.ComboBox1.TabIndex = 0;
		this.ComboBox1.DropDownStyle = ComboBoxStyle.DropDown;
		animals = new string[]{"Elephant", "c r o c o d i l e", "lion"};
		ComboBox1.DataSource = animals;
		this.Controls.Add(this.ComboBox1);

		// Hook up the MeasureItem and DrawItem events
		this.ComboBox1.DrawItem += 
			new DrawItemEventHandler(ComboBox1_DrawItem);
		this.ComboBox1.MeasureItem += 
			new MeasureItemEventHandler(ComboBox1_MeasureItem);
	}

	// If you set the Draw property to DrawMode.OwnerDrawVariable, 
	// you must handle the MeasureItem event. This event handler 
	// will set the height and width of each item before it is drawn. 
	private void ComboBox1_MeasureItem(object sender, 
		System.Windows.Forms.MeasureItemEventArgs e)
	{

		switch(e.Index)
		{
			case 0:
				e.ItemHeight = 45;
				break;
			case 1:
				e.ItemHeight = 20;
				break;
			case 2:
				e.ItemHeight = 35;
				break;
		}
		e.ItemWidth = 260;

	}

	// You must handle the DrawItem event for owner-drawn combo boxes.  
	// This event handler changes the color, size and font of an 
	// item based on its position in the array.
	private void ComboBox1_DrawItem(object sender, 
		System.Windows.Forms.DrawItemEventArgs e)
	{

		float size = 0;
		System.Drawing.Font myFont;
		FontFamily family = null;

		System.Drawing.Color animalColor = new System.Drawing.Color();
		switch(e.Index)
		{
			case 0:
				size = 30;
				animalColor = System.Drawing.Color.Gray;
				family = FontFamily.GenericSansSerif;
				break;
			case 1:
				size = 10;
				animalColor = System.Drawing.Color.LawnGreen;
				family = FontFamily.GenericMonospace;
				break;
			case 2:
				size = 15;
				animalColor = System.Drawing.Color.Tan;
				family = FontFamily.GenericSansSerif;
				break;
		}

		// Draw the background of the item.
		e.DrawBackground();

		// Create a square filled with the animals color. Vary the size
		// of the rectangle based on the length of the animals name.
		Rectangle rectangle = new Rectangle(2, e.Bounds.Top+2, 
				e.Bounds.Height, e.Bounds.Height-4);
		e.Graphics.FillRectangle(new SolidBrush(animalColor), rectangle);

		// Draw each string in the array, using a different size, color,
		// and font for each item.
		myFont = new Font(family, size, FontStyle.Bold);
		e.Graphics.DrawString(animals[e.Index], myFont, System.Drawing.Brushes.Black, new RectangleF(e.Bounds.X+rectangle.Width, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));

		// Draw the focus rectangle if the mouse hovers over an item.
		e.DrawFocusRectangle();
	}

	//</snippet1>
}



