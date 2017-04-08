using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ControlMembers3
{
   public class Form1 : System.Windows.Forms.Form
   {
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.MainMenu mainMenu1;
      private System.Windows.Forms.MenuItem menuItemHelp;
      private System.Windows.Forms.MenuItem menuItemHelpAbout;
      private System.Windows.Forms.Button buttonNewCustomer;
      private System.Windows.Forms.MenuItem menuItemEditInsertCustomerInfo;
      private System.Windows.Forms.TextBox textBox1;
      private System.Windows.Forms.MenuItem menuItemEdit;
      private System.Windows.Forms.MenuItem menuItemEditFontArial;
      private System.Windows.Forms.MenuItem menuItemEditFontTimeNewRoman;
      private System.Windows.Forms.MenuItem menuItemEditFont;
      private System.ComponentModel.Container components = null;

      public Form1()
      {
         InitializeComponent();
         Customer cust = new Customer();
         cust.Name = "Microsoft";
         cust.AccountNumber = 123456;
         this.Tag = cust;
         
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
         this.button1 = new System.Windows.Forms.Button();
         this.mainMenu1 = new System.Windows.Forms.MainMenu();
         this.menuItemHelp = new System.Windows.Forms.MenuItem();
         this.menuItemHelpAbout = new System.Windows.Forms.MenuItem();
         this.buttonNewCustomer = new System.Windows.Forms.Button();
         this.menuItemEdit = new System.Windows.Forms.MenuItem();
         this.menuItemEditInsertCustomerInfo = new System.Windows.Forms.MenuItem();
         this.textBox1 = new System.Windows.Forms.TextBox();
         this.menuItemEditFont = new System.Windows.Forms.MenuItem();
         this.menuItemEditFontArial = new System.Windows.Forms.MenuItem();
         this.menuItemEditFontTimeNewRoman = new System.Windows.Forms.MenuItem();
         this.SuspendLayout();
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(56, 168);
         this.button1.Name = "button1";
         this.button1.TabIndex = 0;
         this.button1.Text = "New Form";
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // mainMenu1
         // 
         this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                  this.menuItemHelp,
                                                                                  this.menuItemEdit});
         // 
         // menuItemHelp
         // 
         this.menuItemHelp.Index = 0;
         this.menuItemHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                     this.menuItemHelpAbout});
         this.menuItemHelp.Text = "Help";
         // 
         // menuItemHelpAbout
         // 
         this.menuItemHelpAbout.Index = 0;
         this.menuItemHelpAbout.Text = "About";
         this.menuItemHelpAbout.Click += new System.EventHandler(this.menuItemHelpAbout_Click);
         // 
         // buttonNewCustomer
         // 
         this.buttonNewCustomer.Location = new System.Drawing.Point(144, 168);
         this.buttonNewCustomer.Name = "buttonNewCustomer";
         this.buttonNewCustomer.Size = new System.Drawing.Size(72, 24);
         this.buttonNewCustomer.TabIndex = 1;
         this.buttonNewCustomer.Text = "New Customer";
         this.buttonNewCustomer.Click += new System.EventHandler(this.buttonNewCustomer_Click);
         // 
         // menuItemEdit
         // 
         this.menuItemEdit.Index = 1;
         this.menuItemEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                     this.menuItemEditInsertCustomerInfo,
                                                                                     this.menuItemEditFont});
         this.menuItemEdit.Text = "Edit";
         this.menuItemEdit.Popup += new System.EventHandler(this.menuItemEdit_Popup);
         // 
         // menuItemEditInsertCustomerInfo
         // 
         this.menuItemEditInsertCustomerInfo.Enabled = false;
         this.menuItemEditInsertCustomerInfo.Index = 0;
         this.menuItemEditInsertCustomerInfo.Text = "Insert Customer Information";
         this.menuItemEditInsertCustomerInfo.Click += new System.EventHandler(this.menuItemEditInsertCustomerInfo_Click);
         // 
         // textBox1
         // 
         this.textBox1.Location = new System.Drawing.Point(56, 96);
         this.textBox1.Multiline = true;
         this.textBox1.Name = "textBox1";
         this.textBox1.Size = new System.Drawing.Size(160, 64);
         this.textBox1.TabIndex = 2;
         this.textBox1.Text = "";
         // 
         // menuItemEditFont
         // 
         this.menuItemEditFont.Index = 1;
         this.menuItemEditFont.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                         this.menuItemEditFontArial,
                                                                                         this.menuItemEditFontTimeNewRoman});
         this.menuItemEditFont.Text = "Font";
         // 
         // menuItemEditFontArial
         // 
         this.menuItemEditFontArial.Index = 0;
         this.menuItemEditFontArial.Text = "Arial";
         this.menuItemEditFontArial.Click += new System.EventHandler(this.menuItemEditFont_Click);
         // 
         // menuItemEditFontTimeNewRoman
         // 
         this.menuItemEditFontTimeNewRoman.Index = 1;
         this.menuItemEditFontTimeNewRoman.Text = "Times New Roman";
         this.menuItemEditFontTimeNewRoman.Click += new System.EventHandler(this.menuItemEditFont_Click);
         // 
         // Form1
         // 
         this.ClientSize = new System.Drawing.Size(292, 273);
         this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.textBox1,
                                                                      this.buttonNewCustomer,
                                                                      this.button1});
         this.Menu = this.mainMenu1;
         this.Name = "Form1";
         this.Text = "Form1";
         this.ResumeLayout(false);

      }
		#endregion

      [STAThread]
      static void Main() 
      {
         Application.Run(new Form1());
      }

      private void button1_Click(object sender, System.EventArgs e)
      {
         AddButtons();
      }


