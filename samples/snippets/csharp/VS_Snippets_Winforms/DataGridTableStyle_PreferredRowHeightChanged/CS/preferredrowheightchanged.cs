   // System.Windows.Forms.DataGridTableStyle.PreferredRowHeightChanged

   /*
     The following example demonstrates 'PreferredRowHeightChanged' Event of 'DataGridTableStyle' class. 
     A DataGrid, Button and TextBox are added to a form. The 'PreferredRowHeight' property of 'DataGridTableStyle' 
     class is set to the value entered by user in the textbox. When user clicks the set button,
     it raises 'PreferredRowHeightChanged' Event which calls user defined  EventHandler function.
   */
   
   using System;
   using System.Data;
   using System.Drawing;
   using System.Windows.Forms;

   public class MyDataForm : Form
   {
      private Button myButton;
      private TextBox myTextBox;
      private Label myLabel;
      private DataGrid myDataGrid;
      private DataSet myDataSet;
      private DataGridTableStyle myTableStyle;

      public MyDataForm()
      {
         InitializeComponent();
         SetUp();
      }

      private void InitializeComponent()
      {
         // Create the form and its controls.
         myButton = new Button();
         myDataGrid = new DataGrid();
         ClientSize = new Size(450, 330);

         myButton.Location = new Point(70, 16);
         myButton.Size = new Size(200, 24);
         myButton.Text = "Set Row Height(in pixels)";
         myButton.Click+=new EventHandler(myButton_Click);

         myTextBox=new TextBox();
         myTextBox.Location= new Point(24,16);
         myTextBox.Size=new Size(40,24);
         myDataGrid.Location = new  Point(24, 50);
         myDataGrid.Size = new Size(120,200);
         myDataGrid.CaptionText = "DataGrid Control";

         myLabel=new Label();
         myLabel.Location=new Point(24,270);
         myLabel.Width=500;

         Controls.Add(myButton);
         Controls.Add(myTextBox);
         Controls.Add(myDataGrid);
         Controls.Add(myLabel);
         Text = "PreferredRowHeightChanged example";
      }

      public static void Main()
      {
         Application.Run(new MyDataForm());
      }

// <Snippet1>
      private void SetUp()
      {
         // Create a DataSet with a table.
         MakeDataSet();
         // Bind the DataGrid to the DataSet.
         myDataGrid.SetDataBinding(myDataSet, "Orders");
         myTableStyle = new DataGridTableStyle();
         // Map 'DataGridTableStyle' instance to the DataTable.
         myTableStyle.MappingName = "Orders";
         // Add EventHandler function for 'PreferredRowHeightChanged' Event.
         myTableStyle.PreferredRowHeightChanged+=new EventHandler(RowHeight_Changed);
      }
      // Called when the PreferredRowHeight property of myTableStyle is modified
      private void RowHeight_Changed(object sender, EventArgs e)
      {
         MessageBox.Show("PreferredRowHeight property is changed");
      }
// </Snippet1>

      private void myButton_Click(object sender, EventArgs e)
      {
         try
         {
            if(myTextBox.Text.Trim()=="")
            {
               MessageBox.Show("Enter the height between 18 and 134");
               return;
            }
         
            int myPreferredRowHeight=Convert.ToInt32(myTextBox.Text.Trim());
            if(myPreferredRowHeight<18 || myPreferredRowHeight >134)
            {
               MessageBox.Show("Enter the height between 18 and 134");
               return;
            }

            // Set the 'PrefferedRowHeight' property of DataGridTableStyle instance.
            myTableStyle.PreferredRowHeight=myPreferredRowHeight;

            // Add the DataGridTableStyle instance to the GridTableStylesCollection. 
            myDataGrid.TableStyles.Add(myTableStyle);
         }
         catch(Exception ex)
         {  
             // Handle raised Exception.
            if(ex!=null)
            {
               MessageBox.Show("Please enter a numeric value between 18 and 134");
               myTextBox.Text=" ";
               bool val=myTextBox.Focus();
            }
         }
         
      }

      // Create a DataSet with a table and populate it.
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
