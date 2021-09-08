---
title: How to retrieve a collection of elements - LINQ to XML
description: Learn how to use the XContainer.Elements method to retrieve a collection of child elements of an element.
ms.date: 07/20/2015
dev_langs:
  - "csharp"
  - "vb"
ms.topic: how-to
---

# How to retrieve a collection of elements (LINQ to XML)

This article demonstrates the <xref:System.Xml.Linq.XContainer.Elements%2A> method, which retrieves a collection of the child elements of an element.

## Example: Iterate through the child elements of an element

This example iterates through the child elements of the `purchaseOrder` element. It uses XML document [Sample XML file: Typical purchase order](sample-xml-file-typical-purchase-order.md).

```csharp
XElement po = XElement.Load("PurchaseOrder.xml");
IEnumerable<XElement> childElements =
    from el in po.Elements()
    select el;
foreach (XElement el in childElements)
    Console.WriteLine("Name: " + el.Name);
```

```vb
Dim po As XElement = XElement.Load("PurchaseOrder.xml")
Dim childElements As IEnumerable(Of XElement)
childElements = _
    From el In po.Elements() _
    Select el
For Each el As XElement In childElements
    Console.WriteLine("Name: " & el.Name.ToString())
Next
```

This example produces the following output:

```output
Name: Address
Name: Address
Name: DeliveryNotes
Name: Items
```

## See also

- [LINQ to XML axes overview](linq-xml-axes-overview.md)
