// System.Windows.Forms.DataGridTextBox.IsInEditOrNavigateMode

/* The following program demonstrates the 'IsInEditOrNavigateMode'
   property of the 'System.Windows.Forms.DataGridTextBox' class.
   It creates a form with 'DataGrid' that has a 'DataTable'.
   A DataGridTextBox is shown which is bound to the DataSet that 
   contains the 'DataTable'. A button is used to display the state of
   'IsInEditOrNavigateMode' property. Editing of the 
   'DataGridTextBox' changes the value of 'IsInEditOrNavigateMode'
   from true to false. */

using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

public class MyDataGridTextBox : Form
{
   private System.ComponentModel.Container components = null;
   private DataGridTableStyle myDataGridTableStyle;
   private DataGridTextBoxColumn myTextBoxColumn;
   private DataGrid myDataGrid;
   private DataSet myDataSet;
   private Button myButton;
   private DataGridTextBox myDataGridTextBox;

   public MyDataGridTextBox()
   {
      // Create the form.
      InitializeComponent();

      // Bind the controls.
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
      Application.Run(new MyDataGridTextBox());
   }

   private void InitializeComponent()
   {
      // Create the form and its controls.
      this.myDataGridTableStyle = new DataGridTableStyle();
      this.myDataGridTextBox    = new DataGridTextBox();
      this.myTextBoxColumn      = new DataGridTextBoxColumn();
      this.myDataGrid           = new DataGrid();
      this.myButton             = new Button();

      this.ClientSize        = new Size(292, 300);
      this.Name              = "DataGridForm";
      this.Text              = "Testing DataGridTextBox";
      this.MaximizeBox       = false;

      myDataGridTextBox.Location  = new Point(20, 5);
      myDataGridTextBox.Size      = new Size(100, 65);

      myDataGrid.Location    = new Point(20, 70);
      myDataGrid.Size        = new Size(250, 170);
      myDataGrid.CaptionText = "MS DataGrid Control";

      myButton.Location  = new Point(71, 250);
      myButton.Size      = new Size(150, 40);
      myButton.Text      = " IsInEditOrNavigateMode";
      myButton.Click    += new EventHandler(Button_ClickEvent);

      this.Controls.Add(myDataGrid);
      this.Controls.Add(myDataGridTextBox);
      this.Controls.Add(myButton);

      // Create 'DataTableStyle' for the DataGrid.
      AddCustomDataTableStyle();

      // Set the properties of DataGridTextBox.
      myDataGridTextBox.ScrollBars = ScrollBars.Vertical;
      myDataGridTextBox.ForeColor  = Color.Red;
      myDataGridTextBox.Multiline  = true;
      myDataGridTextBox.WordWrap   = true;
   }

   private void AddCustomDataTableStyle()
   {
      // Map the DataGridTableStyle to the Table name.
      myDataGridTableStyle.MappingName = "Person";
      // Set other properties.
      myDataGridTableStyle.AlternatingBackColor = Color.LightGray;

      DataGridColumnStyle TextCol = new DataGridTextBoxColumn();

      // Map the DataGridColumnStyle to the Column name of the Table.
      TextCol.MappingName = "PersonName";
      TextCol.HeaderText  = "Person Name";
      TextCol.Width       = 100;
      
      myDataGridTableStyle.GridColumnStyles.Add(TextCol);
      myDataGridTableStyle.GridLineColor = Color.Aquamarine;

      // Add the DataGridTableStyle to GridTableStylesCollection.
      myDataGrid.TableStyles.Add(myDataGridTableStyle);
   }

   // Create a DataSet with a table and populate it.
   private void MakeDataSet()
   {
      myDataSet = new DataSet("myDataSet");

      DataTable tPer = new DataTable("Person");

      DataColumn cPerName = new DataColumn("PersonName");
      tPer.Columns.Add(cPerName);

      myDataSet.Tables.Add(tPer);

      DataRow newRow1;

      for(int i = 1; i < 6; i++)
      {
         newRow1 = tPer.NewRow();
         tPer.Rows.Add(newRow1);
      }
   
      tPer.Rows[0]["PersonName"] = "Robert";
      tPer.Rows[1]["PersonName"] = "Michael";
      tPer.Rows[2]["PersonName"] = "John";
      tPer.Rows[3]["PersonName"] = "Walter";
      tPer.Rows[4]["PersonName"] = "Simon";

      // Bind the 'DataSet' to the 'DataGrid'.
      myDataGrid.SetDataBinding(myDataSet, "Person");
      myDataGridTextBox.DataBindings.Add("Text",myDataSet,"Person.PersonName");
      // Set the DataGrid to the DataGridTextBox.
      myDataGridTextBox.SetDataGrid(myDataGrid);
   }

// <Snippet1>
   // Handle event to show the state of 'IsInEditOrNavigateMode'.
   private void Button_ClickEvent(object sender, EventArgs e)
   {

      if (myDataGridTextBox.IsInEditOrNavigateMode)
      {
         // DataGridTextBox has not been edited.
         MessageBox.Show("Editing of DataGridTextBox not begun, IsInEditOrNavigateMode = True");
      }
      else
      {
         // DataGridTextBox has been edited.
         MessageBox.Show("Editing of DataGridTextBox begun, IsInEditOrNavigateMode = False");
      }
   }
// </Snippet1>
}