// System.Windows.Forms.DataGridTableStyle.HeaderForeColorChanged;System.Windows.Forms.DataGridTableStyle.HeaderForeColor
// System.Windows.Forms.DataGridTableStyle.HeaderBackColorChanged;System.Windows.Forms.DataGridTableStyle.HeaderBackColor

/*
   The following program demonstrates the usage of properties 'HeaderBackColor',
   'HeaderForeColor' and events 'HeaderBackColorChanged','HeaderForeColorChanged'.
   A table is created and added to a datagrid with two coloumns.The table allows to change
   Header's  background and foreground colors through selection of combobox values.
 */

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Datagrid
{
   public class Form1 : System.Windows.Forms.Form
   {
       
      private System.Windows.Forms.DataGrid dataGrid1;
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.ComboBox comboBox1;
      private System.Windows.Forms.ComboBox comboBox2;
      private System.Windows.Forms.Button button2;


      private System.ComponentModel.Container components = null;

      public Form1()
      {
         InitializeComponent();
      }
      
      // Clean up resources.
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
         this.comboBox1 = new System.Windows.Forms.ComboBox();
         this.button1 = new System.Windows.Forms.Button();
         this.dataGrid1 = new System.Windows.Forms.DataGrid();
         this.comboBox2 = new System.Windows.Forms.ComboBox();
         this.button2 = new System.Windows.Forms.Button();
         ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
         this.SuspendLayout();
         // 
         // comboBox1
         // 
         this.comboBox1.DropDownWidth = 136;
         this.comboBox1.Items.AddRange(new object[] {
                                                       "Blue",
                                                       "Red",
                                                       "Yellow"});
         this.comboBox1.Location = new System.Drawing.Point(56, 144);
         this.comboBox1.Name = "comboBox1";
         this.comboBox1.Size = new System.Drawing.Size(136, 21);
         this.comboBox1.Sorted = true;
         this.comboBox1.TabIndex = 2;
         this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(232, 144);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(96, 32);
         this.button1.TabIndex = 1;
         this.button1.Text = "Change Header Background";
         this.button1.Click += new System.EventHandler(this.OnHeaderBackColor_Click);
         // 
         // dataGrid1
         // 
         this.dataGrid1.CaptionText = "DataGrid";
         this.dataGrid1.DataMember = "";
         this.dataGrid1.Location = new System.Drawing.Point(56, 48);
         this.dataGrid1.Name = "dataGrid1";
         this.dataGrid1.Size = new System.Drawing.Size(272, 80);
         this.dataGrid1.TabIndex = 0;
         // 
         // comboBox2
         // 
         this.comboBox2.DropDownWidth = 136;
         this.comboBox2.Items.AddRange(new object[] {
                                                       "Green",
                                                       "White",
                                                       "Violet"});
         this.comboBox2.Location = new System.Drawing.Point(56, 192);
         this.comboBox2.Name = "comboBox2";
         this.comboBox2.Size = new System.Drawing.Size(136, 21);
         this.comboBox2.TabIndex = 3;
         this.comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
         // 
         // button2
         // 
         this.button2.Location = new System.Drawing.Point(232, 184);
         this.button2.Name = "button2";
         this.button2.Size = new System.Drawing.Size(96, 32);
         this.button2.TabIndex = 4;
         this.button2.Text = "Change Header ForeGround";
         this.button2.Click += new System.EventHandler(this.OnHeaderForeColor_Click);
         // 
         // Form1
         // 
         this.ClientSize = new System.Drawing.Size(536, 301);
         this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                         this.button2,
                                                       this.comboBox2,
                                                       this.comboBox1,
                                                         this.button1,
                                                     this.dataGrid1});
         this.Name = "Form1";
         this.Text = "Form1";
         this.Load += new System.EventHandler(this.Form1_Load);
         ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
         this.ResumeLayout(false);

      }
      #endregion
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main() 
      {
         Application.Run(new Form1());
      }

      // Declare objects of DataSet,DataGrid,DataTable.
      private DataSet myDataSet;
      public DataTable myCustomerTable;
      public DataGridTableStyle myTableStyle;

      private void Form1_Load(object sender, System.EventArgs e)
      {
         comboBox1.SelectedIndex = 0;
         comboBox2.SelectedIndex = 0;
         Create_Table();
      }
// <Snippet1>
// <Snippet2>
// <Snippet3>
// <Snippet4>
      private void Create_Table()
      {
         // Create DataSet.
         myDataSet = new DataSet("myDataSet");
         // Create DataTable.
         DataTable myCustomerTable = new DataTable("Customers");
         // Create two columns, and add them to the table.
         DataColumn CustID = new DataColumn("CustID", typeof(int));
         DataColumn CustName = new DataColumn("CustName");
         myCustomerTable.Columns.Add(CustID);
         myCustomerTable.Columns.Add(CustName);
         // Add table to DataSet.
         myDataSet.Tables.Add(myCustomerTable);
         dataGrid1.SetDataBinding(myDataSet,"Customers");
         myTableStyle = new DataGridTableStyle();
         myTableStyle.MappingName = "Customers";
         myTableStyle.HeaderBackColorChanged += 
            new System.EventHandler(HeaderBackColorChangedHandler); 
         myTableStyle.HeaderForeColorChanged +=
            new System.EventHandler(HeaderForeColorChangedHandler); 
      }
      
      // Change header background color.
      private void OnHeaderBackColor_Click(object sender, System.EventArgs e)
      {
         dataGrid1.TableStyles.Clear ();
         switch(comboBox1.SelectedItem.ToString())
         {
            case "Red":
               myTableStyle.HeaderBackColor = Color.Red;
               break;
            case "Yellow":
               myTableStyle.HeaderBackColor = Color.Yellow ;
               break;
            case "Blue":
               myTableStyle.HeaderBackColor = Color.Blue ;
               break;
         }
         myTableStyle.AlternatingBackColor = Color.LightGray;
         dataGrid1.TableStyles.Add(myTableStyle);
      }
// </Snippet4>

      private void HeaderBackColorChangedHandler(object sender,EventArgs e)
      {
         MessageBox.Show("Changed Header Background color to : " + 
         comboBox1.SelectedItem.ToString(),"Success", MessageBoxButtons.OK, 
         MessageBoxIcon.Exclamation);
      }
// </Snippet3>

      // Change header forecolor.
      private void OnHeaderForeColor_Click(object sender, System.EventArgs e)
      {
         dataGrid1.TableStyles.Clear();
         switch(comboBox2.SelectedItem.ToString())
         {
            case "Green":
               myTableStyle.HeaderForeColor = Color.Green;
               break;
            case "White":
               myTableStyle.HeaderForeColor = Color.White;
               break;
            case "Violet":
               myTableStyle.HeaderForeColor = Color.Violet;
               break;
         }
         myTableStyle.AlternatingBackColor = Color.LightGray;
         dataGrid1.TableStyles.Add(myTableStyle);
      }
// </Snippet2>

      private void HeaderForeColorChangedHandler(object sender,EventArgs e)
      {
         MessageBox.Show("Changed Header Fore color to : " + 
         comboBox2.SelectedItem.ToString(), "Success",
         MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
// </Snippet1>
   }
}
