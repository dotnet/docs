---
title: How to filter on an attribute - LINQ to XML
description: This article shows how to use LINQ to XML query and XPath, in C# and Visual Basic, to find descendant elements that have a specified name and attribute value.
ms.date: 07/20/2015
dev_langs:
  - "csharp"
  - "vb"
ms.topic: how-to
---

# How to filter on an attribute (LINQ to XML)

This article shows how to use LINQ to XML query and XPath, in C# and Visual Basic, to find descendant elements that have a specified name and attribute value.

## Example: Find all descendant elements that have a specified name and attribute value

This example uses LINQ to XML query and XPath to find, in XML document [Sample XML file: Multiple purchase orders](sample-xml-file-multiple-purchase-orders.md), all descendant elements that have the name `Address`, and a `Type` attribute whose value is "Shipping". The XPath expression is `.//Address[@Type='Shipping']`

```csharp
XDocument po = XDocument.Load("PurchaseOrders.xml");

// LINQ to XML query
IEnumerable<XElement> list1 =
    from el in po.Descendants("Address")
    where (string)el.Attribute("Type") == "Shipping"
    select el;

// XPath expression
IEnumerable<XElement> list2 = po.XPathSelectElements(".//Address[@Type='Shipping']");

if (list1.Count() == list2.Count() &&
        list1.Intersect(list2).Count() == list1.Count())
    Console.WriteLine("Results are identical");
else
    Console.WriteLine("Results differ");
foreach (XElement el in list1)
    Console.WriteLine(el);
```

```vb
Dim po As XDocument = XDocument.Load("PurchaseOrders.xml")

' LINQ to XML query
Dim list1 As IEnumerable(Of XElement) = _
    From el In po...<Address> _
    Where el.@Type = "Shipping" _
    Select el

' XPath expression
Dim list2 As IEnumerable(Of XElement) = _
    po.XPathSelectElements(".//Address[@Type='Shipping']")

If (list1.Count = list2.Count And _
        list1.Intersect(list2).Count() = list1.Count()) Then
    Console.WriteLine("Results are identical")
Else
    Console.WriteLine("Results differ")
End If
For Each el As XElement In list1
    Console.WriteLine(el)
Next
```

This example produces the following output:

```output
Results are identical
<Address Type="Shipping">
  <Name>Ellen Adams</Name>
  <Street>123 Maple Street</Street>
  <City>Mill Valley</City>
  <State>CA</State>
  <Zip>10999</Zip>
  <Country>USA</Country>
</Address>
<Address Type="Shipping">
  <Name>Cristian Osorio</Name>
  <Street>456 Main Street</Street>
  <City>Buffalo</City>
  <State>NY</State>
  <Zip>98112</Zip>
  <Country>USA</Country>
</Address>
<Address Type="Shipping">
  <Name>Jessica Arnold</Name>
  <Street>4055 Madison Ave</Street>
  <City>Seattle</City>
  <State>WA</State>
  <Zip>98112</Zip>
  <Country>USA</Country>
</Address>
```

## See also

- [Comparison of XPath and LINQ to XML](comparison-xpath-linq-xml.md)
