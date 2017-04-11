using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace MenuPopupEx
{
   /// <summary>
   /// Summary description for Form1.
   /// </summary>
   public class Form1 : System.Windows.Forms.Form
   {
      private System.Windows.Forms.MainMenu mainMenu1;
      private System.Windows.Forms.MenuItem menuEdit;
      private System.Windows.Forms.MenuItem menuCut;
      private System.Windows.Forms.MenuItem menuCopy;
      private System.Windows.Forms.MenuItem menuPaste;
      private System.Windows.Forms.TextBox textBox1;
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.MenuItem menuDelete;
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
         this.mainMenu1 = new System.Windows.Forms.MainMenu();
         this.menuEdit = new System.Windows.Forms.MenuItem();
         this.menuCut = new System.Windows.Forms.MenuItem();
         this.menuCopy = new System.Windows.Forms.MenuItem();
         this.menuPaste = new System.Windows.Forms.MenuItem();
         this.textBox1 = new System.Windows.Forms.TextBox();
         this.button1 = new System.Windows.Forms.Button();
         this.menuDelete = new System.Windows.Forms.MenuItem();
         this.SuspendLayout();
         // 
         // mainMenu1
         // 
         this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                  this.menuEdit});
         // 
         // menuEdit
         // 
         this.menuEdit.Index = 0;
         this.menuEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                 this.menuCut,
                                                                                 this.menuCopy,
                                                                                 this.menuPaste,
                                                                                 this.menuDelete});
         this.menuEdit.Text = "&Edit";
         this.menuEdit.Popup += new System.EventHandler(this.PopupMyMenu);
         // 
         // menuCut
         // 
         this.menuCut.Index = 0;
         this.menuCut.Text = "Cu&t";
         // 
         // menuCopy
         // 
         this.menuCopy.Index = 1;
         this.menuCopy.Text = "&Copy";
         // 
         // menuPaste
         // 
         this.menuPaste.Index = 2;
         this.menuPaste.Text = "&Paste";
         // 
         // textBox1
         // 
         this.textBox1.Location = new System.Drawing.Point(120, 153);
         this.textBox1.Name = "textBox1";
         this.textBox1.Size = new System.Drawing.Size(168, 20);
         this.textBox1.TabIndex = 1;
         this.textBox1.Text = "textBox1";
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(304, 152);
         this.button1.Name = "button1";
         this.button1.TabIndex = 1;
         this.button1.Text = "button1";
         // 
         // menuDelete
         // 
         this.menuDelete.Index = 3;
         this.menuDelete.Text = "&Delete";
         // 
         // Form1
         // 
         this.ClientSize = new System.Drawing.Size(408, 326);
         this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.button1,
                                                                      this.textBox1});
         this.Menu = this.mainMenu1;
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

      //<Snippet1>
      private void PopupMyMenu(object sender, System.EventArgs e)
      {
         if (textBox1.Enabled == false || textBox1.Focused == false ||
            textBox1.SelectedText.Length == 0)
         {
            menuCut.Enabled = false;
            menuCopy.Enabled = false;
            menuDelete.Enabled = false;
         }
         else
         {
            menuCut.Enabled = true;
            menuCopy.Enabled = true;
            menuDelete.Enabled = true;
         }
      }
      //</Snippet1>
   }
}

