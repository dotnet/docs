---
title: System.Xml.Linq.XName class
description: Learn about the System.Xml.Linq.XName class.
ms.date: 12/31/2023
---
# System.Xml.Linq.XName class

[!INCLUDE [context](includes/context.md)]

XML names include a namespace and a local name. A *fully qualified name* is the combination of the namespace and local name.

## Create an XName object

<xref:System.Xml.Linq.XName> does not contain any public constructors. Instead, this class provides an implicit conversion from <xref:System.String> that allows you to create an <xref:System.Xml.Linq.XName>. The most common place you use this conversion is when constructing an element or attribute: The first argument to the <xref:System.Xml.Linq.XElement> constructor is an <xref:System.Xml.Linq.XName>. By passing a string, you take advantage of the implicit conversion. The following code creates an element with a name that is in no namespace:

```csharp
XElement root = new XElement("ElementName", "content");
Console.WriteLine(root);
```

In Visual Basic, it's more appropriate to use XML literals:

```vb
Dim root As XElement = <ElementName>content</ElementName>
Console.WriteLine(root)
```

This example produces the following output:

```xml
<ElementName>content</ElementName>
```

Assigning a string to an <xref:System.Xml.Linq.XName> uses the implicit conversion from <xref:System.String>.

The Visual Basic example creates the <xref:System.Xml.Linq.XElement> using XML literals. Even though XML literals are used, an <xref:System.Xml.Linq.XName> object is created for the <xref:System.Xml.Linq.XElement>.

In addition, you can call the <xref:System.Xml.Linq.XName.Get%2A> method for an <xref:System.Xml.Linq.XName> object. However, the recommended way is to use the implicit conversion from string.

## Create an XName in a namespace

As with XML, an <xref:System.Xml.Linq.XName> can be in a namespace, or it can be in no namespace.

For C#, the recommended approach for creating an <xref:System.Xml.Linq.XName> in a namespace is to declare the <xref:System.Xml.Linq.XNamespace> object, then use the override of the addition operator.

For Visual Basic, the recommended approach is to use XML literals and global namespace declarations to create XML that is in a namespace.

```csharp
XNamespace aw = "http://www.adventure-works.com";
XElement root = new XElement(aw + "ElementName", "content");
Console.WriteLine(root);
```

```vb
Imports <xmlns="http://www.adventure-works.com">

Module Module1
    Sub Main()
        Dim root As XElement = <ElementName>content</ElementName>
        Console.WriteLine(root)
    End Sub
End Module
```

This example produces the following output:

```xml
<ElementName xmlns="http://www.adventure-works.com">content</ElementName>
```

## Create an XName in no namespace

The <xref:System.Xml.Linq.XName.Namespace> property of an <xref:System.Xml.Linq.XName> object is guaranteed to not be null. If the <xref:System.Xml.Linq.XName> is in no namespace, then the <xref:System.Xml.Linq.XName.Namespace> property will be set to <xref:System.Xml.Linq.XNamespace.None%2A>. The following code demonstrates this:

```csharp
XElement root = new XElement("ElementName", "content");
if (root.Name.Namespace == XNamespace.None)
    Console.WriteLine("The element is in no namespace.");
else
    Console.WriteLine("The element is in a namespace.");
```

```vb
Dim root As XElement = <ElementName>content</ElementName>
If (root.Name.Namespace Is XNamespace.None) Then
    Console.WriteLine("The element is in no namespace.")
Else
    Console.WriteLine("The element is in a namespace.")
End If
```

This example produces the following output:

```
The element is in no namespace.
```

## Use expanded names

You can also create an <xref:System.Xml.Linq.XName> from a expanded XML name in the form `{namespace}localname`:

```csharp
XElement root = new XElement("{http://www.adventure-works.com}ElementName", "content");
Console.WriteLine(root);
```

```vb
Dim root As XElement = New XElement("{http://www.adventure-works.com}ElementName", "content")
Console.WriteLine(root)
```

This example produces the following output:

```xml
<ElementName xmlns="http://www.adventure-works.com">content</ElementName>
```

Be aware that creating an <xref:System.Xml.Linq.XName> through an expanded name is less efficient than creating an <xref:System.Xml.Linq.XNamespace> object and using the override of the addition operator. It is also less efficient than importing a global namespace and using XML literals in Visual Basic.

If you create an <xref:System.Xml.Linq.XName> using an expanded name, LINQ to XML must find the atomized instance of a namespace. This work must be repeated for every use of an expanded name. This additional time is likely to be negligible when writing LINQ queries; however, it might be significant when creating a large XML tree.

## XName objects are atomized

<xref:System.Xml.Linq.XName> objects are guaranteed to be atomized; that is, if two <xref:System.Xml.Linq.XName> objects have exactly the same namespace and exactly the same local name, they will share the same instance. The equality and comparison operators are also provided explicitly for this purpose.

Among other benefits, this feature allows for faster execution of queries. When filtering on the name of elements or attributes, the comparisons expressed in predicates use identity comparison, not value comparison. It is much faster to determine that two references actually refer to the same object than to compare two strings.
