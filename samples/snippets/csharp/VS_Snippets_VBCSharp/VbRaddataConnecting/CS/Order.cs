//<Snippet2>
using System;

namespace ObjectBindingWalkthrough
{
    /// <summary>
    /// A single order
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Creates a new order
        /// </summary>
        public Order()
        {
        }

        /// <summary>
        /// Creates a new order
        /// </summary>
        /// <param name="orderid"></param>
        /// <param name="customerID"></param>
        /// <param name="employeeID"></param>
        /// <param name="orderDate"></param>
        /// <param name="requiredDate"></param>
        /// <param name="shippedDate"></param>
        /// <param name="shipVia"></param>
        /// <param name="freight"></param>
        /// <param name="shipName"></param>
        /// <param name="shipAddress"></param>
        /// <param name="shipCity"></param>
        /// <param name="shipRegion"></param>
        /// <param name="shipPostalCode"></param>
        /// <param name="shipCountry"></param>
        public Order(int orderid, string customerID,
           Nullable<int> employeeID, Nullable<DateTime> orderDate,
           Nullable<DateTime> requiredDate, Nullable<DateTime> shippedDate,
           Nullable<int> shipVia, Nullable<decimal> freight,
           string shipName, string shipAddress,
           string shipCity, string shipRegion,
           string shipPostalCode, string shipCountry)
        {

        }

        private int orderIDValue;
        /// <summary>
        /// The ID that uniquely identifies this order
        /// </summary>
        public int OrderID
        {
            get { return orderIDValue; }
            set { orderIDValue = value; }
        }

        private string customerIDValue;
        /// <summary>
        /// The customer who placed this order
        /// </summary>
        public string CustomerID
        {
            get { return customerIDValue; }
            set { customerIDValue = value; }
        }

        private Nullable<int> employeeIDValue;
        /// <summary>
        /// The ID of the employee who took this order
        /// </summary>
        public Nullable<int> EmployeeID
        {
            get { return employeeIDValue; }
            set { employeeIDValue = value; }
        }

        private Nullable<DateTime> orderDateValue;
        /// <summary>
        /// The date this order was placed
        /// </summary>
        public Nullable<DateTime> OrderDate
        {
            get { return orderDateValue; }
            set { orderDateValue = value; }
        }

        private Nullable<DateTime> requiredDateValue;
        /// <summary>
        /// The date this order is required
        /// </summary>
        public Nullable<DateTime> RequiredDate
        {
            get { return requiredDateValue; }
            set { requiredDateValue = value; }
        }

        private Nullable<DateTime> shippedDateValue;
        /// <summary>
        /// The date this order was shipped
        /// </summary>
        public Nullable<DateTime> ShippedDate
        {
            get { return shippedDateValue; }
            set { shippedDateValue = value; }
        }

        private Nullable<int> shipViaValue;
        /// <summary>
        /// The shipping method of this order
        /// </summary>
        public Nullable<int> ShipVia
        {
            get { return shipViaValue; }
            set { shipViaValue = value; }
        }

        private Nullable<decimal> freightValue;
        /// <summary>
        /// The freight charge for this order
        /// </summary>
        public Nullable<decimal> Freight
        {
            get { return freightValue; }
            set { freightValue = value; }
        }

        private string shipNameValue;
        /// <summary>
        /// The name of the recipient for this order
        /// </summary>
        public string ShipName
        {
            get { return shipNameValue; }
            set { shipNameValue = value; }
        }

        private string shipAddressValue;
        /// <summary>
        /// The address to ship this order to
        /// </summary>
        public string ShipAddress
        {
            get { return shipAddressValue; }
            set { shipAddressValue = value; }
        }

        private string shipCityValue;
        /// <summary>
        /// The city to ship this order to
        /// </summary>
        public string ShipCity
        {
            get { return shipCityValue; }
            set { shipCityValue = value; }
        }

        private string shipRegionValue;
        /// <summary>
        /// The region to ship this order to
        /// </summary>
        public string ShipRegion
        {
            get { return shipRegionValue; }
            set { shipRegionValue = value; }
        }

        private string shipPostalCodeValue;
        /// <summary>
        /// The postal code to ship this order to
        /// </summary>
        public string ShipPostalCode
        {
            get { return shipPostalCodeValue; }
            set { shipPostalCodeValue = value; }
        }

        private string shipCountryValue;
        /// <summary>
        /// The country to ship this order to
        /// </summary>
        public string ShipCountry
        {
            get { return shipCountryValue; }
            set { shipCountryValue = value; }
        }

    }


    /// <summary>
    /// A collection of Order objects
    /// </summary>
    class Orders : System.ComponentModel.BindingList<Order>
    {

    }
}
//</Snippet2>
