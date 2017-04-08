// REDMOND\glennha
//<Snippet1>
using namespace System;
using namespace System::Collections::Generic;
using namespace System::Collections::ObjectModel;

public enum class ChangeTypes
{
    Added,
    Removed, 
    Replaced, 
    Cleared
};

ref class SimpleOrderChangedEventArgs; 

// This class represents a simple line item in an order. All the 
// values are immutable except quantity.
// 
public ref class OrderItem
{
private:
    int _quantity;

public:
    initonly int PartNumber;
    initonly String^ Description;
    initonly double UnitPrice;
        
    OrderItem(int partNumber, String^ description, int quantity, 
        double unitPrice)
    {
        this->PartNumber = partNumber;
        this->Description = description;
        this->Quantity = quantity;
        this->UnitPrice = unitPrice;
    };
    
    property int Quantity    
    {
        int get() { return _quantity; };
        void set(int value)
        {
            if (value < 0)
                throw gcnew ArgumentException("Quantity cannot be negative.");
            
            _quantity = value;
        };
    };
        
    virtual String^ ToString() override 
    {
        return String::Format(
            "{0,9} {1,6} {2,-12} at {3,8:#,###.00} = {4,10:###,###.00}", 
            PartNumber, _quantity, Description, UnitPrice, 
            UnitPrice * _quantity);
    };
};

// Event argument for the Changed event.
//
public ref class SimpleOrderChangedEventArgs : EventArgs
{
public:
    OrderItem^ ChangedItem;
    initonly ChangeTypes ChangeType;
    OrderItem^ ReplacedWith;

    SimpleOrderChangedEventArgs(ChangeTypes change, 
        OrderItem^ item, OrderItem^ replacement)
    {
        this->ChangeType = change;
        this->ChangedItem = item;
        this->ReplacedWith = replacement;
    }
};

// This class derives from KeyedCollection and shows how to override
// the protected ClearItems, InsertItem, RemoveItem, and SetItem 
// methods in order to change the behavior of the default Item 
// property and the Add, Clear, Insert, and Remove methods. The
// class implements a Changed event, which is raised by all the
// protected methods.
//
// SimpleOrder is a collection of OrderItem objects, and its key
// is the PartNumber field of OrderItem-> PartNumber is an Integer,
// so SimpleOrder inherits KeyedCollection<int, OrderItem>.
// (Note that the key of OrderItem cannot be changed; if it could 
// be changed, SimpleOrder would have to override ChangeItemKey.)
//
public ref class SimpleOrder : KeyedCollection<int, OrderItem^>
{
public:
    event EventHandler<SimpleOrderChangedEventArgs^>^ Changed;

    // This parameterless constructor calls the base class constructor
    // that specifies a dictionary threshold of 0, so that the internal
    // dictionary is created as soon as an item is added to the 
    // collection.
    //
    SimpleOrder() : KeyedCollection<int, OrderItem^>(nullptr, 0) {};
    
    // This is the only method that absolutely must be overridden,
    // because without it the KeyedCollection cannot extract the
    // keys from the items. 
    //
protected:
    virtual int GetKeyForItem(OrderItem^ item) override
    {
        // In this example, the key is the part number.
        return item->PartNumber;
    }

    virtual void InsertItem(int index, OrderItem^ newItem) override 
    {
        __super::InsertItem(index, newItem);

        Changed(this, gcnew SimpleOrderChangedEventArgs(
            ChangeTypes::Added, newItem, nullptr));
    }

    //<Snippet3>
    virtual void SetItem(int index, OrderItem^ newItem) override 
    {
        OrderItem^ replaced = this->Items[index];
        __super::SetItem(index, newItem);

        Changed(this, gcnew SimpleOrderChangedEventArgs(
            ChangeTypes::Replaced, replaced, newItem));
    }
    //</Snippet3>

    virtual void RemoveItem(int index) override 
    {
        OrderItem^ removedItem = Items[index];
        __super::RemoveItem(index);

        Changed(this, gcnew SimpleOrderChangedEventArgs(
            ChangeTypes::Removed, removedItem, nullptr));
    }

    virtual void ClearItems() override 
    {
        __super::ClearItems();

        Changed(this, gcnew SimpleOrderChangedEventArgs(
            ChangeTypes::Cleared, nullptr, nullptr));
    }

    //<Snippet2>
    // This method uses the internal reference to the dictionary
    // to test fo
public:
    void AddOrMerge(OrderItem^ newItem)
    {

        int key = this->GetKeyForItem(newItem);
        OrderItem^ existingItem = nullptr;

        // The dictionary is not created until the first item is 
        // added, so it is necessary to test for null. Using 
        // AndAlso ensures that TryGetValue is not called if the
        // dictionary does not exist.
        //
        if (this->Dictionary != nullptr && 
            this->Dictionary->TryGetValue(key, existingItem))
        {
            existingItem->Quantity += newItem->Quantity;
        }
        else
        {
            this->Add(newItem);
        }
    }
    //</Snippet2>
};

