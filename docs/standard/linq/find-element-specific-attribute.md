---
title: How to find an element with a specific attribute - LINQ to XML
description: Learn how to find an element whose attribute has a specific value.
ms.date: 07/20/2015
dev_langs:
  - "csharp"
  - "vb"
ms.topic: how-to
---

# How to find an element with a specific attribute (LINQ to XML)

This article provides examples of how to find an element whose attribute has a specific value.

## Example: Find an element whose attribute has a specific value

The following example shows how to find the `Address` element that has a `Type` attribute with a value of "Billing". The example uses XML document [Sample XML file: Typical purchase order](sample-xml-file-typical-purchase-order.md).

```csharp
XElement root = XElement.Load("PurchaseOrder.xml");
IEnumerable<XElement> address =
    from el in root.Elements("Address")
    where (string)el.Attribute("Type") == "Billing"
    select el;
foreach (XElement el in address)
    Console.WriteLine(el);
```

```vb
Dim root As XElement = XElement.Load("PurchaseOrder.xml")
Dim address As IEnumerable(Of XElement) = _
    From el In root.<Address> _
    Where el.@Type = "Billing" _
    Select el
For Each el As XElement In address
    Console.WriteLine(el)
Next
```

This example produces the following output:

```xml
<Address Type="Billing">
  <Name>Tai Yee</Name>
  <Street>8 Oak Avenue</Street>
  <City>Old Town</City>
  <State>PA</State>
  <Zip>95819</Zip>
  <Country>USA</Country>
</Address>
```

## Example: Find an element in XML that's in a namespace

The following example shows the same query, but for XML that's in a namespace. It uses XML document [Sample XML file: typical purchase order in a namespace](sample-xml-file-typical-purchase-order-namespace.md).

For more information about namespaces, see [Namespaces overview](namespaces-overview.md).

```csharp
XElement root = XElement.Load("PurchaseOrderInNamespace.xml");
XNamespace aw = "http://www.adventure-works.com";
IEnumerable<XElement> address =
    from el in root.Elements(aw + "Address")
    where (string)el.Attribute(aw + "Type") == "Billing"
    select el;
foreach (XElement el in address)
    Console.WriteLine(el);
```

```vb
Imports <xmlns:aw='http://www.adventure-works.com'>

Module Module1
    Sub Main()
        Dim root As XElement = XElement.Load("PurchaseOrderInNamespace.xml")
        Dim address As IEnumerable(Of XElement) = _
            From el In root.<aw:Address> _
            Where el.@aw:Type = "Billing" _
            Select el
        For Each el As XElement In address
            Console.WriteLine(el)
        Next
    End Sub
End Module
```

This example produces the following output::

```xml
<aw:Address aw:Type="Billing" xmlns:aw="http://www.adventure-works.com">
  <aw:Name>Tai Yee</aw:Name>
  <aw:Street>8 Oak Avenue</aw:Street>
  <aw:City>Old Town</aw:City>
  <aw:State>PA</aw:State>
  <aw:Zip>95819</aw:Zip>
  <aw:Country>USA</aw:Country>
</aw:Address>
```

## See also

- <xref:System.Xml.Linq.XElement.Attribute%2A>
- <xref:System.Xml.Linq.XContainer.Elements%2A>
- [Standard Query Operators Overview (C#)](../../csharp/programming-guide/concepts/linq/standard-query-operators-overview.md)
- [Projection Operations (C#)](../../csharp/programming-guide/concepts/linq/projection-operations.md)
- [Basic Queries (LINQ to XML) (Visual Basic)](../../visual-basic/programming-guide/concepts/linq/basic-query-operations.md)
- [Standard Query Operators Overview (Visual Basic)](../../visual-basic/programming-guide/concepts/linq/standard-query-operators-overview.md)
- [Projection Operations (Visual Basic)](../../visual-basic/programming-guide/concepts/linq/projection-operations.md)
