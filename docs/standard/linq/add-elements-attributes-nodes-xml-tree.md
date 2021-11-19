---
title: Add elements, attributes, and nodes to an XML tree - LINQ to XML
description: Learn how to add content (elements, attributes, comments, processing instructions, text, and CDATA) to an XML tree.
ms.date: 07/20/2015
dev_langs:
  - "csharp"
  - "vb"
ms.topic: how-to
---

# Add elements, attributes, and nodes to an XML tree (LINQ to XML)

You can add content (elements, attributes, comments, processing instructions, text, and CDATA) to an XML tree.

## Methods for adding content

The following methods add child content to an <xref:System.Xml.Linq.XElement> or an <xref:System.Xml.Linq.XDocument>:

|Method|Description|
|------------|-----------------|
|<xref:System.Xml.Linq.XContainer.Add%2A>|Adds content at the end of the child content of the <xref:System.Xml.Linq.XContainer>.|
|<xref:System.Xml.Linq.XContainer.AddFirst%2A>|Adds content at the beginning of the child content of the <xref:System.Xml.Linq.XContainer>.|

The following methods add content as sibling nodes of an <xref:System.Xml.Linq.XNode>. The most common node to which you add sibling content is <xref:System.Xml.Linq.XElement>, although you can add valid sibling content to other types of nodes such as <xref:System.Xml.Linq.XText> or <xref:System.Xml.Linq.XComment>.

|Method|Description|
|------------|-----------------|
|<xref:System.Xml.Linq.XNode.AddAfterSelf%2A>|Adds content after the <xref:System.Xml.Linq.XNode>.|
|<xref:System.Xml.Linq.XNode.AddBeforeSelf%2A>|Adds content before the <xref:System.Xml.Linq.XNode>.|

## Example: Create two XML trees and modify one of them

The following example creates two XML trees, and then modifies one of them.

```csharp
var srcTree = new XElement("Root",
    new XElement("Element1", 1),
    new XElement("Element2", 2),
    new XElement("Element3", 3),
    new XElement("Element4", 4),
    new XElement("Element5", 5)
);
var xmlTree = new XElement("Root",
    new XElement("Child1", 1),
    new XElement("Child2", 2),
    new XElement("Child3", 3),
    new XElement("Child4", 4),
    new XElement("Child5", 5)
);
xmlTree.Add(new XElement("NewChild", "new content"));
xmlTree.Add(
    from el in srcTree.Elements()
    where (int)el > 3
    select el
);
// Even though Child9 doesn't exist in srcTree, the following statement won't
// throw an exception, and nothing will be added to xmlTree.
xmlTree.Add(srcTree.Element("Child9"));
Console.WriteLine(xmlTree);
```

```vb
Dim srcTree As XElement =
    <Root>
        <Element1>1</Element1>
        <Element2>2</Element2>
        <Element3>3</Element3>
        <Element4>4</Element4>
        <Element5>5</Element5>
    </Root>
Dim xmlTree As XElement =
    <Root>
        <Child1>1</Child1>
        <Child2>2</Child2>
        <Child3>3</Child3>
        <Child4>4</Child4>
        <Child5>5</Child5>
    </Root>

xmlTree.Add(<NewChild>new content</NewChild>)
xmlTree.Add(
    From el In srcTree.Elements()
    Where CInt(el) > 3
    Select el)

' Even though Child9 doesn't exist in srcTree, the following statement
' won't throw an exception, and nothing will be added to xmlTree.
xmlTree.Add(srcTree.Element("Child9"))
Console.WriteLine(xmlTree)
```

This example produces the following output:

```xml
<Root>
  <Child1>1</Child1>
  <Child2>2</Child2>
  <Child3>3</Child3>
  <Child4>4</Child4>
  <Child5>5</Child5>
  <NewChild>new content</NewChild>
  <Element4>4</Element4>
  <Element5>5</Element5>
</Root>
```
