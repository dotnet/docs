/*
   System.Windows.Forms.DataGrid.ShowParentDetailsButtonClick

   The following program demonstrates the 'ShowParentDetailsButtonClick'
   event of 'DataGrid' class. On the click of "ParentDetailsButton" button in the
   Datagrid, a message is displayed.
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
      this.myDataGrid = new DataGrid();

      this.ClientSize        = new Size(292, 300);
      this.Name              = "DataGridForm";
      this.Text              = "Testing DataGrid Events";
      this.MaximizeBox       = false;


      myDataGrid.Location    = new Point(20, 70);
      myDataGrid.Size        = new Size(250, 170);
      myDataGrid.CaptionText = "MS DataGrid Control";
      myDataGrid.ReadOnly    = false;

      // Call the method that instantiate the Event Handlers.
      CallShowParentDetailsButtonClick();

      this.Controls.Add(myDataGrid);
   }

   private void SetUp()
   {
      // Create a DataSet with two tables and one relation.
      MakeDataSet();
      // Bind the DataGrid to the DataSet.
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

      // Add the tables to the DataSet.
      myDataSet.Tables.Add(personTable);
      myDataSet.Tables.Add(detailTable);

      // For each person create a DataRow variable.
      DataRow newRow1;
      DataRow newRow2;

      // Create a DataRelation, and add it to the DataSet.
      DataRelation myDataRelation = new DataRelation("PersonDetail", personID , detailID);
      myDataSet.Relations.Add(myDataRelation);

      // Create persons in the 'Person' Table.
      for(int i = 1; i < 5; i++)
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
      personTable.Rows[3]["PersonName"] = "Walter";

      // For each person, create a detail row in 'Detail' table.
      for(int i = 0; i < 4; i++)
      {
         newRow2 = detailTable.NewRow();
         newRow2["SSN"]     = personTable.Rows[i]["SSN"];
         newRow2["Phone"]   = 1000 + i;
         // Add the row to the 'Detail' table.
         detailTable.Rows.Add(newRow2);
      }
   }

// <Snippet1>
   private void CallShowParentDetailsButtonClick()
   {
      myDataGrid.ShowParentDetailsButtonClick +=
         new EventHandler(DataGridShowParentDetailsButtonClick_Clicked);
   }

   // raise the event when ParentDetailsButton is clicked.
   private void DataGridShowParentDetailsButtonClick_Clicked(object sender, EventArgs e)
   {
      string myMessage = "ShowParentDetailsButtonClick event raised";

      // Show the message when event is raised.
      MessageBox.Show(myMessage, "ShowParentDetailsButtonClick information");
   }
// </Snippet1>
}