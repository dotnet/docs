using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NorthwindClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // <Snippet3>
            ServiceReference1.northwindModel.northwindEntities proxy = new
 ServiceReference1.northwindModel.northwindEntities(new
 Uri("http://localhost:53397/NorthwindCustomers.svc/"));
            this.customersBindingSource.DataSource = proxy.Customers;
            // </Snippet3>
        }
           
        private void button1_Click(object sender, EventArgs e)
        {   
        
        // <Snippet4>
        ServiceReference1.northwindModel.northwindEntities proxy = new
 ServiceReference1.northwindModel.northwindEntities(new
 Uri("http://localhost:53397/NorthwindCustomers.svc/"));
    string city = textBox1.Text;

if (city != "")
{
    this.customersBindingSource.DataSource = from c in
 proxy.Customers where c.City == city select c;   
        // </Snippet4>
        }
        }
    }

        
}
