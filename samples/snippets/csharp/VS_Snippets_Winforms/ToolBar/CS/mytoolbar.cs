using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

	public class MyToolBar : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.TextBox textBox1;
		private System.ComponentModel.IContainer components;
		private ContextMenu contextMenu1;
		private MenuItem menuItem1;
		private MenuItem menuItem2;

		public MyToolBar()
		{
			InitializeComponent();
			this.AddToolBar();
		}

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
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.imageList1.Images.Add(Image.FromFile("c:\\copy.bmp"));
			this.imageList1.Images.Add(Image.FromFile("c:\\button.bmp"));
			this.imageList1.Images.Add(Image.FromFile("c:\\camera.bmp"));
//			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MyToolBar));
			//this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.menuItem1 = new MenuItem("Clear");
			this.menuItem2 = new MenuItem("Test");
			this.contextMenu1 = new ContextMenu(new MenuItem[] {menuItem1, menuItem2} );
			this.SuspendLayout();
			
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			//this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// toolBarButton1
			// 
			this.toolBarButton1.ImageIndex = 0;
			this.toolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton;
			this.toolBarButton1.DropDownMenu = this.contextMenu1;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(24, 192);
			this.button1.Name = "button1";
			this.button1.TabIndex = 1;
			this.button1.Text = "button1";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(136, 200);
			this.button2.Name = "button2";
			this.button2.TabIndex = 2;
			this.button2.Text = "button2";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(96, 144);
			this.textBox1.Name = "textBox1";
			this.textBox1.TabIndex = 3;
			this.textBox1.Text = "textBox1";
			// 
			// MyToolBar
			// 
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																							 this.textBox1,
																							 this.button2,
																							 this.button1});
			this.Name = "MyToolBar";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new MyToolBar());
		}

// <snippet1>
private void AddToolBar()
{
   // Add a toolbar and set some of its properties.
   toolBar1 = new ToolBar();
   toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
   toolBar1.BorderStyle = System.Windows.Forms.BorderStyle.None;
   toolBar1.Buttons.Add(this.toolBarButton1);
   toolBar1.ButtonSize = new System.Drawing.Size(24, 24);
   toolBar1.Divider = true;
   toolBar1.DropDownArrows = true;
   toolBar1.ImageList = this.imageList1;
   toolBar1.ShowToolTips = true;
   toolBar1.Size = new System.Drawing.Size(292, 25);
   toolBar1.TabIndex = 0;
   toolBar1.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right;
   toolBar1.Wrappable = false;
   
   // Add handlers for the ButtonClick and ButtonDropDown events.
   toolBar1.ButtonDropDown += 
     new ToolBarButtonClickEventHandler(toolBar1_ButtonDropDown);
   toolBar1.ButtonClick += 
     new ToolBarButtonClickEventHandler(toolBar1_ButtonClicked);

   // Add the toolbar to the form.
   this.Controls.Add(toolBar1);
}
// </snippet1>

// <snippet2>
private void AddToolbarButtons(ToolBar toolBar)
{
   if(!toolBar.Buttons.IsReadOnly)
   {
      // If toolBarButton1 in in the collection, remove it.
      if(toolBar.Buttons.Contains(toolBarButton1))
      {
         toolBar.Buttons.Remove(toolBarButton1);
      }
	
      // Create three toolbar buttons.
      ToolBarButton tbb1 = new ToolBarButton("tbb1");
      ToolBarButton tbb2 = new ToolBarButton("tbb2");
      ToolBarButton tbb3 = new ToolBarButton("tbb3");
      
      // Add toolbar buttons to the toolbar.		
      toolBar.Buttons.AddRange(new ToolBarButton[] {tbb2, tbb3});
      toolBar.Buttons.Add("tbb4");
	
      // Insert tbb1 into the first position in the collection.
      toolBar.Buttons.Insert(0, tbb1);
   }
}
// </snippet2>

// <snippet3>
private string GetButtonList(ToolBar toolBar)
{	
   string buttonList = "ToolBarButtons: ";
   IEnumerator x = toolBar.Buttons.GetEnumerator();

   // Enumerate through the collection of toolbar buttons.
   while(x.MoveNext())
   {
      buttonList += ((ToolBarButton)x.Current).Text + " "; 
   }
   
  return buttonList;
}
// </snippet3>


//<snippet4>
private void toolBar1_ButtonDropDown(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
{
   // If the text box is disabled, disable the menu item.
   if(!textBox1.Enabled)
   {
      contextMenu1.MenuItems[this.contextMenu1.MenuItems.IndexOf(menuItem1)].Enabled = false;
   }
}

private void toolBar1_ButtonClicked(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
{
   // Disable the text box.
   textBox1.Enabled = false;
}
// </snippet4>


		private void button1_Click(object sender, System.EventArgs e)
		{
			AddToolbarButtons(this.toolBar1);
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show(this.GetButtonList(toolBar1));
		}
	}