// <snippet1>
private void menuItemHelpAbout_Click(object sender, EventArgs e)
{
   // Create and display a modless about dialog box.
   AboutDialog about = new AboutDialog();
   about.Show();

   // Draw a blue square on the form.
   /* NOTE: This is not a persistent object, it will no longer be
      * visible after the next call to OnPaint. To make it persistent, 
      * override the OnPaint method and draw the square there */
   Graphics g = about.CreateGraphics();
   g.FillRectangle(Brushes.Blue, 10, 10, 50, 50);
}
// </snippet1>


// <snippet2>
private void AddButtons()
{
   // Suspend the form layout and add two buttons.
   this.SuspendLayout();
   Button buttonOK = new Button();
   buttonOK.Location = new Point(10, 10);
   buttonOK.Size = new Size(75, 25);
   buttonOK.Text = "OK";

   Button buttonCancel = new Button();
   buttonCancel.Location = new Point(90, 10);
   buttonCancel.Size = new Size(75, 25);
   buttonCancel.Text = "Cancel";
      
   this.Controls.AddRange(new Control[]{buttonOK, buttonCancel});
   this.ResumeLayout();
}
// </snippet2>

// <snippet3>
private void buttonNewCustomer_Click(object sender, EventArgs e)
{
   /* Create a new customer form and assign a new 
    * Customer object to the Tag property. */
   CustomerForm customerForm = new CustomerForm();
   customerForm.Tag = new Customer();
   customerForm.Show();
}
// </snippet3>

// <snippet4>
private void menuItemEdit_Popup(object sender, EventArgs e)
{
   // Disable the menu item if the text box does not have focus.
   this.menuItemEditInsertCustomerInfo.Enabled = this.textBox1.Focused;
}
// </snippet4>




private void menuItemEditInsertCustomerInfo_Click(object sender, EventArgs e)
{
   // Insert the customer information into the text box.
   this.textBox1.Text += ((Customer)this.Tag).ToString();
}




      private void menuItemEditFont_Click(object sender, System.EventArgs e)
      {
         MenuItem menuItem = (MenuItem)sender;
         if(menuItem.Parent == this.menuItemEditFont)
         {
            // Uncheck all the menu items.
            foreach(MenuItem menu in this.menuItemEditFont.MenuItems)
            {
               menu.Checked = false;
            }

            // Check the menu item that was clicked.
            menuItem.Checked = true;

            // Update the font used in the text box.
            textBox1.Font = new Font(menuItem.Text, textBox1.Font.Size);
         }
      }

      
   
   }

   public class CustomerForm : Form
   {
      public string UserName;
   }

   public class Customer
   {
      public string Name;
      public int AccountNumber;

      public override string ToString()
      {
         return AccountNumber.ToString() + "\r\n" + Name;
      }

      
   }


   public class AboutDialog : Form
   {
      public string FormText;
   }
}
