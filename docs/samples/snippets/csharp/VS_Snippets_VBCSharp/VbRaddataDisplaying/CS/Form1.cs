using System;
using System.Windows.Forms;

namespace CS
{
    public partial class Form1 : Form
    {
        void test()
        {
            //<Snippet6>
            customersBindingSource.Filter = "CompanyName like 'B'";
            //</Snippet6>

            //<Snippet7>
            customersBindingSource.Sort = "CompanyName Desc";
            //</Snippet7>
        }


        //<Snippet2>
        private void customersDataGridView_DoubleClick(object sender, EventArgs e)
        {
            System.Data.DataRowView SelectedRowView;
            NorthwindDataSet.CustomersRow SelectedRow;

            SelectedRowView = (System.Data.DataRowView)customersBindingSource.Current;
            SelectedRow = (NorthwindDataSet.CustomersRow)SelectedRowView.Row;

            Form2 OrdersForm = new Form2();
            OrdersForm.LoadOrders(SelectedRow.CustomerID);
            OrdersForm.Show();
        }
        //</Snippet2>


        public Form1()
        {
            InitializeComponent();
        }


        private void customersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.customersBindingSource.EndEdit();
            this.customersTableAdapter.Update(this.northwindDataSet.Customers);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'northwindDataSet1.Customers' table. You can move, or remove it, as needed.
            this.customersTableAdapter.Fill(this.northwindDataSet.Customers);
        }
    }
}