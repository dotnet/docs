// System.BindingManagerBase.RemoveAt

/* This program demonstrates the 'RemoveAt' method of 'BindingManagerBase' class.
 * It creates a 'DataGrid' control and a 'button' control. If Remove button is pressed it deletes 
 * the selected row from the 'DataGrid' control.
 */
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace WindowsApplication1
{
public class Form1 :  Form
   {
      private  Button button1;
      private  DataGrid dataGrid1;
      private DataTable myDataTable;
      public Form1()
      {
         InitializeComponent();
         MakeDataTableAndDisplay();
      }
      private void InitializeComponent()
      {
         dataGrid1 = new  DataGrid();
         button1 = new  Button();
         ((System.ComponentModel.ISupportInitialize)(dataGrid1)).BeginInit();
         SuspendLayout();
         // Create the 'DataGrid'.
         dataGrid1.DataMember = "";
         dataGrid1.Location = new  Point(32, 32);
         dataGrid1.Name = "dataGrid1";
         dataGrid1.Size = new  Size(208, 80);
         dataGrid1.TabIndex = 3;

         button1.Location = new  Point(280, 40);
         button1.Name = "button1";
         button1.Size = new  Size(96, 23);
         button1.TabIndex = 1;
         button1.Text = "Remove Row";
         button1.Click += new System.EventHandler(button1_Click);
         
         ClientSize = new  Size(400, 273);
         Controls.AddRange(new  Control[]{dataGrid1,button1});
         Name = "Form1";
         Text = "Form1";
         ((System.ComponentModel.ISupportInitialize)(dataGrid1)).EndInit();
         ResumeLayout(false);

      }
      static void Main() 
      {
         Application.Run(new Form1());
      }

// <Snippet1>
      private void button1_Click(object sender, System.EventArgs e)
      {
         try
         {
            // Get the 'BindingManagerBase' object.
            BindingManagerBase myBindingManagerBase=BindingContext[myDataTable];
            // Remove the selected row from the grid.
            myBindingManagerBase.RemoveAt(myBindingManagerBase.Position);
         }
         catch(Exception ex)
         {
            MessageBox.Show(ex.Source);
            MessageBox.Show(ex.Message);
         }
      }
// </Snippet1>

      private void MakeDataTableAndDisplay()
      {
         // Create new DataTable.
         myDataTable = new DataTable("MyDataTable");
   
         DataColumn myDataColumn;
         DataRow myDataRow;

         // Create new 'DataColumn'.
         myDataColumn = new DataColumn();
         // Set the 'DataType'.
         myDataColumn.DataType = System.Type.GetType("System.Int32");
         // Set the 'ColumnName'.
         myDataColumn.ColumnName = "id";
         // Add the column to the 'DataTable'.    
         myDataTable.Columns.Add(myDataColumn);

         // Create second column.
         myDataColumn = new DataColumn();
         myDataColumn.DataType = Type.GetType("System.String");
         myDataColumn.ColumnName = "item";
         myDataTable.Columns.Add(myDataColumn);

         // Create new DataRow objects and add to DataTable.    
         for(int i = 0; i < 10; i++)
         {
            myDataRow = myDataTable.NewRow();
            myDataRow["id"] = i;
            myDataRow["item"] = "item " + i;
            myDataTable.Rows.Add(myDataRow);
         }
         // Attach the 'myDataTable' to the DataGrid.
         dataGrid1.DataSource = myDataTable;
      }
   }
}

