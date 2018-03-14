// System.Windows.Forms.DataGridTableStyle.RowHeadersVisibleChanged
// System.Windows.Forms.DataGridTableStyle.RowHeadersVisible

/* The following program demonstrates the 'RowHeadersVisible' 
   method and 'RowHeadersVisibleChanged' event of 
   'System.Windows.Forms.DataGridTableStyle' class. It makes the 
   row headers visible or invisible on button click */

using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

public class MyDataGridTableStyle_RowHeadersVisibleChanged : Form
{
   private System.ComponentModel.Container components = null;
   private DataGridTableStyle myDataGridTableStyle;
   private DataGrid myDataGrid;
   private DataSet myDataSet;
   private Button myButton;
   
   public MyDataGridTableStyle_RowHeadersVisibleChanged()
   {
      // Create the form.
      InitializeComponent();

      // Bind the controls to the DataGrid.
      MakeDataSet();
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
      Application.Run(new MyDataGridTableStyle_RowHeadersVisibleChanged());
   }

   private void InitializeComponent()
   {
      // Create the form and its controls.
      this.myDataGridTableStyle = new DataGridTableStyle();
      this.myDataGrid           = new DataGrid();
      this.myButton             = new Button();

      this.ClientSize        = new Size(292, 300);
      this.Name              = "DataGridForm";
      this.Text              = "Testing DataGridTableStyle";
      this.MaximizeBox       = false;

      myButton.Location = new Point(80, 15);
      myButton.Size     = new Size(130, 40);
      myButton.Text     = "Toggle Row Headers";
      myButton.Click   += new EventHandler(myButton_Click);

      myDataGrid.Location    = new Point(20, 70);
      myDataGrid.Size        = new Size(250, 170);
      myDataGrid.CaptionText = "MS DataGrid Control";
      myDataGrid.ReadOnly    = false;

      this.Controls.Add(myButton);
      this.Controls.Add(myDataGrid);

      this.Load += new System.EventHandler(this.DataGridTableStyle_RowHeadersVisible_Load);
   }

   private void MakeDataSet()
   {
      // Create a DataSet.
      myDataSet = new DataSet("myDataSet");

      // Create a DataTable.
      DataTable tPer = new DataTable("Person");

      // Create two columns, and add them to the Person table.
      DataColumn cPerID   = new DataColumn("SSN", typeof(int));
      DataColumn cPerName = new DataColumn("PersonName");
      tPer.Columns.Add(cPerID);
      tPer.Columns.Add(cPerName);

      // Add the tables to the DataSet.
      myDataSet.Tables.Add(tPer);

      // For each person create a DataRow variable.
      DataRow newRow1;

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

      myDataGrid.SetDataBinding(myDataSet, "Person");
   }

   private void DataGridTableStyle_RowHeadersVisible_Load(object sender, EventArgs e)
   {
      myDataGridTableStyle.MappingName = "Person";
      // Set other properties.
      myDataGridTableStyle.AlternatingBackColor = Color.LightGray;

      // Create DataGridColumnStyle 
      DataGridColumnStyle IdCol = new DataGridTextBoxColumn();
      DataGridColumnStyle TextCol = new DataGridTextBoxColumn();

      // Set MappingName to DataColumn name in DataTable.
      IdCol.MappingName = "SSN";
       
      // Set the HeaderText and Width properties.
      IdCol.HeaderText = "SSN";
      IdCol.Width = 50;
      
      // Add a second column style.
      TextCol.MappingName = "PersonName";
      TextCol.HeaderText  = "Person Name";
      TextCol.Width       = 150;
      
      // Add the GridColumnStyles to DataGridTableStyle.
      myDataGridTableStyle.GridColumnStyles.Add(IdCol);
      myDataGridTableStyle.GridColumnStyles.Add(TextCol);

      // Add the DataGridTableStyle to GridTableStylesCollection.
      myDataGrid.TableStyles.Add(myDataGridTableStyle);
      myDataGridTableStyle.GridLineColor = Color.Aquamarine;      
      AttachRowHeaderVisibleChanged();
   }
// <Snippet1>
// <Snippet2>
   // Instantiate the EventHandler.
   public void AttachRowHeaderVisibleChanged()
   {
      myDataGridTableStyle.RowHeadersVisibleChanged += new EventHandler (MyDelegateRowHeadersVisibleChanged);
   }

   // raise the event when RowHeadersVisible property is changed.
   private void MyDelegateRowHeadersVisibleChanged(object sender, EventArgs e)
   {
      string myString = "'RowHeadersVisibleChanged' event raised, Row Headers are";
      if (myDataGridTableStyle.RowHeadersVisible)
         myString += " visible";
      else
         myString += " not visible";

      MessageBox.Show(myString, "RowHeader information");
   }

   // raise the event when a button is clicked.
   private void myButton_Click(object sender, System.EventArgs e)
   {
      if (myDataGridTableStyle.RowHeadersVisible)
         myDataGridTableStyle.RowHeadersVisible = false;
      else
         myDataGridTableStyle.RowHeadersVisible = true;
   }
// </Snippet2>
// </Snippet1>
}