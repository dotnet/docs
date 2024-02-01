---
title: System.Xml.XmlReader.Create methods
description: Learn about the System.Xml.XmlReader.Create methods.
ms.date: 01/24/2024
dev_langs:
  - CSharp
  - VB
---
# System.Xml.XmlReader.Create methods

[!INCLUDE [context](includes/context.md)]

Most of the <xref:System.Xml.XmlReader.Create%2A> overloads include a `settings` parameter that accepts an <xref:System.Xml.XmlReaderSettings> object. You can use this object to:

- Specify which features you want supported on the <xref:System.Xml.XmlReader> object.
- Reuse the <xref:System.Xml.XmlReaderSettings> object to create multiple readers. You can use the same settings to create multiple readers with the same functionality. Or, you can modify the settings on an <xref:System.Xml.XmlReaderSettings> instance and create a new reader with a different set of features.
- Add features to an existing XML reader. The <xref:System.Xml.XmlReader.Create%2A> method can accept another <xref:System.Xml.XmlReader> object. The underlying <xref:System.Xml.XmlReader> object can be a user-defined reader, a <xref:System.Xml.XmlTextReader> object, or another <xref:System.Xml.XmlReader> instance that you want to add additional features to.
- Take full advantage of features such as better conformance checking and compliance to the [XML 1.0 (fourth edition)](https://www.w3.org/TR/2006/REC-xml-20060816/) recommendation that are available only on <xref:System.Xml.XmlReader> objects created by the static <xref:System.Xml.XmlReader.Create%2A> method.

> [!NOTE]
> Although .NET includes concrete implementations of the <xref:System.Xml.XmlReader> class, such as the <xref:System.Xml.XmlTextReader>, <xref:System.Xml.XmlNodeReader>, and the <xref:System.Xml.XmlValidatingReader> classes, we recommend that you create <xref:System.Xml.XmlReader> instances by using the <xref:System.Xml.XmlReader.Create%2A> method.

## Default settings

If you use a <xref:System.Xml.XmlReader.Create%2A> overload that doesn't accept a <xref:System.Xml.XmlReaderSettings> object, the following default reader settings are used:

| Setting                                                             | Default                                               |
|---------------------------------------------------------------------|-------------------------------------------------------|
| <xref:System.Xml.XmlReaderSettings.CheckCharacters%2A>              | `true`                                                |
| <xref:System.Xml.XmlReaderSettings.ConformanceLevel%2A> | <xref:System.Xml.ConformanceLevel.Document?displayProperty=nameWithType> |
| <xref:System.Xml.XmlReaderSettings.IgnoreComments%2A>               | `false`                                               |
| <xref:System.Xml.XmlReaderSettings.IgnoreProcessingInstructions%2A> | `false`                                               |
| <xref:System.Xml.XmlReaderSettings.IgnoreWhitespace%2A>             | `false`                                               |
| <xref:System.Xml.XmlReaderSettings.LineNumberOffset%2A>             | 0                                                     |
| <xref:System.Xml.XmlReaderSettings.LinePositionOffset%2A>           | 0                                                     |
| <xref:System.Xml.XmlReaderSettings.NameTable%2A>                    | `null`                                                |
| <xref:System.Xml.XmlReaderSettings.DtdProcessing%2A>                | <xref:System.Xml.DtdProcessing.Prohibit>              |
| <xref:System.Xml.XmlReaderSettings.Schemas%2A>                      | An empty <xref:System.Xml.Schema.XmlSchemaSet> object |
| <xref:System.Xml.XmlReaderSettings.ValidationFlags%2A> | <xref:System.Xml.Schema.XmlSchemaValidationFlags.ProcessIdentityConstraints> enabled |
| <xref:System.Xml.XmlReaderSettings.ValidationType%2A>               | <xref:System.Xml.ValidationType.None>                 |
| <xref:System.Xml.XmlReaderSettings.XmlResolver%2A>                  | `null` |

## Settings for common scenarios

Here are the <xref:System.Xml.XmlReaderSettings> properties you should set for some of the typical XML reader scenarios.

|Requirement|Set|
|-----------------|---------|
|Data must be a well-formed XML document.|<xref:System.Xml.XmlReaderSettings.ConformanceLevel%2A> to <xref:System.Xml.ConformanceLevel.Document>.|
|Data must be a well-formed XML parsed entity.|<xref:System.Xml.XmlReaderSettings.ConformanceLevel%2A> to <xref:System.Xml.ConformanceLevel.Fragment>.|
|Data must be validated against a DTD.|<xref:System.Xml.XmlReaderSettings.DtdProcessing%2A> to <xref:System.Xml.DtdProcessing.Parse><br /><xref:System.Xml.XmlReaderSettings.ValidationType%2A> to <xref:System.Xml.ValidationType.DTD>.|
|Data must be validated against an XML schema.|<xref:System.Xml.XmlReaderSettings.ValidationType%2A> to <xref:System.Xml.ValidationType.Schema><br /><xref:System.Xml.XmlReaderSettings.Schemas%2A> to the <xref:System.Xml.Schema.XmlSchemaSet> to use for validation. Note that <xref:System.Xml.XmlReader> doesn't support XML-Data Reduced (XDR) schema validation.|
|Data must be validated against an inline XML schema.|<xref:System.Xml.XmlReaderSettings.ValidationType%2A> to <xref:System.Xml.ValidationType.Schema><br /><xref:System.Xml.XmlReaderSettings.ValidationFlags%2A> to <xref:System.Xml.Schema.XmlSchemaValidationFlags.ProcessInlineSchema>.|
|Type support.|<xref:System.Xml.XmlReaderSettings.ValidationType%2A> to <xref:System.Xml.ValidationType.Schema><br /><xref:System.Xml.XmlReaderSettings.Schemas%2A> to the <xref:System.Xml.Schema.XmlSchemaSet> to use.|

<xref:System.Xml.XmlReader> doesn't support XML-Data Reduced (XDR) schema validation.

## Asynchronous programming

In synchronous mode, the <xref:System.Xml.XmlReader.Create%2A> method reads the first chunk of data from the buffer of the file, stream, or text reader. This may throw an exception if an I/O operation fails. In asynchronous mode, the first I/O operation occurs with a read operation, so exceptions that arise will be thrown when the read operation occurs.

## Security considerations

By default, the <xref:System.Xml.XmlReader> uses an <xref:System.Xml.XmlUrlResolver> object with no user credentials to open resources. This means that, by default, the XML reader can access any location that doesn't require credentials. Use the <xref:System.Xml.XmlReaderSettings.XmlResolver> property to control access to resources:

- Set <xref:System.Xml.XmlReaderSettings.XmlResolver%2A> to an <xref:System.Xml.XmlSecureResolver> object to restrict the resources that the XML reader can access, or...
- Set <xref:System.Xml.XmlReaderSettings.XmlResolver%2A> to `null` to prevent the XML reader from opening any external resources.

## Examples

This example creates an XML reader that strips insignificant white space, strips comments, and performs fragment-level conformance checking.

:::code language="csharp" source="./snippets/System.Xml/XmlParserContext/Overview/csharp/XmlReader_Create.cs" id="Snippet11":::
:::code language="vb" source="./snippets/System.Xml/XmlReader/Create/vb/XmlReader_Create.vb" id="Snippet11":::

The following example uses an <xref:System.Xml.XmlUrlResolver> with default credentials to access a file.

:::code language="csharp" source="./snippets/System.Xml/XmlReader/Create/csharp/factory_rdr_cctor21.cs" id="Snippet1":::
:::code language="vb" source="./snippets/System.Xml/XmlReader/Create/vb/factory_rdr_cctor2.vb" id="Snippet1":::

:::code language="csharp" source="./snippets/System.Xml/XmlReader/Create/csharp/factory_rdr_cctor21.cs" id="Snippet2":::
:::code language="vb" source="./snippets/System.Xml/XmlReader/Create/vb/factory_rdr_cctor2.vb" id="Snippet2":::

The following code wraps a reader instance within another reader.

:::code language="csharp" source="./snippets/System.Xml/XmlParserContext/Overview/csharp/XmlReader_Create.cs" id="Snippet13":::
:::code language="vb" source="./snippets/System.Xml/XmlReader/Create/vb/XmlReader_Create.vb" id="Snippet13":::

This example chains readers to add DTD and XML schema validation.

:::code language="csharp" source="./snippets/System.Xml/XmlParserContext/Overview/csharp/XmlReader_Create.cs" id="Snippet12":::
:::code language="vb" source="./snippets/System.Xml/XmlReader/Create/vb/XmlReader_Create.vb" id="Snippet12":::
