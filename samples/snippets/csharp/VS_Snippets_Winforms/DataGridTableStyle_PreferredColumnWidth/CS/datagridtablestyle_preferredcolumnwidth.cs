// System.Windows.Forms.DataGridTableStyle.PreferredColumnWidth
/*
The following example demonstrates the property 'PreferredColumnWidth'
of 'DataGridTableStyle' class.

It creates a 'Button' a 'TextBox' and 'DataGrid', attaches an employee table to
DataGrid and applies 'DataGridTableStyle' to it.
Event Handler has been attached to handle 'PreferredColumnWidthChanged' event.
*/

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace DataGridTableStyle_PreferredColumnWidthChanged
{
   public class Form1 : System.Windows.Forms.Form
   {
      private System.ComponentModel.Container components = null;

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
         this.myButton = new System.Windows.Forms.Button();
         this.myLabel = new System.Windows.Forms.Label();
         this.myColWidth = new System.Windows.Forms.TextBox();
         this.SuspendLayout();
         // 
         // myButton
         // 
         this.myButton.Location = new System.Drawing.Point(136, 304);
         this.myButton.Name = "myButton";
         this.myButton.TabIndex = 1;
         this.myButton.Text = "Apply";
         this.myButton.Click += new System.EventHandler(this.myButton_Click);
         // 
         // myLabel
         // 
         this.myLabel.Location = new System.Drawing.Point(96, 264);
         this.myLabel.Name = "myLabel";
         this.myLabel.Size = new System.Drawing.Size(80, 16);
         this.myLabel.TabIndex = 3;
         this.myLabel.Text = "Column width: ";
         // 
         // myColWidth
         // 
         this.myColWidth.Location = new System.Drawing.Point(184, 264);
         this.myColWidth.Name = "myColWidth";
         this.myColWidth.TabIndex = 2;
         this.myColWidth.Text = "";
         // 
         // Form1
         // 
         this.ClientSize = new System.Drawing.Size(400, 397);
         this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                    this.myLabel,
                                    this.myColWidth,
                                    this.myButton});
         this.Name = "Form1";
         this.Text = "Form1";
         this.Load += new System.EventHandler(this.Form1_Load);
         this.ResumeLayout(false);

      }
      #endregion

      [STAThread]
      static void Main() 
      {
         Application.Run(new Form1());
      }
      public Form1()
      {
         InitializeComponent();
      }

      private System.Windows.Forms.Button myButton;
      private System.Windows.Forms.TextBox myColWidth;
      private System.Windows.Forms.Label myLabel;
      private System.Windows.Forms.DataGrid myDataGrid = new DataGrid();
      private System.Windows.Forms.DataGridTableStyle myDataGridTableStyle =
               new DataGridTableStyle();
// <Snippet1>
      private void CreateAndBindDataSet(DataGrid myDataGrid)
      {
         DataSet myDataSet = new DataSet("myDataSet");
         DataTable myEmpTable = new DataTable("Employee");
         // Create two columns, and add them to employee table.
         DataColumn myEmpID = new DataColumn("EmpID", typeof(int));
         DataColumn myEmpName = new DataColumn("EmpName");
         myEmpTable.Columns.Add(myEmpID);
         myEmpTable.Columns.Add(myEmpName);
         // Add table to DataSet.
         myDataSet.Tables.Add(myEmpTable);
         // Populate table.
         DataRow newRow1;
         // Create employee records in employee Table.
         for(int i = 1; i < 6; i++)
         {
            newRow1 = myEmpTable.NewRow();
            newRow1["EmpID"] = i;
            // Add row to Employee table.
            myEmpTable.Rows.Add(newRow1);
         }
         // Give each employee a distinct name.
         myEmpTable.Rows[0]["EmpName"] = "Alpha";
         myEmpTable.Rows[1]["EmpName"] = "Beta";
         myEmpTable.Rows[2]["EmpName"] = "Omega";
         myEmpTable.Rows[3]["EmpName"] = "Gamma";
         myEmpTable.Rows[4]["EmpName"] = "Delta";
         // Bind DataGrid to DataSet.
         myDataGrid.SetDataBinding(myDataSet, "Employee");
      }

      private void Form1_Load(object sender, System.EventArgs e)
      {
         // Set and Display myDataGrid.
         myDataGrid.DataMember = "";
         myDataGrid.Location = new System.Drawing.Point(72, 32);
         myDataGrid.Name = "myDataGrid";
         myDataGrid.Size = new System.Drawing.Size(240, 200);
         myDataGrid.TabIndex = 4;
         // Add it to controls.
         Controls.Add(myDataGrid);
         CreateAndBindDataSet(myDataGrid);
         myDataGridTableStyle.MappingName = "Employee";
         // Set other properties.
         myDataGridTableStyle.AlternatingBackColor = Color.LightGray;
         // Add DataGridTableStyle instances to GridTableStylesCollection.
         myDataGridTableStyle.PreferredColumnWidth = 100;
         myColWidth.Text = "";
         myDataGrid.TableStyles.Add(myDataGridTableStyle);
         myDataGridTableStyle.PreferredColumnWidthChanged +=
               new EventHandler(MyDelegatePreferredColWidthChanged);
      }

      private void MyDelegatePreferredColWidthChanged(object sender, EventArgs e)
      {
         MessageBox.Show("Preferred Column width has changed");
      }

      private void myButton_Click(object sender, System.EventArgs e)
      {
         try
         {
            if( myColWidth.Text != "" )
            {
               int newwidth = myDataGridTableStyle.PreferredColumnWidth = 
                  int.Parse(myColWidth.Text);
               // Dispose datagrid and datagridtablestyle and then create.
               myDataGrid.Dispose();
               myDataGridTableStyle.Dispose();
               myDataGrid = new DataGrid();
               myDataGridTableStyle = new DataGridTableStyle();
               myDataGrid.DataMember = "";
               myDataGrid.Location = new System.Drawing.Point(72, 32);
               myDataGrid.Name = "myDataGrid";
               myDataGrid.Size = new System.Drawing.Size(240, 200);
               myDataGrid.TabIndex = 4;
               Controls.Add(myDataGrid);
               CreateAndBindDataSet(myDataGrid);
               myDataGridTableStyle.MappingName = "Employee";
               // Set other properties.
               myDataGridTableStyle.AlternatingBackColor = Color.LightGray;
               // Add DataGridTableStyle instances to GridTableStylesCollection.
               myDataGridTableStyle.PreferredColumnWidth = newwidth;
               myColWidth.Text = "";
               myDataGrid.TableStyles.Add(myDataGridTableStyle);
               myDataGridTableStyle.PreferredColumnWidthChanged += 
                  new EventHandler(MyDelegatePreferredColWidthChanged);
            }
            else
            {
               MessageBox.Show("Please enter a number");
            }
         }
         catch(Exception ex)
         {
            MessageBox.Show(ex.Message);
         }
      }
// </Snippet1>
   }
}
