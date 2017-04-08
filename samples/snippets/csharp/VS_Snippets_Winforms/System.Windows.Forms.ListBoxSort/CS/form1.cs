//<snippet1>

// The following code example demonstrates using the ListBox.Sort method
// by inheriting from the ListBox class and overriding the Sort method.


using System.Drawing;
using System.Windows.Forms;

public class Form1:
	System.Windows.Forms.Form
{

	internal System.Windows.Forms.Button Button1;
	internal SortByLengthListBox sortingBox;
	
	public Form1() : base()
	{        
		this.Button1 = new System.Windows.Forms.Button();
		this.sortingBox = 
			new SortByLengthListBox();
		this.SuspendLayout();
		this.Button1.Location = new System.Drawing.Point(64, 16);
		this.Button1.Name = "Button1";
		this.Button1.Size = new System.Drawing.Size(176, 23);
		this.Button1.TabIndex = 0;
		this.Button1.Text = "Click me for list sorted by length";
		this.Button1.Click += new System.EventHandler(Button1_Click);
		this.sortingBox.Items.AddRange(new object[]{"System", 
			"System.Windows.Forms", "System.Xml", "System.Net", 
			"System.Drawing", "System.IO"});
		this.sortingBox.Location = 
			new System.Drawing.Point(72, 48);
		this.sortingBox.Size = 
			new System.Drawing.Size(120, 95);
		this.sortingBox.TabIndex = 1;
		this.ClientSize = new System.Drawing.Size(292, 266);
		this.Controls.Add(this.sortingBox);
		this.Controls.Add(this.Button1);
		this.Name = "Form1";
		this.Text = "Sort Example";
		this.ResumeLayout(false);
	}
	
   	public static void Main()
	{
		Application.Run(new Form1());
	}

    
	private void Button1_Click(System.Object sender, System.EventArgs e)
	{
		// Set the Sorted property to True to raise the overridden Sort
		// method.
		sortingBox.Sorted = true;
	}
}

// This class inherits from ListBox and implements a different 
// sorting method. Sort will be called by setting the class's Sorted
// property to True.
public class SortByLengthListBox:
	ListBox

{
	public SortByLengthListBox() : base()
	{        
	}

	// Overrides the parent class Sort to perform a simple
	// bubble sort on the length of the string contained in each item.
	protected override void Sort()
	{
		if (Items.Count > 1)
		{
			bool swapped;
			do
			{
				int counter = Items.Count - 1;
				swapped = false;
				
				while (counter > 0)
				{
					// Compare the items' length. 
					if (Items[counter].ToString().Length  
						< Items[counter-1].ToString().Length)
					{
						// Swap the items.
						object temp = Items[counter];
						Items[counter] = Items[counter-1];
						Items[counter-1] = temp;
						swapped = true;
					}
					// Decrement the counter.
					counter -= 1;
				}
			}
			while((swapped==true));
		}
	}
}

//</snippet1>

