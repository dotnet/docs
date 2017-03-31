using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text;

namespace ListViewAfterLabelEditEx
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
      private System.Windows.Forms.ListView listView1;
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
         System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new System.Windows.Forms.ListViewItem.ListViewSubItem[] {
                                                                                                                                                            new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "Item A", System.Drawing.SystemColors.WindowText, System.Drawing.SystemColors.Window, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))))}, -1);
         System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new System.Windows.Forms.ListViewItem.ListViewSubItem[] {
                                                                                                                                                            new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "Item B", System.Drawing.SystemColors.WindowText, System.Drawing.SystemColors.Window, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))))}, -1);
         System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new System.Windows.Forms.ListViewItem.ListViewSubItem[] {
                                                                                                                                                            new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "Item C", System.Drawing.SystemColors.WindowText, System.Drawing.SystemColors.Window, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))))}, -1);
         System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem(new System.Windows.Forms.ListViewItem.ListViewSubItem[] {
                                                                                                                                                            new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "Item D", System.Drawing.SystemColors.WindowText, System.Drawing.SystemColors.Window, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))))}, -1);
         this.listView1 = new System.Windows.Forms.ListView();
         this.SuspendLayout();
         // 
         // listView1
         // 
         this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
                                                                                  listViewItem1,
                                                                                  listViewItem2,
                                                                                  listViewItem3,
                                                                                  listViewItem4});
         this.listView1.LabelEdit = true;
         this.listView1.Location = new System.Drawing.Point(16, 24);
         this.listView1.Name = "listView1";
         this.listView1.Size = new System.Drawing.Size(424, 328);
         this.listView1.TabIndex = 0;
         this.listView1.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.MyListView_AfterLabelEdit);
         // 
         // Form1
         // 
         this.ClientSize = new System.Drawing.Size(464, 422);
         this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.listView1});
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
      private void MyListView_AfterLabelEdit(object sender, System.Windows.Forms.LabelEditEventArgs e)
      {
       
         // Determine if label is changed by checking for null.
         if (e.Label == null)
            return;

         // ASCIIEncoding is used to determine if a number character has been entered.
         ASCIIEncoding AE = new ASCIIEncoding();
         // Convert the new label to a character array.
         char[] temp = e.Label.ToCharArray();

         // Check each character in the new label to determine if it is a number.
         for(int x=0; x < temp.Length; x++)
         {
            // Encode the character from the character array to its ASCII code.
            byte[] bc = AE.GetBytes(temp[x].ToString());
         
            // Determine if the ASCII code is within the valid range of numerical values.
            if(bc[0] > 47 && bc[0] < 58)
            {
               // Cancel the event and return the lable to its original state.
               e.CancelEdit = true;
               // Display a MessageBox alerting the user that numbers are not allowed.
               MessageBox.Show ("The text for the item cannot contain numerical values.");
               // Break out of the loop and exit.
               return;
            }
         }
      }
      //</Snippet1>
	}
}
