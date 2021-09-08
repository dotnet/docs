---
title: How to change the namespace for an entire XML tree - LINQ to XML
description: Learn how to change the namespace for an entire XML tree.
ms.date: 07/20/2015
dev_langs:
  - "csharp"
  - "vb"
ms.topic: how-to
---

# How to change the namespace for an entire XML tree (LINQ to XML)

You sometimes have to programmatically change the namespace for an element or an attribute. LINQ to XML makes this easy. The <xref:System.Xml.Linq.XElement.Name%2A?displayProperty=nameWithType> property can be set. The <xref:System.Xml.Linq.XAttribute.Name%2A?displayProperty=nameWithType> property can't be set, but you can easily copy the attributes into a <xref:System.Collections.Generic.List%601?displayProperty=nameWithType>, remove the existing attributes, and then add new attributes that are in the new desired namespace.

For more information, see [Namespaces overview](namespaces-overview.md).

## Example: Create two XML trees, change the namespaces, and combine the trees

The following code creates two XML trees in no namespace. It then changes the namespace of each of the trees, and combines them into a single tree.

```csharp
XElement tree1 = new XElement("Data",
    new XElement("Child", "content",
        new XAttribute("MyAttr", "content")
    )
);
XElement tree2 = new XElement("Data",
    new XElement("Child", "content",
        new XAttribute("MyAttr", "content")
    )
);
XNamespace aw = "http://www.adventure-works.com";
XNamespace ad = "http://www.adatum.com";
// Change the namespace of every element and attribute in the first tree.
foreach (XElement el in tree1.DescendantsAndSelf())
{
    el.Name = aw.GetName(el.Name.LocalName);
    List<XAttribute> atList = el.Attributes().ToList();
    el.Attributes().Remove();
    foreach (XAttribute at in atList)
        el.Add(new XAttribute(aw.GetName(at.Name.LocalName), at.Value));
}
// Change the namespace of every element and attribute in the second tree.
foreach (XElement el in tree2.DescendantsAndSelf())
{
    el.Name = ad.GetName(el.Name.LocalName);
    List<XAttribute> atList = el.Attributes().ToList();
    el.Attributes().Remove();
    foreach (XAttribute at in atList)
        el.Add(new XAttribute(ad.GetName(at.Name.LocalName), at.Value));
}
// Add attribute namespaces so that the tree will be serialized with
// the aw and ad namespace prefixes.
tree1.Add(
    new XAttribute(XNamespace.Xmlns + "aw", "http://www.adventure-works.com")
);
tree2.Add(
    new XAttribute(XNamespace.Xmlns + "ad", "http://www.adatum.com")
);
// Create a new composite tree.
XElement root = new XElement("Root",
    tree1,
    tree2
);
Console.WriteLine(root);
```

```vb
Dim tree1 As XElement = _
    <Data>
        <Child MyAttr="content">content</Child>
    </Data>
Dim tree2 As XElement = _
    <Data>
        <Child MyAttr="content">content</Child>
    </Data>
Dim aw As XNamespace = "http://www.adventure-works.com"
Dim ad As XNamespace = "http://www.adatum.com"
' Change the namespace of every element and attribute in the first tree.
For Each el As XElement In tree1.DescendantsAndSelf
    el.Name = aw.GetName(el.Name.LocalName)
    Dim atList As List(Of XAttribute) = el.Attributes().ToList()
    el.Attributes().Remove()
    For Each at As XAttribute In atList
        el.Add(New XAttribute(aw.GetName(at.Name.LocalName), at.Value))
    Next
Next
' Change the namespace of every element and attribute in the second tree.
For Each el As XElement In tree2.DescendantsAndSelf()
    el.Name = ad.GetName(el.Name.LocalName)
    Dim atList As List(Of XAttribute) = el.Attributes().ToList()
    el.Attributes().Remove()
    For Each at As XAttribute In atList
        el.Add(New XAttribute(ad.GetName(at.Name.LocalName), at.Value))
    Next
Next
' Add attribute namespaces so that the tree will be serialized with
' the aw and ad namespace prefixes.
tree1.Add( _
    New XAttribute(XNamespace.Xmlns + "aw", "http://www.adventure-works.com") _
)
tree2.Add( _
    New XAttribute(XNamespace.Xmlns + "ad", "http://www.adatum.com") _
)
' Create a new composite tree.
Dim root As XElement = _
    <Root>
        <%= tree1 %>
        <%= tree2 %>
    </Root>
Console.WriteLine(root)
```

This example produces the following output:

```xml
<Root>
  <aw:Data xmlns:aw="http://www.adventure-works.com">
    <aw:Child aw:MyAttr="content">content</aw:Child>
  </aw:Data>
  <ad:Data xmlns:ad="http://www.adatum.com">
    <ad:Child ad:MyAttr="content">content</ad:Child>
  </ad:Data>
</Root>
```
