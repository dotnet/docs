using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace CursorSetStyle
{
	public class Form1 : System.Windows.Forms.Form
	{
      private System.Windows.Forms.TreeView treeView1;
      private System.Windows.Forms.ComboBox comboBox1;
	
      private System.ComponentModel.Container components = null;

		public Form1()
		{
			InitializeComponent();
         this.treeView1.ContextMenu = new ContextMenu(new MenuItem[]{new MenuItem("Edit")} );
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
		/// <summary>
		/// Required method for Designer support; do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
         this.treeView1 = new System.Windows.Forms.TreeView();
         this.comboBox1 = new System.Windows.Forms.ComboBox();
         this.SuspendLayout();
         // 
         // treeView1
         // 
         this.treeView1.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right);
         this.treeView1.ImageIndex = -1;
         this.treeView1.Name = "treeView1";
         this.treeView1.SelectedImageIndex = -1;
         this.treeView1.Size = new System.Drawing.Size(232, 224);
         this.treeView1.TabIndex = 0;
         this.treeView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseUp);
         this.treeView1.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeExpand);
         // 
         // comboBox1
         // 
         this.comboBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.comboBox1.Location = new System.Drawing.Point(0, 224);
         this.comboBox1.Name = "comboBox1";
         this.comboBox1.Size = new System.Drawing.Size(232, 21);
         this.comboBox1.TabIndex = 1;
         this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
         // 
         // Form1
         // 
         this.ClientSize = new System.Drawing.Size(232, 245);
         this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.comboBox1,
                                                                      this.treeView1});
         this.Name = "Form1";
         this.Text = "Form1";
         this.Load += new System.EventHandler(this.Form1_Load);
         this.ResumeLayout(false);

      }
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}


// <snippet1>
private void Form1_Load(object sender, EventArgs e)
{
   // Display the hand cursor when the mouse pointer
   // is over the combo box drop-down button. 
   comboBox1.Cursor = Cursors.Hand;

   // Fill the combo box with all the logical 
   // drives available to the user.
   try
   {
      foreach(string logicalDrive in Environment.GetLogicalDrives() )
      {
         comboBox1.Items.Add(logicalDrive);
      }
   }
   catch(Exception ex)
   {
      MessageBox.Show(ex.Message);
   }
}
// </snippet1>

// <snippet4>
protected override ImeMode DefaultImeMode
{
   get
   {
      // Disable the IME mode for the control.
      return ImeMode.Off;
   }
}
// </snippet4>
      

// <snippet3>
protected override Size DefaultSize
{
   get
   {
      // Set the default size of
      // the form to 500 pixels square.
      return new Size(500,500);
   }
}
// </snippet3>

// <snippet5>
private void treeView1_MouseUp(object sender, MouseEventArgs e)
{
   // If the right mouse button was clicked and released,
   // display the shortcut menu assigned to the TreeView. 
   if(e.Button == MouseButtons.Right)
   {
      treeView1.ContextMenu.Show(treeView1, new Point(e.X, e.Y) );      
   }
}
// </snippet5>

private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
{
   try
   {
      DirectoryInfo dirInfo = new DirectoryInfo(comboBox1.SelectedItem.ToString() );
      this.treeView1.Nodes.Clear();

      // Do not display or attempt to access System, Temporary, or Hidden directories.
      if(dirInfo.Exists && (dirInfo.Attributes & (FileAttributes.Hidden 
         | FileAttributes.System | FileAttributes.Temporary) ) != 0 )
      {
         TreeNode rootNode = new TreeNode(comboBox1.SelectedItem.ToString() );
         treeView1.Nodes.Add(rootNode);
         CreateChildNodes(dirInfo, rootNode);
      }
   }
   catch(Exception ex)
   {
      MessageBox.Show(ex.Message);
   }
}

private void CreateChildNodes(DirectoryInfo dirInfo, TreeNode parentNode)
{
   try
   {
      foreach(DirectoryInfo d in dirInfo.GetDirectories() )
      {
         // Do not display or attempt to access System, Temporary, or System directories.
         if((d.Attributes & (FileAttributes.Hidden 
            | FileAttributes.System | FileAttributes.Temporary) ) == 0)
         {
            parentNode.Nodes.Add(new TreeNode(d.Name) );
            Application.DoEvents();
         }
      }
   }
   catch(Exception ex)
   {
      MessageBox.Show(ex.Message);
   }
}

private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
{
   foreach(TreeNode node in e.Node.Nodes)
   {
      // Create a DirectoryInfo object from the node path.
      CreateChildNodes(new DirectoryInfo(node.FullPath), node);
   }
}

	}
}
