---
title: How to write queries on XML in namespaces - LINQ to XML
description: To write a query on XML that's in a namespace, you use XName objects that have the correct namespace. Learn how to do this in C# and Visual Basic, and how to create queries.
ms.date: 07/20/2015
dev_langs:
  - "csharp"
  - "vb"
ms.topic: how-to
---

# How to write queries on XML in namespaces (LINQ to XML)

To write a query on XML that's in a namespace, you must use <xref:System.Xml.Linq.XName> objects that have the correct namespace.

For C#, the most common approach is to initialize an <xref:System.Xml.Linq.XNamespace> using a string that contains the URI, then use the addition operator overload to combine the namespace with the local name.

For Visual Basic, the most common approach is to define a global namespace, and then use XML literals and XML properties that use the global namespace. You can define a global default namespace, in which case elements in the XML literals will be in the namespace by default. Alternatively, you can define a global namespace with a prefix, and then use the prefix as required in the XML literals and in XML properties. As with other forms of XML, attributes are always in no namespace by default.

The first example in this article shows how to create an XML tree in a default namespace. The second shows how to create an XML tree in a namespace with a prefix.

## Example: Create a tree in a default namespace and retrieve elements

The following example creates an XML tree that's in a default namespace, and then retrieves a collection of elements.

```csharp
XNamespace aw = "http://www.adventure-works.com";
XElement root = XElement.Parse(
@"<Root xmlns='http://www.adventure-works.com'>
    <Child>1</Child>
    <Child>2</Child>
    <Child>3</Child>
    <AnotherChild>4</AnotherChild>
    <AnotherChild>5</AnotherChild>
    <AnotherChild>6</AnotherChild>
</Root>");
IEnumerable<XElement> c1 =
    from el in root.Elements(aw + "Child")
    select el;
foreach (XElement el in c1)
    Console.WriteLine((int)el);
```

```vb
Imports <xmlns="http://www.adventure-works.com">

Module Module1
    Sub Main()
        Dim root As XElement = _
            <Root>
                <Child>1</Child>
                <Child>2</Child>
                <Child>3</Child>
                <AnotherChild>4</AnotherChild>
                <AnotherChild>5</AnotherChild>
                <AnotherChild>6</AnotherChild>
            </Root>
        Dim c1 As IEnumerable(Of XElement) = _
            From el In root.<Child> _
            Select el
        For Each el As XElement In c1
            Console.WriteLine(el.Value)
        Next
    End Sub
End Module
```

This example produces the following output:

```output
1
2
3
```

## Example: Create a tree in a namespace with a prefix and retrieve elements

In C#, you write queries in the same way regardless of whether you're writing queries on an XML tree that uses a namespace with a prefix or on an XML tree with a default namespace.

The following example creates an XML tree that's in a namespace with a prefix, and then retrieves a collection of elements.

```csharp
XNamespace aw = "http://www.adventure-works.com";
XElement root = XElement.Parse(
@"<aw:Root xmlns:aw='http://www.adventure-works.com'>
    <aw:Child>1</aw:Child>
    <aw:Child>2</aw:Child>
    <aw:Child>3</aw:Child>
    <aw:AnotherChild>4</aw:AnotherChild>
    <aw:AnotherChild>5</aw:AnotherChild>
    <aw:AnotherChild>6</aw:AnotherChild>
</aw:Root>");
IEnumerable<XElement> c1 =
    from el in root.Elements(aw + "Child")
    select el;
foreach (XElement el in c1)
    Console.WriteLine((int)el);
```

```vb
Imports <xmlns:aw="http://www.adventure-works.com">

Module Module1
    Sub Main()
        Dim root As XElement = _
            <aw:Root>
                <aw:Child>1</aw:Child>
                <aw:Child>2</aw:Child>
                <aw:Child>3</aw:Child>
                <aw:AnotherChild>4</aw:AnotherChild>
                <aw:AnotherChild>5</aw:AnotherChild>
                <aw:AnotherChild>6</aw:AnotherChild>
            </aw:Root>
        Dim c1 As IEnumerable(Of XElement) = _
            From el In root.<aw:Child> _
            Select el
        For Each el As XElement In c1
            Console.WriteLine(CInt(el))
        Next
    End Sub
End Module
```

This example produces the following output:

```output
1
2
3
```

## See also

- [Namespaces overview](namespaces-overview.md)
