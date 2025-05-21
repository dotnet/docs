---
title: Scope of default namespaces - LINQ to XML
description: Default namespaces as represented in the XML tree aren't in scope for queries. Here are proper and improper ways of querying them.
ms.date: 07/20/2015
dev_langs:
  - "csharp"
  - "vb"
ms.assetid: fe826236-830f-457a-9027-7ad62c909fae
ms.topic: article
---

# Scope of default namespaces (LINQ to XML)

Default namespaces as represented in the XML tree aren't in scope for queries. If you have XML that's in a default namespace, you must combine a namespace with the local name to make a qualified name to be used in the query.

A common mistake in querying an XML tree that has a default namespace is to write the query as if the XML weren't in a namespace. The first example shows a typical improper query of a default namespace. The second shows a proper query.

## Example: Improper query of XML in a namespace

This example shows the creation of XML in a namespace, and an improper query that returns an empty result set.

```csharp
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
    from el in root.Elements("Child")
    select el;
Console.WriteLine("Result set follows:");
foreach (XElement el in c1)
    Console.WriteLine((int)el);
Console.WriteLine("End of result set");
```

```vb
Module Module1
    Sub Main()
        Dim root As XElement = _
            <Root xmlns='http://www.adventure-works.com'>
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
        Console.WriteLine("Result set follows:")
        For Each el As XElement In c1
            Console.WriteLine(CInt(el))
        Next
        Console.WriteLine("End of result set")
    End Sub
End Module
```

This example produces the following output:

```output
Result set follows:
End of result set
```

## Example:  Proper query of XML in a namespace

This example shows the creation of XML in a namespace, and a proper query.

In C#, the correct approach is to declare and initialize an <xref:System.Xml.Linq.XNamespace> object, and to use it when specifying <xref:System.Xml.Linq.XName> objects. In this case, the argument to the <xref:System.Xml.Linq.XContainer.Elements%2A> method is an <xref:System.Xml.Linq.XName> object.

The correct approach when using Visual Basic is to declare and initialize a global default namespace. This places all XML properties in the default namespace.

Here is the code:

```csharp
XElement root = XElement.Parse(
@"<Root xmlns='http://www.adventure-works.com'>
    <Child>1</Child>
    <Child>2</Child>
    <Child>3</Child>
    <AnotherChild>4</AnotherChild>
    <AnotherChild>5</AnotherChild>
    <AnotherChild>6</AnotherChild>
</Root>");
XNamespace aw = "http://www.adventure-works.com";
IEnumerable<XElement> c1 =
    from el in root.Elements(aw + "Child")
    select el;
Console.WriteLine("Result set follows:");
foreach (XElement el in c1)
    Console.WriteLine((int)el);
Console.WriteLine("End of result set");
```

```vb
Imports <xmlns="http://www.adventure-works.com">

Module Module1
    Sub Main()
        Dim root As XElement = _
            <Root xmlns='http://www.adventure-works.com'>
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
        Console.WriteLine("Result set follows:")
        For Each el As XElement In c1
            Console.WriteLine(el.Value)
        Next
        Console.WriteLine("End of result set")
    End Sub
End Module
```

This example produces the following output:

```output
Result set follows:
1
2
3
End of result set
```

## See also

- [Namespaces overview](namespaces-overview.md)
