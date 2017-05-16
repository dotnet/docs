// System.Windows.Forms.DataGridTableStyle.SelectionBackColorChanged
// System.Windows.Forms.DataGridTableStyle.SelectionBackColor
// System.Windows.Forms.DataGridTableStyle.ResetSelectionBackColor

/* The following program demonstrates the 'SelectionBackColorChanged'
   event, 'SelectionBackColor' property and 'ResetSelectionBackColor'
   method of the'DataGridTableStyle'class. It changes the BackColor
   of the selected cells by raising the 'SelectionBackColorChanged'
   event. The SelectionBackColor is reset to its default value with
   the 'ResetSelectionBackColor' button.
*/
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

public class MyForm : System.Windows.Forms.Form
{      
   private System.ComponentModel.Container components = null;
   private System.Windows.Forms.Button myBackColorButton;
   private System.Windows.Forms.Button myResetButton;
   private DataGridTableStyle myGridTableStyle;    
    
   public MyForm()
   {
      InitializeComponent();
   }

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

      #region Windows Form Designer generated code
   /// <summary>
   /// Required method for Designer support - do not modify
   /// the contents of this method with the code editor.
   /// </summary>
   private void InitializeComponent()
   {   
      this.myBackColorButton = new System.Windows.Forms.Button();
      this.myResetButton = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // myBackColorButton
      // 
      this.myBackColorButton.Location = new System.Drawing.Point(0, 352);
      this.myBackColorButton.Name = "myBackColorButton";
      this.myBackColorButton.Size = new System.Drawing.Size(160, 23);
      this.myBackColorButton.TabIndex = 0;
      this.myBackColorButton.Text = "Change SelectionBackColor";
      this.myBackColorButton.Click += new System.EventHandler(this.MyBackColorButton_Click);
      // 
      // myResetButton
      // 
      this.myResetButton.Location = new System.Drawing.Point(160, 352);
      this.myResetButton.Name = "myResetButton";
      this.myResetButton.Size = new System.Drawing.Size(152, 23);
      this.myResetButton.TabIndex = 1;
      this.myResetButton.Text = "Reset SelectionBackColor";
      this.myResetButton.Click += new System.EventHandler(this.MyResetButton_Click);
      // 
      // MyForm
      // 
      this.ClientSize = new System.Drawing.Size(316, 411);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                   this.myResetButton,
                                                                   this.myBackColorButton});
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "MyForm";
      this.Text = "MyForm";
      this.Load += new System.EventHandler(this.MyForm_Load);
      this.ResumeLayout(false);

   }
#endregion
      
   DataGrid myDataGrid = new DataGrid();
     
   [STAThread]
   static void Main() 
   {
      Application.Run(new MyForm());
   }
    
   private void MyForm_Load(object sender, System.EventArgs e)
   {      
      myDataGrid.CaptionText ="My Data Grid";
      myDataGrid.Height=300;
      myDataGrid.Width=300;
      myDataGrid.BorderStyle =System.Windows.Forms.BorderStyle.FixedSingle;
      myDataGrid.SetDataBinding(MakeDataSet(), "Orders");
      Controls.Add(myDataGrid);      
      myGridTableStyle = new DataGridTableStyle();
      myGridTableStyle.MappingName = "Orders";      
      myGridTableStyle.SelectionForeColor=Color.Coral;
      myDataGrid.TableStyles.Add(myGridTableStyle);
      AttachSelectionBackColorChanged();
   }
// <Snippet1>   
   public void AttachSelectionBackColorChanged()
   {
      // Handle the 'SelectionBackColorChanged' event.
      myGridTableStyle.SelectionBackColorChanged  += new EventHandler(this.MyDataGrid_SelectedBackColorChanged);      
   }
   
   private void MyDataGrid_SelectedBackColorChanged(object sender, System.EventArgs e)  
   {
      MessageBox.Show("SelectionBackColorChanged event was raised, Color changed to "+ myGridTableStyle.SelectionBackColor);
   }
