using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using UserControls;

namespace MyApplication 
{

   public class MyUserControlHost : System.Windows.Forms.Form 
   {
      // Create the controls.
      private System.ComponentModel.IContainer components;
      private System.Windows.Forms.Panel panel1;
      private UserControls.MyCustomerInfoUserControl myUserControl;

      // Define the constructor.
      public MyUserControlHost() 
      {
         this.InitializeComponent();
      }
        
      [System.STAThreadAttribute()]
      public static void Main() 
      {
         System.Windows.Forms.Application.Run(new MyUserControlHost());
      }
        
      // Add a Panel control to a Form and host the UserControl in the Panel.
      private void InitializeComponent() 
      {
         components = new System.ComponentModel.Container();
         panel1 = new System.Windows.Forms.Panel();
         myUserControl = new UserControls.MyCustomerInfoUserControl();
         // Set the DockStyle of the UserControl to Fill.
         myUserControl.Dock = System.Windows.Forms.DockStyle.Fill;

         // Make the Panel the same size as the UserControl and give it a border.
         panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         panel1.Size = myUserControl.Size;
         panel1.Location = new System.Drawing.Point(5, 5);
         // Add the user control to the Panel.
         panel1.Controls.Add(myUserControl);
         // Size the Form to accommodate the Panel.
         this.ClientSize = new System.Drawing.Size(
            panel1.Size.Width + 10, panel1.Size.Height + 10);
         this.Text = "Please enter the information below...";
         // Add the Panel to the Form.
         this.Controls.Add(panel1);
      }   
   } // End Class
} // End Namespace