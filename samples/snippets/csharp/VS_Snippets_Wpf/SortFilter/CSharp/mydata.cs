using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Data;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace SDKSample
{
  // Create the collection of Order objects
  public class Orders: ObservableCollection<Order>
  {
    public Order o1 = new Order(1001, 5682, "Blue Sweater", 44, "Yes", new DateTime(2003, 1, 23), new DateTime(2003, 2, 4));
    public Order o2 = new Order(1002, 2211, "Gray Jacket Long", 181, "No", new DateTime(2003, 2, 14));
    public Order o3 = new Order(1003, 5682, "Brown Pant W", 02, "Yes", new DateTime(2002, 12, 20), new DateTime(2003, 1, 13));
    public Order o4 = new Order(1004, 3143, "Orange T-shirt", 205, "No", new DateTime(2003, 1, 28));
    public Orders():base()
  	{
  		Add(o1);
  		Add(o2);
  		Add(o3);
  		Add(o4);
  	}
  }

  public class Order : INotifyPropertyChanged
  {
    private int _order;
    private int _customer;
    private string _name;
    private int _id;
    private string _filled;
    private DateTime _orderdate;
    private DateTime _datefilled;

    public int OrderItem
    {
      get{ return _order;}
      set{ _order=value; OnPropertyChanged("OrderItem");}
    }
    public int Customer
    {
      get{ return _customer;}
      set{_customer=value; OnPropertyChanged("Customer");}
    }
    public string Name
    {
      get{ return _name;}
      set{_name=value; OnPropertyChanged("Name");}
    }
    public int Id
    {
      get{ return _id;}
      set{_id=value; OnPropertyChanged("Id");}
    }
    public string Filled
    {
      get{ return _filled;}
      set{ _filled=value; OnPropertyChanged("Filled");}
    }
    public DateTime OrderDate
    {
      get{ return _orderdate;}
      set{ _orderdate=value; OnPropertyChanged("OrderDate");}
    }
    public DateTime DateFilled
    {
      get{ return _datefilled;}
      set{ _datefilled=value; OnPropertyChanged("DateFilled");}
    }
    public Order(int _order, int _customer, string _name, int _id, string _filled, DateTime _orderdate, DateTime _datefilled)
    {
      this.OrderItem = _order;
      this.Customer = _customer;
      this.Name  = _name;
      this.Id = _id;
      this.Filled = _filled;
      this.OrderDate = _orderdate;
      this.DateFilled = _datefilled;
    }
    public Order(int _order, int _customer, string _name, int _id, string _filled, DateTime _orderdate)
    {
      this.OrderItem = _order;
      this.Customer = _customer;
      this.Name  = _name;
      this.Id = _id;
      this.Filled = _filled;
      this.OrderDate = _orderdate;
    }

    public event PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChanged(String info)
    {
        PropertyChangedEventHandler handler = PropertyChanged;
        if (handler != null)
            handler(this, new PropertyChangedEventArgs(info));
    }
  }
}
