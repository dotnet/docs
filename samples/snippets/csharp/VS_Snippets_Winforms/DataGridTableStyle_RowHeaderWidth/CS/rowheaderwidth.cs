// System.Windows.Forms.DataGridTableStyle.RowHeaderWidth
// System.Windows.Forms.DataGridTableStyle.RowHeaderWidthChanged

/* The following program demonstrates the 'RowHeaderWidth' 
   method and 'RowHeaderWidthChanged' event of 'DataGridTableStyle'
   class. It changes the row header width on button click 
   and resets the row header width. */
 
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

public class DataGridTableStyle_RowHeaderWidth : Form
{
   private Container components = null;
   private Button button2;

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
      this.myDataGrid = new DataGrid();
      this.button1    = new Button();
      this.button2    = new Button();
   ((System.ComponentModel.ISupportInitialize)(this.myDataGrid)).BeginInit();
      this.SuspendLayout();
      // 
      // myDataGrid
      // 
      this.myDataGrid.DataMember = "";
      this.myDataGrid.LinkColor  = SystemColors.Desktop;
      this.myDataGrid.Location   = new Point(56, 40);
      this.myDataGrid.Name       = "myDataGrid";
      this.myDataGrid.Size       = new Size(224, 144);
      this.myDataGrid.TabIndex   = 0;
      // 
      // button1
      // 
      this.button1.Location = new Point(168, 208);
      this.button1.Name     = "button1";
      this.button1.Size     = new Size(152, 23);
      this.button1.TabIndex = 1;
      this.button1.Text     = " Change RowHeader Width";
      this.button1.Click   += new EventHandler(this.button1_Click);
      // 
      // button2
      // 
      this.button2.Location = new Point(16, 208);
      this.button2.Name     = "button2";
      this.button2.Size     = new Size(152, 23);
      this.button2.TabIndex = 1;
      this.button2.Text     = "Display RowHeader Width";
      this.button2.Click   += new EventHandler(this.button2_Click);
      // 
      // DataGridTableStyle_RowHeaderWidth
      // 
      this.ClientSize = new Size(344, 261);
      this.Controls.AddRange(new Control[] {this.button1, 
                                              this.myDataGrid, this.button2});
      this.Name = "DataGridTableStyle_RowHeaderWidth";
      this.Text = "Change Row Width";

      CallEventLoader();
      ((System.ComponentModel.ISupportInitialize)(this.myDataGrid)).EndInit();
      this.ResumeLayout(false);
   }

   #endregion

   DataGridColumnStyle IdCol   = new DataGridTextBoxColumn();
   DataGridColumnStyle TextCol = new DataGridTextBoxColumn();

   [STAThread]
   static void Main() 
   {
      Application.Run(new DataGridTableStyle_RowHeaderWidth());
   }

   private DataGridTableStyle myDataGridTableStyle = new DataGridTableStyle();
   private DataGrid myDataGrid;
   private Button button1;

   public DataGridTableStyle_RowHeaderWidth()
   {
      InitializeComponent();
      // Create and bind DataSet to DataGrid.
      CreateNBindDataSet();
   }

   private void CreateNBindDataSet()
   {
      // Create a DataSet with one table.
      DataSet myDataSet = new DataSet("myDataSet");
      // Create a DataTable.
      DataTable myEmpTable = new DataTable("Employee");
      // Create two columns, and add them to the employee table.
      DataColumn myEmpID = new DataColumn("EmpID", typeof(int));
      DataColumn myEmpName = new DataColumn("EmpName");
      myEmpTable.Columns.Add(myEmpID);
      myEmpTable.Columns.Add(myEmpName);
      // Add the table to the DataSet.
      myDataSet.Tables.Add(myEmpTable);

      // Populate the table.
      DataRow newRow1;

      // Create employee records in the employee table.
      for(int i = 1; i < 6; i++)
      {
         newRow1 = myEmpTable.NewRow();
         newRow1["EmpID"] = i;
         // Add the row to the Employee table.
         myEmpTable.Rows.Add(newRow1);
      }

      // Give each employee a distinct name.
      myEmpTable.Rows[0]["EmpName"] = "Gary";
      myEmpTable.Rows[1]["EmpName"] = "Harry";
      myEmpTable.Rows[2]["EmpName"] = "Mary";
      myEmpTable.Rows[3]["EmpName"] = "Larry";
      myEmpTable.Rows[4]["EmpName"] = "Robert";

      // Bind the DataGrid to the DataSet.
      myDataGrid.SetDataBinding(myDataSet, "Employee");
   }

   private void DataGridTableStyle_RowHeaderWidth_Load(object sender, System.EventArgs e)
   {
      myDataGridTableStyle.MappingName = "Employee";
      // Set other properties.
      myDataGridTableStyle.AlternatingBackColor = Color.LightGray;

      // Set MappingName to the DataColumn name in the DataTable.
      IdCol.MappingName = "EmpID";
      
      // Set the HeaderText and Width properties.
      IdCol.HeaderText = "Emp ID";
      IdCol.Width = 50;
      
      // Add a GridColumnStyle.
      myDataGridTableStyle.GridColumnStyles.Add(IdCol);
      myDataGridTableStyle.RowHeaderWidth = 10;
      
      // Add a second column style.
      TextCol.MappingName = "EmpName";
      TextCol.HeaderText = "Emp Name";
      TextCol.Width = 100;
      myDataGridTableStyle.GridColumnStyles.Add(TextCol);
      
      // Add the DataGridTableStyle to GridTableStylesCollection.
      myDataGrid.TableStyles.Add(myDataGridTableStyle);
      myDataGridTableStyle.GridLineColor = Color.Red;    
      AttachRowHeaderWidthChanged();
   }

// <Snippet1>
// <Snippet2>
   private void CallEventLoader()
   {
      this.Load += new EventHandler(
         this.DataGridTableStyle_RowHeaderWidth_Load);
   }

   public void AttachRowHeaderWidthChanged()
   {
      myDataGridTableStyle.RowHeaderWidthChanged += 
                               new EventHandler(MyDelegateRowHeaderChanged);
   }
   private void MyDelegateRowHeaderChanged(object sender, EventArgs e)
   {
      MessageBox.Show("Row header width is changed");
   }

   private void button1_Click(object sender, System.EventArgs e)
   {  
      myDataGridTableStyle.RowHeaderWidth = 30;
   }

   private void button2_Click(object sender, System.EventArgs e)
   {
      MessageBox.Show("Row header width is: " + 
                          myDataGridTableStyle.RowHeaderWidth);
   }
// </Snippet2>
// </Snippet1>
}
