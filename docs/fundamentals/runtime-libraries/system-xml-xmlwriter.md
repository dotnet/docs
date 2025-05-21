---
title: System.Xml.XmlWriter class
description: Learn about the System.Xml.XmlWriter class.
ms.date: 12/31/2023
dev_langs:
  - CSharp
  - VB
ms.topic: article
---
# System.Xml.XmlWriter class

The <xref:System.Xml.XmlWriter> class writes XML data to a stream, file, text reader, or string. It supports the W3C [Extensible Markup Language (XML) 1.0 (fourth edition)](https://www.w3.org/TR/2006/REC-xml-20060816/) and [Namespaces in XML 1.0 (third edition)](https://www.w3.org/TR/REC-xml-names/) recommendations.

The members of the <xref:System.Xml.XmlWriter> class enable you to:

- Verify that the characters are legal XML characters and that element and attribute names are valid XML names.
- Verify that the XML document is well-formed.
- Encode binary bytes as Base64 or BinHex, and write out the resulting text.
- Pass values by using common language runtime types instead of strings, to avoid having to manually perform value conversions.
- Write multiple documents to one output stream.
- Write valid names, qualified names, and name tokens.

## Create an XML writer

To create an <xref:System.Xml.XmlWriter> instance, use the <xref:System.Xml.XmlWriter.Create%2A?displayProperty=nameWithType> method. To specify the set of features you want to enable on the XML writer, pass an <xref:System.Xml.XmlWriterSettings> to the <xref:System.Xml.XmlWriter.Create%2A> method. Otherwise, default settings are used. See the <xref:System.Xml.XmlWriter.Create%2A> reference pages for details.

## Specify the output format

The <xref:System.Xml.XmlWriterSettings> class includes several properties that control how <xref:System.Xml.XmlWriter> output is formatted:

|Property|Description|
|--------------|-----------------|
|<xref:System.Xml.XmlWriterSettings.Encoding%2A>|Specifies the text encoding to use. The default is `Encoding.UTF8`.|
|<xref:System.Xml.XmlWriterSettings.Indent%2A>|Indicates whether to indent elements. The default is `false` (no indentation).|
|<xref:System.Xml.XmlWriterSettings.IndentChars%2A>|Specifies the character string to use when indenting. The default is two spaces.|
|<xref:System.Xml.XmlWriterSettings.NewLineChars%2A>|Specifies the character string to use for line breaks. The default is `\r\n` (carriage return, line feed) for non-Unix platforms, and `\n` (line feed) for Unix platforms.|
|<xref:System.Xml.XmlWriterSettings.NewLineHandling%2A>|Specifies how to handle newline characters.|
|<xref:System.Xml.XmlWriterSettings.NewLineOnAttributes%2A>|Indicates whether to write attributes on a new line. <xref:System.Xml.XmlWriterSettings.Indent%2A> should be set to `true` when using this property. The default is `false`.|
|<xref:System.Xml.XmlWriterSettings.OmitXmlDeclaration%2A>|Indicates whether to write an XML declaration. The default is `false`.|

The <xref:System.Xml.XmlWriterSettings.Indent%2A> and <xref:System.Xml.XmlWriterSettings.IndentChars%2A> properties control how insignificant white space is formatted. For example, to indent element nodes:

:::code language="csharp" source="./snippets/System.Xml/XmlWriter/Overview/csharp/writer_v2.cs" id="Snippet8":::
:::code language="vb" source="./snippets/System.Xml/XmlWriter/Overview/vb/writer_v2.vb" id="Snippet8":::

Use the <xref:System.Xml.XmlWriterSettings.NewLineOnAttributes%2A> to write each attribute on a new line with one extra level of indentation:

:::code language="csharp" source="./snippets/System.Xml/XmlWriter/Overview/csharp/writer_v2.cs" id="Snippet9":::
:::code language="vb" source="./snippets/System.Xml/XmlWriter/Overview/vb/writer_v2.vb" id="Snippet9":::

## Data conformance

An XML writer uses two properties from the <xref:System.Xml.XmlWriterSettings> class to check for data conformance:

- The <xref:System.Xml.XmlWriterSettings.CheckCharacters> property instructs the XML writer to check characters and throw an <xref:System.Xml.XmlException> exception if any characters are outside the legal range, as defined by the W3C.

- The <xref:System.Xml.XmlWriterSettings.ConformanceLevel> property configures the XML writer to check that the stream being written complies with the rules for a well-formed XML 1.0 document or document fragment, as defined by the W3C. The three conformance levels are described in the following table. The default is <xref:System.Xml.ConformanceLevel.Document>. For details, see the <xref:System.Xml.XmlWriterSettings.ConformanceLevel?displayProperty=nameWithType> property and the <xref:System.Xml.ConformanceLevel?displayProperty=nameWithType> enumeration.

    |Level|Description|
    |-----------|-----------------|
    |<xref:System.Xml.ConformanceLevel.Document>|The XML output conforms to the rules for a well-formed XML 1.0 document and can be processed by any conforming processor.|
    |<xref:System.Xml.ConformanceLevel.Fragment>|The XML output conforms to the rules for a well-formed XML 1.0 document fragment.|
    |<xref:System.Xml.ConformanceLevel.Auto>|The XML writer determines which level of conformation checking to apply (document or fragment) based on the incoming data.|

## Write elements

You can use the following <xref:System.Xml.XmlWriter> methods to write element nodes. For examples, see the methods listed.

|Use|To|
|---------|--------|
|<xref:System.Xml.XmlWriter.WriteElementString%2A>|Write an entire element node, including a string value.|
|<xref:System.Xml.XmlWriter.WriteStartElement%2A>|To write an element value by using multiple method calls. For example, you can call <xref:System.Xml.XmlWriter.WriteValue%2A> to write a typed value, <xref:System.Xml.XmlWriter.WriteCharEntity%2A> to write a character entity, <xref:System.Xml.XmlWriter.WriteAttributeString%2A> to write an attribute, or you can write a child element. This is a more sophisticated version of the <xref:System.Xml.XmlWriter.WriteElementString%2A> method.<br /><br />To close the element, you call the <xref:System.Xml.XmlWriter.WriteEndElement%2A> or <xref:System.Xml.XmlWriter.WriteFullEndElement%2A> method.|
|<xref:System.Xml.XmlWriter.WriteNode%2A>|To copy an element node found at the current position of an <xref:System.Xml.XmlReader> or <xref:System.Xml.XPath.XPathNavigator> object. When called, it copies everything from the source object to the <xref:System.Xml.XmlWriter> instance.|

## Write attributes

You can use the following <xref:System.Xml.XmlWriter> methods to write attributes on element nodes. These methods can also be used to create namespace declarations on an element, as discussed in the next section.

|Use|To|
|---------|--------|
|<xref:System.Xml.XmlWriter.WriteAttributeString%2A>|To write an entire attribute node, including a string value.|
|<xref:System.Xml.XmlWriter.WriteStartAttribute%2A>|To write the attribute value using multiple method calls. For example, you can call <xref:System.Xml.XmlWriter.WriteValue%2A> to write a typed value. This is a more sophisticated version of the <xref:System.Xml.XmlWriter.WriteElementString%2A> method.<br /><br />To close the element, you call the <xref:System.Xml.XmlWriter.WriteEndAttribute%2A> method.|
|<xref:System.Xml.XmlWriter.WriteAttributes%2A>|To copy all the attributes found at the current position of an <xref:System.Xml.XmlReader> object. The attributes that are written depend on the type of node the reader is currently positioned on:<br /><br />- For an attribute node, it writes the current attribute, and then the rest of the attributes until the element closing tag.<br />- For an element node, it writes all attributes contained by the element.<br />- For an XML declaration node, it writes all the attributes in the declaration.<br />- For all other node types, the method throws an exception.|

## Handle namespaces

Namespaces are used to qualify element and attribute names in an XML document. Namespace prefixes associate elements and attributes with namespaces, which are in turn associated with URI references. Namespaces create element and attribute name uniqueness in an XML document.

The <xref:System.Xml.XmlWriter> maintains a namespace stack that corresponds to all the namespaces defined in the current namespace scope. When writing elements and attributes you can utilize namespaces in the following ways:

- Declare namespaces manually by using the <xref:System.Xml.XmlWriter.WriteAttributeString%2A> method. This can be useful when you know how to best optimize the number of namespace declarations. For an example, see the <xref:System.Xml.XmlWriter.WriteAttributeString%28System.String%2CSystem.String%2CSystem.String%2CSystem.String%29> method.

- Override the current namespace declaration with a new namespace. In the following code, the <xref:System.Xml.XmlWriter.WriteAttributeString%2A> method changes the namespace URI for the `"x"` prefix from `"123"` to `"abc"`.

  :::code language="csharp" source="./snippets/System.Xml/XmlWriter/Overview/csharp/writer_v2.cs" id="Snippet18":::
  :::code language="vb" source="./snippets/System.Xml/XmlWriter/Overview/vb/writer_v2.vb" id="Snippet18":::

  The code generates the following XML string:

    ```xml
    <x:root xmlns:x="123">
      <item xmlns:x="abc" />
    </x:root>
    ```

- Specify a namespace prefix when writing attributes or elements. Many of the methods used to write element and attributes enable you to do this. For example, the <xref:System.Xml.XmlWriter.WriteStartElement%28System.String%2CSystem.String%2CSystem.String%29> method writes a start tag and associates it with a specified namespace and prefix.

## Write typed data

The <xref:System.Xml.XmlWriter.WriteValue%2A> method accepts a common language runtime (CLR) object, converts the input value to its string representation according to XML schema definition language (XSD) data type conversion rules, and writes it out by using the <xref:System.Xml.XmlWriter.WriteString%2A> method. This is easier than using the methods in the <xref:System.Xml.XmlConvert> class to convert the typed data to a string value before writing it out.

When writing to text, the typed value is serialized to text by using the <xref:System.Xml.XmlConvert> rules for that schema type.

For default XSD data types that correspond to CLR types, see the <xref:System.Xml.XmlWriter.WriteValue%2A> method.

The <xref:System.Xml.XmlWriter> can also be used to write to an XML data store. For example, the <xref:System.Xml.XPath.XPathNavigator> class can create an <xref:System.Xml.XmlWriter> object to create nodes for an <xref:System.Xml.XmlDocument> object. If the data store has schema information available to it, the <xref:System.Xml.XmlWriter.WriteValue%2A> method throws an exception if you try to convert to a type that is not allowed. If the data store does not have schema information available to it, the <xref:System.Xml.XmlWriter.WriteValue%2A> method treats all values as an `xsd:anySimpleType` type.

## Close the XML writer

When you use <xref:System.Xml.XmlWriter> methods to output XML, the elements and attributes are not written until you call the <xref:System.Xml.XmlWriter.Close%2A> method. For example, if you are using <xref:System.Xml.XmlWriter> to populate an <xref:System.Xml.XmlDocument> object, you won't be able to see the written elements and attributes in the target document until you close the <xref:System.Xml.XmlWriter> instance.

## Asynchronous programming

Most of the <xref:System.Xml.XmlWriter> methods have asynchronous counterparts that have "Async" at the end of their method names. For example, the asynchronous equivalent of <xref:System.Xml.XmlWriter.WriteAttributeString%2A> is <xref:System.Xml.XmlWriter.WriteAttributeStringAsync%2A>.

For the <xref:System.Xml.XmlWriter.WriteValue%2A> method, which doesn't have an asynchronous counterpart, convert the return value to a string and use the <xref:System.Xml.XmlWriter.WriteStringAsync%2A> method instead.

## Security considerations

Consider the following when working with the <xref:System.Xml.XmlWriter> class:

- Exceptions thrown by the <xref:System.Xml.XmlWriter> can disclose path information that you do not want bubbled up to the app. Your app must catch exceptions and process them appropriately.

- <xref:System.Xml.XmlWriter> does not validate any data that is passed to the <xref:System.Xml.XmlWriter.WriteDocType%2A> or <xref:System.Xml.XmlWriter.WriteRaw%2A> method. You should not pass arbitrary data to these methods.
