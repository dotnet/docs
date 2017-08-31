using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CS
{
    public partial class Form1 : Form
    {
        //<Snippet1>
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'northwindDataSet1.Customers' table.
            // You can move, or remove it, as needed.

            this.customersTableAdapter1.Fill(this.northwindDataSet1.Customers);
        }
        //</Snippet1>


        //<Snippet2>
        private void ReadXmlButton_Click(object sender, EventArgs e)
        {
            string filePath = "Complete path where you saved the XML file";

            AuthorsDataSet.ReadXml(filePath);

            dataGridView1.DataSource = AuthorsDataSet;
            dataGridView1.DataMember = "authors";
        }
        //</Snippet2>


        //<Snippet3>
        private void ShowSchemaButton_Click(object sender, EventArgs e)
        {
            System.IO.StringWriter swXML = new System.IO.StringWriter();
            AuthorsDataSet.WriteXmlSchema(swXML);
            textBox1.Text = swXML.ToString();
        }
        //</Snippet3>


        public Form1()
        {
            InitializeComponent();
        }


        private void customersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.customersBindingSource.EndEdit();
            this.customersTableAdapter1.Update(this.northwindDataSet1.Customers);
        }
    }
}