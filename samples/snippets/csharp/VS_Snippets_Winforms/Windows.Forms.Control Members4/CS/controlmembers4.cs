using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ControlMembers4
{
   public class Form2 : System.Windows.Forms.Form
   {
      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.StatusBar statusBar1;
      private System.Windows.Forms.TreeView treeView1;
      private System.Windows.Forms.ContextMenu contextMenu1;
      private System.Windows.Forms.MenuItem menuItem1;
      private System.Windows.Forms.MenuItem menuItem2;
      private System.Windows.Forms.MenuItem menuItem3;
      private System.Windows.Forms.Label label1;
      

      private System.ComponentModel.Container components = null;

      public Form2()
      {
         InitializeComponent();
      }

      protected override void Dispose( bool disposing )
      {
         if( disposing )
         {
            if(components != null)
            {
               components.Dispose();
            }
         }
         base.Dispose( disposing );
      }

		#region Windows Form Designer generated code
      private void InitializeComponent()
      {
         this.panel1 = new System.Windows.Forms.Panel();
         this.button1 = new System.Windows.Forms.Button();
         this.label1 = new System.Windows.Forms.Label();
         this.statusBar1 = new System.Windows.Forms.StatusBar();
         this.treeView1 = new System.Windows.Forms.TreeView();
         this.contextMenu1 = new System.Windows.Forms.ContextMenu();
         this.menuItem1 = new System.Windows.Forms.MenuItem();
         this.menuItem2 = new System.Windows.Forms.MenuItem();
         this.menuItem3 = new System.Windows.Forms.MenuItem();
         this.panel1.SuspendLayout();
         this.SuspendLayout();
         // 
         // panel1
         // 
         this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                             this.button1,
                                                                             this.label1});
         this.panel1.Location = new System.Drawing.Point(48, 40);
         this.panel1.Name = "panel1";
         this.panel1.TabIndex = 0;
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(16, 16);
         this.button1.Name = "button1";
         this.button1.TabIndex = 1;
         this.button1.Text = "button1";
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // label1
         // 
         this.label1.Location = new System.Drawing.Point(16, 16);
         this.label1.Name = "label1";
         this.label1.TabIndex = 2;
         this.label1.Text = "label1";
         // 
         // statusBar1
         // 
         this.statusBar1.Location = new System.Drawing.Point(0, 295);
         this.statusBar1.Name = "statusBar1";
         this.statusBar1.Size = new System.Drawing.Size(320, 22);
         this.statusBar1.TabIndex = 1;
         this.statusBar1.Text = "statusBar1";
         // 
         // treeView1
         // 
         this.treeView1.ContextMenu = this.contextMenu1;
         this.treeView1.ImageIndex = -1;
         this.treeView1.Location = new System.Drawing.Point(64, 152);
         this.treeView1.Name = "treeView1";
         this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
                                                                              new System.Windows.Forms.TreeNode("Node0", new System.Windows.Forms.TreeNode[] {
                                                                                                                                                                new System.Windows.Forms.TreeNode("Node1", new System.Windows.Forms.TreeNode[] {
                                                                                                                                                                                                                                                  new System.Windows.Forms.TreeNode("Node2")})})});
         this.treeView1.SelectedImageIndex = -1;
         this.treeView1.TabIndex = 2;
         this.treeView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeView1_KeyDown);
         this.treeView1.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeView1_AfterLabelEdit);
         // 
         // contextMenu1
         // 
         this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                     this.menuItem1,
                                                                                     this.menuItem2,
                                                                                     this.menuItem3});
         // 
         // menuItem1
         // 
         this.menuItem1.Index = 0;
         this.menuItem1.Text = "Edit";
         // 
         // menuItem2
         // 
         this.menuItem2.Index = 1;
         this.menuItem2.Text = "Expand";
         // 
         // menuItem3
         // 
         this.menuItem3.Index = 2;
         this.menuItem3.Text = "Collapse";
         // 
         // Form2
         // 
         this.ClientSize = new System.Drawing.Size(320, 317);
         this.DoubleClick += new System.EventHandler(this.Form2_DoubleClick);
         this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.treeView1,
                                                                      this.statusBar1,
                                                                      this.panel1});
         this.Name = "Form2";
         this.Text = "Form2";
         this.panel1.ResumeLayout(false);
         this.ResumeLayout(false);

      }
		#endregion

      [STAThread]
      static void Main() 
      {
         Application.Run(new Form2());
      }


      private void Form2_DoubleClick(object sender, System.EventArgs e)
      {
         this.MakeLabelVisible();
      }



// <snippet1>
private void MakeLabelVisible()
{
   /* If the panel contains label1, bring it 
   * to the front to make sure it is visible. */
   if(panel1.Contains(label1))
   {
      label1.BringToFront();
   }
}
// </snippet1>

// <snippet2>
private void button1_Click(object sender, System.EventArgs e)
{
   /* If the CTRL key is pressed when the 
      * control is clicked, hide the control. */
   if(Control.ModifierKeys == Keys.Control)
   {
      ((Control)sender).Hide();
   }
}
// </snippet2>

// <snippet3>
private void treeView1_KeyDown(object sender, KeyEventArgs e)
{
   /* If the 'Alt' and 'E' keys are pressed,
      * allow the user to edit the TreeNode label. */
   if(e.Alt && e.KeyCode == Keys.E)
         
   {
      treeView1.LabelEdit = true;
      // If there is a TreeNode under the mose cursor, begin editing. 
      TreeNode editNode = treeView1.GetNodeAt(
         treeView1.PointToClient(System.Windows.Forms.Control.MousePosition));
      if(editNode != null)
      { 
         editNode.BeginEdit();
      }
   }
}

private void treeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
{
   // Disable the ability to edit the TreeNode labels.
   treeView1.LabelEdit = false;
}
// </snippet3>

   }
}