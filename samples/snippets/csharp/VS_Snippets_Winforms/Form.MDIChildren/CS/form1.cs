using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace FormMDIChildrenEx
{
   /// <summary>
   /// Summary description for Form1.
   /// </summary>
   public class Form1 : System.Windows.Forms.Form
   {
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.Button button2;
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
         this.button2 = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(208, 48);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(72, 32);
         this.button1.TabIndex = 1;
         this.button1.Text = "button1";
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // button2
         // 
         this.button2.Location = new System.Drawing.Point(344, 144);
         this.button2.Name = "button2";
         this.button2.Size = new System.Drawing.Size(96, 40);
         this.button2.TabIndex = 2;
         this.button2.Text = "button2";
         this.button2.Click += new System.EventHandler(this.button2_Click);
         // 
         // Form1
         // 
         this.ClientSize = new System.Drawing.Size(512, 494);
         this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.button2,
                                                                      this.button1});
         this.IsMdiContainer = true;
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

      private void button1_Click(object sender, System.EventArgs e)
      {

		   Form frm2 = new Form(); 
         frm2.MdiParent = this;
         frm2.Show();
			
      }
      private void button2_Click(object sender, System.EventArgs e)
      {
         AddButtonsToMyChildren();
      }

      //<Snippet1>
      private void AddButtonsToMyChildren()
      {
         // If there are child forms in the parent form, add Button controls to them.
         for (int x =0; x < this.MdiChildren.Length;x++)
         {
            // Create a temporary Button control to add to the child form.
            Button tempButton = new Button();
            // Set the location and text of the Button control.
            tempButton.Location = new Point(10,10);
            tempButton.Text = "OK";
            // Create a temporary instance of a child form (Form 2 in this case).
            Form tempChild = (Form)this.MdiChildren[x];
            // Add the Button control to the control collection of the form.
            tempChild.Controls.Add(tempButton);
         }
      }
      //</Snippet1>
   }
}

