using System;
using System.Collections.Generic;
using System.Text;

namespace CS
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
         int employeeID, DateTime orderDate,
         DateTime requiredDate, DateTime shippedDate,
         int shipVia, decimal freight,
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
      
      private int employeeIDValue;
      /// <summary>
      /// The ID of the employee who took this order
      /// </summary>
      public int EmployeeID
      {
      get { return employeeIDValue; }
         set { employeeIDValue = value; }
      }
      
      private DateTime orderDateValue;
      /// <summary>
      /// The date this order was placed
      /// </summary>
      public DateTime OrderDate
      {
         get { return orderDateValue; }
         set { orderDateValue = value; }
      }
      
      private DateTime requiredDateValue;
      /// <summary>
      /// The date this order is required
      /// </summary>
      public DateTime RequiredDate
      {
         get { return requiredDateValue; }
         set { requiredDateValue = value; }
      }
      
      private DateTime shippedDateValue;
      /// <summary>
      /// The date this order was shipped
      /// </summary>
      public DateTime ShippedDate
      {
         get { return shippedDateValue; }
         set { shippedDateValue = value; }
      }
      
      private int shipViaValue;
      /// <summary>
      /// The shipping method of this order
      /// </summary>
      public int ShipVia
      {
         get { return shipViaValue; }
         set { shipViaValue = value; }
      }
      
      private decimal freightValue;
      /// <summary>
      /// The freight charge for this order
      /// </summary>
      public decimal Freight
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
   class Orders: System.ComponentModel.BindingList<Order>
   {
   
   }

}
