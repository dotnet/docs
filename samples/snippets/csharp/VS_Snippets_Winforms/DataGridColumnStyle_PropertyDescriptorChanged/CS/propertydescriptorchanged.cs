   // System.Windows.Forms.DataGridColumnStyle.PropertyDescriptorChanged

   /* The following example demonstrates 'PropertyDescriptorChanged' Event of 'DataGridColumnStyle' class.
     A  DataGrid and Button are added to a form. When user clicks on the button, the 'PropertyDescriptor'Format of 
     'DataGridColumnStyle' is changed  to 'Currency' format . This raises 'PropertyDescriptorChanged' event,
     which then calls user defined EventHandler function.
   */

   using System;
   using System.ComponentModel;
   using System.Data;
   using System.Drawing;
   using System.Windows.Forms;

   public class myDataForm : Form
   {
      private Button myButton;
      private Label myLabel;
      private DataGrid myDataGrid;
      private DataSet myDataSet;
      private bool TablesAlreadyAdded;
      public myDataForm()
      {
         InitializeComponent();
         SetUp();
      }
      private void InitializeComponent()
      {
         Text="PropertyDescriptor Example";
         myButton = new Button();
         myDataGrid = new DataGrid();
         ClientSize = new Size(450, 330);
         myButton.Location = new Point(24, 16);
         myButton.Size = new Size(120, 24);
         myButton.Text = "Currency Format";
         myButton.Click+=new EventHandler(myButton_Click);
         myDataGrid.Location = new  Point(24, 50);
         myDataGrid.Size = new Size(120,200);
         myDataGrid.CaptionText = "DataGrid Control";
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
      private void SetUp()
      {
         MakeDataSet();
         myDataGrid.SetDataBinding(myDataSet, "Orders");
      }
// <Snippet1>
      private void myButton_Click(object sender, EventArgs e)
      {
         if(TablesAlreadyAdded) 
         {
            return;
         }
         AddCustomDataTableStyle();
      }
      private void AddCustomDataTableStyle()
      {
         DataGridTableStyle myTableStyle = new DataGridTableStyle();
         // Map DataGridTableStyle to a DataTable.
         myTableStyle.MappingName = "Orders";
         // Get CurrencyManager object.
         CurrencyManager myCurrencyManager = (CurrencyManager)BindingContext[myDataSet,"Orders"];
         // Use the CurrencyManager to get the PropertyDescriptor for column.
         PropertyDescriptor myPropertyDescriptor = myCurrencyManager.GetItemProperties()["Amount"];
         // Construct a 'DataGridColumnStyle' object changing its format to 'Currency'.
         DataGridColumnStyle myColumnStyle =  new DataGridTextBoxColumn(myPropertyDescriptor,"c",true);
         // Add EventHandler function for PropertyDescriptorChanged Event.
         myColumnStyle.PropertyDescriptorChanged+=new System.EventHandler(MyPropertyDescriptor_Changed);
         myTableStyle.GridColumnStyles.Add(myColumnStyle);
         // Add the DataGridTableStyle instance to the GridTableStylesCollection. 
         myDataGrid.TableStyles.Add(myTableStyle);
         TablesAlreadyAdded=true;
      }
      private void MyPropertyDescriptor_Changed(object sender,EventArgs e)
      {
         myLabel.Text="Property Descriptor Property of DataGridColumnStyle has changed";
      }
// </Snippet1>
      private void MakeDataSet()
      {
         myDataSet = new DataSet("myDataSet");
         DataTable myTable = new DataTable("Orders");
         DataColumn myColumn =  new DataColumn("Amount",typeof(decimal));
         myTable.Columns.Add(myColumn); 
         myDataSet.Tables.Add(myTable);
         DataRow newRow; 
         for(int j = 1; j < 15; j++)
         {
            newRow = myTable.NewRow();
            newRow["Amount"] = j * 10;
            myTable.Rows.Add(newRow);
         }
      }
   }
