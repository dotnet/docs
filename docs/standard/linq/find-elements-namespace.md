---
title: How to find elements in a namespace - LINQ to XML
description: Learn how to find elements in a particular namespace by using namespace prefixes in XPath expressions.
ms.date: 07/20/2015
dev_langs:
  - "csharp"
  - "vb"
ms.topic: how-to
---

# How to find elements in a namespace (LINQ to XML)

Use namespace prefixes in XPath expressions to find nodes in a particular namespace. To parse an XPath expression that contains namespace prefixes, you pass an object to the XPath methods that implement <xref:System.Xml.IXmlNamespaceResolver>.

## Example: Find purchase orders from a specific namespace in a document that has two namespaces

The following example uses an <xref:System.Xml.XmlReader> to read XML document [Sample XML file: Consolidated purchase orders](sample-xml-file-consolidated-purchase-orders.md), which has purchase orders in two namespaces. It then gets an <xref:System.Xml.XmlNameTable> from the <xref:System.Xml.XmlReader>, and an <xref:System.Xml.XmlNamespaceManager> from the <xref:System.Xml.XmlNameTable>. It uses the <xref:System.Xml.XmlNamespaceManager> when selecting elements.

The XPath expression is: `./aw:*`

```csharp
XmlReader reader = XmlReader.Create("ConsolidatedPurchaseOrders.xml");
XElement root = XElement.Load(reader);
XmlNameTable nameTable = reader.NameTable;
XmlNamespaceManager namespaceManager = new XmlNamespaceManager(nameTable);
namespaceManager.AddNamespace("aw", "http://www.adventure-works.com");
IEnumerable<XElement> list1 = root.XPathSelectElements("./aw:*", namespaceManager);
IEnumerable<XElement> list2 =
    from el in root.Elements()
    where el.Name.Namespace == "http://www.adventure-works.com"
    select el;
if (list1.Count() == list2.Count() &&
        list1.Intersect(list2).Count() == list1.Count())
    Console.WriteLine("Results are identical");
else
    Console.WriteLine("Results differ");
foreach (XElement el in list2)
    Console.WriteLine(el);
```

```vb
Dim reader As XmlReader = _
        XmlReader.Create("ConsolidatedPurchaseOrders.xml")
Dim root As XElement = XElement.Load(reader)
Dim nameTable As XmlNameTable = reader.NameTable
Dim namespaceManager As XmlNamespaceManager = New XmlNamespaceManager(nameTable)
namespaceManager.AddNamespace("aw", "http://www.adventure-works.com")

Dim list1 As IEnumerable(Of XElement) = _
        root.XPathSelectElements("./aw:*", namespaceManager)
Dim list2 As IEnumerable(Of XElement) = _
    From el In root.Elements() _
    Where el.Name.Namespace = "http://www.adventure-works.com" _
    Select el

If list1.Count() = list2.Count() And _
        list1.Intersect(list2).Count() = list1.Count() Then
    Console.WriteLine("Results are identical")
Else
    Console.WriteLine("Results differ")
End If
For Each el As XElement In list2
    Console.WriteLine(el)
Next
```

This example produces the following output:

```output
Results are identical
<aw:PurchaseOrder PONumber="11223" Date="2000-01-15" xmlns:aw="http://www.adventure-works.com">
    <aw:ShippingAddress>
      <aw:Name>Chris Preston</aw:Name>
      <aw:Street>123 Main St.</aw:Street>
      <aw:City>Seattle</aw:City>
      <aw:State>WA</aw:State>
      <aw:Zip>98113</aw:Zip>
      <aw:Country>USA</aw:Country>
    </aw:ShippingAddress>
    <aw:BillingAddress>
      <aw:Name>Chris Preston</aw:Name>
      <aw:Street>123 Main St.</aw:Street>
      <aw:City>Seattle</aw:City>
      <aw:State>WA</aw:State>
      <aw:Zip>98113</aw:Zip>
      <aw:Country>USA</aw:Country>
    </aw:BillingAddress>
    <aw:DeliveryInstructions>Ship only complete order.</aw:DeliveryInstructions>
    <aw:Item PartNum="LIT-01">
      <aw:ProductID>Litware Networking Card</aw:ProductID>
      <aw:Qty>1</aw:Qty>
      <aw:Price>20.99</aw:Price>
    </aw:Item>
    <aw:Item PartNum="LIT-25">
      <aw:ProductID>Litware 17in LCD Monitor</aw:ProductID>
      <aw:Qty>1</aw:Qty>
      <aw:Price>199.99</aw:Price>
    </aw:Item>
  </aw:PurchaseOrder>
```

## See also

- [LINQ to XML for XPath Users (Visual Basic)](./comparison-xpath-linq-xml.md)
