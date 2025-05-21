---
title: How to work with dictionaries using LINQ to XML - LINQ to XML
description: You can convert many kinds of data structures to XML, and you can convert XML to structures. Here is an example that converts a Generic.Dictionary to XML and back.
ms.date: 07/20/2015
dev_langs:
  - "csharp"
  - "vb"
ms.assetid: 57bcefe3-8433-4d3b-935a-511c9bcbdfa8
ms.topic: how-to
---

# How to work with dictionaries using LINQ to XML

It's often convenient to convert data structures of various kinds to XML, and then from XML to other data structures. This article shows a conversion of a <xref:System.Collections.Generic.Dictionary%602> to XML and back.

## Example: Create a Dictionary and convert its contents to XML

This first example creates a <xref:System.Collections.Generic.Dictionary%602>, and then converts it to XML.

This C# version of the example uses a form of functional construction in which a query projects new <xref:System.Xml.Linq.XElement> objects, and the resulting collection is passed as an argument to the constructor of the Root <xref:System.Xml.Linq.XElement> object.

The Visual Basic version uses XML literals and a query in an embedded expression. The query projects new <xref:System.Xml.Linq.XElement> objects which then become the new content for the `Root` <xref:System.Xml.Linq.XElement> object.

```csharp
Dictionary<string, string> dict = new Dictionary<string, string>();
dict.Add("Child1", "Value1");
dict.Add("Child2", "Value2");
dict.Add("Child3", "Value3");
dict.Add("Child4", "Value4");
XElement root = new XElement("Root",
    from keyValue in dict
    select new XElement(keyValue.Key, keyValue.Value)
);
Console.WriteLine(root);
```

```vb
Dim dict As Dictionary(Of String, String) = New Dictionary(Of String, String)()
dict.Add("Child1", "Value1")
dict.Add("Child2", "Value2")
dict.Add("Child3", "Value3")
dict.Add("Child4", "Value4")
Dim root As XElement = _
    <Root>
        <%= From keyValue In dict _
            Select New XElement(keyValue.Key, keyValue.Value) %>
    </Root>
Console.WriteLine(root)
```

This example produces the following output:

```xml
<Root>
  <Child1>Value1</Child1>
  <Child2>Value2</Child2>
  <Child3>Value3</Child3>
  <Child4>Value4</Child4>
</Root>
```

## Example: Create a dictionary and load it from XML data

The next example creates a dictionary loads it from XML data.

```csharp
XElement root = new XElement("Root",
    new XElement("Child1", "Value1"),
    new XElement("Child2", "Value2"),
    new XElement("Child3", "Value3"),
    new XElement("Child4", "Value4")
);

Dictionary<string, string> dict = new Dictionary<string, string>();
foreach (XElement el in root.Elements())
    dict.Add(el.Name.LocalName, el.Value);
foreach (string str in dict.Keys)
    Console.WriteLine("{0}:{1}", str, dict[str]);
```

```vb
Dim root As XElement = _
        <Root>
            <Child1>Value1</Child1>
            <Child2>Value2</Child2>
            <Child3>Value3</Child3>
            <Child4>Value4</Child4>
        </Root>

Dim dict As Dictionary(Of String, String) = New Dictionary(Of String, String)
For Each el As XElement In root.Elements
    dict.Add(el.Name.LocalName, el.Value)
Next
For Each str As String In dict.Keys
    Console.WriteLine("{0}:{1}", str, dict(str))
Next
```

This example produces the following output:

```output
Child1:Value1
Child2:Value2
Child3:Value3
Child4:Value4
```

## See also

- [Projection Operations (Visual Basic)](../../visual-basic/programming-guide/concepts/linq/projection-operations.md)
