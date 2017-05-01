/*
   System.Windows.Forms.DataGrid.UnSelect

   The following program demonstrates the 'UnSelect' method of 'DataGrid' class.
   On clicking the "Unselect Row" button, the selected row of
   the Datagrid is unselected.
*/

using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

public class MyForm : Form
{
   private System.ComponentModel.Container components = null;
   private DataGrid myDataGrid;
   private DataSet myDataSet;
   private Button unselectButton;

   public MyForm()
   {
      InitializeComponent();
      SetUp();
   }

   // Clean up any resources being used.
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

   public static void Main()
   {
      Application.Run(new MyForm());
   }

   private void InitializeComponent()
   {
      // Create the form and its controls.
      this.unselectButton    = new Button();
      this.myDataGrid = new DataGrid();

      this.ClientSize        = new Size(292, 300);
      this.Name              = "DataGridForm";
      this.Text              = "Testing DataGrid Events";
      this.MaximizeBox       = false;

      unselectButton.Location   = new Point(70, 15);
      unselectButton.Size       = new Size(130, 40);
      unselectButton.Text       = "Unselect Row";
      unselectButton.Click     += new EventHandler(UnselectRow_Clicked);

      myDataGrid.Location    = new Point(20, 70);
      myDataGrid.Size        = new Size(250, 170);
      myDataGrid.CaptionText = "MS DataGrid Control";
      myDataGrid.ReadOnly    = true;

      this.Controls.Add(unselectButton);
      this.Controls.Add(myDataGrid);
   }

   private void SetUp()
   {
      MakeDataSet();
      myDataGrid.SetDataBinding(myDataSet, "Person");
   }

   // Create a DataSet with two tables and populate it.
   private void MakeDataSet()
   {
      myDataSet = new DataSet("myDataSet");

      DataTable personTable = new DataTable("Person");
      DataTable detailTable = new DataTable("Detail");

      // Create two columns, and add them to the Person table.
      DataColumn personID   = new DataColumn("SSN", typeof(int));
      DataColumn personName = new DataColumn("PersonName");
      personTable.Columns.Add(personID);
      personTable.Columns.Add(personName);

      // Create three columns, and add them to the Detail table.
      DataColumn detailID   = new DataColumn("SSN", typeof(int));
      DataColumn detailPhone   = new DataColumn("Phone");
      detailTable.Columns.Add(detailID);
      detailTable.Columns.Add(detailPhone);

      myDataSet.Tables.Add(personTable);
      myDataSet.Tables.Add(detailTable);

      // For each person create a DataRow variable.
      DataRow newRow1;
      DataRow newRow2;

      // Create a DataRelation, and add it to the DataSet.
      DataRelation myDataRelation = new DataRelation("PersonDetail", personID , detailID);
      myDataSet.Relations.Add(myDataRelation);

      // Create persons in the 'Person' Table.
      for(int i = 1; i < 4; i++)
      {
         newRow1 = personTable.NewRow();
         newRow1["SSN"] = i;
         // Add the row to the 'Person' table.
         personTable.Rows.Add(newRow1);
      }

      // Give each person a distinct name.
      personTable.Rows[0]["PersonName"] = "Robert";
      personTable.Rows[1]["PersonName"] = "Michael";
      personTable.Rows[2]["PersonName"] = "John";

      // For each person, create a detail row in 'Detail' table.
      for(int i = 0; i < 3; i++)
      {
         newRow2 = detailTable.NewRow();
         newRow2["SSN"]     = personTable.Rows[i]["SSN"];
         newRow2["Phone"]   = 1000 + i;
         // Add the row to the 'Detail' table.
         detailTable.Rows.Add(newRow2);
      }
   }

// <Snippet1>

   // On Click of Button "Unselect Row" this event is raised.
   private void UnselectRow_Clicked(object sender, EventArgs e)
   {
      // Unselect the current row from the Datagrid
      myDataGrid.UnSelect(myDataGrid.CurrentRowIndex);
   }
// </Snippet1>
}