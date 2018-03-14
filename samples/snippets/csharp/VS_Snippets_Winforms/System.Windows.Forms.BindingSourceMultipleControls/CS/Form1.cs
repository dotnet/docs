using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace MultipleControls
{
    public class Form1 : Form
    {
       
        public Form1()
        {
            this.Load += new EventHandler(Form1_Load);
         
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //InitializeControlsAndDataSource();
            InitializeControlsAndData();
        }

        //<snippet1>
        //<snippet3>

        // Declare the controls to be used.
        private BindingSource bindingSource1;
        private TextBox textBox1;
        private TextBox textBox2;
        private DataGridView dataGridView1;
    
        private void InitializeControlsAndDataSource()
        {
            // Initialize the controls and set location, size and 
            // other basic properties.
            this.dataGridView1 = new DataGridView();
            this.bindingSource1 = new BindingSource();
            this.textBox1 = new TextBox();
            this.textBox2 = new TextBox();
            this.dataGridView1.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = DockStyle.Top;
            this.dataGridView1.Location = new Point(0, 0);
            this.dataGridView1.Size = new Size(292, 150);
            this.textBox1.Location = new Point(132, 156);
            this.textBox1.Size = new Size(100, 20);
            this.textBox2.Location = new Point(12, 156);
            this.textBox2.Size = new Size(100, 20);
            this.ClientSize = new Size(292, 266);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridView1);

            // Declare the DataSet and add a table and column.
            DataSet set1 = new DataSet();
            set1.Tables.Add("Menu");
            set1.Tables[0].Columns.Add("Beverages");

            // Add some rows to the table.
            set1.Tables[0].Rows.Add("coffee");
            set1.Tables[0].Rows.Add("tea");
            set1.Tables[0].Rows.Add("hot chocolate");
            set1.Tables[0].Rows.Add("milk");
            set1.Tables[0].Rows.Add("orange juice");

            // Set the data source to the DataSet.
            bindingSource1.DataSource = set1;

            //Set the DataMember to the Menu table.
            bindingSource1.DataMember = "Menu";

            // Add the control data bindings.
            dataGridView1.DataSource = bindingSource1;
            textBox1.DataBindings.Add("Text", bindingSource1, 
                "Beverages", true, DataSourceUpdateMode.OnPropertyChanged);
            textBox2.DataBindings.Add("Text", bindingSource1, 
                "Beverages", true, DataSourceUpdateMode.OnPropertyChanged);
            bindingSource1.BindingComplete += 
                new BindingCompleteEventHandler(bindingSource1_BindingComplete);
        }
        //</snippet3>

        //<snippet2>
        private void bindingSource1_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            // Check if the data source has been updated, and that no error has occured.
            if (e.BindingCompleteContext == 
                BindingCompleteContext.DataSourceUpdate && e.Exception == null)

                // If not, end the current edit.
                e.Binding.BindingManagerBase.EndCurrentEdit();
        }
        //</snippet2>

        //</snippet1>

        //<snippet11>
        private void InitializeControlsAndData()
        {
            // Initialize the controls and set location, size and 
            // other basic properties.
            this.dataGridView1 = new DataGridView();
            
            this.textBox1 = new TextBox();
            this.textBox2 = new TextBox();
            this.dataGridView1.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = DockStyle.Top;
            this.dataGridView1.Location = new Point(0, 0);
            this.dataGridView1.Size = new Size(292, 150);
            this.textBox1.Location = new Point(132, 156);
            this.textBox1.Size = new Size(100, 20);
            this.textBox2.Location = new Point(12, 156);
            this.textBox2.Size = new Size(100, 20);
            this.ClientSize = new Size(292, 266);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridView1);

            // Declare the DataSet and add a table and column.
            DataSet set1 = new DataSet();
            set1.Tables.Add("Menu");
            set1.Tables[0].Columns.Add("Beverages");

            // Add some rows to the table.
            set1.Tables[0].Rows.Add("coffee");
            set1.Tables[0].Rows.Add("tea");
            set1.Tables[0].Rows.Add("hot chocolate");
            set1.Tables[0].Rows.Add("milk");
            set1.Tables[0].Rows.Add("orange juice");

            
            // Add the control data bindings.
            dataGridView1.DataSource = set1;
            dataGridView1.DataMember = "Menu";
            textBox1.DataBindings.Add("Text", set1,
                "Menu.Beverages", true, DataSourceUpdateMode.OnPropertyChanged);
            textBox2.DataBindings.Add("Text", set1,
                "Menu.Beverages", true, DataSourceUpdateMode.OnPropertyChanged);

            BindingManagerBase bmb = this.BindingContext[set1, "Menu"];
            bmb.BindingComplete += new BindingCompleteEventHandler(bmb_BindingComplete);
          
        }

        private void bmb_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            // Check if the data source has been updated, and that no error has occured.
            if (e.BindingCompleteContext ==
                BindingCompleteContext.DataSourceUpdate && e.Exception == null)

                // If not, end the current edit.
                e.Binding.BindingManagerBase.EndCurrentEdit(); ;
        }
 	//</snippet11>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }
    }
}