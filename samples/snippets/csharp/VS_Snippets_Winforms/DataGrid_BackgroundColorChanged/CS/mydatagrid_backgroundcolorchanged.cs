// System.Windows.Forms.DataGrid.BackButtonClick
// System.Windows.Forms.DataGrid.BackgroundColorChanged

/* The following program demonstrates the 'BackButtonClick'
   and 'BackgroundColorChanged' events of 
   'System.Windows.Forms.DataGrid' class. It creates a DataGrid 
   onto a form. This Datagrid is linked to two tables, 
   Person (parent) table and Detail (child) table which are related 
   together by a 'DataRelation'. User can look for the details of a 
   person by navigating along. The "Toggle Background Color" button 
   is used to set the 'BackgroundColor' property by toggling 
   the color. The BackButton can be clicked when user is in the 
   child table. When a property is set, an event associated with it 
   is raised which is confirmed by the message shown by the
   alert message box. */

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
      // Create the form.
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
      this.myButton   = new Button();
      this.myDataGrid = new DataGrid();

      this.ClientSize        = new Size(292, 300);
      this.Name              = "DataGridForm";
      this.Text              = "Testing DataGrid Events";
      this.MaximizeBox       = false;
            
      myButton.Location = new Point(85, 15);
      myButton.Size     = new Size(130, 40);
      myButton.Text     = "Toggle Background Color";
      myButton.Click   += new EventHandler(myButton_Click);
      
      myDataGrid.Location        = new Point(20, 70);
      myDataGrid.Size            = new Size(250, 170);
      myDataGrid.CaptionText     = "MS DataGrid Control";
      myDataGrid.BackgroundColor = Color.Yellow;
      myDataGrid.ReadOnly        = true;
      
      // Call the methods that instantiate the Event Handlers.
      CallBackButtonClick();
      CallBackgroundColorChanged();

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

      // Create five persons in the Person Table.
      for(int i = 1; i < 6; i++)
      {
         newRow1 = tPer.NewRow();
         newRow1["SSN"] = i;
         // Add the row to the Person table.
         tPer.Rows.Add(newRow1);
      }
   
      // Give each person a distinct name.
      tPer.Rows[0]["PersonName"] = "Robert";
      tPer.Rows[1]["PersonName"] = "Michael";
      tPer.Rows[2]["PersonName"] = "John";
      tPer.Rows[3]["PersonName"] = "Walter";
      tPer.Rows[4]["PersonName"] = "Simon";

      // For each person, create a detail row in Detail table.
      for(int i = 0; i < 5; i++)
      {
         newRow2 = tDet.NewRow();
         newRow2["SSN"]     = tPer.Rows[i]["SSN"];
         newRow2["Phone"]   = 1000 + i;
         // Add the row to the 'Detail' table.
         tDet.Rows.Add(newRow2);
      }
   }

// <Snippet1>
   // Create an instance of the 'BackButtonClick' EventHandler.
   private void CallBackButtonClick()
   {
      myDataGrid.BackButtonClick += new EventHandler(Grid_BackClick);
   }

   // Raise the event when 'BackButton' on child table is clicked.
   private void Grid_BackClick(object sender, EventArgs e)
   {
      // String variable used to show message.
      string myString = "BackButtonClick event raised, showing parent table";
      // Show information about Back button.
      MessageBox.Show(myString, "Back button information");
   }
// </Snippet1>

// <Snippet2>
   // Create an instance of the 'BackgroundColorChanged' EventHandler.
   private void CallBackgroundColorChanged()
   {
      myDataGrid.BackgroundColorChanged += new EventHandler(Grid_ColChange);
   }

   // Set the 'BackgroundColor' property on click of button.
   private void myButton_Click(object sender, EventArgs e)
   {
      if (myDataGrid.BackgroundColor == Color.Yellow)
      {
         myDataGrid.BackgroundColor = Color.Red;
      }
      else
      {
         myDataGrid.BackgroundColor = Color.Yellow;
      }
   }

   // Raise the event when 'Background' color of DataGrid changes.
   private void Grid_ColChange(object sender, EventArgs e)
   {
      // String variable used to show message.
      string myString = "BackgroundColorChanged event raised, changed to ";
      // Get the background color of DataGrid.
      Color myColor = myDataGrid.BackgroundColor;
      myString += myColor.ToString();
      // Show information about background color setting.
      MessageBox.Show(myString, "Background color information");
   }
// </Snippet2>
}