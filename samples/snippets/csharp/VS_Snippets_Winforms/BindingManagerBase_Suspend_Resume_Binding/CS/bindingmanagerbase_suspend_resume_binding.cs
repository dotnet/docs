// System.BindingManagerBase.SuspendBinding
// System.BindingManagerBase.ResumeBinding

/* This program demonstrates 'SuspendBinding' and 'ResumeBinding' method of 'BindingManagerBase'class.
   It creates a 'DataTable'and two 'TextBox' controls. The 'Text' property of the two 'TextBox' is 
   binded with the two columns of the 'DataTable'. If 'SuspendBinding' button is pressed it 
   suspend the Data Binding between TextBoxes and a 'DataTable' and if ResumeButton is pressed it
   resumes Data Binding.
 */

using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class Form1 :  Form
{
   private Button button1;
   private Button button2;
   private TextBox textBox1;
   private TextBox textBox2;
   private BindingManagerBase myBindingManager;
   private  Button button3;
   private  Button button4;
   private  Label label1;
   private  Label label2;
   private DataSet myDataSet;

   public Form1()
   {
       InitializeComponent();
      // Call SetUp to bind the controls.
      SetUp();
   }

   private void InitializeComponent()
   {
      button1 = new  Button();
      button2 = new  Button();
      button3 = new  Button();
      textBox2 = new  TextBox();
      textBox1 = new  TextBox();
      button4 = new  Button();
      label1 = new  Label();
      label2 = new  Label();
      SuspendLayout();
       
      button1.Location = new  Point(120, 8);
      button1.Name = "button1";
      button1.Size = new  Size(64, 24);
      button1.TabIndex = 0;
      button1.Text = "<";
      button1.Click += new System.EventHandler(button1_Click);
      
      button2.Location = new  Point(184, 8);
      button2.Name = "button2";
      button2.Size = new  Size(64, 24);
      button2.TabIndex = 1;
      button2.Text = ">";
      button2.Click += new System.EventHandler(button2_Click);
       
      button3.Location = new  Point(96, 112);
      button3.Name = "button3";
      button3.TabIndex = 4;
      button3.Text = "Suspend";
      button3.Click += new System.EventHandler(button3_Click);
       
      textBox2.Location = new  Point(200, 72);
      textBox2.Name = "textBox2";
      textBox2.Size = new  Size(150, 20);
      textBox2.TabIndex = 3;
      textBox2.Text = "";
       
      textBox1.Location = new  Point(40, 72);
      textBox1.Name = "textBox1";
      textBox1.Size = new  Size(150, 20);
      textBox1.TabIndex = 2;
      textBox1.Text = "";
       
      button4.Location = new  Point(192, 112);
      button4.Name = "button4";
      button4.TabIndex = 5;
      button4.Text = "Resume";
      button4.Click += new System.EventHandler(button4_Click);
       
      label1.Location = new  Point(48, 48);
      label1.Name = "label1";
      label1.TabIndex = 6;
      label1.Text = "Customer Name";
       
      label2.Location = new  Point(216, 48);
      label2.Name = "label2";
      label2.TabIndex = 7;
      label2.Text = "CustomerID";
       
      ClientSize = new  Size(450, 200);
      Controls.AddRange(new  Control[] {label2,label1,button4,button3,button1,button2,textBox1,textBox2});
      Name = "Form1";
      Text = "Binding Sample";
      ResumeLayout(false);
   }

   public static void Main()
   {
      Application.Run(new Form1());
   }
   
   private void SetUp()
   {
      MakeDataSet();
      BindControls();
   }

   protected void BindControls()
   {
      textBox1.DataBindings.Add(new Binding
         ("Text", myDataSet, "customers.custName"));
      textBox2.DataBindings.Add(new Binding
         ("Text", myDataSet, "customers.custID"));
      
      myBindingManager = BindingContext [myDataSet, "Customers"];
   }

   private void button1_Click(object sender, EventArgs e)
   {
      // Go to the previous item in the Customer list.
      myBindingManager.Position -= 1;
   }

   private void button2_Click(object sender, EventArgs e)
   {
      // Go to the next item in the Customer list.
      myBindingManager.Position += 1;
   }    
   
   // Create a DataSet with two tables and populate it.
   private void MakeDataSet()
   {
      // Create a DataSet.
      myDataSet = new DataSet("myDataSet");
      
      // Create a DataTable.
      DataTable myCustomerTable = new DataTable("Customers");
      
      // Create two columns, and add them to the first table.
      DataColumn myCustomerColumnID = new DataColumn("CustID", typeof(int));
      DataColumn myCustomerName = new DataColumn("CustName");
      myCustomerTable.Columns.Add(myCustomerColumnID);
      myCustomerTable.Columns.Add(myCustomerName);

      // Add the tables to the DataSet.
      myDataSet.Tables.Add(myCustomerTable);

      DataRow newRow1;
      // Create three customers in the Customers Table.
      for(int i = 1; i < 4; i++)
      {
         newRow1 = myCustomerTable.NewRow();
         newRow1["custID"] = i;
         // Add the row to the Customers table.
         myCustomerTable.Rows.Add(newRow1);
      }
      // Give each customer a distinct name.
      myCustomerTable.Rows[0]["custName"] = "Alpha";
      myCustomerTable.Rows[1]["custName"] = "Beta";
      myCustomerTable.Rows[2]["custName"] = "Omega";

      UniqueConstraint idKeyRestraint = new UniqueConstraint(myCustomerColumnID);
      myCustomerTable.Constraints.Add(idKeyRestraint);
      myDataSet.EnforceConstraints = true;
   }

// <Snippet1>
   private void button3_Click(object sender, EventArgs e)
   {
      try
      {
         BindingManagerBase myBindingManager1=BindingContext [myDataSet, "Customers"];
         myBindingManager1.SuspendBinding();
      }
      catch(Exception ex)
      {
         MessageBox.Show(ex.Source);
         MessageBox.Show(ex.Message);
      }
   }
// </Snippet1>

// <Snippet2>
   private void button4_Click(object sender, EventArgs e)
   {
      try
      {
         BindingManagerBase myBindingManager2=BindingContext [myDataSet, "Customers"];
         myBindingManager2.ResumeBinding();
      }
      catch(Exception ex)
      {
         MessageBox.Show(ex.Source);
         MessageBox.Show(ex.Message);
      }
   }
// </Snippet2>
}

