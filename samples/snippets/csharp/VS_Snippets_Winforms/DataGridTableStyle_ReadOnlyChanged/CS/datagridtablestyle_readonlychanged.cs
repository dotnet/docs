// System.Windows.Forms.DataGridTableStyle.ReadOnlyChanged

/*
   The following example demonstrates the 'ReadOnlyChanged' event of 'DataGridTableStyle' class. 
   It adds a DataGrid and checkbox to a Form. When  the Check box is checked, the 'ReadOnly' property of
   'DataGridTableStyle' is changed. 
*/

   using System;
   using System.Data;
   using System.Drawing;
   using System.Windows.Forms;

   public class Form1 : Form
   {
      private DataSet myDataSet1;
      private CheckBox myCheckBox1;
      private DataGrid myDataGrid1;
      private DataGridTableStyle myDataGridTableStyle;

      public Form1()
      {
         InitializeComponent();
         MakeDataSet();
         AddTableStyle();
      }

      private void InitializeComponent()
      {
         myDataGrid1 = new DataGrid();
         myCheckBox1 = new CheckBox();
         SuspendLayout();
         myDataGrid1.DataMember = "";
         myDataGrid1.Location = new Point(72, 64);
         myDataGrid1.Name = "myDataGrid1";
         myDataGrid1.Size = new Size(208, 128);
         myDataGrid1.TabIndex = 0;
         myCheckBox1.Location = new Point(304, 112);
         myCheckBox1.Name = "myCheckBox1";
         myCheckBox1.TabIndex = 1;
         myCheckBox1.Text = "Read Only";
         myCheckBox1.CheckedChanged += new EventHandler(myCheckBox1_CheckedChanged);
         ClientSize = new Size(472, 273);
         Controls.AddRange(new Control[] {myCheckBox1,myDataGrid1});
         Name = "Form1";
         Text = "Test \'ReadOnleChanged\' Event of \'DataGridTableStyle\' class";
         ResumeLayout(false);
      }

      public static void Main()
      {
         Application.Run(new Form1());
      }

      // Create a DataSet with a table and populate it.
      private void MakeDataSet()
      {
         myDataSet1 = new DataSet("myDataSet");

         DataTable customerTable = new DataTable("Customers");

         // Create two columns, and add them to the first table.
         DataColumn myColumn = new DataColumn("CustID", typeof(int));
         DataColumn myColumn1 = new DataColumn("CustName");
         customerTable.Columns.Add(myColumn);
         customerTable.Columns.Add(myColumn1);

         // Add the tables to the DataSet.
         myDataSet1.Tables.Add(customerTable);
         
         // Create three customers in the Customers Table.
         DataRow newRow1;
         for(int i = 1; i < 4; i++)
         {
            newRow1 = customerTable.NewRow();
            newRow1["custID"] = i;
            // Add the row to the Customers table.
            customerTable.Rows.Add(newRow1);
         }
         // Give each customer a distinct name.
         customerTable.Rows[0]["CustName"] = "Alpha";
         customerTable.Rows[1]["CustName"] = "Beta";
         customerTable.Rows[2]["CustName"] = "Omega";

         // Add Unique Key constraint to the CustID column.
         UniqueConstraint idKeyRestraint = new UniqueConstraint(myColumn);
         customerTable.Constraints.Add(idKeyRestraint);
         myDataSet1.EnforceConstraints = true;
      }

// <Snippet1>
      protected void AddTableStyle()
      {
         // Create a new DataGridTableStyle.
         myDataGridTableStyle = new DataGridTableStyle();
         myDataGridTableStyle.MappingName = myDataSet1.Tables[0].TableName;
         myDataGrid1.DataSource=myDataSet1.Tables[0];
         myDataGridTableStyle.ReadOnlyChanged+=new EventHandler(MyReadOnlyChangedEventHandler);
         myDataGrid1.TableStyles.Add(myDataGridTableStyle);
      }

      // Handle the 'ReadOnlyChanged' event.
      private void MyReadOnlyChangedEventHandler(object sender, EventArgs e)
      {
         MessageBox.Show("ReadOnly property is changed");
      }

      // Handle the check box's CheckedChanged event
      private void myCheckBox1_CheckedChanged(object sender, EventArgs e)
      {
         if(myDataGridTableStyle.ReadOnly)
         {
            myDataGridTableStyle.ReadOnly=false;
         }
         else
         {
            myDataGridTableStyle.ReadOnly=true;
         }
      }
// </Snippet1>
   }
