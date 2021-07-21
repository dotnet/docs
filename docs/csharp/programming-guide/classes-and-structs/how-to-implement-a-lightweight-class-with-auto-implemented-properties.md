---
title: "How to implement a lightweight class with auto-implemented properties - C# Programming Guide"
description: Learn how to create an immutable lightweight class in C# that encapsulates auto-implemented properties. There are two implementation approaches.
ms.date: 07/20/2015
helpviewer_keywords:
  - "auto-implemented properties [C#]"
  - "properties [C#], auto-implemented"
ms.topic: how-to
ms.custom: contperf-fy21q2
ms.assetid: 1dc5a8ad-a4f7-4f32-8506-3fc6d8c8bfed
---
# How to implement a lightweight class with auto-implemented properties (C# Programming Guide)

This example shows how to create an immutable lightweight class that serves only to encapsulate a set of auto-implemented properties. Use this kind of construct instead of a struct when you must use reference type semantics.

You can make an immutable property in the following ways:

- Declare only the [get](../../language-reference/keywords/get.md) accessor, which makes the property immutable everywhere except in the type's constructor.

- Declare an [init](../../language-reference/keywords/init.md) accessor instead of a `set` accessor, which makes the property settable only in the constructor or by using an [object initializer](object-and-collection-initializers.md).

- Declare the [set](../../language-reference/keywords/set.md) accessor to be [private](../../language-reference/keywords/private.md).  The property is settable within the type, but it is immutable to consumers.

  When you declare a private `set` accessor, you cannot use an object initializer to initialize the property. You must use a constructor or a factory method.

The following example shows how a property with only get accessor differs than one with get and private set.

```csharp
class Contact
{
    public string Name { get; }
    public string Address { get; private set; }

    public Contact(string contactName, string contactAddress)
    {
        // Both properties are accessible in the constructor.
        Name = contactName;
        Address = contactAddress;
    }

    // Name isn't assignable here. This will generate a compile error.
    //public void ChangeName(string newName) => Name = newName;

    // Address is assignable here.
    public void ChangeAddress(string newAddress) => Address = newAddress;
}
```

## Example

The following example shows two ways to implement an immutable class that has auto-implemented properties. Each way declares one of the properties with a private `set` and one of the properties with a `get` only.  The first class uses a constructor only to initialize the properties, and the second class uses a static factory method that calls a constructor.

```csharp
// This class is immutable. After an object is created,
// it cannot be modified from outside the class. It uses a
// constructor to initialize its properties.
class Contact
{
    // Read-only property.
    public string Name { get; }

    // Read-write property with a private set accessor.
    public string Address { get; private set; }

    // Public constructor.
    public Contact(string contactName, string contactAddress)
    {
        Name = contactName;
        Address = contactAddress;
    }
}

// This class is immutable. After an object is created,
// it cannot be modified from outside the class. It uses a
// static method and private constructor to initialize its properties.
public class Contact2
{
    // Read-write property with a private set accessor.
    public string Name { get; private set; }

    // Read-only property.
    public string Address { get; }

    // Private constructor.
    private Contact2(string contactName, string contactAddress)
    {
        Name = contactName;
        Address = contactAddress;
    }

    // Public factory method.
    public static Contact2 CreateContact(string name, string address)
    {
        return new Contact2(name, address);
    }
}

public class Program
{
    static void Main()
    {
        // Some simple data sources.
        string[] names = {"Terry Adams","Fadi Fakhouri", "Hanying Feng",
                            "Cesar Garcia", "Debra Garcia"};
        string[] addresses = {"123 Main St.", "345 Cypress Ave.", "678 1st Ave",
                                "12 108th St.", "89 E. 42nd St."};

        // Simple query to demonstrate object creation in select clause.
        // Create Contact objects by using a constructor.
        var query1 = from i in Enumerable.Range(0, 5)
                    select new Contact(names[i], addresses[i]);

        // List elements cannot be modified by client code.
        var list = query1.ToList();
        foreach (var contact in list)
        {
            Console.WriteLine("{0}, {1}", contact.Name, contact.Address);
        }

        // Create Contact2 objects by using a static factory method.
        var query2 = from i in Enumerable.Range(0, 5)
                        select Contact2.CreateContact(names[i], addresses[i]);

        // Console output is identical to query1.
        var list2 = query2.ToList();

        // List elements cannot be modified by client code.
        // CS0272:
        // list2[0].Name = "Eugene Zabokritski";

        // Keep the console open in debug mode.
        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
}

/* Output:
    Terry Adams, 123 Main St.
    Fadi Fakhouri, 345 Cypress Ave.
    Hanying Feng, 678 1st Ave
    Cesar Garcia, 12 108th St.
    Debra Garcia, 89 E. 42nd St.
*/
```

The compiler creates backing fields for each auto-implemented property. The fields are not accessible directly from source code.

## See also

- [Properties](./properties.md)
- [struct](../../language-reference/builtin-types/struct.md)
- [Object and Collection Initializers](./object-and-collection-initializers.md)
