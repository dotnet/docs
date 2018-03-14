// System.Windows.Forms.DataGrid.CaptionVisibleChanged
// System.Windows.Forms.DataGrid.CurrentCellChanged
// System.Windows.Forms.DataGrid.Scroll

/* The following program demonstrates the 'CaptionVisibleChanged', 
   'CurrentCellChanged' and 'Scroll' events of 
   'System.Windows.Forms.DataGrid' class. It creates a DataGrid 
   onto a form. This Datagrid is linked to two tables, 
   Person (parent) table and Detail (child) table which are related 
   together by a 'DataRelation'. User can look for the details of a 
   person by navigating along. The "Toggle Caption" button is used 
   to set the 'CaptionVisible' property by toggling. When a property 
   is set, an event associated with it is raised which is confirmed 
   by the message shown by the alert message box. */

using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

public class MyDataGrid : Form
{
   private System.ComponentModel.Container components = null;
   private DataGrid myDataGrid;
   private DataSet myDataSet;
   private Button myButton;

   public MyDataGrid()
   {
      // Create form.
      InitializeComponent();

      // Call SetUp to bind the controls.
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

   // Main entry point for the application.
   static void Main()
   {
      Application.Run(new MyDataGrid());
   }

   private void InitializeComponent()
   {
      // Create the form and its controls.
      this.myButton    = new Button();
      this.myDataGrid = new DataGrid();

      this.ClientSize        = new Size(292, 300);
      this.Name              = "DataGridForm";
      this.Text              = "Testing DataGrid Events";
      this.MaximizeBox       = false;
            
      myButton.Location = new Point(85, 15);
      myButton.Size     = new Size(130, 40);
      myButton.Text     = "Toggle Caption";
      myButton.Click   += new EventHandler(myButton_Click);
      
      myDataGrid.Location    = new Point(20, 70);
      myDataGrid.Size        = new Size(250, 170);
      myDataGrid.CaptionText = "MS DataGrid Control";
      myDataGrid.ReadOnly    = true;
      
      // Call the methods that instantiate the Event Handlers.
      CallCaptionVisibleChanged();
      CallCurrentCellChanged();
      CallScroll();

      this.Controls.Add(myButton);
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
      // Create a DataSet.
      myDataSet = new DataSet("myDataSet");

      // Create a DataTable.
      DataTable tPer = new DataTable("Person");
      DataTable tDet = new DataTable("Detail");

      // Create two columns, and add them to the Person table.
      DataColumn cPerID   = new DataColumn("SSN", typeof(int));
      DataColumn cPerName = new DataColumn("PersonName");
      tPer.Columns.Add(cPerID);
      tPer.Columns.Add(cPerName);

      // Create three columns, and add them to the Detail table.
      DataColumn cDetID   = new DataColumn("SSN", typeof(int));
      DataColumn cDetPh   = new DataColumn("Phone");
      tDet.Columns.Add(cDetID);
      tDet.Columns.Add(cDetPh);

      // Add the tables to the DataSet.
      myDataSet.Tables.Add(tPer);
      myDataSet.Tables.Add(tDet);

      // For each person create a DataRow variable.
      DataRow newRow1;
      DataRow newRow2;

      // Create a DataRelation, and add it to the DataSet.
      DataRelation dr = new DataRelation("PersonDetail", cPerID , cDetID);
      myDataSet.Relations.Add(dr);

      // Create nine persons in the 'Person' Table.
      for(int i = 1; i < 10; i++)
      {
         newRow1 = tPer.NewRow();
         newRow1["SSN"] = i;
         // Add the row to the 'Person' table.
         tPer.Rows.Add(newRow1);
      }
   
      // Give each person a distinct name.
      tPer.Rows[0]["PersonName"] = "Robert";
      tPer.Rows[1]["PersonName"] = "Michael";
      tPer.Rows[2]["PersonName"] = "John";
      tPer.Rows[3]["PersonName"] = "Walter";
      tPer.Rows[4]["PersonName"] = "Simon";
      tPer.Rows[5]["PersonName"] = "Wilson";
      tPer.Rows[6]["PersonName"] = "Donald";
      tPer.Rows[7]["PersonName"] = "Bill";
      tPer.Rows[8]["PersonName"] = "James";

      // For each person, create a detail row in 'Detail' table.
      for(int i = 0; i < 9; i++)
      {
         newRow2 = tDet.NewRow();
         newRow2["SSN"]     = tPer.Rows[i]["SSN"];
         newRow2["Phone"]   = 1000 + i;
         // Add the row to the 'Detail' table.
         tDet.Rows.Add(newRow2);
      }
   }

// <Snippet1>
   // Create an instance of the 'CaptionVisibleChanged' EventHandler.
   private void CallCaptionVisibleChanged()
   {
      myDataGrid.CaptionVisibleChanged += 
                              new EventHandler(Grid_CaptionVisibleChanged);
   }

   // Set the 'CaptionVisible' property on click of a button.
   private void myButton_Click(object sender, EventArgs e)
   {
      if (myDataGrid.CaptionVisible == true)
         myDataGrid.CaptionVisible = false;
      else
         myDataGrid.CaptionVisible = true;
   }
   
   // Raise the event when 'CaptionVisible' property is changed.
   private void Grid_CaptionVisibleChanged(object sender, EventArgs e)
   {
      // String variable used to show message.
      string myString = "CaptionVisibleChanged event raised, caption is";
      // Get the state of 'CaptionVisible' property.
      bool myBool = myDataGrid.CaptionVisible;
      // Create appropriate alert message.
      myString += (myBool ? " " : " not ") + "visible";
      // Show information about caption of DataGrid. 
      MessageBox.Show(myString, "Caption information");
   }
// </Snippet1>

// <Snippet2>
   // Create an instance of the 'CurrentCellChanged' EventHandler.
   private void CallCurrentCellChanged()
   {
      myDataGrid.CurrentCellChanged += new EventHandler(Grid_CurCellChange);
   }

   // Raise the event when focus on DataGrid cell changes.
   private void Grid_CurCellChange(object sender, EventArgs e)
   {
      // String variable used to show message.
      string myString = "CurrentCellChanged event raised, cell focus is at ";
      // Get the co-ordinates of the focussed cell.
      string myPoint  = myDataGrid.CurrentCell.ColumnNumber + "," +
                     myDataGrid.CurrentCell.RowNumber;
      // Create the alert message.
      myString = myString + "(" + myPoint + ")";
      // Show Co-ordinates when CurrentCellChanged event is raised.
      MessageBox.Show(myString, "Current cell co-ordinates");
   }
// </Snippet2>

// <Snippet3>
   // Create an instance of the 'Scroll' EventHandler.
   private void CallScroll()
   {
      myDataGrid.Scroll += new EventHandler(Grid_Scroll);
   }

   // Raise the event when DataGrid is scrolled.
   private void Grid_Scroll(object sender, EventArgs e)
   {
      // String variable used to show message.
      string myString = "Scroll event raised, DataGrid is scrolled";
      // Show the message when scrolling is done.
      MessageBox.Show(myString, "Scroll information");
   }
// </Snippet3> 
}