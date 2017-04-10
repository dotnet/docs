//<snippet1>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NavigatingData
{
    public partial class Form1 : Form
    {
        private Button nextButton;
        private Button findButton;
        private BindingSource customersBindingSource;
        private DataGridView customersDataGridView;
    
        public Form1()
        {
            this.customersDataGridView = new DataGridView();
            this.nextButton = new Button();
            this.findButton = new Button();
            this.customersBindingSource = new BindingSource();
                  
            this.customersDataGridView.Location = new Point(23, 62);
            this.customersDataGridView.Size = new Size(240, 150);
            this.nextButton.Location = new Point(23, 22);
            this.nextButton.Size = new Size(75, 23);
            this.nextButton.Text = "Next";
            this.findButton.Location = new Point(122, 22);
            this.findButton.Size = new Size(75, 23);
            this.findButton.Text = "Find ANTON";
            this.ClientSize = new Size(292, 266);
            this.Controls.Add(this.findButton);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.customersDataGridView);
            nextButton.Click += new EventHandler(nextButton_Click);
            findButton.Click += new EventHandler(findButton_Click);
            this.Load += new EventHandler(Form1_Load);
            this.customersBindingSource.PositionChanged += new EventHandler(customersBindingSource_PositionChanged);


        }
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }
        //<snippet2>
        void findButton_Click(object sender, EventArgs e)
        {
            int foundIndex = customersBindingSource.Find("CustomerID", "ANTON");
            customersBindingSource.Position = foundIndex;
        }
        //</snippet2>

        //<snippet3>
        void customersBindingSource_PositionChanged(object sender, EventArgs e)
        {
            if (customersBindingSource.Position == customersBindingSource.Count - 1)
                nextButton.Enabled = false;
            else
                nextButton.Enabled = true;
        }
        //</snippet3>

        //<snippet4>
        private void nextButton_Click(object sender, System.EventArgs e)
        {
            this.customersBindingSource.MoveNext();
        }
        //</snippet4>

        //<snippet5>
        private void Form1_Load(object sender, EventArgs e)
        {
            // Create the connection string, data adapter, data table and data view.
            SqlConnection connectionString =
                 new SqlConnection("Initial Catalog=Northwind;" +
                 "Data Source=localhost;Integrated Security=SSPI;");
            SqlDataAdapter customersDataAdapter =
                new SqlDataAdapter("Select * from Customers", connectionString);
                     
            DataTable customerTable = new DataTable();
            

            // Fill the the table with the contents of the customer table.
            customersDataAdapter.Fill(customerTable);
            DataView customerView = new DataView(customerTable);

            // Set data source for customersBindingSource.
            customersBindingSource.DataSource = customerView;
            customersDataGridView.DataSource = customersBindingSource;
        }
        //</snippet5>
   
    }
}
//</snippet1>