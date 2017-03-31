// System.Windows.Forms.DataGridColumnStyle.HeaderTextChanged

/*
   The following example demonstrates 'HeaderTextChanged' event of 'DataGridColumnStyle' class.
   It adds a DataGrid and a Button and to a form.  When user clicks on the button, it changes the'HeaderText' property 
   to 'Amount in $'. This raises the 'HeaderTextChanged' event which calls user defined EventHandler function and 
   displays a message on form.
*/

   using System;
   using System.ComponentModel;
   using System.Data;
   using System.Drawing;
   using System.Windows.Forms;

   public class myDataForm :Form
   {
      private Button myButton;
      private Label myLabel;
      private DataGrid myDataGrid;
      private DataSet myDataSet;
      private bool TablesAlreadyAdded;

      public myDataForm()
      {
         InitializeComponent();
          MakeDataSet();
          myDataGrid.SetDataBinding(myDataSet, "Orders");
      }

      private void InitializeComponent()
      {
         Text="HeaderTextChanged Example";
         myButton = new Button();
         myDataGrid = new DataGrid();
         ClientSize = new Size(450, 330);
         myButton.Location = new Point(24, 16);
         myButton.Size = new Size(120, 24);
         myButton.Text = "Currency Format";
         myButton.Click+=new EventHandler(myButton_Click);

         myDataGrid.Location = new  Point(24, 50);
         myDataGrid.Size = new Size(170,200);
         myDataGrid.CaptionText = "DataGridColumnStyle";

         myLabel=new Label();
         myLabel.Location=new Point(24,270);
         myLabel.Width=500;

         Controls.Add(myButton);
         Controls.Add(myDataGrid);
         Controls.Add(myLabel);
      }

      public static void Main()
      {
         Application.Run(new myDataForm());
      }

      private void myButton_Click(object sender, EventArgs e)
      {  
          if(TablesAlreadyAdded)
          {
              return;
          }
         AddCustomDataTableStyle();
      }


// <Snippet1>

      private void AddCustomDataTableStyle()
      {
         DataGridTableStyle myTableStyle = new DataGridTableStyle();
         // Map DataGridTableStyle to a DataTable.
         myTableStyle.MappingName = "Orders";
         // Get CurrencyManager object.
         CurrencyManager myCurrencyManager = (CurrencyManager)BindingContext[myDataSet,"Orders"];
         // Use the CurrencyManager to get the PropertyDescriptor for the column.
         PropertyDescriptor myPropertyDescriptor = myCurrencyManager.GetItemProperties()["Amount"];
         // Change the HeaderText.
         DataGridColumnStyle myColumnStyle = new DataGridTextBoxColumn(myPropertyDescriptor,"c",true);
         // Attach a event handler function with the 'HeaderTextChanged' event.
         myColumnStyle.HeaderTextChanged+=new EventHandler(MyHeaderText_Changed);
         myColumnStyle.Width=130;
         myColumnStyle.HeaderText="Amount in $";
         myTableStyle.GridColumnStyles.Add(myColumnStyle);
         myDataGrid.TableStyles.Add(myTableStyle);
         TablesAlreadyAdded=true;
      }

      private void MyHeaderText_Changed(object sender,EventArgs e)
      {
         myLabel.Text="Header Descriptor Property of DataGridColumnStyle has changed";
      }
// </Snippet1>


      private void MakeDataSet()
      {
         // Create a DataSet.
         myDataSet = new DataSet("myDataSet");
         DataTable myTable = new DataTable("Orders");
         DataColumn myColumn =  new DataColumn("Amount",typeof(decimal));
         myTable.Columns.Add(myColumn);
         myDataSet.Tables.Add(myTable);
         DataRow newRow;
            for(int j = 1; j < 15; j++)
            {
            newRow = myTable.NewRow();
            newRow["Amount"] = j * 10 + j * .1;
            myTable.Rows.Add(newRow);
       }
      }
   }
