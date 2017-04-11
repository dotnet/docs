using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EndEditOnAllBindingSourcesCS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void customersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {

            this.Validate();
            //<snippet2>
            EndEditOnAllBindingSources();
            //</snippet2>
            this.tableAdapterManager.UpdateAll(this.northwindDataSet);
        }

        //<snippet1>
        private void EndEditOnAllBindingSources()
        {
            var BindingSourcesQuery =
                from Component bindingSources in this.components.Components
                where bindingSources is BindingSource
                select bindingSources;

            foreach (BindingSource bindingSource in BindingSourcesQuery)
            {
                bindingSource.EndEdit();
            }
        }
        //</snippet1>

        private void Form1_Load(object sender, EventArgs e)
        {

            // TODO: This line of code loads data into the 'northwindDataSet.Customers' table. You can move, or remove it, as needed.
            this.customersTableAdapter.Fill(this.northwindDataSet.Customers);
            // TODO: This line of code loads data into the 'northwindDataSet.Orders' table. You can move, or remove it, as needed.
            this.ordersTableAdapter.Fill(this.northwindDataSet.Orders);
            // TODO: This line of code loads data into the 'northwindDataSet.OrderDetails' table. You can move, or remove it, as needed.
            this.order_DetailsTableAdapter.Fill(this.northwindDataSet.Order_Details);
        }
    }
}
