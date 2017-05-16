// REDMOND\glennha
//<Snippet1>
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

// This class represents a very simple keyed list of OrderItems,
// inheriting most of its behavior from the KeyedCollection and 
// Collection classes. The immediate base class is the constructed
// type KeyedCollection<int, OrderItem>. When you inherit
// from KeyedCollection, the second generic type argument is the 
// type that you want to store in the collection -- in this case
// OrderItem. The first type argument is the type that you want
// to use as a key. Its values must be calculated from OrderItem; 
// in this case it is the int field PartNumber, so SimpleOrder
// inherits KeyedCollection<int, OrderItem>.
//
public class SimpleOrder : KeyedCollection<int, OrderItem>
{
       
    // This is the only method that absolutely must be overridden,
    // because without it the KeyedCollection cannot extract the
    // keys from the items. The input parameter type is the 
    // second generic type argument, in this case OrderItem, and 
    // the return value type is the first generic type argument,
    // in this case int.
    //
    protected override int GetKeyForItem(OrderItem item)
    {
        // In this example, the key is the part number.
        return item.PartNumber;
    }
}

public class Demo
{    
    public static void Main()
    {
        SimpleOrder weekly = new SimpleOrder();

        // The Add method, inherited from Collection, takes OrderItem.
        //
        weekly.Add(new OrderItem(110072674, "Widget", 400, 45.17));
        weekly.Add(new OrderItem(110072675, "Sprocket", 27, 5.3));
        weekly.Add(new OrderItem(101030411, "Motor", 10, 237.5));
        weekly.Add(new OrderItem(110072684, "Gear", 175, 5.17));
        
        Display(weekly);
    
        // The Contains method of KeyedCollection takes the key, 
        // type, in this case int.
        //
        Console.WriteLine("\nContains(101030411): {0}", 
            weekly.Contains(101030411));

        // The default Item property of KeyedCollection takes a key.
        //
        Console.WriteLine("\nweekly[101030411].Description: {0}", 
            weekly[101030411].Description);

        // The Remove method of KeyedCollection takes a key.
        //
        Console.WriteLine("\nRemove(101030411)");
        weekly.Remove(101030411);
        Display(weekly);

        // The Insert method, inherited from Collection, takes an 
        // index and an OrderItem.
        //
        Console.WriteLine("\nInsert(2, New OrderItem(...))");
        weekly.Insert(2, new OrderItem(111033401, "Nut", 10, .5));
        Display(weekly);

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

        // The IndexOf method inherited from Collection<OrderItem> 
        // takes an OrderItem instead of a key
        // 
        Console.WriteLine("\nIndexOf(temp): {0}", weekly.IndexOf(temp));

        // The inherited Remove method also takes an OrderItem.
        //
        Console.WriteLine("\nRemove(temp)");
        weekly.Remove(temp);
        Display(weekly);

        Console.WriteLine("\nRemoveAt(0)");
        weekly.RemoveAt(0);
        Display(weekly);

    }
    
    private static void Display(SimpleOrder order)
    {
        Console.WriteLine();
        foreach( OrderItem item in order )
        {
            Console.WriteLine(item);
        }
    }
}

// This class represents a simple line item in an order. All the 
// values are immutable except quantity.
// 
public class OrderItem
{
    public readonly int PartNumber;
    public readonly string Description;
    public readonly double UnitPrice;
    
    private int _quantity = 0;
    
    public OrderItem(int partNumber, string description, 
        int quantity, double unitPrice)
    {
        this.PartNumber = partNumber;
        this.Description = description;
        this.Quantity = quantity;
        this.UnitPrice = unitPrice;
    } 
    
    public int Quantity    
    {
        get { return _quantity; }
        set
        {
            if (value<0)
                throw new ArgumentException("Quantity cannot be negative.");
            
            _quantity = value;
        }
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

110072674    400 Widget       at    45.17 =  18,068.00
110072675     27 Sprocket     at     5.30 =     143.10
101030411     10 Motor        at   237.50 =   2,375.00
110072684    175 Gear         at     5.17 =     904.75

Contains(101030411): True

weekly[101030411].Description: Motor

Remove(101030411)

110072674    400 Widget       at    45.17 =  18,068.00
110072675     27 Sprocket     at     5.30 =     143.10
110072684    175 Gear         at     5.17 =     904.75

Insert(2, New OrderItem(...))

110072674    400 Widget       at    45.17 =  18,068.00
110072675     27 Sprocket     at     5.30 =     143.10
111033401     10 Nut          at      .50 =       5.00
110072684    175 Gear         at     5.17 =     904.75

coweekly[2].Description: Nut

coweekly[2] = new OrderItem(...)

IndexOf(temp): 2

Remove(temp)

110072674    400 Widget       at    45.17 =  18,068.00
110072675     27 Sprocket     at     5.30 =     143.10
110072684    175 Gear         at     5.17 =     904.75

RemoveAt(0)

110072675     27 Sprocket     at     5.30 =     143.10
110072684    175 Gear         at     5.17 =     904.75
 */
//</Snippet1>


