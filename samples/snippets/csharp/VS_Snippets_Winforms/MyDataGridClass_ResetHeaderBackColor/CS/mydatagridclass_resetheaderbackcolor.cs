// System.Windows.Forms.DataGrid.ResetHeaderBackColor
// System.Windows.Forms.DataGrid.ResetHeaderForeColor
// System.Windows.Forms.DataGrid.ResetHeaderFont
// System.Windows.Forms.DataGrid.Select
// System.Windows.Forms.DataGrid.IsSelected
// System.Windows.Forms.DataGrid.RowHeaderWidth

/* The following program demonstrates various methods and properties of
   the 'DataGrid' class. It creates a 'GridControl', changes the 
   header background color,header foreground color, header font
   and resets them. It also selects a row, checks weather the row is selected 
   and checks the 'ReadOnly'	and 'FlatMode' properties of the data grid.
   Displays the 'RowHeaderWidth', depending on the selection of 
   buttons.
*/

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace MyDataGridClass
{
   /// <summary>
   /// Summary description for MyDataGridClass_ResetHeaderBackColor.
   /// </summary>
   public class MyDataGridClass_ResetHeaderBackColor: Form
   {
      private DataGrid myDataGrid;
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private Container components = null;
      private Button button1;
      private Button button2;
      private Button button3;
      private Button button4;
      private Button button5;
      private Button button6;
      private Button button7;
      private Button button8;
      private DataSet myDataSet;
      private Button button9;
      private Button button11;
      
      public MyDataGridClass_ResetHeaderBackColor()
      {
         InitializeComponent();
         SetUp();
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
         this.FormBorderStyle = FormBorderStyle.FixedDialog;
         this.button8 = new Button();
         this.button9 = new Button();
         this.button11 = new Button();
         this.button4 = new Button();
         this.button5 = new Button();
         this.button6 = new Button();
         this.button7 = new Button();
         this.button1 = new Button();
         this.button2 = new Button();
         this.button3 = new Button();
         this.myDataGrid = new DataGrid();
         ((ISupportInitialize)(this.myDataGrid)).BeginInit();
         this.SuspendLayout();
         // 
         // button8
         // 
         this.button8.Location = new Point(352, 176);
         this.button8.Name = "button8";
         this.button8.Size = new Size(96, 40);
         this.button8.TabIndex = 8;
         this.button8.Text = "Display Status";
         this.button8.Click += new EventHandler(this.button8_Click);
         // 
         // button9
         // 
         this.button9.Location = new Point(24, 216);
         this.button9.Name = "button9";
         this.button9.Size = new Size(96, 40);
         this.button9.TabIndex = 9;
         this.button9.Text = "Get Row Header Width";
         this.button9.Click += new EventHandler(this.button9_Click);
         // 
         // button11
         // 
         this.button11.Location = new Point(256, 216);
         this.button11.Name = "button11";
         this.button11.Size = new Size(96, 40);
         this.button11.TabIndex = 7;
         this.button11.Text = "UnSelect Row";
         this.button11.Click += new EventHandler(this.button11_Click);
         // 
         // button4
         // 
         this.button4.Location = new Point(352, 72);
         this.button4.Name = "button4";
         this.button4.Size = new Size(96, 40);
         this.button4.TabIndex = 4;
         this.button4.Text = "Reset Header Fore Color";
         this.button4.Click += new EventHandler(this.button4_Click);
         // 
         // button5
         // 
         this.button5.Location = new Point(352, 128);
         this.button5.Name = "button5";
         this.button5.Size = new Size(96, 40);
         this.button5.TabIndex = 5;
         this.button5.Text = "Reset Header Font";
         this.button5.Click += new EventHandler(this.button5_Click);
         // 
         // button6
         // 
         this.button6.Location = new Point(256, 128);
         this.button6.Name = "button6";
         this.button6.Size = new Size(96, 40);
         this.button6.TabIndex = 6;
         this.button6.Text = "Change Header Font";
         this.button6.Click += new EventHandler(this.button6_Click);
         // 
         // button7
         // 
         this.button7.Location = new Point(256, 176);
         this.button7.Name = "button7";
         this.button7.Size = new Size(96, 40);
         this.button7.TabIndex = 7;
         this.button7.Text = "Select Row";
         this.button7.Click += new EventHandler(this.button7_Click);
         // 
         // button1
         // 
         this.button1.Location = new Point(256, 24);
         this.button1.Name = "button1";
         this.button1.Size = new Size(96, 40);
         this.button1.TabIndex = 1;
         this.button1.Text = "Change Header Back Color";
         this.button1.Click += new EventHandler(this.button1_Click);
         // 
         // button2
         // 
         this.button2.Location = new Point(352, 24);
         this.button2.Name = "button2";
         this.button2.Size = new Size(96, 40);
         this.button2.TabIndex = 2;
         this.button2.Text = "Reset Header Back Color";
         this.button2.Click += new EventHandler(this.button2_Click);
         // 
         // button3
         // 
         this.button3.Location = new Point(256, 72);
         this.button3.Name = "button3";
         this.button3.Size = new Size(96, 40);
         this.button3.TabIndex = 3;
         this.button3.Text = "Change Header Fore Color";
         this.button3.Click += new EventHandler(this.button3_Click);
         // 
         // myDataGrid
         // 
         this.myDataGrid.CaptionText = "My Grid Control";
         this.myDataGrid.DataMember = "";
         this.myDataGrid.Location = new Point(8, 32);
         this.myDataGrid.Name = "myDataGrid";
         this.myDataGrid.RowHeaderWidth = 50;
         this.myDataGrid.Size = new Size(216, 152);
         this.myDataGrid.TabIndex = 0;
         // 
         // MyDataGridClass_ResetHeaderBackColor
         // 
         this.AutoScale = false;
         this.ClientSize = new Size(528, 273);
         this.Controls.AddRange(new Control[] {
         this.button9,
         this.button8,
         this.button7,
         this.button6,
         this.button5,
         this.button4,
         this.button3,
         this.button2,
         this.button1,
         this.myDataGrid,
         this.button11});
         this.MaximizeBox = false;
         this.Name = "MyDataGridClass_ResetHeaderBackColor";
         this.Text = "Grid Control";
         ((ISupportInitialize)(this.myDataGrid)).EndInit();
         this.ResumeLayout(false);

      }
      #endregion

      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main() 
      {
         Application.Run(new MyDataGridClass_ResetHeaderBackColor());
      }
      private void SetUp()
      {
         MakeDataSet();
         myDataGrid.SetDataBinding(myDataSet, "Customers");
         myDataGrid.ReadOnly = true;
      }

      private void MakeDataSet()
      {
         // Create a 'DataSet'.
         myDataSet = new DataSet("myDataSet");
         // Create a 'DataTable'.
         DataTable myTable = new DataTable("Customers");
         // Create two columns, and add them to the table.
         DataColumn myColumn1 = new DataColumn("CustID", typeof(int));
         DataColumn myColumn2 = new DataColumn("CustName");
         myTable.Columns.Add(myColumn1);
         myTable.Columns.Add(myColumn2);
         // Add the table to the 'DataSet'.
         myDataSet.Tables.Add(myTable);   
         // For the customer, create a 'DataRow' variable. 
         DataRow newRow;
         // Create one customer in the customers table.
         for(int i = 1; i < 2; i++)
         {
            newRow = myTable.NewRow();
            newRow["custID"] = i;
            // Add the row to the 'Customers' table.
            myTable.Rows.Add(newRow);
         }
         // Give the customer a name.
         myTable.Rows[0]["custName"] = "Customer";               
      }         
// <Snippet1>      
      private void button1_Click(object sender, EventArgs e)
      {
         ColorDialog myColorDialog = new ColorDialog();
         // Disable selecting a custom color.
         myColorDialog.AllowFullOpen = false ;
         // Enable the help button.
         myColorDialog.ShowHelp = true ;
         // Set the initial color to the current color.
         myColorDialog.Color = myDataGrid.HeaderBackColor;
         // Show color dialog box.
         myColorDialog.ShowDialog();
         // Set the header background color.   
         myDataGrid.HeaderBackColor  = myColorDialog.Color;
         
      }
      // Reset the header background color.
      private void button2_Click(object sender, EventArgs e)
      {           
         myDataGrid.ResetHeaderBackColor();
      }
// </Snippet1>      
// <Snippet2>
      private void button3_Click(object sender, EventArgs e)
      {
         ColorDialog myColorDialog = new ColorDialog();
         // Disable selecting a custom color.
         myColorDialog.AllowFullOpen = false ;
         // Enable the help button.
         myColorDialog.ShowHelp = true ;
         // Set the initial color to the current color.
         myColorDialog.Color = myDataGrid.HeaderForeColor;
         // Show color dialog box.
         myColorDialog.ShowDialog();
         // Set the header foreground color.
         myDataGrid.HeaderForeColor = myColorDialog.Color;
      }
      // Reset the header foregroundcolor.
      private void button4_Click(object sender, EventArgs e)
      {
         myDataGrid.ResetHeaderForeColor();
      }
// </Snippet2>
// <Snippet3>
      // Set the header font to Arial with size 20.
      private void button6_Click(object sender, EventArgs e)
      {
         myDataGrid.HeaderFont = new Font("Arial", 20);
      }
      // Reset the header font.
      private void button5_Click(object sender, EventArgs e)
      {
         myDataGrid.ResetHeaderFont();
      }
// </Snippet3>
// <Snippet4>
      // Select the first row.
      private void button7_Click(object sender, EventArgs e)
      {
         myDataGrid.Select(0);
      }
// <Snippet5>
      // Check if the first row is selected.
      private void button8_Click(object sender, EventArgs e)
      {         
         if(myDataGrid.IsSelected(0))
         {
            MessageBox.Show("Row selected",
               "Message",   MessageBoxButtons.OK,
               MessageBoxIcon.Exclamation);
         }
         else
         {
            MessageBox.Show("Row not selected",
               "Message",   MessageBoxButtons.OK,
               MessageBoxIcon.Exclamation);
         }         
      }
      // Deselect the first row.
      private void button11_Click(object sender, EventArgs e)
      {
         myDataGrid.UnSelect(0);
      }
// </Snippet5>
// </Snippet4>
// <Snippet6>
      // Get the width of row header.
      private void button9_Click(object sender, EventArgs e)
      {
         Int32 myRowHeaderWidth = myDataGrid.RowHeaderWidth;
         MessageBox.Show("Width of row headers is: "+ 
                  myRowHeaderWidth.ToString(), "Message",
                  MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
      }      
// </Snippet6>      
   }
}
