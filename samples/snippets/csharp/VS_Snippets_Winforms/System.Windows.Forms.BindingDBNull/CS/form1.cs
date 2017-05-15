// <snippet1>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DBNullCS
{
	public class Form1 : Form
	{
		public Form1()
		{		
			this.Load += new EventHandler(Form1_Load);
        }

        // The controls and components we need for the form.
        private Button button1;
        private PictureBox pictureBox1;
        private BindingSource bindingSource1;
        private TextBox textBox1;
        private TextBox textBox2;
        
        // Data table to hold the database data.
        DataTable employeeTable = new DataTable();

		void Form1_Load(object sender, EventArgs e)
		{
            // Basic form setup.
            this.pictureBox1 = new PictureBox();
            this.bindingSource1 = new BindingSource();
            this.textBox1 = new TextBox();
            this.textBox2 = new TextBox();
            this.button1 = new Button();
            this.pictureBox1.Location = new System.Drawing.Point(20, 20);
            this.pictureBox1.Size = new System.Drawing.Size(174, 179);
            this.textBox1.Location = new System.Drawing.Point(25, 215);
            this.textBox1.ReadOnly = true;
            this.textBox2.Location = new System.Drawing.Point(25, 241);
            this.textBox2.ReadOnly = true;
            this.button1.Location = new System.Drawing.Point(200, 103);
            this.button1.Text = "Move Next";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox1);
            this.ResumeLayout(false);
            this.PerformLayout();
           
            // Create the connection string and populate the data table
            // with data.
            string connectionString = "Integrated Security=SSPI;" +
				"Persist Security Info = False;Initial Catalog=Northwind;" +
				"Data Source = localhost";
			SqlConnection connection = new SqlConnection();
			connection.ConnectionString = connectionString;
            SqlDataAdapter employeeAdapter = 
                new SqlDataAdapter(new SqlCommand("Select * from Employees", connection));
            connection.Open();
            employeeAdapter.Fill(employeeTable);
            
            // Set the DataSource property of the BindingSource to the employee table.
            bindingSource1.DataSource = employeeTable;

           // Set up the binding to the ReportsTo column.
            Binding reportsToBinding = textBox2.DataBindings.Add("Text", bindingSource1, 
                "ReportsTo", true);

            // Set the NullValue property for this binding.
            reportsToBinding.NullValue = "No Manager";

            // Set up the binding for the PictureBox using the Add method, setting
            // the null value in method call.
            pictureBox1.DataBindings.Add("Image", bindingSource1, "Photo", true, 
                DataSourceUpdateMode.Never, new Bitmap(typeof(Button), "Button.bmp"));

            // Set up the remaining binding.
            textBox1.DataBindings.Add("Text", bindingSource1, "LastName", true);
		}

        // Move through the data when the button is clicked.
        private void button1_Click(object sender, EventArgs e)
        {
            bindingSource1.MoveNext();
        }

		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.Run(new Form1());
        }
       
	}
}
// </snippet1>
