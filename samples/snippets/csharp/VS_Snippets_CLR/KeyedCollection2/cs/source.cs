// REDMOND\glennha
//<Snippet1>
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

// This class derives from KeyedCollection and shows how to override
// the protected ClearItems, InsertItem, RemoveItem, and SetItem 
// methods in order to change the behavior of the default Item 
// property and the Add, Clear, Insert, and Remove methods. The
// class implements a Changed event, which is raised by all the
// protected methods.
//
// SimpleOrder is a collection of OrderItem objects, and its key
// is the PartNumber field of OrderItem. PartNumber is an Integer,
// so SimpleOrder inherits KeyedCollection<int, OrderItem>.
// (Note that the key of OrderItem cannot be changed; if it could 
// be changed, SimpleOrder would have to override ChangeItemKey.)
//
public class SimpleOrder : KeyedCollection<int, OrderItem>
{
    public event EventHandler<SimpleOrderChangedEventArgs> Changed;

    // This parameterless constructor calls the base class constructor
    // that specifies a dictionary threshold of 0, so that the internal
    // dictionary is created as soon as an item is added to the 
    // collection.
    //
    public SimpleOrder() : base(null, 0) {}
    
    // This is the only method that absolutely must be overridden,
    // because without it the KeyedCollection cannot extract the
    // keys from the items. 
    //
    protected override int GetKeyForItem(OrderItem item)
    {
        // In this example, the key is the part number.
        return item.PartNumber;
    }

    protected override void InsertItem(int index, OrderItem newItem)
    {
        base.InsertItem(index, newItem);

        EventHandler<SimpleOrderChangedEventArgs> temp = Changed;
        if (temp != null)
        {
            temp(this, new SimpleOrderChangedEventArgs(
                ChangeType.Added, newItem, null));
        }
    }

    //<Snippet3>
    protected override void SetItem(int index, OrderItem newItem)
    {
        OrderItem replaced = Items[index];
        base.SetItem(index, newItem);

        EventHandler<SimpleOrderChangedEventArgs> temp = Changed;
        if (temp != null)
        {
            temp(this, new SimpleOrderChangedEventArgs(
                ChangeType.Replaced, replaced, newItem));
        }
    }
    //</Snippet3>

    protected override void RemoveItem(int index)
    {
        OrderItem removedItem = Items[index];
        base.RemoveItem(index);

        EventHandler<SimpleOrderChangedEventArgs> temp = Changed;
        if (temp != null)
        {
            temp(this, new SimpleOrderChangedEventArgs(
                ChangeType.Removed, removedItem, null));
        }
    }

    protected override void ClearItems()
    {
        base.ClearItems();

        EventHandler<SimpleOrderChangedEventArgs> temp = Changed;
        if (temp != null)
        {
            temp(this, new SimpleOrderChangedEventArgs(
                ChangeType.Cleared, null, null));
        }
    }
}

// Event argument for the Changed event.
//
public class SimpleOrderChangedEventArgs : EventArgs
{
    private OrderItem _changedItem;
    private ChangeType _changeType;
    private OrderItem _replacedWith;

    public OrderItem ChangedItem { get { return _changedItem; }}
    public ChangeType ChangeType { get { return _changeType; }}
    public OrderItem ReplacedWith { get { return _replacedWith; }}

    public SimpleOrderChangedEventArgs(ChangeType change, 
        OrderItem item, OrderItem replacement)
    {
        _changeType = change;
        _changedItem = item;
        _replacedWith = replacement;
    }
}

public enum ChangeType
{
    Added, 
    Removed, 
    Replaced, 
    Cleared
};

