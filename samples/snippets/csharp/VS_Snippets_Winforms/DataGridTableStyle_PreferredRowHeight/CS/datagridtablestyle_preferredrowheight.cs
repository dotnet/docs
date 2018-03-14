// System.Windows.Forms.DataGridTableStyle.PreferredRowHeight

/*
   The following example demonstrates 'PreferredRowHeight' property of 'DataGridTableStyle' 
   class. It adds a DataGrid, Button and a TextBox to a form. It changes the 
   'PreferredRowHeight' property by taking the value entered in the textbox.
*/

   using System;
   using System.Data;
   using System.Drawing;
   using System.Windows.Forms;

   public class myDataForm : Form
   {
      private Button myButton;
      private TextBox myTextBox;
      private Label myLabel;
      private DataGrid myDataGrid;
      private DataSet myDataSet;
      private DataGridTableStyle myTableStyle;
            public myDataForm()
            {
               // Required for Windows Form Designer support.
               InitializeComponent();
               // Call SetUp to bind the controls.
               SetUp();
            }
            private void InitializeComponent()
            {
               // Create the form and its controls.
               myButton = new Button();
               myDataGrid = new DataGrid();
               ClientSize = new Size(450, 330);
               myButton.Location = new Point(100,16);
               myButton.Size = new Size(200, 24);
               myButton.Text = "Change Row Height";
               myButton.Click+=new EventHandler(myButton_Click);
               myTextBox=new TextBox();
               myTextBox.Location= new Point(24,16);
               myTextBox.Size=new Size(40,24);
               myDataGrid.Location = new  Point(24, 50);
               myDataGrid.Size = new Size(120,200);
               myDataGrid.CaptionText = "DataGridTableStyle Example";
               myLabel=new Label();
               myLabel.Location=new Point(24,270);
               myLabel.Width=500;
               Controls.Add(myButton);
               Controls.Add(myTextBox);
               Controls.Add(myDataGrid);
               Controls.Add(myLabel);
               Text = "PreferredRowHeight example";
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

            private void myButton_Click(object sender, EventArgs e)
            {

               if(myTextBox.Text.Trim()=="")
               {
                  MessageBox.Show("Enter the height between 18 and 134");
                  return;
               }
               try
               {
// <Snippet1>
                  int myPreferredRowHeight=Convert.ToInt32(myTextBox.Text.Trim());
                  if(myPreferredRowHeight<18 || myPreferredRowHeight >134)
                  {
                     MessageBox.Show("Enter the height between 18 and 134");
                     return;
                  }
                  // Set the 'PreferredRowHeight' property of DataGridTableStyle instance.
                  myTableStyle.PreferredRowHeight=myPreferredRowHeight;
                  // Add the DataGridTableStyle instance to the GridTableStylesCollection. 
                  myDataGrid.TableStyles.Add(myTableStyle);
// </Snippet1>
               }
               catch(Exception ex)
               {
                  MessageBox.Show(ex.Message+"Enter Integer only .");
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
