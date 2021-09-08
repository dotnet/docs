---
title: How to create a document with namespaces in Visual Basic - LINQ to XML
description: Use XML literals in Visual Basic to create documents that have default namespaces or namespaces with a prefix.
ms.date: 07/20/2015
ms.topic: how-to
---

# How to create a document with namespaces in Visual Basic (LINQ to XML)

This article shows how to create a document with namespaces in Visual Basic.

When using XML literals in Visual Basic, users can define one global default XML namespace. This namespace is the default namespace for both XML literals and XML properties. The default XML namespace can be defined at either the project level or the file level. If it's defined at the file level, it overrides the default namespace at the project level.

You can also define other namespaces, and specify the namespace prefixes for those namespaces. You use the `Imports` keyword to define both types of namespace.

For more information, see [XML literals in Visual Basic](xml-literals.md).

Note that the default XML namespace only applies to elements and not to attributes. Attributes are by default in the default namespace. However, you can use a namespace prefix to put an attribute in a namespace.

## Example: Create a document that has a namespace

This example creates a document that contains a namespace.

```vb
Imports <xmlns:aw="http://www.adventure-works.com">
Module Module1
    Sub Main()
        Dim root As XElement = _
            <aw:Root>
                <aw:Child aw:Att="attvalue"/>
            </aw:Root>
        Console.WriteLine(root)
    End Sub
End Module
```

This example produces the following output:

```xml
<aw:Root xmlns:aw="http://www.adventure-works.com">
  <aw:Child aw:Att="attvalue" />
</aw:Root>
```

## Example: Create a document that has two namespaces, one with a prefix

This example creates a document that contains two namespaces. One is the default namespace, the other has a prefix.

```vb
Imports <xmlns="http://www.adventure-works.com">
Imports <xmlns:fc="www.fourthcoffee.com">

Module Module1

    Sub Main()
        Dim root As XElement = _
            <Root>
                <Child Att="attvalue"/>
                <fc:Child2>child2 content</fc:Child2>
            </Root>
        Console.WriteLine(root)
    End Sub

End Module
```

This example produces the following output:

```xml
<Root xmlns:fc="www.fourthcoffee.com" xmlns="http://www.adventure-works.com">
  <Child Att="attvalue" />
  <fc:Child2>child2 content</fc:Child2>
</Root>
```

## Example: Create a document that has two namespaces, both with prefixes

The following example creates a document that contains two namespaces, both having namespace prefixes.

When serializing an XML tree, LINQ to XML emits namespace declarations as required so that each element is in its designated namespace.

```vb
Imports <xmlns:aw="http://www.adventure-works.com">
Imports <xmlns:fc="www.fourthcoffee.com">

Module Module1

    Sub Main()
        Dim root As XElement = _
            <aw:Root>
                <fc:Child>
                    <aw:DifferentChild>other content</aw:DifferentChild>
                </fc:Child>
                <aw:Child2>c2 content</aw:Child2>
                <fc:Child3>c3 content</fc:Child3>
            </aw:Root>
        Console.WriteLine(root)
    End Sub

End Module
```

This example produces the following output:

```xml
<aw:Root xmlns:fc="www.fourthcoffee.com" xmlns:aw="http://www.adventure-works.com">
  <fc:Child>
    <aw:DifferentChild>other content</aw:DifferentChild>
  </fc:Child>
  <aw:Child2>c2 content</aw:Child2>
  <fc:Child3>c3 content</fc:Child3>
</aw:Root>
```

## See also

- [Namespaces overview](namespaces-overview.md)
