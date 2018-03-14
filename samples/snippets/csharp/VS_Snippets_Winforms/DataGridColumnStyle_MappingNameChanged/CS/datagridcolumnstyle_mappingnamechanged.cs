// System.Windows.Forms.DataGridColumnStyle.MappingNameChanged
/*
 * The following example demonstrates the 'MappingNameChanged' event of 'DataGridColumnStyle' class. 
   It adds a DataGrid and a button to a Form. When the user clicks on the 'Change Mapping Name'
   button, it changes  mapping name and generates 'MappingNameChanged' event.
 */
using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Data;

public class MyForm : Form
{
      private DataGrid myDataGrid;
      private bool flag;
      private Button myButton;
      DataSet myDataSet;
      DataGridColumnStyle myColumnStyle;
      public MyForm()
      {
         InitializeComponent();
         SetUp();
      }
      private void InitializeComponent()
      {
         myDataGrid = new DataGrid();
         myButton = new Button();
         myDataGrid.Location = new Point(24, 24);
         myDataGrid.Name = "myDataGrid";
         myDataGrid.CaptionText   = "DataGridColumn"; 
         myDataGrid.Height = 130;
         myDataGrid.Width = 150;
         myDataGrid.TabIndex =0;
         
         myButton.Location = new Point(60,208);
         myButton.Name = "myButton ";
         myButton.TabIndex =3;
         myButton.Size = new Size(140, 20);
         myButton.Text  = "Change Mapping Name";
         myButton.Click += new EventHandler(button_Click);
         
         ClientSize = new Size(292, 273);
         Controls.AddRange(new Control[] {myButton,myDataGrid});
         Name = "Form1";
         Text = "MappingNameChanged Event";
         ResumeLayout(false);
      }
      static void Main() 
      {
         Application.Run(new MyForm());
      }
      private void SetUp()
      {
         MakeDataSet();
         myDataGrid.SetDataBinding(myDataSet, "Orders");
      }
      private void MakeDataSet()
      {
         myDataSet = new DataSet("myDataSet");
         DataTable myTable = new DataTable("Orders");
         DataColumn myColumn =  new DataColumn("Amount",typeof(decimal));
         DataColumn myColumn1 =  new DataColumn("Orders",typeof(decimal));

         myTable.Columns.Add(myColumn);
         myTable.Columns.Add(myColumn1);
         myDataSet.Tables.Add(myTable);
         DataRow newRow;
         for(int j = 1; j < 15; j++)
         {
            newRow = myTable.NewRow();
            newRow["Amount"] = j * 10;
            newRow["Orders"]=10;
            myTable.Rows.Add(newRow);
         }
         AddCustomColumnStyle();
      }
// <Snippet1>
      private void AddCustomColumnStyle()
      {
         DataGridTableStyle myTableStyle = new DataGridTableStyle();
         myTableStyle.MappingName = "Orders";
         myColumnStyle =  new DataGridTextBoxColumn();
         myColumnStyle.MappingName="Orders";
         myColumnStyle.HeaderText="Orders";
         myTableStyle.GridColumnStyles.Add(myColumnStyle);
         myDataGrid.TableStyles.Add(myTableStyle);
         myColumnStyle.MappingNameChanged+=new EventHandler(columnStyle_MappingNameChanged);
         flag=true;
      }
      // MappingNameChanged event handler of DataGridColumnStyle.
      private void columnStyle_MappingNameChanged(object sender, EventArgs e)
      {
         MessageBox.Show("Mapping Name changed");
      }
// </Snippet1>
      private void button_Click(object sender, EventArgs e)
      {
        // Change the Mapping name.
         if(flag)
         {
            myColumnStyle=myDataGrid.TableStyles[0].GridColumnStyles["Orders"];
            myColumnStyle.MappingName="Amount";
            myColumnStyle.HeaderText="Amount";
            this.Refresh();
            flag=false;
         }
         else
         {
           myColumnStyle=myDataGrid.TableStyles[0].GridColumnStyles["Amount"];
           myColumnStyle.MappingName="Orders";
           myColumnStyle.HeaderText="Orders";
            this.Refresh();
           flag=true;
         }
      }

}
