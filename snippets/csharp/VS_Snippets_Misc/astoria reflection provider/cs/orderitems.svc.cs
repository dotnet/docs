//<snippetCustomIQueryable>
using System;
using System.Collections.Generic;
using System.Data.Services;
using System.Data.Services.Common;
using System.Linq;

namespace CustomDataServiceClient
{
    [DataServiceKeyAttribute("OrderId")]
    public class Order
    {
        public int OrderId { get; set; }
        public string Customer { get; set; }
        public IList<Item> Items { get; set; }
    }
    [DataServiceKeyAttribute("Product")]
    public class Item
    {
        public string Product { get; set; }
        public int Quantity { get; set; }
    }
    public partial class OrderItemData
    {
        #region Populate Service Data
        static IList<Order> _orders;
        static IList<Item> _items;
        static OrderItemData()
        {
            _orders = new Order[]{
              new Order(){ OrderId=0, Customer = "Peter Franken", Items = new List<Item>()},
              new Order(){ OrderId=1, Customer = "Ana Trujillo", Items = new List<Item>()}};
            _items = new Item[]{
              new Item(){ Product="Chai", Quantity=10 },
              new Item(){ Product="Chang", Quantity=25 },
              new Item(){ Product="Aniseed Syrup", Quantity = 5 },
              new Item(){ Product="Chef Anton's Cajun Seasoning", Quantity=30}};
            _orders[0].Items.Add(_items[0]);
            _orders[0].Items.Add(_items[1]);
            _orders[1].Items.Add(_items[2]);
            _orders[1].Items.Add(_items[3]);
        }
        #endregion
        public IQueryable<Order> Orders
        {
            get { return _orders.AsQueryable<Order>(); }
        }
        public IQueryable<Item> Items
        {
            get { return _items.AsQueryable<Item>(); }
        }
    }
    public class OrderItems : DataService<OrderItemData>
    {
        // This method is called only once to initialize
        //service-wide policies.
        public static void InitializeService(IDataServiceConfiguration
                                             config)
        {
            config.SetEntitySetAccessRule("Orders", EntitySetRights.All);
            config.SetEntitySetAccessRule("Items", EntitySetRights.All);
        }
    }
}
//</snippetCustomIQueryable>
