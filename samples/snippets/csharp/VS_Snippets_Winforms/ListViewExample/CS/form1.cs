using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ListViewExample
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(344, 360);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(104, 24);
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Form1
			// 
			this.ClientSize = new System.Drawing.Size(464, 397);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.button1});
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		//<snippet1>
		private void CreateMyListView()
		{
			// Create a new ListView control.
			ListView listView1 = new ListView();
			listView1.Bounds = new Rectangle(new Point(10,10), new Size(300,200));

			// Set the view to show details.
			listView1.View = View.Details;
			// Allow the user to edit item text.
			listView1.LabelEdit = true;
			// Allow the user to rearrange columns.
			listView1.AllowColumnReorder = true;
			// Display check boxes.
			listView1.CheckBoxes = true;
			// Select the item and subitems when selection is made.
			listView1.FullRowSelect = true;
			// Display grid lines.
			listView1.GridLines = true;
			// Sort the items in the list in ascending order.
			listView1.Sorting = SortOrder.Ascending;
            			
			// Create three items and three sets of subitems for each item.
			ListViewItem item1 = new ListViewItem("item1",0);
			// Place a check mark next to the item.
			item1.Checked = true;
			item1.SubItems.Add("1");
			item1.SubItems.Add("2");
			item1.SubItems.Add("3");
			ListViewItem item2 = new ListViewItem("item2",1);
			item2.SubItems.Add("4");
			item2.SubItems.Add("5");
			item2.SubItems.Add("6");
			ListViewItem item3 = new ListViewItem("item3",0);
			// Place a check mark next to the item.
			item3.Checked = true;
			item3.SubItems.Add("7");
			item3.SubItems.Add("8");
			item3.SubItems.Add("9");

			// Create columns for the items and subitems.
			// Width of -2 indicates auto-size.
			listView1.Columns.Add("Item Column", -2, HorizontalAlignment.Left);
			listView1.Columns.Add("Column 2", -2, HorizontalAlignment.Left);
			listView1.Columns.Add("Column 3", -2, HorizontalAlignment.Left);
			listView1.Columns.Add("Column 4", -2, HorizontalAlignment.Center);

			//Add the items to the ListView.
            		listView1.Items.AddRange(new ListViewItem[]{item1,item2,item3});

			// Create two ImageList objects.
			ImageList imageListSmall = new ImageList();
			ImageList imageListLarge = new ImageList();

			// Initialize the ImageList objects with bitmaps.
			imageListSmall.Images.Add(Bitmap.FromFile("C:\\MySmallImage1.bmp"));
			imageListSmall.Images.Add(Bitmap.FromFile("C:\\MySmallImage2.bmp"));
			imageListLarge.Images.Add(Bitmap.FromFile("C:\\MyLargeImage1.bmp"));
			imageListLarge.Images.Add(Bitmap.FromFile("C:\\MyLargeImage2.bmp"));

			//Assign the ImageList objects to the ListView.
			listView1.LargeImageList = imageListLarge;
			listView1.SmallImageList = imageListSmall;

			// Add the ListView to the control collection.
			this.Controls.Add(listView1);
		}
		//</snippet1>

		private void button1_Click(object sender, System.EventArgs e)
		{
			CreateMyListView();
		}
	}
}
