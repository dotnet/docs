// <Snippet1>
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
// </Snippet1>

//////////////////////////////////////////////////////////////////////////////////////


namespace UserControls 
{
   public class MyCustomerInfoUserControl : System.Windows.Forms.UserControl 
   {
      // Create the controls.
      private System.Windows.Forms.ErrorProvider errorProvider1;
      private System.Windows.Forms.TextBox textName;
      private System.Windows.Forms.TextBox textAddress;
      private System.Windows.Forms.TextBox textCity;
      private System.Windows.Forms.TextBox textStateProvince;
      private System.Windows.Forms.TextBox textPostal;
      private System.Windows.Forms.TextBox textCountryRegion;
      private System.Windows.Forms.TextBox textEmail;
      private System.Windows.Forms.Label labelName;
      private System.Windows.Forms.Label labelAddress;
      private System.Windows.Forms.Label labelCityStateProvincePostal;
      private System.Windows.Forms.Label labelCountryRegion;
      private System.Windows.Forms.Label labelEmail;
      private System.ComponentModel.IContainer components;

      // Define the constructor.
      public MyCustomerInfoUserControl() 
      {
         InitializeComponent();
      }
 
      // Initialize the control elements.
      public void InitializeComponent() 
      {
         // Initialize the controls.
         components = new System.ComponentModel.Container();
         errorProvider1 = new System.Windows.Forms.ErrorProvider();
         textName = new System.Windows.Forms.TextBox();
         textAddress = new System.Windows.Forms.TextBox();
         textCity = new System.Windows.Forms.TextBox();
         textStateProvince = new System.Windows.Forms.TextBox();
         textPostal = new System.Windows.Forms.TextBox();
         textCountryRegion = new System.Windows.Forms.TextBox();
         textEmail = new System.Windows.Forms.TextBox();
         labelName = new System.Windows.Forms.Label();
         labelAddress = new System.Windows.Forms.Label();
         labelCityStateProvincePostal = new System.Windows.Forms.Label();
         labelCountryRegion = new System.Windows.Forms.Label();
         labelEmail = new System.Windows.Forms.Label();

         // Set the tab order, text alignment, size, and location of the controls.
         textName.Location = new System.Drawing.Point(120, 8);
         textName.Size = new System.Drawing.Size(232, 20);
         textName.TabIndex = 0;
         textAddress.Location = new System.Drawing.Point(120, 32);
         textAddress.Size = new System.Drawing.Size(232, 20);
         textAddress.TabIndex = 1;
         textCity.Location = new System.Drawing.Point(120, 56);
         textCity.Size = new System.Drawing.Size(96, 20);
         textCity.TabIndex = 2;
         textStateProvince.Location = new System.Drawing.Point(216, 56);
         textStateProvince.Size = new System.Drawing.Size(56, 20);
         textStateProvince.TabIndex = 3;
         textPostal.Location = new System.Drawing.Point(272, 56);
         textPostal.Size = new System.Drawing.Size(80, 20);
         textPostal.TabIndex = 4;
         textCountryRegion.Location = new System.Drawing.Point(120, 80);
         textCountryRegion.Size = new System.Drawing.Size(232, 20);
         textCountryRegion.TabIndex = 5;
         textEmail.Location = new System.Drawing.Point(120, 104);
         textEmail.Size = new System.Drawing.Size(232, 20);
         textEmail.TabIndex = 6;
         labelName.Location = new System.Drawing.Point(8, 8);
         labelName.Size = new System.Drawing.Size(112, 23);
         labelName.Text = "Name:";
         labelName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         labelAddress.Location = new System.Drawing.Point(8, 32);
         labelAddress.Size = new System.Drawing.Size(112, 23);
         labelAddress.Text = "Address:";
         labelAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         labelCityStateProvincePostal.Location = new System.Drawing.Point(8, 56);
         labelCityStateProvincePostal.Size = new System.Drawing.Size(112, 23);
         labelCityStateProvincePostal.Text = "City, St/Prov. Postal:";
         labelCityStateProvincePostal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         labelCountryRegion.Location = new System.Drawing.Point(8, 80);
         labelCountryRegion.Size = new System.Drawing.Size(112, 23);
         labelCountryRegion.Text = "Country/Region:";
         labelCountryRegion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         labelEmail.Location = new System.Drawing.Point(8, 104);
         labelEmail.Size = new System.Drawing.Size(112, 23);
         labelEmail.Text = "email:";
         labelEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

         // Add the Validating and Validated handlers for textEmail.
         textEmail.Validating += new System.ComponentModel.CancelEventHandler(textEmail_Validating);
         textEmail.Validated += new System.EventHandler(textEmail_Validated);

         // Add the controls to the user control.
         Controls.AddRange(new System.Windows.Forms.Control[] 
         {
            labelName,
            labelAddress,
            labelCityStateProvincePostal,
            labelCountryRegion,
            labelEmail,
            textName,
            textAddress,
            textCity,
            textStateProvince,
            textPostal,
            textCountryRegion,
            textEmail
         });  

         // Size the user control.
         Size = new System.Drawing.Size(375, 150);
      }   


      private void MyValidatingCode()
      {
         // Confirm there is text in the control.
         if (textEmail.Text.Length == 0)
         {
            throw new Exception("Email address is a required field.");
         }
         // Confirm that there is a "." and an "@" in the e-mail address.
         else if(textEmail.Text.IndexOf(".") == -1 || textEmail.Text.IndexOf("@") == -1)
         {
            throw new Exception("Email address must be valid e-mail address format." +
             "\nFor example: 'someone@example.com'");
         }
      }


      // Validate the data input by the user into textEmail.
      private void textEmail_Validating(object sender, System.ComponentModel.CancelEventArgs e)
      { 
         try
         {
            MyValidatingCode();
         }

         catch(Exception ex)
         {
            // Cancel the event and select the text to be corrected by the user.
            e.Cancel = true;
            textEmail.Select(0, textEmail.Text.Length);

            // Set the ErrorProvider error with the text to display. 
            this.errorProvider1.SetError(textEmail,ex.Message);
          }
      }   


      private void textEmail_Validated(Object sender, System.EventArgs e)
      {
         //If all conditions have been met, clear the error provider of errors.
         errorProvider1.SetError(textEmail, "");
      }

   } // End Class   
} // End Namespace
