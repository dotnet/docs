using System;
using System.Data;
using System.Windows.Forms;

namespace CS
{
    public partial class Form1 : Form
    {
        //---------------------------------------------------------------------
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'northwindDataSet.Customers' table. You can move, or remove it, as needed.

            //<Snippet1>
            this.customersTableAdapter.Fill(this.northwindDataSet.Customers);
            //</Snippet1>

            //<Snippet2>
            customersTableAdapter.Update(northwindDataSet.Customers);
            //</Snippet2>

            //<Snippet3>
            textBox1.Text = northwindDataSet.Customers[3].ContactName;
            //</Snippet3>


            //<Snippet6>
            string custID = "ALFKI";
            NorthwindDataSet.OrdersRow[] orders;

            orders = (NorthwindDataSet.OrdersRow[])northwindDataSet.Customers.
                FindByCustomerID(custID).GetChildRows("FK_Orders_Customers");

            MessageBox.Show(orders.Length.ToString());
            //</Snippet6>


            //<Snippet7>
            int orderID = 10707;
            NorthwindDataSet.CustomersRow customer;

            customer = (NorthwindDataSet.CustomersRow)northwindDataSet.Orders.
                FindByOrderID(orderID).GetParentRow("FK_Orders_Customers");

            MessageBox.Show(customer.CompanyName); 
            //</Snippet7>
        }


        //---------------------------------------------------------------------
        void TestTyped()
        {
            //<Snippet4>
            // This accesses the CustomerID column in the first row of the Customers table.
            string customerIDValue = northwindDataSet.Customers[0].CustomerID;
            //</Snippet4>
        }


        //---------------------------------------------------------------------
        void TestUnTyped()
        {
            DataSet dataset1 = new DataSet();
        
            //<Snippet5>
            string customerIDValue = (string)
                dataset1.Tables["Customers"].Rows[0]["CustomerID"];
            //</Snippet5>
        }


        //---------------------------------------------------------------------
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
    }
}