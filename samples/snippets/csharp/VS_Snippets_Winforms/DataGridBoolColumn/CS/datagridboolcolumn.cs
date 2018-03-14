// System.Windows.Forms.DataGridBoolColumn.TrueValueChanged
// System.Windows.Forms.DataGridBoolColumn.AllowNullChanged
// System.Windows.Forms.DataGridBoolColumn.FalseValueChanged

/*
   The following example demonstrates 'TrueValueChanged',
   AllowNullChanged' and 'FalseValueChanged' events for the
   'DataGridBoolColumn' class. This example had a 'DataGrid'
   which is associated with three columns and a datasource 
   created with the 'CreateSource' method. There are three
   additional combo boxes each to change the 'TrueValue',
   'FalseValue' and 'AllowNull' properties of the 'DataGridBoolColumn'.
   The 'TrueValue' property is used to specify the object that
   the 'DataGridBoolColumn' presumes to be a true value. The
   'FalseValue' property has the same semantics. Changing
   the value of these properties raises the corresponding 
   events. Changing 'TrueValue' raises the 'TrueValueChanged', 
   changing 'FalseValue' raises the 'FalseValueChanged' and
   'AllowNull' changes the 'AllowNullChanged' events respectively.
 */

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

public class MyForm : System.Windows.Forms.Form
{
   private System.Windows.Forms.DataGrid myDataGrid;
   private System.Windows.Forms.DataGridTableStyle myDataGridTableStyle;
   private System.Windows.Forms.DataGridTextBoxColumn myDataGridTextBoxColumn1;
   private System.Windows.Forms.DataGridTextBoxColumn myDataGridTextBoxColumn2;
   private System.Windows.Forms.DataGridBoolColumn myDataGridBoolColumn;
   private System.Windows.Forms.Label myLabel1;
   private System.Windows.Forms.ComboBox myComboBox1;
   private System.Windows.Forms.Label myLabel2;
   private System.Windows.Forms.ComboBox myComboBox2;
   private System.Windows.Forms.Label myLabel3;
   private System.Windows.Forms.ComboBox myComboBox3;
   private System.ComponentModel.Container components = null;

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

   ICollection CreateSource() 
   {
      //Create a new 'DataTable' object.
      DataTable myDataTable = new DataTable("TestTable");
      DataRow myDataRow;

      //Associate 'DataColumns' with the 'DataTable' object.
      myDataTable.Columns.Add(new DataColumn("IntegerValue", typeof(Int32)));
      myDataTable.Columns.Add(new DataColumn("StringValue", typeof(string)));
      myDataTable.Columns.Add(new DataColumn("CurrencyValue", typeof(double)));
      myDataTable.Columns.Add(new DataColumn("BooleanValue", typeof(Boolean)));
	
      int count = 1;
      bool even = false;
      //Insert new rows into the 'DataTable' object.
      for(int i = -5; i < 5; i++) 
      {
         myDataRow = myDataTable.NewRow();
         myDataRow[0] = count;
         myDataRow[1] = "Item " + count.ToString();
         myDataRow[2] = 1.23 * (count + 1);
         // If 'even' insert a 'DBNull' into the table.
         if(even)
         {
            myDataRow[3] = Convert.DBNull;
            even = false;
         }
         else
         {
            if(i < 0)
               // If 'negative' insert a 'false' into the table.
               myDataRow[3] = false;
            else
               // If 'positive' insert a 'true' into the table.
               myDataRow[3] = true;
            even = true;
         }
         myDataTable.Rows.Add(myDataRow);
         count += 1;
      }

      //Create a new instance of 'DataView' from the 'DataTable' instance.
      DataView myDataView = new DataView(myDataTable);

      return myDataView;
   }

