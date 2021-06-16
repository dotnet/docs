---
title: How to control namespace prefixes - LINQ to XML
description: You can control namespace prefixes when serializing an XML tree in C# and Visual Basic. To do this, insert attributes that declare namespaces.
ms.date: 07/20/2015
dev_langs:
  - "csharp"
  - "vb"
ms.topic: how-to
---

# How to control namespace prefixes (LINQ to XML)

This article describes how to control namespace prefixes when serializing an XML tree in C# and Visual Basic.

In many situations, it's not necessary to control namespace prefixes. However, certain XML programming tools require it. For example, you might be manipulating an XSLT style sheet or a XAML document that contains embedded XPath expressions that refer to specific namespace prefixes. In such a case, it's important that the document be serialized with those prefixes. This is a common reason for controlling namespace prefixes.

Another reason is that you want users to edit the XML document manually, and you want to create namespace prefixes that are convenient for the user to type. For example, you might be generating an XSD document. Conventions for schemas suggest that you use either `xs` or `xsd` as the prefix for the schema namespace.

To control namespace prefixes, you insert attributes that declare namespaces. If you declare the namespaces with specific prefixes, LINQ to XML will attempt to honor the namespace prefixes when serializing.

To create an attribute that declares a namespace with a prefix, you create an attribute where the namespace of the name of the attribute is <xref:System.Xml.Linq.XNamespace.Xmlns%2A>, and the name of the attribute is the namespace prefix. The value of the attribute is the URI of the namespace.

## Example: Create two namespaces that have prefixes

This example declares two namespaces. It specifies the prefix `aw` for the `http://www.adventure-works.com` namespace, and the prefix `fc` for the `www.fourthcoffee.com` namespace.

```csharp
XNamespace aw = "http://www.adventure-works.com";
XNamespace fc = "www.fourthcoffee.com";
XElement root = new XElement(aw + "Root",
    new XAttribute(XNamespace.Xmlns + "aw", "http://www.adventure-works.com"),
    new XAttribute(XNamespace.Xmlns + "fc", "www.fourthcoffee.com"),
    new XElement(fc + "Child",
        new XElement(aw + "DifferentChild", "other content")
    ),
    new XElement(aw + "Child2", "c2 content"),
    new XElement(fc + "Child3", "c3 content")
);
Console.WriteLine(root);
```

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

This example produces the following output:

```xml
<aw:Root xmlns:aw="http://www.adventure-works.com" xmlns:fc="www.fourthcoffee.com">
  <fc:Child>
    <aw:DifferentChild>other content</aw:DifferentChild>
  </fc:Child>
  <aw:Child2>c2 content</aw:Child2>
  <fc:Child3>c3 content</fc:Child3>
</aw:Root>
```

## See also

- [Namespaces overview](namespaces-overview.md)
