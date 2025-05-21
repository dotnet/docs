---
title: System.Xml.Linq.XNamespace class
description: Learn about the System.Xml.Linq.XNamespace class.
ms.date: 12/31/2023
dev_langs:
  - CSharp
  - VB
ms.topic: article
---
# System.Xml.Linq.XNamespace class

[!INCLUDE [context](includes/context.md)]

This class represents the XML construct of namespaces.

Every <xref:System.Xml.Linq.XName> contains an <xref:System.Xml.Linq.XNamespace>. Even if an element is not in a namespace, the element's <xref:System.Xml.Linq.XName> still contains a namespace, <xref:System.Xml.Linq.XNamespace.None%2A?displayProperty=nameWithType>. The <xref:System.Xml.Linq.XName.Namespace?displayProperty=nameWithType> property is guaranteed to not be `null`.

## Create an XNamespace object

The most common way to create an <xref:System.Xml.Linq.XNamespace> object is to simply assign a string to it. You can then combine the namespace with a local name by using the override of the addition operator. The following example shows this idiom:

```csharp
XNamespace aw = "http://www.adventure-works.com";
XElement root = new XElement(aw + "Root", "Content");
Console.WriteLine(root);
```

```vb
Dim aw As XNamespace = "http://www.adventure-works.com"
Dim root As XElement = New XElement(aw + "Root", "Content")
Console.WriteLine(root)
```

However, in Visual Basic, you would typically declare a global default namespace, as follows:

```vb
Imports <xmlns='http://www.adventure-works.com'>

Module Module1
    Sub Main()
        Dim root As XElement = _
            <Root>Content</Root>
        Console.WriteLine(root)
    End Sub
End Module
```

This example produces the following output:

```xml
<Root xmlns="http://www.adventure-works.com">Content</Root>
```

Assigning a string to an <xref:System.Xml.Linq.XNamespace> uses the implicit conversion from <xref:System.String>.

See [How to create a document with namespaces in C# (LINQ to XML)](../../standard/linq/create-document-namespaces-csharp.md) for more information and examples.

See [Work with XML namespaces](../../standard/linq/namespaces-overview.md) for more information on using namespaces in Visual Basic.

## Control namespace prefixes

If you create an attribute that declares a namespace, the prefix specified in the attribute will be persisted in the serialized XML. To create an attribute that declares a namespace with a prefix, you create an attribute where the namespace of the name of the attribute is <xref:System.Xml.Linq.XNamespace.Xmlns%2A>, and the name of the attribute is the namespace prefix. The value of the attribute is the URI of the namespace. The following example shows this idiom:

```csharp
XNamespace aw = "http://www.adventure-works.com";
XElement root = new XElement(aw + "Root",
    new XAttribute(XNamespace.Xmlns + "aw", "http://www.adventure-works.com"),
    "Content");
Console.WriteLine(root);
```

```vb
Dim aw As XNamespace = "http://www.adventure-works.com"
Dim root As XElement = New XElement(aw + "Root", _
    New XAttribute(XNamespace.Xmlns + "aw", "http://www.adventure-works.com"), _
    "Content")
Console.WriteLine(root)
```

In Visual Basic, instead of creating a namespace node to control namespace prefixes, you would typically use a global namespace declaration:

```vb
Imports <xmlns:aw='http://www.adventure-works.com'>

Module Module1
    Sub Main()
        Dim root As XElement = _
            <aw:Root>Content</aw:Root>
        Console.WriteLine(root)
    End Sub
End Module
```

This example produces the following output:

```
<aw:Root xmlns:aw="http://www.adventure-works.com">Content</aw:Root>
```

For more information, see [How to control namespace prefixes](../../standard/linq/control-namespace-prefixes.md).

## Create a default namespace

When constructing an attribute that will be a namespace, if the attribute name has the special value of "xmlns", then when the XML tree is serialized, the namespace will be declared as the default namespace. The special attribute with the name of "xmlns" itself is not in any namespace. The value of the attribute is the namespace URI.

The following example creates an XML tree that contains an attribute that is declared in such a way that the namespace will become the default namespace:

```csharp
XNamespace aw = "http://www.adventure-works.com";
XElement root = new XElement(aw + "Root",
    new XAttribute("xmlns", "http://www.adventure-works.com"),
    new XElement(aw + "Child", "content")
);
Console.WriteLine(root);
```

```vb
Dim aw As XNamespace = "http://www.adventure-works.com"
Dim root As XElement = New XElement(aw + "Root", _
    New XAttribute("xmlns", "http://www.adventure-works.com"), _
    New XElement(aw + "Child", "content") _
)
Console.WriteLine(root)
```

In Visual Basic, instead of creating a namespace node to create a default namespace, you would typically use a global default namespace declaration:

```vb
Imports <xmlns='http://www.adventure-works.com'>

Module Module1
    Sub Main()
        Dim root As XElement = _
            <Root>
                <Child>content</Child>
            </Root>
        Console.WriteLine(root)
    End Sub
End Module
```

This example produces the following output:

```
<Root xmlns="http://www.adventure-works.com">
  <Child>content</Child>
</Root>
```

## XNamespace atomization

<xref:System.Xml.Linq.XNamespace> objects are guaranteed to be atomized; that is, if two <xref:System.Xml.Linq.XNamespace> objects have exactly the same URI, they will share the same instance. The equality and comparison operators are provided explicitly for this purpose.

## Use expanded names

Another way to specify a namespace and a local name is to use an expanded name in the form `{namespace}name`:

```csharp
XElement e = new XElement("{http://www.adventure-works.com}Root",
     new XAttribute("{http://www.adventure-works.com}Att", "content")
);
Console.WriteLine(e);
```

```vb
Dim e As XElement = New XElement("{http://www.adventure-works.com}Root", _
     New XAttribute("{http://www.adventure-works.com}Att", "content") _
)
Console.WriteLine(e)
```

This example produces the following output:

```
<Root p1:Att="content" xmlns:p1="http://www.adventure-works.com" xmlns="http://www.adventure-works.com" />
```

This approach has performance implications. Each time that you pass a string that contains an expanded name to LINQ to XML, it must parse the name, find the atomized namespace, and find the atomized name. This process takes CPU time. If performance is important, you may want to use a different approach.

With Visual Basic, the recommended approach is to use XML literals, which does not involve the use of expanded names.
