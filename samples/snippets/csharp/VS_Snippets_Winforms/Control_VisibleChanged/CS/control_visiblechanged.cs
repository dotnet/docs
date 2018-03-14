// System.Windows.Forms.Control.VisibleChanged

/*
   The following program demonstrates 'VisibleChanged' event for the 'Control' class.
   The 'VisibleChanged' event is raised when the 'Visible' property value of
   'Label' control has changed.
*/

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace MyControlExample
{
   public class MyForm: Form
   {
      private Label myLabel;
      private Button myButton;

      private Container components = null;

      public MyForm()
      {
         InitializeComponent();
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

      private void InitializeComponent()
      {
         this.myLabel = new Label();
         this.myButton = new Button();
         this.SuspendLayout();

         //
         // myLabel
         //
         this.myLabel.Location = new System.Drawing.Point(24, 8);
         this.myLabel.Name = "myLabel";
         this.myLabel.Size = new System.Drawing.Size(240, 40);
         this.myLabel.Text += "Welcome to .NET.";

         //
         // myButton
         //
         this.myButton.Location = new System.Drawing.Point(54, 50);
         this.myButton.Name = "myLabel";
         this.myButton.Size = new System.Drawing.Size(100, 40);
         this.myButton.TabIndex = 0;
         this.myButton.Text = "Hide Label";
         this.myButton.Click += new EventHandler(Button_HideLabel);

         //
         // MyForm
         //
         this.ClientSize = new System.Drawing.Size(292, 273);
         this.Controls.Add(this.myLabel);
         this.Controls.Add(this.myButton);

         this.Name = "MyForm";
         this.Text = "VisibleChanged example";
         this.ResumeLayout(false);
         AddVisibleChangedEventHandler();
      }

      [STAThread]
      static void Main()
      {
         Application.Run(new MyForm());
      }

// <Snippet1>
      private void Button_HideLabel(object sender, EventArgs e)
      {
         myLabel.Visible = false;
      }

      private void AddVisibleChangedEventHandler()
      {
         myLabel.VisibleChanged += new EventHandler(this.Label_VisibleChanged);
      }

      private void Label_VisibleChanged(object sender, EventArgs e)
      {
         MessageBox.Show("Visible change event raised!!!");
      }
// </Snippet1>
   }
}
