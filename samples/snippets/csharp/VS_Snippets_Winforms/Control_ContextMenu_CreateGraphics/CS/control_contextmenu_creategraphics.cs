// System.Windows.Forms.Control.ContextMenu
// System.Windows.Forms.Control.ContextMenuChanged
// System.Windows.Forms.Control.CreateGraphics

/*
   The following program demonstrates the 'ContextMenu' property, 'ContextMenuChanged'
   event handler and 'CreateGraphics' method of 'Control' class.
   It displays the 'TextBox' and 'Button' controls on the form. When mouse is clicked inside
   the 'TextBox' control, an instance of 'ContextMenu' is created and assigned to 'TextBox'
   control by using 'ContextMenu' property. The shortcut menu pops-up when right button of
   mouse is clicked inside the 'TextBox' control. When the 'Button' is clicked, an
   instance of 'Graphics' class is obtained by calling 'CreateGraphics' method and draws an
   ellipse inside the 'TextBox' control.
*/
using System;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;

namespace MyApplication
{
   public class MyForm : Form
   {
      private System.Windows.Forms.TextBox myTextBox;
      private System.ComponentModel.Container components = null;
      private System.Windows.Forms.Label myLabel;
      private System.Windows.Forms.Button myButton;

      public MyForm()
      {
         InitializeComponent();
         AddClickHandler();
         AddContextMenuChangedHandler();
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
         this.myButton = new System.Windows.Forms.Button();
         this.myLabel = new System.Windows.Forms.Label();
         this.myTextBox = new System.Windows.Forms.TextBox();
         this.SuspendLayout();
         //
         // myButton
         //
         this.myButton.Location = new System.Drawing.Point(48, 232);
         this.myButton.Name = "myButton";
         this.myButton.Size = new System.Drawing.Size(96, 23);
         this.myButton.TabIndex = 2;
         this.myButton.Text = "CreateGraphics";
         this.myButton.Click += new System.EventHandler(this.CreateGraphicsButton_Click);
         //
         // myLabel
         //
         this.myLabel.Location = new System.Drawing.Point(24, 16);
         this.myLabel.Name = "myLabel";
         this.myLabel.Size = new System.Drawing.Size(256, 40);
         this.myLabel.TabIndex = 1;
         this.myLabel.Text = "Click inside the TextBox to set the ContextMenu and then" +
            " click the right mouse button inside the TextBox to popup the ContextMenu.";
         //
         // myTextBox
         //
         this.myTextBox.Location = new System.Drawing.Point(16, 80);
         this.myTextBox.Multiline = true;
         this.myTextBox.Name = "myTextBox";
         this.myTextBox.Size = new System.Drawing.Size(240, 112);
         this.myTextBox.TabIndex = 0;
         this.myTextBox.Text = "Welcome to .NET";
         //
         // MyForm
         //
         this.ClientSize = new System.Drawing.Size(292, 273);
         this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                      this.myButton,
                                                      this.myLabel,
                                                      this.myTextBox});
         this.Name = "MyForm";
         this.Text = "ContextMenu Example";
         this.ResumeLayout(false);

      }
      #endregion

// <Snippet1>
      private void AddClickHandler()
      {
         this.myTextBox.Click += new EventHandler(TextBox_Click);
      }

      private void TextBox_Click(object sender, EventArgs e)
      {
         MenuItem[] myMenuItems = new MenuItem[2];
         myMenuItems[0] = new MenuItem("New", new EventHandler(MenuItem_New));
         myMenuItems[1] = new MenuItem("Open", new EventHandler(MenuItem_Open));
         this.myTextBox.ContextMenu = new ContextMenu(myMenuItems);
      }

      private void MenuItem_New(object sender, EventArgs e)
      {
         MessageBox.Show("New MenuItem is selected from TextBox's shortcut menu.");
      }

      private void MenuItem_Open(object sender, EventArgs e)
      {
         MessageBox.Show("Open MenuItem is selected from TextBox's shortcut menu.");
      }
// </Snippet1>

// <Snippet2>
      private void AddContextMenuChangedHandler()
      {
         this.myTextBox.ContextMenuChanged += new EventHandler(TextBox_ContextMenuChanged);
      }

      private void TextBox_ContextMenuChanged(object sender, EventArgs e)
      {
         MessageBox.Show("Shortcut menu of TextBox is changed.");
      }
// </Snippet2>

      private void CreateGraphicsButton_Click(object sender, System.EventArgs e)
      {
// <Snippet3>
         Graphics myGraphics = myTextBox.CreateGraphics();
         myGraphics.DrawEllipse(new Pen(Color.Black, 3), 0F, 0F, 230F, 105F);
         myGraphics.FillEllipse(Brushes.Goldenrod, 0F, 0F, 230F, 105F);
// </Snippet3>
      }

      [STAThread]
      static void Main()
      {
         Application.Run(new MyForm());
      }
   }
}
