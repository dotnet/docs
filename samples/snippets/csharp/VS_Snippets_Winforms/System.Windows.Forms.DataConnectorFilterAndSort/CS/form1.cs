#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace FilterAndSort
{
    class Form1 : Form
    {



        private BindingSource BindingSource1;
        private DataGridView dataGridView1;
        private Button button1;
        private Label label1;
        private Label label2;


        private IContainer components;

        public Form1()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load);
        }
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.BindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 100);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(292, 166);
            this.dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 39);
            this.button1.Name = "button1";
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(112, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(112, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "label2";
            // 
            // Form1
            // 

            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        void Form1_Load(object sender, EventArgs e)
        {
            InitializeSortedFilteredBindingSource();
        }
        // The following code example demonstrates BindingSource.Filter and
        // BindingSource.Sort members.  

        // To run this example paste the code into a form that contains a 
        // BindingSource named BindingSource1 and a DataGridView named
        // dataGridView1.  Handle the form's load event and call 
        // InitializeSortedFilteredBindingSource in the load event-handling 
        // method.
        //<snippet1>
        private void InitializeSortedFilteredBindingSource()
		{
			// Create the connection string, data adapter and data table.
			SqlConnection connectionString =
				 new SqlConnection("Initial Catalog=Northwind;" +
				 "Data Source=localhost;Integrated Security=SSPI;");
			SqlDataAdapter customersTableAdapter =
				new SqlDataAdapter("Select * from Customers", connectionString);
			DataTable customerTable = new DataTable();

			// Fill the the adapter with the contents of the customer table.
			customersTableAdapter.Fill(customerTable);

			// Set data source for BindingSource1.
			BindingSource1.DataSource = customerTable;

			// Filter the items to show contacts who are owners.
			// <snippet11>
			BindingSource1.Filter = "ContactTitle='Owner'";
			// </snippet11>

			// Sort the items on the company name in descending order.
			// <snippet12>
			BindingSource1.Sort = "Country DESC, Address ASC";
			// </snippet12>

			// Set the data source for dataGridView1 to BindingSource1.
			dataGridView1.DataSource = BindingSource1;

        }
        //</snippet1>

        // The following code example demonstrates BindingSource.Items,
        // BindingSource.List, BindingSource.RemoveAt, BindingSource.Count
        // BindingSourceItemCollection.Count.

        // To run this example paste the code into a form that contains a 
        // BindingSource named BindingSource1, two labels named label1 and label2
        // and a button named button1. Associate the button1_Click
        // method with the click event for button1. 

        //<snippet2>    
        private void button1_Click(object sender, EventArgs e)
        {
            // Create the connection string, data adapter and data table.
            SqlConnection connectionString =
                 new SqlConnection("Initial Catalog=Northwind;" +
                 "Data Source=localhost;Integrated Security=SSPI;");
            SqlDataAdapter customersTableAdapter =
                new SqlDataAdapter("Select * from Customers", connectionString);
            DataTable customerTable = new DataTable();

            // Fill the the adapter with the contents of the customer table.
            customersTableAdapter.Fill(customerTable);

            // Set data source for BindingSource1.
            BindingSource1.DataSource = customerTable;

            // Set the label text to the number of items in the collection before
            // an item is removed.
            label1.Text = "Starting count: " + BindingSource1.Count.ToString();

            // Access the List property and remove an item.
            BindingSource1.List.RemoveAt(4);

            // Remove an item directly from the BindingSource. 
            // This is equivalent to the previous line of code.
            BindingSource1.RemoveAt(4);

            // Show the new count.
            label2.Text = "Count after removal: " + BindingSource1.Count.ToString();
        }
        //</snippet2>


    }

}
