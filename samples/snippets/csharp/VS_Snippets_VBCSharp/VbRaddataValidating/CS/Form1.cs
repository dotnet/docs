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
        public Form1()
        {
            InitializeComponent();
        }

        private void order_DetailsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.order_DetailsBindingSource.EndEdit();
            this.order_DetailsTableAdapter1.Update(this.northwindDataSet1.Order_Details);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'northwindDataSet1.Order_Details' table. You can move, or remove it, as needed.
            this.order_DetailsTableAdapter1.Fill(this.northwindDataSet1.Order_Details);

        }
    }
}