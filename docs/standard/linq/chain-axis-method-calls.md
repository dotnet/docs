---
title: How to chain axis method calls - LINQ to XML
description: Learn how to use the XContainer.Elements and Extensions.Elements methods to find all elements of a specified name at a given depth in the tree.
ms.date: 07/20/2015
dev_langs:
  - "csharp"
  - "vb"
ms.topic: how-to
---

# How to chain axis method calls (LINQ to XML)

A common pattern that you will use in your code is to call an axis method, then call one of the extension method axes.

There are two axes with the name of `Elements` that return a collection of elements: the <xref:System.Xml.Linq.XContainer.Elements%2A?displayProperty=nameWithType> method and the <xref:System.Xml.Linq.Extensions.Elements%2A?displayProperty=nameWithType> method. You can combine these two axes to find all elements of a specified name at a given depth in the tree.

## Example: Retrieve all name elements

This example uses <xref:System.Xml.Linq.XContainer.Elements%2A?displayProperty=nameWithType> and <xref:System.Xml.Linq.Extensions.Elements%2A?displayProperty=nameWithType> to retrieve all `Name` elements in all `Address` elements in all `PurchaseOrder` elements.

This example uses XML document [Sample XML file: Multiple purchase orders](sample-xml-file-multiple-purchase-orders.md).

```csharp
XElement purchaseOrders = XElement.Load("PurchaseOrders.xml");
IEnumerable<XElement> names =
    from el in purchaseOrders
        .Elements("PurchaseOrder")
        .Elements("Address")
        .Elements("Name")
    select el;
foreach (XElement e in names)
    Console.WriteLine(e);
```

```vb
Dim purchaseOrders As XElement = XElement.Load("PurchaseOrders.xml")
Dim names As IEnumerable(Of XElement) = _
    From el In purchaseOrders.<PurchaseOrder>.<Address>.<Name> _
    Select el
For Each e As XElement In names
    Console.WriteLine(e)
Next
```

This example produces the following output:

```xml
<Name>Ellen Adams</Name>
<Name>Tai Yee</Name>
<Name>Cristian Osorio</Name>
<Name>Cristian Osorio</Name>
<Name>Jessica Arnold</Name>
<Name>Jessica Arnold</Name>
```

This works because one of the implementations of the `Elements` axis is as an extension method on <xref:System.Collections.Generic.IEnumerable%601> of <xref:System.Xml.Linq.XContainer>. <xref:System.Xml.Linq.XElement> derives from <xref:System.Xml.Linq.XContainer>, so you can call the <xref:System.Xml.Linq.Extensions.Elements%2A?displayProperty=nameWithType> method on the results of a call to the <xref:System.Xml.Linq.XContainer.Elements%2A?displayProperty=nameWithType> method.

## Example: Retrieve all elements at a particular depth

Sometimes you want to retrieve all elements at a particular element depth when there may not be intervening ancestors. For example, in the following document, you might want to retrieve all the `ConfigParameter` elements that are children of the `Customer` element, but not the `ConfigParameter` that's a child of the `Root` element.

```xml
<Root>
  <ConfigParameter>RootConfigParameter</ConfigParameter>
  <Customer>
    <Name>Frank</Name>
    <Config>
      <ConfigParameter>FirstConfigParameter</ConfigParameter>
    </Config>
  </Customer>
  <Customer>
    <Name>Bob</Name>
    <!--This customer doesn't have a Config element-->
  </Customer>
  <Customer>
    <Name>Bill</Name>
    <Config>
      <ConfigParameter>SecondConfigParameter</ConfigParameter>
    </Config>
  </Customer>
</Root>
```

 To do this, you can use the <xref:System.Xml.Linq.Extensions.Elements%2A?displayProperty=nameWithType> axis, as follows:

```csharp
XElement root = XElement.Load("Irregular.xml");
IEnumerable<XElement> configParameters =
    root.Elements("Customer").Elements("Config").
    Elements("ConfigParameter");
foreach (XElement cp in configParameters)
    Console.WriteLine(cp);
```

```vb
Dim root As XElement = XElement.Load("Irregular.xml")
Dim configParameters As IEnumerable(Of XElement) = _
    root.<Customer>.<Config>.<ConfigParameter>
For Each cp As XElement In configParameters
    Console.WriteLine(cp)
Next
```

This example produces the following output:

```xml
<ConfigParameter>FirstConfigParameter</ConfigParameter>
<ConfigParameter>SecondConfigParameter</ConfigParameter>
```

## Example: Retrieve elements for XML that's in a namespace

The following example shows the same technique for XML that's in a namespace. For more information, see [Namespaces overview](namespaces-overview.md).

This example uses XML document [Sample XML file: Multiple purchase orders in a namespace](sample-xml-file-multiple-purchase-orders-namespace.md).

```csharp
XNamespace aw = "http://www.adventure-works.com";
XElement purchaseOrders = XElement.Load("PurchaseOrdersInNamespace.xml");
IEnumerable<XElement> names =
    from el in purchaseOrders
        .Elements(aw + "PurchaseOrder")
        .Elements(aw + "Address")
        .Elements(aw + "Name")
    select el;
foreach (XElement e in names)
    Console.WriteLine(e);
```

```vb
Imports <xmlns:aw="http://www.adventure-works.com">

Module Module1
    Sub Main()
        Dim purchaseOrders As XElement = XElement.Load("PurchaseOrdersInNamespace.xml")
        Dim names As IEnumerable(Of XElement) = _
            From el In purchaseOrders.<aw:PurchaseOrder>.<aw:Address>.<aw:Name> _
            Select el
        For Each e As XElement In names
            Console.WriteLine(e)
        Next
    End Sub
End Module
```

This example produces the following output:

```xml
<aw:Name xmlns:aw="http://www.adventure-works.com">Ellen Adams</aw:Name>
<aw:Name xmlns:aw="http://www.adventure-works.com">Tai Yee</aw:Name>
<aw:Name xmlns:aw="http://www.adventure-works.com">Cristian Osorio</aw:Name>
<aw:Name xmlns:aw="http://www.adventure-works.com">Cristian Osorio</aw:Name>
<aw:Name xmlns:aw="http://www.adventure-works.com">Jessica Arnold</aw:Name>
<aw:Name xmlns:aw="http://www.adventure-works.com">Jessica Arnold</aw:Name>
```

## See also

- [LINQ to XML axes overview](linq-xml-axes-overview.md)
