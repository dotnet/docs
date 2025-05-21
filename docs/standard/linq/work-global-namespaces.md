---
title: Work with global namespaces in Visual Basic - LINQ to XML
description: You declare a namespace in Visual Basic with the Imports statement, whether the namespace is a default namespace or has a prefix. This article discusses Import statements and other aspects of working with namespaces.
ms.date: 07/20/2015
dev_langs:
  - "csharp"
  - "vb"
ms.assetid: 0a8064d5-e02f-4315-ad48-6deaa443a2f0
ms.topic: how-to
---

# Work with global namespaces in Visual Basic (LINQ to XML)

One of the key features of XML literals in Visual Basic is the capability to declare XML namespaces by using the `Imports` statement. Using this feature, you can declare an XML namespace that uses a prefix, or you can declare a default XML namespace.

This capability is useful in two situations:

- Namespaces declared in XML literals don't carry over into embedded expressions. Declaring global namespaces reduces the amount of work needed to use embedded expressions with namespaces.
- You must declare global namespaces in order to use namespaces with XML properties.

You can declare global namespaces at the project level. You can also declare global namespaces at the module level, which overrides the project-level global namespaces. Finally, you can override global namespaces in an XML literal.

When using XML literals or XML properties that are in globally declared namespaces, you can see the expanded name of XML literals or properties by hovering over them in Visual Studio. You will see the expanded name in a tooltip.

You can get an <xref:System.Xml.Linq.XNamespace> object that corresponds to a global namespace using the `GetXmlNamespace` method.

## Example: Use `Imports` to declare a global namespace

The following example declares a default global namespace with the `Imports` statement, and then initializes an <xref:System.Xml.Linq.XElement> object in that namespace with an XML literal:

```vb
Imports <xmlns="http://www.adventure-works.com">

Module Module1
    Sub Main()
        Dim root As XElement = <Root/>
        Console.WriteLine(root)
    End Sub
End Module
```

This example produces the following output:

```xml
<Root xmlns="http://www.adventure-works.com" />
```

## Example: Declare a global namespace that has a prefix

The next example declares a global namespace with a prefix, and initializes an element with an XML literal:

```vb
Imports <xmlns:aw="http://www.adventure-works.com">

Module Module1
    Sub Main()
        Dim root As XElement = <aw:Root/>
        Console.WriteLine(root)
    End Sub
End Module
```

This example produces the following output:

```xml
<aw:Root xmlns:aw="http://www.adventure-works.com" />
```

## Example: Declare a default namespace and use an embedded expression for the `Child` element

Namespaces that are declared in XML literals don't carry over into embedded expressions. The following example declares a default namespace, and then uses an embedded expression for the `Child` element.

```vb
Dim root As XElement = _
    <Root xmlns="http://www.adventure-works.com">
        <%= <Child/> %>
    </Root>
Console.WriteLine(root)
```

This example produces the following output:

```xml
<Root xmlns="http://www.adventure-works.com">
  <Child xmlns="" />
</Root>
```

The resulting XML includes a declaration of a default namespace so that the `Child` element is in no namespace.

You could declare a different namespace in the embedded expression, as follows:

```vb
Dim root As XElement = _
    <Root xmlns="http://www.adventure-works.com">
        <%= <Child xmlns="http://www.adventure-works.com"/> %>
    </Root>
Console.WriteLine(root)
```

This example produces the following output:

```xml
<Root xmlns="http://www.adventure-works.com">
  <Child xmlns="http://www.adventure-works.com" />
</Root>
```

However, with the global default namespace you can use XML literals without declaring namespaces. The resulting XML will be in the globally-declared default namespace, as in this example:

```vb
Imports <xmlns="http://www.adventure-works.com">

Module Module1
    Sub Main()
        Dim root As XElement = <Root>
                                   <%= <Child/> %>
                               </Root>
        Console.WriteLine(root)
    End Sub
End Module
```

This example produces the following output:

```xml
<Root xmlns="http://www.adventure-works.com">
  <Child />
</Root>
```

## Example: Use namespaces with XML properties

If you're working with an XML tree that's in a namespace, and you use XML properties, then you must use a global namespace so that the XML properties will also be in the correct namespace. The following example declares an XML tree in a namespace, and then prints the count of `Child` elements.

```vb
Dim root As XElement = _
    <Root xmlns="http://www.adventure-works.com">
        <Child>content</Child>
    </Root>
Console.WriteLine(root.<Child>.Count())
```

This example indicates that there are no `Child` elements. It produces this output:

```output
0
```

If, however, you declare a default global namespace, then both the XML literal and the XML property are in the default global namespace:

```vb
Imports <xmlns="http://www.adventure-works.com">

Module Module1
    Sub Main()
        Dim root As XElement = _
            <Root>
                <Child>content</Child>
            </Root>
        Console.WriteLine(root.<Child>.Count())
    End Sub
End Module
```

This example indicates that there is one `Child` element. It produces this output:

```output
1
```

If you declare a global namespace that has a prefix, you can use the prefix for both XML literals and XML properties:

```vb
Imports <xmlns:aw="http://www.adventure-works.com">

Module Module1
    Sub Main()
        Dim root As XElement = _
            <aw:Root>
                <aw:Child>content</aw:Child>
            </aw:Root>
        Console.WriteLine(root.<aw:Child>.Count())
    End Sub
End Module
```

## Example: Use `GetXmlNamespace` to get an `XNamespace`

You can obtain an <xref:System.Xml.Linq.XNamespace> object by using the `GetXmlNamespace` method:

```vb
Imports <xmlns:aw="http://www.adventure-works.com">

Module Module1
    Sub Main()
        Dim root As XElement = <aw:Root/>
        Dim xn As XNamespace = GetXmlNamespace(aw)
        Console.WriteLine(xn)
    End Sub
End Module
```

This example produces the following output:

```output
http://www.adventure-works.com
```

## See also

- [Namespaces overview](namespaces-overview.md)
