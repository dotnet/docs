// System.Windows.Forms.DataGridTableStyle.ResetHeaderFont

/* The following example demonstrates 'ResetHeaderFont' method of 'DataGridTableStyle' class.
   A DataGrid and two Button's are added to a form. When user clicks 'Set Header Font' button the Header Font of  
   DataGrid is changed. The HeaderFont is reset to its default value when the 'Reset Header Font' button is clicked.
. */
   using System;
   using System.Data;
   using System.Drawing;
   using System.Windows.Forms;

   public class myDataForm : Form
   {
      private Button mySetButton;
      private Button myResetButton;
      private Label myLabel;
      private DataGrid myDataGrid;
      private DataSet myDataSet;
      private DataGridTableStyle myTableStyle;
      public myDataForm()
      {
         InitializeComponent();
         SetUp();
      }
      private void InitializeComponent()
      {
         // Create the form and its controls.
         mySetButton = new Button();
         myDataGrid = new DataGrid();
         ClientSize = new Size(450, 330);
         mySetButton.Location = new Point(24, 16);
         mySetButton.Size = new Size(220, 24);
         mySetButton.Text = "Set Header Font To 'Impact'";
         mySetButton.Click+=new EventHandler(MySetButton_Click);
         myResetButton=new Button();
         myResetButton.Location= new Point(250,16);
         myResetButton.Size=new Size(130,24);
         myResetButton.Text = "Reset Header Font";
         myResetButton.Click+=new EventHandler(MyResetButton_Click);
         myDataGrid.Location = new  Point(24, 50);
         myDataGrid.Size = new Size(120,200);
         myDataGrid.CaptionText = "DataGrid Control";
         myLabel=new Label();
         myLabel.Location=new Point(24,270);
         myLabel.Width=500;
         Controls.Add(mySetButton);
         Controls.Add(myResetButton);
         Controls.Add(myDataGrid);
         Controls.Add(myLabel);
         Text = "ResetHeaderFont example";
      }
      public static void Main()
      {
         Application.Run(new myDataForm());
      }
      private void SetUp()
      {
         // Create a DataSet with a table.
         MakeDataSet();
         // Bind the DataGrid to the DataSet.
         myDataGrid.SetDataBinding(myDataSet, "Orders");
         // Create the DataGridTableStyle.
         myTableStyle = new DataGridTableStyle();
         // Map DataGridTableStyle to a DataTable.
         myTableStyle.MappingName = "Orders";
      } 
// <Snippet1>
      private void MySetButton_Click(object sender, EventArgs e)
      {
         // Set the 'HeaderFont' property of the DataGridTableStyle instance.
         myTableStyle.HeaderFont=new Font("Impact",10);
         // Add the DataGridTableStyle instance to the GridTableStylesCollection. 
         myDataGrid.TableStyles.Add(myTableStyle);
      }
      private void MyResetButton_Click(object sender, EventArgs e)
      {
         // Reset the Header Font to its default value.
         myTableStyle.ResetHeaderFont();
      }
// </Snippet1>
      private void MakeDataSet()
      {
         // Create a DataSet.
         myDataSet = new DataSet("myDataSet");
         DataTable myTable = new DataTable("Orders");
         DataColumn myColumn =  new DataColumn("Amount",typeof(decimal));
         myTable.Columns.Add(myColumn); 
         // Add the table to the DataSet.
         myDataSet.Tables.Add(myTable);
         DataRow newRow;
         for(int j = 1; j < 15; j++)
         {
            newRow = myTable.NewRow();
            newRow["Amount"] = j * 10;
            // Add the row to the Orders table.
            myTable.Rows.Add(newRow);
         }
      }
   }
