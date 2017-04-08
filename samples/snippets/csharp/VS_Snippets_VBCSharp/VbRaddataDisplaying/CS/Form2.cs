using System;
using System.Windows.Forms;

namespace CS
{
    public partial class Form2 : Form
    {
        //<Snippet1>
        internal void LoadOrders(String CustomerID)
        {
            ordersTableAdapter.FillByCustomerID(northwindDataSet.Orders, CustomerID);
        }
        //</Snippet1>


        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'northwindDataSet.Orders' table. You can move, or remove it, as needed.
            //this.ordersTableAdapter.Fill(this.northwindDataSet.Orders);
        }


        public Form2()
        {
            InitializeComponent();
        }

 
        private void ordersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.ordersBindingSource.EndEdit();
            this.ordersTableAdapter.Update(this.northwindDataSet.Orders);

        }
    }
}