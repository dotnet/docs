---
title: In-memory XML tree modification vs. functional construction - LINQ to XML
description: See examples of two different approaches to modifying XML trees.
ms.date: 07/20/2015
dev_langs:
  - "csharp"
  - "vb"
ms.assetid: b5afc31d-a325-4ec6-bf17-0ff90a20ffca
ms.topic: article
---

# In-memory XML tree modification vs. functional construction (LINQ to XML)

Modifying an XML tree in place is a traditional approach to changing the shape of an XML document. A typical application loads a document into a data store such as DOM or LINQ to XML; uses a programming interface to insert or delete nodes, or change their content; and then saves the XML to a file or transmits it over a network.

LINQ to XML enables another approach that is useful in many scenarios: *functional construction*. Functional construction treats modifying data as a problem of transformation, rather than as detailed manipulation of a data store. If you can take a representation of data and transform it efficiently from one form to another, the result is the same as if you took one data store and manipulated it in some way to take another shape. A key to the functional construction approach is to pass the results of queries to <xref:System.Xml.Linq.XDocument> and <xref:System.Xml.Linq.XElement> constructors.

In many cases you can write the transformational code in a fraction of the time that it would take to manipulate the data store, and the resulting code is more robust and easier to maintain. In these cases, even though the transformational approach can take more processing power, it's a more effective way to modify data. If a developer is familiar with the functional approach, the resulting code in many cases is easier to understand, and it's easy to find the code that modifies each part of the tree.

The approach where you modify an XML tree in place is more familiar to many DOM programmers, whereas code written using the functional approach might look unfamiliar to a developer who doesn't yet understand that approach. If you have to only make a small modification to a large XML tree, the approach where you modify a tree in place in many cases will take less CPU time.

This article provides examples of both approaches. Suppose you want to modify the following simple XML document so that the attributes become elements:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<Root Data1="123" Data2="456">
  <Child1>Content</Child1>
</Root>
```

The first of the following examples uses the traditional in-place modification approach, and the second uses the functional construction approach.

## Example: Transform attributes into elements with the traditional in-place approach

You can write some procedural code to create elements from the attributes, and then delete the attributes, as follows:

```csharp
XElement root = XElement.Load("Data.xml");
foreach (XAttribute att in root.Attributes()) {
    root.Add(new XElement(att.Name, (string)att));
}
root.Attributes().Remove();
Console.WriteLine(root);
```

```vb
Dim root As XElement = XElement.Load("Data.xml")
For Each att As XAttribute In root.Attributes()
    root.Add(New XElement(att.Name, att.Value))
Next
root.Attributes().Remove()
Console.WriteLine(root)
```

This example produces the following output:

```xml
<Root>
  <Child1>Content</Child1>
  <Data1>123</Data1>
  <Data2>456</Data2>
</Root>
```

## Example: Transform attributes into elements with the functional construction approach

By contrast, a functional approach consists of code to form a new tree, picking and choosing elements and attributes from the source tree, and transforming them as appropriate as they're added to the new tree.

```csharp
XElement root = XElement.Load("Data.xml");
XElement newTree = new XElement("Root",
    root.Element("Child1"),
    from att in root.Attributes()
    select new XElement(att.Name, (string)att)
);
Console.WriteLine(newTree);
```

```vb
Dim root As XElement = XElement.Load("Data.xml")
Dim newTree As XElement = _
    <Root>
        <%= root.<Child1> %>
        <%= From att In root.Attributes() _
            Select New XElement(att.Name, att.Value) %>
    </Root>
Console.WriteLine(newTree)
```

This example outputs the same XML as the first example. However, notice that you can actually see the resulting structure of the new XML in the functional approach. You can see the creation of the `Root` element, the code that pulls the `Child1` element from the source tree, and the code that transforms the attributes from the source tree to elements in the new tree.

The functional example in this case is neither shorter nor simpler than the first example. However, if you have many changes to make to an XML tree, the procedural approach will become quite complex and somewhat obtuse. In contrast, when using the functional approach, you still just form the desired XML, embedding queries and expressions as appropriate, to pull in the desired content. The functional approach yields code that is easier to maintain.

Notice that in this case the functional approach probably would not perform quite as well as the tree manipulation approach. The main issue is that the functional approach creates more short-lived objects. However, the tradeoff is an effective one if using the functional approach allows for greater programmer productivity.

This is a very simple example, but it serves to show the difference in philosophy between the two approaches. The functional approach yields greater productivity gains for transforming larger XML documents.
