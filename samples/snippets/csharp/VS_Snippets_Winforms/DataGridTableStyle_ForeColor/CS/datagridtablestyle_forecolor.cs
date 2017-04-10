// System.Windows.Forms.DataGridTableStyle.ForeColor

/*
   The following program demonstrates the property 'ForeColor' of class 'DataGridTableStyle'.
   A table with 2 columns is created and attached to grid. A listbox allows selection of forecolors
   for the grid.
*/


using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Datagrid
{
   public class Form1 : System.Windows.Forms.Form
   {
      private System.Windows.Forms.DataGrid dataGrid1;
      private System.Windows.Forms.ComboBox myComboBox;
      private System.Windows.Forms.Button button2;
      // Declare objects of DataSet,DataGrid,DataTable.
      private DataSet myDataSet;
      public DataTable myCustomerTable;
      public DataGridTableStyle myTableStyle;
      private System.ComponentModel.Container components = null;

      public Form1()
      {
         InitializeComponent();
      }

      // Clean up resources.
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
         this.myComboBox = new System.Windows.Forms.ComboBox();
         this.dataGrid1 = new System.Windows.Forms.DataGrid();
         this.button2 = new System.Windows.Forms.Button();
         ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
         this.SuspendLayout();
         // 
         // myComboBox
         // 
         this.myComboBox.DropDownWidth = 136;
         this.myComboBox.Items.AddRange(new object[] {
                                                        "Green",
                                                        "Red",
                                                        "Violet"});
         this.myComboBox.Location = new System.Drawing.Point(64, 160);
         this.myComboBox.Name = "myComboBox";
         this.myComboBox.Size = new System.Drawing.Size(136, 21);
         this.myComboBox.TabIndex = 3;
         this.myComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
         // 
         // dataGrid1
         // 
         this.dataGrid1.CaptionText = "DataGrid";
         this.dataGrid1.DataMember = "";
         this.dataGrid1.Location = new System.Drawing.Point(56, 48);
         this.dataGrid1.Name = "dataGrid1";
         this.dataGrid1.Size = new System.Drawing.Size(272, 80);
         this.dataGrid1.TabIndex = 0;
         // 
         // button2
         // 
         this.button2.Location = new System.Drawing.Point(232, 160);
         this.button2.Name = "button2";
         this.button2.Size = new System.Drawing.Size(96, 32);
         this.button2.TabIndex = 4;
         this.button2.Text = "Change ForeGround";
         this.button2.Click += new System.EventHandler(this.OnForeColor_Click);
         // 
         // Form1
         // 
         this.ClientSize = new System.Drawing.Size(536, 301);
         this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.button2,
                                                                      this.myComboBox,
                                                                      this.dataGrid1});
         this.Name = "Form1";
         this.Text = "Form1";
         this.Load += new System.EventHandler(this.Form1_Load);
         ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
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

      private void Form1_Load(object sender, System.EventArgs e)
      {
         myComboBox.SelectedIndex = 0;
         Create_Table();
      }
// <Snippet1>
      private void Create_Table()
      {
         // Create a DataSet.
         myDataSet = new DataSet("myDataSet");
         // Create DataTable.
         DataTable myCustomerTable = new DataTable("Customers");
         // Create two columns, and add to the table.
         DataColumn CustID = new DataColumn("CustID", typeof(int));
         DataColumn CustName = new DataColumn("CustName");
         myCustomerTable.Columns.Add(CustID);
         myCustomerTable.Columns.Add(CustName);
         DataRow newRow1;
         // Create three customers in the Customers Table.
         for(int i = 1; i < 3; i++)
         {
            newRow1 = myCustomerTable.NewRow();
            newRow1["custID"] = i;
            // Add row to the Customers table.
            myCustomerTable.Rows.Add(newRow1);
         }
         // Give each customer a distinct name.
         myCustomerTable.Rows[0]["custName"] = "Alpha";
         myCustomerTable.Rows[1]["custName"] = "Beta";
         // Add table to DataSet.
         myDataSet.Tables.Add(myCustomerTable);
         dataGrid1.SetDataBinding(myDataSet,"Customers");
         myTableStyle = new DataGridTableStyle();
         myTableStyle.MappingName = "Customers";
         myTableStyle.ForeColor  = Color.DarkMagenta;
         dataGrid1.TableStyles.Add(myTableStyle);
      }

      // Set table's forecolor.
      private void OnForeColor_Click(object sender, System.EventArgs e)
      {
         dataGrid1.TableStyles.Clear();
         switch(myComboBox.SelectedItem.ToString())
         {
            case "Green":
               myTableStyle.ForeColor = Color.Green;
               break;
            case "Red":
               myTableStyle.ForeColor = Color.Red;
               break;
            case "Violet":
               myTableStyle.ForeColor = Color.Violet;
               break;
         }
         dataGrid1.TableStyles.Add(myTableStyle);
      }
// </Snippet1>
   }
}