public class Demo
{    
    public static void Main()
    {
        SimpleOrder weekly = new SimpleOrder();
        weekly.Changed += new 
            EventHandler<SimpleOrderChangedEventArgs>(ChangedHandler);

        // The Add method, inherited from Collection, takes OrderItem.
        //
        weekly.Add(new OrderItem(110072674, "Widget", 400, 45.17));
        weekly.Add(new OrderItem(110072675, "Sprocket", 27, 5.3));
        weekly.Add(new OrderItem(101030411, "Motor", 10, 237.5));
        weekly.Add(new OrderItem(110072684, "Gear", 175, 5.17));

        Display(weekly);
        
        // The Contains method of KeyedCollection takes TKey.
        //
        Console.WriteLine("\nContains(101030411): {0}", 
            weekly.Contains(101030411));

        // The default Item property of KeyedCollection takes the key
        // type, Integer. The property is read-only.
        //
        Console.WriteLine("\nweekly[101030411].Description: {0}", 
            weekly[101030411].Description);

        // The Remove method of KeyedCollection takes a key.
        //
        Console.WriteLine("\nRemove(101030411)");
        weekly.Remove(101030411);

        // The Insert method, inherited from Collection, takes an 
        // index and an OrderItem.
        //
        Console.WriteLine("\nInsert(2, new OrderItem(...))");
        weekly.Insert(2, new OrderItem(111033401, "Nut", 10, .5));
         
        // The default Item property is overloaded. One overload comes
        // from KeyedCollection<int, OrderItem>; that overload
        // is read-only, and takes Integer because it retrieves by key. 
        // The other overload comes from Collection<OrderItem>, the 
        // base class of KeyedCollection<int, OrderItem>; it 
        // retrieves by index, so it also takes an Integer. The compiler
        // uses the most-derived overload, from KeyedCollection, so the
        // only way to access SimpleOrder by index is to cast it to
        // Collection<OrderItem>. Otherwise the index is interpreted
        // as a key, and KeyNotFoundException is thrown.
        //
        Collection<OrderItem> coweekly = weekly;
        Console.WriteLine("\ncoweekly[2].Description: {0}", 
            coweekly[2].Description);
 
        Console.WriteLine("\ncoweekly[2] = new OrderItem(...)");
        coweekly[2] = new OrderItem(127700026, "Crank", 27, 5.98);

        OrderItem temp = coweekly[2];

        // The IndexOf method, inherited from Collection<OrderItem>, 
        // takes an OrderItem instead of a key.
        // 
        Console.WriteLine("\nIndexOf(temp): {0}", weekly.IndexOf(temp));

        // The inherited Remove method also takes an OrderItem.
        //
        Console.WriteLine("\nRemove(temp)");
        weekly.Remove(temp);

        Console.WriteLine("\nRemoveAt(0)");
        weekly.RemoveAt(0);

        // Increase the quantity for a line item.
        Console.WriteLine("\ncoweekly(1) = New OrderItem(...)");
        coweekly[1] = new OrderItem(coweekly[1].PartNumber, 
            coweekly[1].Description, coweekly[1].Quantity + 1000, 
            coweekly[1].UnitPrice);

        Display(weekly);

        Console.WriteLine();
        weekly.Clear();
    }
    
    private static void Display(SimpleOrder order)
    {
        Console.WriteLine();
        foreach( OrderItem item in order )
        {
            Console.WriteLine(item);
        }
    }

    private static void ChangedHandler(object source, 
        SimpleOrderChangedEventArgs e)
    {

        OrderItem item = e.ChangedItem;

        if (e.ChangeType==ChangeType.Replaced)
        {
            OrderItem replacement = e.ReplacedWith;

            Console.WriteLine("{0} (quantity {1}) was replaced " +
                "by {2}, (quantity {3}).", item.Description, 
                item.Quantity, replacement.Description, 
                replacement.Quantity);
        }
        else if(e.ChangeType == ChangeType.Cleared)
        {
            Console.WriteLine("The order list was cleared.");
        }
        else
        {
            Console.WriteLine("{0} (quantity {1}) was {2}.", 
                item.Description, item.Quantity, e.ChangeType);
        }
    }
}

// This class represents a simple line item in an order. All the 
// values are immutable except quantity.
// 
public class OrderItem
{
    private int _partNumber;
    private string _description;
    private double _unitPrice;
    private int _quantity;
    
    public int PartNumber { get { return _partNumber; }}
    public string Description { get { return _description; }}
    public double UnitPrice { get { return _unitPrice; }}
    public int Quantity { get { return _quantity; }}
    
    public OrderItem(int partNumber, string description, int quantity, 
        double unitPrice)
    {
        _partNumber = partNumber;
        _description = description;
        _quantity = quantity;
        _unitPrice = unitPrice;
    }
    
    public override string ToString()
    {
        return String.Format(
            "{0,9} {1,6} {2,-12} at {3,8:#,###.00} = {4,10:###,###.00}", 
            PartNumber, _quantity, Description, UnitPrice, 
            UnitPrice * _quantity);
    }
}

/* This code example produces the following output:

Widget (quantity 400) was Added.
Sprocket (quantity 27) was Added.
Motor (quantity 10) was Added.
Gear (quantity 175) was Added.

110072674    400 Widget       at    45.17 =  18,068.00
110072675     27 Sprocket     at     5.30 =     143.10
101030411     10 Motor        at   237.50 =   2,375.00
110072684    175 Gear         at     5.17 =     904.75

Contains(101030411): True

weekly[101030411].Description: Motor

Remove(101030411)
Motor (quantity 10) was Removed.

Insert(2, new OrderItem(...))
Nut (quantity 10) was Added.

coweekly[2].Description: Nut

coweekly[2] = new OrderItem(...)
Nut (quantity 10) was replaced by Crank, (quantity 27).

IndexOf(temp): 2

Remove(temp)
Crank (quantity 27) was Removed.

RemoveAt(0)
Widget (quantity 400) was Removed.

coweekly(1) = New OrderItem(...)
Gear (quantity 175) was replaced by Gear, (quantity 1175).

110072675     27 Sprocket     at     5.30 =     143.10
110072684   1175 Gear         at     5.17 =   6,074.75

The order list was cleared.
 */
//</Snippet1>


