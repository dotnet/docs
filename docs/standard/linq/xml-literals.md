---
title: XML Literals in Visual Basic - LINQ to XML
description: You can create an XML tree in Visual Basic using XML literals and embedded expressions. Embedded expressions enable you to evaluate an expression and insert the results of the expression into the XML tree.
ms.date: 07/20/2015
ms.assetid: 94fc0e03-978e-4c08-ab6c-0dc3c1e64f10
ms.topic: article
---

# XML Literals in Visual Basic (LINQ to XML)

This article provides information about creating XML trees in Visual Basic using XML literals and embedded expressions.

## Example: Use XML literals to create an XML tree

The following example shows how to create an <xref:System.Xml.Linq.XElement>, in this case `contacts`, with XML literals:

```vb
Dim contacts As XElement = _
    <Contacts>
        <Contact>
            <Name>Patrick Hines</Name>
            <Phone>206-555-0144</Phone>
            <Address>
                <Street1>123 Main St</Street1>
                <City>Mercer Island</City>
                <State>WA</State>
                <Postal>68042</Postal>
            </Address>
        </Contact>
    </Contacts>
```

## Example: Use XML literals to create an XElement with simple content

You can create an <xref:System.Xml.Linq.XElement> that contains simple content, as follows:

```vb
Dim n as XElement = <Customer>Adventure Works</Customer>
Console.WriteLine(n)
```

This example produces the following output:

```xml
<Customer>Adventure Works</Customer>
```

## Example: Use an XML literal to create an empty element

You can create an empty <xref:System.Xml.Linq.XElement>, as follows:

```vb
Dim n As XElement = <Customer/>
Console.WriteLine(n)
```

This example produces the following output:

```xml
<Customer />
```

## Use embedded expressions to create content

An important feature of XML literals is that they allow embedded expressions. Embedded expressions enable you to evaluate an expression and insert the results of the expression into the XML tree. If the expression evaluates to a type of <xref:System.Xml.Linq.XElement>, an element is inserted into the tree. If the expression evaluates to a type of <xref:System.Xml.Linq.XAttribute>, an attribute is inserted into the tree. You can insert elements and attributes into the tree only where they're valid.

it's important to note that only a single expression can go into an embedded expression. You can't embed multiple statements. If an expression extends beyond a single line, you must use the line continuation character.

If you use an embedded expression to add existing nodes (including elements) and attributes to a new XML tree and if the existing nodes are already parented, the nodes are cloned. The newly cloned nodes are attached to the new XML tree. If the existing nodes aren't parented, the nodes are simply attached to the new XML tree. The last example in this article demonstrates this.

## Example: Use an embedded expression to insert an element

The following example uses an embedded expression to insert an element into the tree:

```vb
xmlTree1 As XElement = _
    <Root>
        <Child>Contents</Child>
    </Root>
Dim xmlTree2 As XElement = _
    <Root>
        <%= xmlTree1.<Child> %>
    </Root>
Console.WriteLine(xmlTree2)
```

This example produces the following output:

```xml
<Root>
  <Child>Contents</Child>
</Root>
```

## Example: Use an embedded expression for content

You can use an embedded expression to supply the content of an element:

```vb
Dim str As String
str = "Some content"
Dim root As XElement = <Root><%= str %></Root>
Console.WriteLine(root)
```

This example produces the following output:

```xml
<Root>Some content</Root>
```

## Example: Use a LINQ query in an embedded expression

You can use the results of a LINQ query to provide the content of an element:

```vb
Dim arr As Integer() = {1, 2, 3}

Dim n As XElement = _
    <Root>
        <%= From i In arr Select <Child><%= i %></Child> %>
    </Root>

Console.WriteLine(n)
```

This example produces the following output:

```xml
<Root>
  <Child>1</Child>
  <Child>2</Child>
  <Child>3</Child>
</Root>
```

## Example: Use an embedded expression to provide node names

You can also use an embedded expression to calculate attribute names, attribute values, element names, and element values:

```vb
Dim eleName As String = "ele"
Dim attName As String = "att"
Dim attValue As String = "aValue"
Dim eleValue As String = "eValue"
Dim n As XElement = _
    <Root <%= attName %>=<%= attValue %>>
        <<%= eleName %>>
            <%= eleValue %>
        </>
    </Root>
Console.WriteLine(n)
```

This example produces the following output:

```xml
<Root att="aValue">
  <ele>eValue</ele>
</Root>
```

## Example: Use an embedded expression to clone and attach nodes

As mentioned earlier, if you use an embedded expression to add existing nodes (including elements) and attributes to a new XML tree, and if the nodes being added nodes are already parented, the nodes are cloned and the clones are attached to the new XML tree. If the existing nodes aren't parented, they're simply attached to the new XML tree.

The following code demonstrates the behavior when you add a parented element to a tree, and when you add an element with no parent to a tree.

```vb
' Create a tree with a child element.
Dim xmlTree1 As XElement = _
    <Root>
        <Child1>1</Child1>
    </Root>

' Create an element that's not parented.
Dim child2 As XElement = <Child2>2</Child2>

' Create a tree and add Child1 and Child2 to it.
Dim xmlTree2 As XElement = _
    <Root>
        <%= xmlTree1.<Child1>(0) %>
        <%= child2 %>
    </Root>

' Compare Child1 identity.
Console.WriteLine("Child1 was {0}", _
    IIf(xmlTree1.Element("Child1") Is xmlTree2.Element("Child1"), _
    "attached", "cloned"))

' Compare Child2 identity.
Console.WriteLine("Child2 was {0}", _
    IIf(child2 Is xmlTree2.Element("Child2"), _
    "attached", "cloned"))
```

This example produces the following output:

```output
Child1 was cloned
Child2 was attached
```

## See also

- [Functional construction](functional-construction.md)
