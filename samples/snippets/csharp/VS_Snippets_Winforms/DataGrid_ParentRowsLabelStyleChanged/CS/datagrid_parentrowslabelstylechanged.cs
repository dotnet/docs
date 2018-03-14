/*
   System.Windows.Forms.DataGrid.ParentRowsLabelStyleChanged
   System.Windows.Forms.DataGrid.ParentRowsVisibleChanged

 The following program demonstrates the 'ParentRowsLabelStyleChanged', and
 'ParentRowsVisibleChanged' events. It creates a DataGrid and
 two DataTables, Person(parent) and Detail(child) which are related 
 together by a DataRelation, are linked to it. The "Toggle LabelStyle" button
 sets the 'ParentRowsLabelStyle' property and the "Toggle Visible" button sets the 
 'ParentRowsVisible' property. When the events is raised a message will be displayed.
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
   private Button toggleStyleButton;
   private Button toggleVisibleButton;

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
      this.toggleStyleButton    = new Button();
      this.toggleVisibleButton   = new Button();
      this.myDataGrid = new DataGrid();

      this.ClientSize        = new Size(292, 300);
      this.Name              = "DataGridForm";
      this.Text              = "Testing DataGrid Events";
      this.MaximizeBox       = false;

      toggleStyleButton.Location   = new Point(70, 15);
      toggleStyleButton.Size       = new Size(130, 40);
      toggleStyleButton.Text       = "Toggle LabelStyle";
      toggleStyleButton.Click     += new EventHandler(ToggleStyle_Clicked);

      toggleVisibleButton.Location  = new Point(70, 250);
      toggleVisibleButton.Size      = new Size(130, 40);
      toggleVisibleButton.Text      = "Toggle Visible";
      toggleVisibleButton.Click    += new EventHandler(ToggleVisible_Clicked);

      myDataGrid.Location    = new Point(20, 70);
      myDataGrid.Size        = new Size(250, 170);
      myDataGrid.CaptionText = "MS DataGrid Control";
      myDataGrid.ReadOnly    = true;

      // Call the methods that instantiate the Event Handlers.
      CallParentRowsLabelStyleChanged();
      CallParentRowsVisibleChanged();

      this.Controls.Add(toggleStyleButton);
      this.Controls.Add(toggleVisibleButton);
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

      DataColumn personID   = new DataColumn("SSN", typeof(int));
      DataColumn personName = new DataColumn("PersonName");
      personTable.Columns.Add(personID);
      personTable.Columns.Add(personName);

      DataColumn detailID   = new DataColumn("SSN", typeof(int));
      DataColumn detailPhone   = new DataColumn("Phone");
      detailTable.Columns.Add(detailID);
      detailTable.Columns.Add(detailPhone);

      // Add the tables to the DataSet.
      myDataSet.Tables.Add(personTable);
      myDataSet.Tables.Add(detailTable);

      DataRow newRow1;
      DataRow newRow2;

      // Create a DataRelation, and add it to the DataSet.
      DataRelation myDataRelation = new DataRelation("PersonDetail", personID , detailID);
      myDataSet.Relations.Add(myDataRelation);

      for(int i = 1; i < 4; i++)
      {
         newRow1 = personTable.NewRow();
         newRow1["SSN"] = i;
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
   private void CallParentRowsLabelStyleChanged()
   {
      myDataGrid.ParentRowsLabelStyleChanged +=
         new EventHandler(DataGridParentRowsLabelStyleChanged_Clicked);
   }

   // Set the 'ParentRowsLabelStyle' property on click of a button.
   private void ToggleStyle_Clicked(object sender, EventArgs e)
   {
      if (myDataGrid.ParentRowsLabelStyle.ToString() == "Both")
         myDataGrid.ParentRowsLabelStyle = DataGridParentRowsLabelStyle.TableName;
      else
         myDataGrid.ParentRowsLabelStyle = DataGridParentRowsLabelStyle.Both;
   }

   // raise the event when 'ParentRowsLabelStyle' property is changed.
   private void DataGridParentRowsLabelStyleChanged_Clicked(object sender, EventArgs e)
   {
      string myMessage = "ParentRowsLabelStyleChanged event raised, LabelStyle is : ";
      // Get the state of 'ParentRowsLabelStyle' property.
      string myLabelStyle = myDataGrid.ParentRowsLabelStyle.ToString();
      myMessage += myLabelStyle;

      MessageBox.Show(myMessage, "ParentRowsLabelStyle information");
   }
// </Snippet1>

// <Snippet2>
   private void CallParentRowsVisibleChanged()
   {
      myDataGrid.ParentRowsVisibleChanged +=
         new EventHandler(DataGridParentRowsVisibleChanged_Clicked);
   }

   // Set the 'ParentRowsVisible' property on click of a button.
   private void ToggleVisible_Clicked(object sender, EventArgs e)
   {
      if (myDataGrid.ParentRowsVisible == true)
         myDataGrid.ParentRowsVisible = false;
      else
         myDataGrid.ParentRowsVisible = true;
   }

   // raise the event when 'ParentRowsVisible' property is changed.
   private void DataGridParentRowsVisibleChanged_Clicked(object sender, EventArgs e)
   {
      string myMessage = "ParentRowsVisibleChanged event raised, Parent row is : ";
      bool visible = myDataGrid.ParentRowsVisible;
      myMessage += (visible ? " " : " NOT ") + "visible";

      MessageBox.Show(myMessage, "ParentRowsVisible information");
   }
// </Snippet2>
}