// </Snippet1>    
   private void MyBackColorButton_Click(object sender, System.EventArgs e)
   {
// <Snippet2>   
      // Allow the user to select a Color.
      ColorDialog myColorDialog = new ColorDialog();      
      myColorDialog.AllowFullOpen = false ;      
      myColorDialog.ShowHelp = true ;
      // Set the initial color select to the current color.
      myColorDialog.Color = myGridTableStyle.SelectionBackColor;
      // Show color dialog box.
      myColorDialog.ShowDialog();
      // Set the backcolor for the selected cells. 
      myGridTableStyle.SelectionBackColor = myColorDialog.Color;    
// </Snippet2>      
      myDataGrid.Invalidate();
   } 
   
   private void MyResetButton_Click(object sender, System.EventArgs e)
   {
// <Snippet3> 
      // Set the SelectionBackColor to the default color.
      myGridTableStyle.ResetSelectionBackColor();      
// </Snippet3>       
   }   
    
   private DataSet MakeDataSet()
   {
      // Create a DataSet.
      DataSet myDataSet = new DataSet("myDataSet");

      // Create two DataTables.
      DataTable myDataGrid = new DataTable("Customers");
      DataTable tOrders = new DataTable("Orders");

      // Create two columns, and add them to the first table.
      DataColumn cCustID = new DataColumn("CustID", typeof(int));
      DataColumn cCustName = new DataColumn("CustName");
      DataColumn cCurrent = new DataColumn("Current", typeof(bool));
      myDataGrid.Columns.Add(cCustID);
      myDataGrid.Columns.Add(cCustName);
      myDataGrid.Columns.Add(cCurrent);

      // Create three columns, and add them to the second table.
      DataColumn cID = new DataColumn("CustID", typeof(int));
      DataColumn cOrderDate = new DataColumn("OrderDate",typeof(DateTime));
      DataColumn cOrderAmount = new DataColumn("OrderAmount", typeof(decimal));
      tOrders.Columns.Add(cOrderAmount);
      tOrders.Columns.Add(cID);
      tOrders.Columns.Add(cOrderDate);

      // Add the tables to the DataSet.
      myDataSet.Tables.Add(myDataGrid);
      myDataSet.Tables.Add(tOrders);

      // Create a DataRelation, and add it to the DataSet.
      DataRelation dr = new DataRelation("custToOrders", cCustID , cID);
      myDataSet.Relations.Add(dr);

      // Populate the tables. 
      // Create for each customer and order two DataRow variables.
      DataRow newRow1;
      DataRow newRow2;

      // Create three customers in the Customers Table.
      for(int i = 1; i < 4; i++)
      {
         newRow1 = myDataGrid.NewRow();
         newRow1["custID"] = i;
         // Add the row to the Customers table.
         myDataGrid.Rows.Add(newRow1);
      }
      // Give each customer a distinct name.
      myDataGrid.Rows[0]["custName"] = "Customer 1";
      myDataGrid.Rows[1]["custName"] = "Customer 2";
      myDataGrid.Rows[2]["custName"] = "Customer 3";

      // Give the Current column a value.
      myDataGrid.Rows[0]["Current"] = true;
      myDataGrid.Rows[1]["Current"] = true;
      myDataGrid.Rows[2]["Current"] = false;

      // For each customer, create five rows in the Orders table.
      for(int i = 1; i < 4; i++)
      {
         for(int j = 1; j < 6; j++)
         {
            newRow2 = tOrders.NewRow();
            newRow2["CustID"]= i;
            newRow2["orderDate"]= new DateTime(2001, i, j * 2);
            newRow2["OrderAmount"] = i * 10 + j  * .1;
            // Add the row to the Orders table.
            tOrders.Rows.Add(newRow2);
         }
      }
      return myDataSet;
   }
}

