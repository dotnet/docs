---
title: Atomized XName and XNamespace objects - LINQ to XML
description: Learn how atomized XName and XNamespace objects of the same name share an instance.
ms.date: 07/20/2015
dev_langs:
  - "csharp"
  - "vb"
ms.assetid: a5b21433-b49d-415c-b00e-bcbfb0d267d7
ms.topic: article
---

# Atomized XName and XNamespace objects (LINQ to XML)

<xref:System.Xml.Linq.XName> and <xref:System.Xml.Linq.XNamespace> objects are *atomized*; that is, if they contain the same qualified name, they refer to the same object. This yields performance benefits for queries: when you compare two atomized names for equality, the underlying intermediate language only has to determine whether the two references point to the same object. The underlying code doesn't have to do string comparisons, which would take longer.

## Atomization semantics

Atomization means that if two <xref:System.Xml.Linq.XName> objects have the same local name, and they're in the same namespace, they share the same instance. In the same way, if two <xref:System.Xml.Linq.XNamespace> objects have the same namespace URI, they share the same instance.

For a class to enable atomized objects, the constructor for the class must be private, not public. This is because if the constructor were public, you could create a non-atomized object. The <xref:System.Xml.Linq.XName> and <xref:System.Xml.Linq.XNamespace> classes implement an implicit conversion operator to convert a string into an <xref:System.Xml.Linq.XName> or <xref:System.Xml.Linq.XNamespace>. This is how you get an instance of these objects. You can't get an instance by using a constructor, because the constructor is inaccessible.

<xref:System.Xml.Linq.XName> and <xref:System.Xml.Linq.XNamespace> also implement the equality and inequality operators, which determine whether the two objects being compared are references to the same instance.

## Example: Create objects and show that identical names share an instance

The following code creates some <xref:System.Xml.Linq.XElement> objects and demonstrates that identical names share the same instance.

```csharp
var r1 = new XElement("Root", "data1");
XElement r2 = XElement.Parse("<Root>data2</Root>");

if ((object)r1.Name == (object)r2.Name)
    Console.WriteLine("r1 and r2 have names that refer to the same instance.");
else
    Console.WriteLine("Different");

XName n = "Root";

if ((object)n == (object)r1.Name)
    Console.WriteLine("The name of r1 and the name in 'n' refer to the same instance.");
else
    Console.WriteLine("Different");
```

```vb
Dim r1 As New XElement("Root", "data1")
Dim r2 As XElement = XElement.Parse("<Root>data2</Root>")

If DirectCast(r1.Name, Object) = DirectCast(r2.Name, Object) Then
    Console.WriteLine("r1 and r2 have names that refer to the same instance.")
Else
    Console.WriteLine("Different")
End If

Dim n As XName = "Root"

If DirectCast(n, Object) = DirectCast(r1.Name, Object) Then
    Console.WriteLine("The name of r1 and the name in 'n' refer to the same instance.")
Else
    Console.WriteLine("Different")
End If
```

This example produces the following output:

```output
r1 and r2 have names that refer to the same instance.
The name of r1 and the name in 'n' refer to the same instance.
```

As mentioned earlier, the benefit of atomized objects is that when you use one of the axis methods that take an <xref:System.Xml.Linq.XName> as a parameter, the axis method only has to determine that two names reference the same instance to select the desired elements.

The following example passes an <xref:System.Xml.Linq.XName> to the <xref:System.Xml.Linq.XContainer.Descendants%2A> method call, which then has better performance because of the atomization pattern.

```csharp
var root = new XElement("Root",
    new XElement("C1", 1),
    new XElement("Z1",
        new XElement("C1", 2),
        new XElement("C1", 1)
    )
);

var query = from e in root.Descendants("C1")
            where (int)e == 1
            select e;

foreach (var z in query)
    Console.WriteLine(z);
```

```vb
Dim root As New XElement("Root", New XElement("C1", 1), New XElement("Z1", New XElement("C1", 2), New XElement("C1", 1)))

Dim query = From e In root.Descendants("C1") Where CInt(e) = 1

For Each z In query
    Console.WriteLine(z)
Next
```

This example produces the following output:

```xml
<C1>1</C1>
<C1>1</C1>
```