public ref class Demo
{    
public:
    static void Main()
    {
        SimpleOrder^ weekly = gcnew SimpleOrder();
        weekly->Changed += gcnew 
            EventHandler<SimpleOrderChangedEventArgs^>(ChangedHandler);

        // The Add method, inherited from Collection, takes OrderItem->
        //
        weekly->Add(gcnew OrderItem(110072674, "Widget", 400, 45.17));
        weekly->Add(gcnew OrderItem(110072675, "Sprocket", 27, 5.3));
        weekly->Add(gcnew OrderItem(101030411, "Motor", 10, 237.5));
        weekly->Add(gcnew OrderItem(110072684, "Gear", 175, 5.17));

        Display(weekly);
        
        // The Contains method of KeyedCollection takes TKey.
        //
        Console::WriteLine("\nContains(101030411): {0}", 
            weekly->Contains(101030411));

        // The default Item property of KeyedCollection takes the key
        // type, Integer. The property is read-only.
        //
        Console::WriteLine("\nweekly[101030411]->Description: {0}", 
            weekly[101030411]->Description);

        // The Remove method of KeyedCollection takes a key.
        //
        Console::WriteLine("\nRemove(101030411)");
        weekly->Remove(101030411);

        // The Insert method, inherited from Collection, takes an 
        // index and an OrderItem.
        //
        Console::WriteLine("\nInsert(2, gcnew OrderItem(...))");
        weekly->Insert(2, gcnew OrderItem(111033401, "Nut", 10, .5));
         
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
        Collection<OrderItem^>^ coweekly = weekly;
        Console::WriteLine("\ncoweekly[2].Description: {0}", 
            coweekly[2]->Description);
 
        Console::WriteLine("\ncoweekly[2] = gcnew OrderItem(...)");
        coweekly[2] = gcnew OrderItem(127700026, "Crank", 27, 5.98);

        OrderItem^ temp = coweekly[2];

        // The IndexOf method, inherited from Collection<OrderItem>, 
        // takes an OrderItem instead of a key.
        // 
        Console::WriteLine("\nIndexOf(temp): {0}", weekly->IndexOf(temp));

        // The inherited Remove method also takes an OrderItem->
        //
        Console::WriteLine("\nRemove(temp)");
        weekly->Remove(temp);

        Console::WriteLine("\nRemoveAt(0)");
        weekly->RemoveAt(0);

        weekly->AddOrMerge(gcnew OrderItem(110072684, "Gear", 1000, 5.17));

        Display(weekly);

        Console::WriteLine();
        weekly->Clear();
    }
    
private:
    static void Display(SimpleOrder^ order)
    {
        Console::WriteLine();
        for each( OrderItem^ item in order )
        {
            Console::WriteLine(item);
        }
    }

    static void ChangedHandler(Object^ source, 
        SimpleOrderChangedEventArgs^ e)
    {
        OrderItem^ item = e->ChangedItem;

        if (e->ChangeType == ChangeTypes::Replaced)
        {
            OrderItem^ replacement = e->ReplacedWith;

            Console::WriteLine("{0} (quantity {1}) was replaced " +
                "by {2}, (quantity {3}).", item->Description, 
                item->Quantity, replacement->Description, 
                replacement->Quantity);
        }
        else if(e->ChangeType == ChangeTypes::Cleared)
        {
            Console::WriteLine("The order list was cleared.");
        }
        else
        {
            Console::WriteLine("{0} (quantity {1}) was {2}.", 
                item->Description, item->Quantity, e->ChangeType);
        }
    }
};

void main()
{
    Demo::Main();
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

weekly[101030411]->Description: Motor

Remove(101030411)
Motor (quantity 10) was Removed.

Insert(2, gcnew OrderItem(...))
Nut (quantity 10) was Added.

coweekly[2].Description: Nut

coweekly[2] = gcnew OrderItem(...)
Nut (quantity 10) was replaced by Crank, (quantity 27).

IndexOf(temp): 2

Remove(temp)
Crank (quantity 27) was Removed.

RemoveAt(0)
Widget (quantity 400) was Removed.

110072675     27 Sprocket     at     5.30 =     143.10
110072684   1175 Gear         at     5.17 =   6,074.75

The order list was cleared.
 */
//</Snippet1>


