---
title: Statically compiled queries - LINQ to XML
description: Learn how LINQ to XML queries gain a performance advantage over XMLDocument by being statically compiled.
ms.date: 07/20/2015
dev_langs:
  - "csharp"
  - "vb"
ms.assetid: 3bf558fe-0705-479d-86d4-00188f5fcf9c
ms.topic: article
---
# Statically compiled queries (LINQ to XML)

One of the most important performance advantages of LINQ to XML, as compared to <xref:System.Xml.XmlDocument>, is that queries in LINQ to XML are statically compiled, whereas XPath queries must be interpreted at run time. This feature is built into LINQ to XML, so you don't have to perform extra steps to take advantage of it, but it's helpful to understand the distinction when choosing between the two technologies. This article explains the difference.

## Statically compiled queries vs. XPath

The following example shows how to get the descendant elements with a specified name, and with an attribute with a specified value. The equivalent XPath expression is `//Address[@Type='Shipping']`.

```csharp
XDocument po = XDocument.Load("PurchaseOrders.xml");

IEnumerable<XElement> list1 =
    from el in po.Descendants("Address")
    where (string)el.Attribute("Type") == "Shipping"
    select el;

foreach (XElement el in list1)
    Console.WriteLine(el);
```

```vb
Dim po = XDocument.Load("PurchaseOrders.xml")

Dim list1 = From el In po.Descendants("Address")
            Where el.@Type = "Shipping"

For Each el In list1
    Console.WriteLine(el)
Next
```

The query expression in this example is rewritten by the compiler to method-based query syntax. The following example, which is written in method-based query syntax, produces the same results as the previous one:

```csharp
XDocument po = XDocument.Load("PurchaseOrders.xml");

IEnumerable<XElement> list1 =
    po
    .Descendants("Address")
    .Where(el => (string)el.Attribute("Type") == "Shipping");

foreach (XElement el in list1)
    Console.WriteLine(el);
```

 ```vb
Dim po = XDocument.Load("PurchaseOrders.xml")

Dim list1 As IEnumerable(Of XElement) = po.Descendants("Address").Where(Function(el) el.@Type = "Shipping")

For Each el In list1
    Console.WriteLine(el)
Next
```

The <xref:System.Linq.Enumerable.Where%2A> method is an extension method. For more information, see [Extension Methods (C# Programming Guide)](../../csharp/programming-guide/classes-and-structs/extension-methods.md). Because <xref:System.Linq.Enumerable.Where%2A> is an extension method, the query above is compiled as though it were written as follows:

```csharp
XDocument po = XDocument.Load("PurchaseOrders.xml");

IEnumerable<XElement> list1 =
    System.Linq.Enumerable.Where(
        po.Descendants("Address"),
        el => (string)el.Attribute("Type") == "Shipping");

foreach (XElement el in list1)
    Console.WriteLine(el);
```

```vb
Dim po = XDocument.Load("PurchaseOrders.xml")

Dim list1 = Enumerable.Where(po.Descendants("Address"), Function(el) el.@Type = "Shipping")

For Each el In list1
    Console.WriteLine(el)
Next
```

This example produces exactly the same results as the previous two examples. This illustrates the fact that queries are effectively compiled into statically linked method calls. This, combined with the deferred execution semantics of iterators, improves performance. For more information about the deferred execution semantics of iterators, see [Deferred execution and lazy evaluation](deferred-execution-lazy-evaluation.md).

> [!NOTE]
> These examples are representative of the code that the compiler might write. The actual implementation might differ slightly from these examples, but the performance will be the same as, or similar to, these examples.

## Executing XPath expressions with XmlDocument

The following example uses <xref:System.Xml.XmlDocument> to accomplish the same results as the previous examples:

```csharp
XmlReader reader = XmlReader.Create("PurchaseOrders.xml");
XmlDocument doc = new XmlDocument();
doc.Load(reader);
XmlNodeList nl = doc.SelectNodes(".//Address[@Type='Shipping']");
foreach (XmlNode n in nl)
    Console.WriteLine(n.OuterXml);
reader.Close();
```

```vb
Dim reader = Xml.XmlReader.Create("PurchaseOrders.xml")
Dim doc As New Xml.XmlDocument()
doc.Load(reader)
Dim nl As Xml.XmlNodeList = doc.SelectNodes(".//Address[@Type='Shipping']")
For Each n As Xml.XmlNode In nl
    Console.WriteLine(n.OuterXml)
Next
reader.Close()
```

This query returns the same output as the examples that use LINQ to XML; the only difference is that LINQ to XML indents the printed XML, whereas <xref:System.Xml.XmlDocument> doesn't.

However, the <xref:System.Xml.XmlDocument> approach generally doesn't perform as well as LINQ to XML, because the <xref:System.Xml.XmlNode.SelectNodes%2A> method must do the following every time it's called:

- Parse the string that contains the XPath expression, breaking the string into tokens.
- Validate the tokens to make sure that the XPath expression is valid.
- Translate the expression into an internal expression tree.
- Iterate through the nodes, appropriately selecting the nodes for the result set based on the evaluation of the expression.

This is significantly more than the work done by the corresponding LINQ to XML query. The specific performance difference varies for different types of queries, but in general LINQ to XML queries do less work, and therefore perform better, than evaluating XPath expressions using <xref:System.Xml.XmlDocument>.
