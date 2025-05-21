---
title: System.Xml.XmlTextWriter class
description: Learn about the System.Xml.XmlTextWriter class.
ms.date: 12/31/2023
ms.topic: article
---
# System.Xml.XmlTextWriter class

[!INCLUDE [context](includes/context.md)]

The <xref:System.Xml.XmlTextWriter> class implements the <xref:System.Xml.XmlWriter> class.

> [!NOTE]
> We recommend that you create <xref:System.Xml.XmlWriter> instances by using the <xref:System.Xml.XmlWriter.Create%2A?displayProperty=nameWithType> method and the <xref:System.Xml.XmlWriterSettings> class to take advantage of new functionality.

`XmlTextWriter` maintains a namespace stack corresponding to all the namespaces defined in the current element stack. Using `XmlTextWriter` you can declare namespaces manually.

```csharp
w.WriteStartElement("root");
w.WriteAttributeString("xmlns", "x", null, "urn:1");
w.WriteStartElement("item","urn:1");
w.WriteEndElement();
w.WriteStartElement("item","urn:1");
w.WriteEndElement();
w.WriteEndElement();
```

The above C# code produces the following output. `XmlTextWriter` promotes the namespace declaration to the root element to avoid having it duplicated on the two child elements. The child elements pick up the prefix from the namespace declaration.

```xml
<root xmlns:x="urn:1">
<x:item/>
<x:item/>
</x:root>
```

`XmlTextWriter` also allows you to override the current namespace declaration. In the following example, the namespace URI "123" is overridden by "abc" to produce the XML element `<x:node xmlns:x="abc"/>`.

```csharp
w.WriteStartElement("x","node","123");
w.WriteAttributeString("xmlns","x",null,"abc");
```

By using the write methods that take a prefix as an argument you can also specify which prefix to use. In the following example, two different prefixes are mapped to the same namespace URI to produce the XML text `<x:root xmlns:x="urn:1"><y:item xmlns:y="urn:1"/></x:root>`.

```csharp
XmlTextWriter w = new XmlTextWriter(Console.Out);
w.WriteStartElement("x","root","urn:1");
w.WriteStartElement("y","item","urn:1");
w.WriteEndElement();
w.WriteEndElement();
w.Close();
```

If there are multiple namespace declarations mapping different prefixes to the same namespace URI, `XmlTextWriter` walks the stack of namespace declarations backwards and picks the closest one.

```csharp
XmlTextWriter w = new XmlTextWriter(Console.Out);
w.Formatting = Formatting.Indented;
w.WriteStartElement("x","root","urn:1");
w.WriteStartElement("y","item","urn:1");
w.WriteAttributeString("attr","urn:1","123");
w.WriteEndElement();
w.WriteEndElement();
w.Close();
```

In the above C# example, because the `WriteAttributeString` call does not specify a prefix, the writer uses the last prefix pushed onto the namespace stack, and produces the following XML:

```xml
<x:root xmlns:x="urn:1">
<y:item y:attr="123" xmlns:y="urn:1" />
</x:root>
```

If namespace conflicts occur, `XmlTextWriter` resolves them by generating alternate prefixes. For example, if an attribute and element have the same prefix but different namespaces, `XmlWriter` generates an alternate prefix for the attribute. The generated prefixes are named `n{i}` where `i` is a number beginning at 1. The number is reset to 1 for each element.

Attributes which are associated with a namespace URI must have a prefix (default namespaces do not apply to attributes). This conforms to section 5.2 of the W3C Namespaces in XML recommendation. If an attribute references a namespace URI, but does not specify a prefix, the writer generates a prefix for the attribute.

When writing an empty element, an additional space is added between tag name and the closing tag, for example `<item />`. This provides compatibility with older browsers.

When a `String` is used as method parameter, `null` and `String.Empty` are equivalent. `String.Empty` follows the W3C rules.

To write strongly typed data, use the <xref:System.Xml.XmlConvert> class to convert data types to string. For example, the following C# code converts the data from `Double` to `String` and writes the element `<price>19.95</price>`.

```csharp
Double price = 19.95;
writer.WriteElementString("price", XmlConvert.ToString(price));
```

`XmlTextWriter` does not check for the following:

- Invalid characters in attribute and element names.
- Unicode characters that do not fit the specified encoding. If the Unicode characters do not fit the specified encoding, the `XmlTextWriter` does not escape the Unicode characters into character entities.
- Duplicate attributes.
- Characters in the DOCTYPE public identifier or system identifier.

## Security considerations

The following items are things to consider when working with the <xref:System.Xml.XmlTextWriter> class.

- Exceptions thrown by the <xref:System.Xml.XmlTextWriter> can disclose path information that you do not want bubbled up to the application. Your applications must catch exceptions and process them appropriately.

- When you pass the <xref:System.Xml.XmlTextWriter> to another application the underlying stream is exposed to that application. If you need to pass the <xref:System.Xml.XmlTextWriter> to a semi-trusted application, you should use an <xref:System.Xml.XmlWriter> object created by the <xref:System.Xml.XmlWriter.Create%2A> method instead.

- The <xref:System.Xml.XmlTextWriter> does not validate any data that is passed to the <xref:System.Xml.XmlTextWriter.WriteDocType%2A> or <xref:System.Xml.XmlTextWriter.WriteRaw%2A> methods. You should not pass arbitrary data to these methods.

- If the default settings are changed, there is no guarantee that the generated output is well-formed XML data.

- Do not accept supporting components, such as an <xref:System.Text.Encoding> object, from an untrusted source.
