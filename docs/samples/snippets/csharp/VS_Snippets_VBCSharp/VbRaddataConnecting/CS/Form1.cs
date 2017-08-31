//<Snippet3>
using System;
using System.Windows.Forms;

namespace ObjectBindingWalkthrough
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        //<Snippet4>
        private void LoadCustomers()
        {
            NorthwindDataSet.CustomersDataTable customerData = 
                customersTableAdapter1.GetTop5Customers();
            
            foreach (NorthwindDataSet.CustomersRow customerRow in customerData)
            {
                Customer currentCustomer = new Customer();
                currentCustomer.CustomerID = customerRow.CustomerID;
                currentCustomer.CompanyName = customerRow.CompanyName;

                if (customerRow.IsAddressNull() == false)
                {
                    currentCustomer.Address = customerRow.Address;
                }

                if (customerRow.IsCityNull() == false)
                {
                    currentCustomer.City = customerRow.City;
                }

                if (customerRow.IsContactNameNull() == false)
                {
                    currentCustomer.ContactName = customerRow.ContactName;
                }

                if (customerRow.IsContactTitleNull() == false)
                {
                    currentCustomer.ContactTitle = customerRow.ContactTitle;
                }

                if (customerRow.IsCountryNull() == false)
                {
                    currentCustomer.Country = customerRow.Country;
                }

                if (customerRow.IsFaxNull() == false)
                {
                    currentCustomer.Fax = customerRow.Fax;
                }

                if (customerRow.IsPhoneNull() == false)
                {
                    currentCustomer.Phone = customerRow.Phone;
                }

                if (customerRow.IsPostalCodeNull() == false)
                {
                    currentCustomer.PostalCode = customerRow.PostalCode;
                }

                if (customerRow.IsRegionNull() == false)
                {
                    currentCustomer.Region = customerRow.Region;
                }

                LoadOrders(currentCustomer);
                customerBindingSource.Add(currentCustomer);
            }
        }
        //</Snippet4>


        private void LoadOrders(Customer currentCustomer)
        {
            NorthwindDataSet.OrdersDataTable orderData = 
                ordersTableAdapter1.GetDataByCustomerID(currentCustomer.CustomerID);

            foreach (NorthwindDataSet.OrdersRow orderRow in orderData)
            {
                Order currentOrder = new Order();
                currentOrder.OrderID = orderRow.OrderID;

                if (orderRow.IsCustomerIDNull() == false)
                {
                    currentOrder.CustomerID = orderRow.CustomerID;
                }

                if (orderRow.IsEmployeeIDNull() == false)
                {
                    currentOrder.EmployeeID = orderRow.EmployeeID;
                }

                if (orderRow.IsFreightNull() == false)
                {
                    currentOrder.Freight = orderRow.Freight;
                }

                if (orderRow.IsOrderDateNull() == false)
                {
                    currentOrder.OrderDate = orderRow.OrderDate;
                }

                if (orderRow.IsRequiredDateNull() == false)
                {
                    currentOrder.RequiredDate = orderRow.RequiredDate;
                }

                if (orderRow.IsShipAddressNull() == false)
                {
                    currentOrder.ShipAddress = orderRow.ShipAddress;
                }

                if (orderRow.IsShipCityNull() == false)
                {
                    currentOrder.ShipCity = orderRow.ShipCity;
                }

                if (orderRow.IsShipCountryNull() == false)
                {
                    currentOrder.ShipCountry = orderRow.ShipCountry;
                }

                if (orderRow.IsShipNameNull() == false)
                {
                    currentOrder.ShipName = orderRow.ShipName;
                }

                if (orderRow.IsShippedDateNull() == false)
                {
                    currentOrder.ShippedDate = orderRow.ShippedDate;
                }

                if (orderRow.IsShipPostalCodeNull() == false)
                {
                    currentOrder.ShipPostalCode = orderRow.ShipPostalCode;
                }

                if (orderRow.IsShipRegionNull() == false)
                {
                    currentOrder.ShipRegion = orderRow.ShipRegion;
                }

                if (orderRow.IsShipViaNull() == false)
                {
                    currentOrder.ShipVia = orderRow.ShipVia;
                }
                currentCustomer.Orders.Add(currentOrder);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadCustomers();
        }

    }
}
//</Snippet3>