   private void InitializeComponent()
   {
      System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MyForm));
      myDataGridTableStyle = new System.Windows.Forms.DataGridTableStyle();
      myDataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
      myDataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
      myDataGridBoolColumn = new System.Windows.Forms.DataGridBoolColumn();
      myLabel1 = new System.Windows.Forms.Label();
      myLabel2 = new System.Windows.Forms.Label();
      myDataGrid = new System.Windows.Forms.DataGrid();
      myLabel3 = new System.Windows.Forms.Label();
      myComboBox3 = new System.Windows.Forms.ComboBox();
      myComboBox2 = new System.Windows.Forms.ComboBox();
      myComboBox1 = new System.Windows.Forms.ComboBox();
      ((System.ComponentModel.ISupportInitialize)(myDataGrid)).BeginInit();
      SuspendLayout();
      // 
      // myDataGridTableStyle
      // 
      myDataGridTableStyle.DataGrid = myDataGrid;
      myDataGridTableStyle.GridColumnStyles.AddRange(
         new System.Windows.Forms.DataGridColumnStyle[] {
                                                           myDataGridTextBoxColumn1,
                                                           myDataGridTextBoxColumn2,
                                                           myDataGridBoolColumn});
      myDataGridTableStyle.MappingName = "TestTable";
      // 
      // myDataGridTextBoxColumn1
      // 
      myDataGridTextBoxColumn1.MappingName = "IntegerValue";
      // 
      // myDataGridTextBoxColumn2
      // 
      myDataGridTextBoxColumn2.MappingName = "StringValue";
      // 
      // myDataGridBoolColumn
      // 
      myDataGridBoolColumn.MappingName = "BooleanValue";
      myDataGridBoolColumn.TrueValue = true;
      myDataGridBoolColumn.FalseValue = false;
      myDataGridBoolColumn.NullValue = Convert.DBNull;
      myDataGridBoolColumn.AllowNull = true;
      RegisterEventHandlers(myDataGridBoolColumn);
      // 
      // myLabel1
      // 
      myLabel1.Location = new System.Drawing.Point(16, 232);
      myLabel1.Size = new System.Drawing.Size(136, 24);
      myLabel1.Text = "Change the TrueValue to:";
      // 
      // myLabel2
      // 
      myLabel2.Location = new System.Drawing.Point(16, 264);
      myLabel2.Size = new System.Drawing.Size(136, 24);
      myLabel2.Text = "Change the FalseValue to:";
      // 
      // myDataGrid
      // 
      myDataGrid.Location = new System.Drawing.Point(16, 0);
      myDataGrid.Size = new System.Drawing.Size(296, 216);
      myDataGrid.DataSource = CreateSource();
      myDataGrid.TableStyles.AddRange(
         new System.Windows.Forms.DataGridTableStyle[] {
                                                          myDataGridTableStyle});
      // 
      // myLabel3
      // 
      myLabel3.Location = new System.Drawing.Point(16, 296);
      myLabel3.Size = new System.Drawing.Size(136, 24);
      myLabel3.Text = "Allow null values to appear:";
      // 
      // myComboBox3
      // 
      myComboBox3.Location = new System.Drawing.Point(168, 288);
      myComboBox3.Size = new System.Drawing.Size(144, 21);
      myComboBox3.Items.AddRange(new Object[] {true, false});
      myComboBox3.SelectedIndexChanged +=
         new System.EventHandler(myComboBox3_SelectedIndexChanged);
      // 
      // myComboBox2
      // 
      myComboBox2.Location = new System.Drawing.Point(168, 256);
      myComboBox2.Size = new System.Drawing.Size(144, 21);
      myComboBox2.Items.AddRange(new Object[] {true, false});
      myComboBox2.SelectedIndexChanged += 
         new System.EventHandler(myComboBox2_SelectedIndexChanged);
      // 
      // myComboBox1
      // 
      myComboBox1.Location = new System.Drawing.Point(168, 224);
      myComboBox1.Size = new System.Drawing.Size(144, 21);
      myComboBox1.Items.AddRange(new Object[] {true, false});
      myComboBox1.SelectedIndexChanged += 
         new System.EventHandler(myComboBox1_SelectedIndexChanged);
      // 
      // MyForm
      // 
      ClientSize = new System.Drawing.Size(336, 341);
      Controls.AddRange(
         new System.Windows.Forms.Control[] {
                                               myComboBox3,
                                               myLabel3,
                                               myComboBox2,
                                               myLabel2,
                                               myComboBox1,
                                               myLabel1,
                                               myDataGrid});
      Name = "MyForm";
      Text = "MyForm";
      ((System.ComponentModel.ISupportInitialize)(myDataGrid)).EndInit();
      ResumeLayout(false);

   }

   [STAThread]
   static void Main() 
   {
      Application.Run(new MyForm());
   }

// <Snippet1>
// <Snippet2>
// <Snippet3>

   private void RegisterEventHandlers(DataGridBoolColumn myDataGridBoolColumn)
   {
      myDataGridBoolColumn.AllowNullChanged += 
         new System.EventHandler(myDataGridBoolColumn_AllowNullChanged);
      myDataGridBoolColumn.TrueValueChanged += 
         new System.EventHandler(myDataGridBoolColumn_TrueValueChanged);
      myDataGridBoolColumn.FalseValueChanged +=
         new System.EventHandler(myDataGridBoolColumn_FalseValueChanged);
   }

   // Event handler for event when 'TrueValue' is property changed.
   private void myDataGridBoolColumn_TrueValueChanged(object sender, EventArgs e)
   {
      MessageBox.Show("The TrueValue property of the DataGridBoolColumn has been changed to "
         + myDataGridBoolColumn.TrueValue);
   }

   // Event handler for event when 'FalseValue' is property changed.
   private void myDataGridBoolColumn_FalseValueChanged(object sender, EventArgs e)
   {
      MessageBox.Show("The FalseValue property of the DataGridBoolColumn has been changed to "
         + myDataGridBoolColumn.FalseValue);
   }

   // Event handler for event when 'AllowNull' is property changed.
   private void myDataGridBoolColumn_AllowNullChanged(object sender, EventArgs e)
   {
      MessageBox.Show("The AllowNull property of DataGridBoolColumn has been changed to "
         + myDataGridBoolColumn.AllowNull);
   }

// </Snippet3>
// </Snippet2>
// </Snippet1>

   // Change the value of 'TrueValue' property to what user specifies.
   private void myComboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
   {
      myDataGridBoolColumn.TrueValue = 
         (Boolean)myComboBox1.Items[myComboBox1.SelectedIndex];
   }

   // Change the value of 'FalseValue' property to what user specifies.
   private void myComboBox2_SelectedIndexChanged(object sender, System.EventArgs e)
   {
      myDataGridBoolColumn.FalseValue = 
         (Boolean)myComboBox2.Items[myComboBox2.SelectedIndex];
   }

   // Change the value of 'AllowNull' property to what user specifies.
   private void myComboBox3_SelectedIndexChanged(object sender, System.EventArgs e)
   {
      myDataGridBoolColumn.AllowNull = 
         (Boolean)myComboBox3.Items[myComboBox3.SelectedIndex];
   }
}
