---
title: System.Xml.XmlReader class
description: Learn about the System.Xml.XmlReader class.
ms.date: 12/31/2023
dev_langs:
  - CSharp
  - VB
---
# System.Xml.XmlReader class

[!INCLUDE [context](includes/context.md)]

<xref:System.Xml.XmlReader> provides forward-only, read-only access to XML data in a document or stream. This class conforms to the W3C [Extensible Markup Language (XML) 1.0 (fourth edition)](https://www.w3.org/TR/2006/REC-xml-20060816/) and the [Namespaces in XML 1.0 (third edition)](https://www.w3.org/TR/REC-xml-names/) recommendations.

<xref:System.Xml.XmlReader> methods let you move through XML data and read the contents of a node. The properties of the class reflect the value of the current node, which is where the reader is positioned. The <xref:System.Xml.XmlReader.ReadState> property value indicates the current state of the XML reader. For example, the property is set to <xref:System.Xml.ReadState.Initial?displayProperty=nameWithType> by the <xref:System.Xml.XmlReader.Read%2A?displayProperty=nameWithType> method and <xref:System.Xml.ReadState.Closed?displayProperty=nameWithType> by the <xref:System.Xml.XmlReader.Close%2A?displayProperty=nameWithType> method. <xref:System.Xml.XmlReader> also provides data conformance checks and validation against a DTD or schema.

<xref:System.Xml.XmlReader> uses a pull model to retrieve data. This model:

- Simplifies state management by a natural, top-down procedural refinement.
- Supports multiple input streams and layering.
- Enables the client to give the parser a buffer into which the string is directly written, and thus avoids the necessity of an extra string copy.
- Supports selective processing. The client can skip items and process those that are of interest to the application. You can also set properties in advance to manage how the XML stream is processed (for example, normalization).

## Create an XML reader

Use the <xref:System.Xml.XmlReader.Create%2A> method to create an <xref:System.Xml.XmlReader> instance.

Although .NET provides concrete implementations of the <xref:System.Xml.XmlReader> class, such as the <xref:System.Xml.XmlTextReader>, <xref:System.Xml.XmlNodeReader>, and the <xref:System.Xml.XmlValidatingReader> classes, we recommend that you use the specialized classes only in these scenarios:

- When you want to read an XML DOM subtree from an <xref:System.Xml.XmlNode> object, use the <xref:System.Xml.XmlNodeReader> class. (However, this class doesn't support DTD or schema validation.)
- If you must expand entities on request, you don't want your text content normalized, or you don't want default attributes returned, use the <xref:System.Xml.XmlTextReader> class.

To specify the set of features you want to enable on the XML reader, pass an <xref:System.Xml.XmlReaderSettings?displayProperty=nameWithType> object to the <xref:System.Xml.XmlReader.Create%2A> method. You can use a single <xref:System.Xml.XmlReaderSettings?displayProperty=nameWithType> object to create multiple readers with the same functionality, or modify the <xref:System.Xml.XmlReaderSettings?displayProperty=nameWithType> object to create a new reader with a different set of features. You can also easily add features to an existing reader.

If you don't use a <xref:System.Xml.XmlReaderSettings?displayProperty=nameWithType> object, default settings are used. See the <xref:System.Xml.XmlReader.Create%2A> reference page for details.

<xref:System.Xml.XmlReader> throws an <xref:System.Xml.XmlException> on XML parse errors. After an exception is thrown, the state of the reader is not predictable. For example, the reported node type may be different from the actual node type of the current node. Use the <xref:System.Xml.XmlReader.ReadState> property to check whether the reader is in error state.

## Validate XML data

To define the structure of an XML document and its element relationships, data types, and content constraints, you use a document type definition (DTD) or XML Schema definition language (XSD) schema. An XML document is considered to be well formed if it meets all the syntactical requirements defined by the [W3C XML 1.0 Recommendation](https://www.w3.org/TR/2006/REC-xml-20060816/). It's considered valid if it's well formed and also conforms to the constraints defined by its DTD or schema. (See the [W3C XML Schema Part 1: Structures](https://www.w3.org/TR/xmlschema-1/) and the [W3C XML Schema Part 2: Datatypes](https://www.w3.org/TR/xmlschema-2/) recommendations.) Therefore, although all valid XML documents are well formed, not all well-formed XML documents are valid.

You can validate the data against a DTD, an inline XSD Schema, or an XSD Schema stored in an <xref:System.Xml.Schema.XmlSchemaSet> object (a cache); these scenarios are described on the <xref:System.Xml.XmlReader.Create%2A> reference page. <xref:System.Xml.XmlReader> doesn't support XML-Data Reduced (XDR) schema validation.

You use the following settings on the <xref:System.Xml.XmlReaderSettings> class to specify what type of validation, if any, the <xref:System.Xml.XmlReader> instance supports.

|Use this <xref:System.Xml.XmlReaderSettings> member|To specify|
|-----------------------------------------------------------------------------------------------------------------------------------------------------------|----------------|
|<xref:System.Xml.XmlReaderSettings.DtdProcessing> property|Whether to allow DTD processing. The default is to disallow DTD processing.|
|<xref:System.Xml.XmlReaderSettings.ValidationType> property|Whether the reader should validate data, and what type of validation to perform (DTD or schema). The default is no data validation.|
|<xref:System.Xml.XmlReaderSettings.ValidationEventHandler> event|An event handler for receiving information about validation events. If an event handler is not provided, an <xref:System.Xml.XmlException> is thrown on the first validation error.|
|<xref:System.Xml.XmlReaderSettings.ValidationFlags> property|Additional validation options through the <xref:System.Xml.Schema.XmlSchemaValidationFlags> enumeration members:<br /><br />- `AllowXmlAttributes`-- Allow XML attributes (`xml:*`) in instance documents even when they're not defined in the schema. The attributes are validated based on their data type. See the <xref:System.Xml.Schema.XmlSchemaValidationFlags> reference page for the setting to use in specific scenarios. (Disabled by default.)<br />- `ProcessIdentityConstraints` --Process identity constraints (`xs:ID`, `xs:IDREF`, `xs:key`, `xs:keyref`, `xs:unique`) encountered during validation. (Enabled by default.)<br />- `ProcessSchemaLocation` --Process schemas specified by the `xsi:schemaLocation` or `xsi:noNamespaceSchemaLocation` attribute. (Enabled by default.)<br />- `ProcessInlineSchema`-- Process inline XML Schemas during validation. (Disabled by default.)<br />- `ReportValidationWarnings`--Report events if a validation warning occurs. A warning is typically issued when there is no DTD or XML Schema to validate a particular element or attribute against. The <xref:System.Xml.XmlReaderSettings.ValidationEventHandler> is used for notification. (Disabled by default.)|
|<xref:System.Xml.XmlReaderSettings.Schemas%2A>|The <xref:System.Xml.Schema.XmlSchemaSet> to use for validation.|
|<xref:System.Xml.XmlReaderSettings.XmlResolver> property|The <xref:System.Xml.XmlResolver> for resolving and accessing external resources. This can include external entities such as DTD and schemas, and any `xs:include` or `xs:import` elements contained in the XML Schema. If you don't specify an <xref:System.Xml.XmlResolver>, the <xref:System.Xml.XmlReader> uses a default <xref:System.Xml.XmlUrlResolver> with no user credentials.|

## Data conformance

XML readers that are created by the <xref:System.Xml.XmlReader.Create%2A> method meet the following compliance requirements by default:

- New lines and attribute value are normalized according to the W3C [XML 1.0 Recommendation](https://www.w3.org/TR/2006/REC-xml-20060816/).

- All entities are automatically expanded.

- Default attributes declared in the document type definition are always added even when the reader doesn't validate.

- Declaration of XML prefix mapped to the correct XML namespace URI is allowed.

- The notation names in a single `NotationType` attribute declaration and `NmTokens` in a single `Enumeration` attribute declaration are distinct.

Use these <xref:System.Xml.XmlReaderSettings> properties to specify the type of conformance checks you want to enable:

|Use this <xref:System.Xml.XmlReaderSettings> property|To|Default|
|-------------------------------------------------------------------------------------------------------------------------------------------------------------|--------|-------------|
|<xref:System.Xml.XmlReaderSettings.CheckCharacters> property|Enable or disable checks for the following:<br /><br />- Characters are within the range of legal XML characters, as defined by the [2.2 Characters](https://www.w3.org/TR/2006/REC-xml-20060816/#charsets) section of the W3C XML 1.0 Recommendation.<br />- All XML names are valid, as defined by the [2.3 Common Syntactic Constructs](https://www.w3.org/TR/2006/REC-xml-20060816/#NT-Name) section of the W3C XML 1.0 Recommendation.<br /><br />When this property is set to `true` (default), an <xref:System.Xml.XmlException> exception is thrown if the XML file contains illegal characters or invalid XML names (for example, an element name starts with a number).|Character and name checking is enabled.<br /><br />Setting <xref:System.Xml.XmlReaderSettings.CheckCharacters%2A> to `false` turns off character checking for character entity references. If the reader is processing text data, it always checks that XML names are valid, regardless of this setting. **Note:**  The XML 1.0 recommendation requires document-level conformance when a DTD is present. Therefore, if the reader is configured to support <xref:System.Xml.ConformanceLevel.Fragment?displayProperty=nameWithType>, but the XML data contains a document type definition (DTD), an <xref:System.Xml.XmlException> is thrown.|
|<xref:System.Xml.XmlReaderSettings.ConformanceLevel> property|Choose the level of conformance to enforce:<br /><br />- <xref:System.Xml.ConformanceLevel.Document>. Conforms to the rules for a [well-formed XML 1.0 document](https://www.w3.org/TR/2006/REC-xml-20060816/#sec-well-formed).<br />- <xref:System.Xml.ConformanceLevel.Fragment>. Conforms to the rules for a well-formed document fragment that can be consumed as an [external parsed entity](https://www.w3.org/TR/2006/REC-xml-20060816/#wf-entities).<br />- <xref:System.Xml.ConformanceLevel.Auto>. Conforms to the level decided by the reader.<br /><br />If the data isn't in conformance, an <xref:System.Xml.XmlException> exception is thrown.|<xref:System.Xml.ConformanceLevel.Document>|

## Navigate through nodes

The current node is the XML node on which the XML reader is currently positioned. All <xref:System.Xml.XmlReader> methods perform operations in relation to this node, and all <xref:System.Xml.XmlReader> properties reflect the value of the current node.

The following methods make it easy to navigate through nodes and parse data.

|Use this <xref:System.Xml.XmlReaderSettings> method|To|
|-----------------------------------------------------------------------------------------------------------------------------------------------------------|--------|
|<xref:System.Xml.XmlReader.Read%2A>|Read the first node, and advance through the stream one node at a time. Such calls are typically performed inside a `while` loop.<br /><br />Use the <xref:System.Xml.XmlReader.NodeType> property to get the type (for example, attribute, comment, element, and so on) of the current node.|
|<xref:System.Xml.XmlReader.Skip%2A>|Skip the children of the current node and move to the next node.|
|<xref:System.Xml.XmlReader.MoveToContent%2A> and <xref:System.Xml.XmlReader.MoveToContentAsync%2A>|Skip non-content nodes and move to the next content node or to the end of the file.<br /><br />Non-content nodes include <xref:System.Xml.XmlNodeType.ProcessingInstruction>, <xref:System.Xml.XmlNodeType.DocumentType>, <xref:System.Xml.XmlNodeType.Comment>, <xref:System.Xml.XmlNodeType.Whitespace>, and <xref:System.Xml.XmlNodeType.SignificantWhitespace>.<br /><br />Content nodes include non-white space text, <xref:System.Xml.XmlNodeType.CDATA>, <xref:System.Xml.XmlNodeType.EntityReference> , and <xref:System.Xml.XmlNodeType.EndEntity>.|
|<xref:System.Xml.XmlReader.ReadSubtree%2A>|Read an element and all its children, and return a new <xref:System.Xml.XmlReader> instance set to <xref:System.Xml.ReadState.Initial?displayProperty=nameWithType>.<br /><br />This method is useful for creating boundaries around XML elements; for example, if you want to pass data to another component for processing and you want to limit how much of your data the component can access.|

See the <xref:System.Xml.XmlReader.Read%2A?displayProperty=nameWithType> reference page for an example of navigating through a text stream one node at a time and displaying the type of each node.

The following sections describe how you can read specific types of data, such as elements, attributes, and typed data.

## Read XML elements

The following table lists the methods and properties that the <xref:System.Xml.XmlReader> class provides for processing elements. After the <xref:System.Xml.XmlReader> is positioned on an element, the node properties, such as <xref:System.Xml.XmlReader.Name%2A>, reflect the element values. In addition to the members described below, any of the general methods and properties of the <xref:System.Xml.XmlReader> class can also be used to process elements. For example, you can use the <xref:System.Xml.XmlReader.ReadInnerXml%2A> method to read the contents of an element.

> [!NOTE]
> See section 3.1 of the [W3C XML 1.0 Recommendation](https://www.w3.org/TR/2006/REC-xml-20060816/#sec-starttags) for definitions of start tags, end tags, and empty element tags.

|Use this <xref:System.Xml.XmlReader> member|To|
|---------------------------------------------------------------------------------------------------------------------------------------------------|--------|
|<xref:System.Xml.XmlReader.IsStartElement%2A> method|Check if the current node is a start tag or an empty element tag.|
|<xref:System.Xml.XmlReader.ReadStartElement%2A> method|Check that the current node is an element and advance the reader to the next node (calls <xref:System.Xml.XmlReader.IsStartElement%2A> followed by <xref:System.Xml.XmlReader.Read%2A>).|
|<xref:System.Xml.XmlReader.ReadEndElement%2A> method|Check that the current node is an end tag and advance the reader to the next node.|
|<xref:System.Xml.XmlReader.ReadElementString%2A> method|Read a text-only element.|
|<xref:System.Xml.XmlReader.ReadToDescendant%2A> method|Advance the XML reader to the next descendant (child) element that has the specified name.|
|<xref:System.Xml.XmlReader.ReadToNextSibling%2A> method|Advance the XML reader to the next sibling element that has the specified name.|
|<xref:System.Xml.XmlReader.IsEmptyElement> property|Check if the current element has an end element tag. For example:<br /><br />- `<item num="123"/>` (<xref:System.Xml.XmlReader.IsEmptyElement%2A> is `true`.)<br />- `<item num="123"> </item>` (<xref:System.Xml.XmlReader.IsEmptyElement%2A> is `false`, although the element's content is empty.)|

For an example of reading the text content of elements, see the <xref:System.Xml.XmlReader.ReadString%2A> method. The following example processes elements by using a `while` loop.

:::code language="csharp" source="./snippets/System.Xml/XmlReader/Overview/csharp/XmlReader_Basic.cs" id="Snippet10":::
:::code language="vb" source="./snippets/System.Xml/XmlReader/Overview/vb/xmlreader_basic.vb" id="Snippet10":::

## Read XML attributes

XML attributes are most commonly found on elements, but they're also allowed on XML declaration and document type nodes.

When positioned on an element node, the <xref:System.Xml.XmlReader.MoveToAttribute%2A> method lets you go through the attribute list of the element. Note that after <xref:System.Xml.XmlReader.MoveToAttribute%2A> has been called, node properties such as <xref:System.Xml.XmlReader.Name%2A>, <xref:System.Xml.XmlReader.NamespaceURI%2A>, and <xref:System.Xml.XmlReader.Prefix%2A> reflect the properties of that attribute, not the properties of the element the attribute belongs to.

The <xref:System.Xml.XmlReader> class provides these methods and properties to read and process attributes on elements.

|Use this <xref:System.Xml.XmlReader> member|To|
|---------------------------------------------------------------------------------------------------------------------------------------------------|--------|
|<xref:System.Xml.XmlReader.HasAttributes> property|Check whether the current node has any attributes.|
|<xref:System.Xml.XmlReader.AttributeCount> property|Get the number of attributes on the current element.|
|<xref:System.Xml.XmlReader.MoveToFirstAttribute%2A> method|Move to the first attribute in an element.|
|<xref:System.Xml.XmlReader.MoveToNextAttribute%2A> method|Move to the next attribute in an element.|
|<xref:System.Xml.XmlReader.MoveToAttribute%2A> method|Move to a specified attribute.|
|<xref:System.Xml.XmlReader.GetAttribute%2A> method or <xref:System.Xml.XmlReader.Item%2A> property|Get the value of a specified attribute.|
|<xref:System.Xml.XmlReader.IsDefault> property|Check whether the current node is an attribute that was generated from the default value defined in the DTD or schema.|
|<xref:System.Xml.XmlReader.MoveToElement%2A> method|Move to the element that owns the current attribute. Use this method to return to an element after navigating through its attributes.|
|<xref:System.Xml.XmlReader.ReadAttributeValue%2A> method|Parse the attribute value into one or more `Text`, `EntityReference`, or `EndEntity` nodes.|

Any of the general <xref:System.Xml.XmlReader> methods and properties can also be used to process attributes. For example, after the <xref:System.Xml.XmlReader> is positioned on an attribute, the <xref:System.Xml.XmlReader.Name%2A> and <xref:System.Xml.XmlReader.Value%2A> properties reflect the values of the attribute. You can also use any of the content `Read` methods to get the value of the attribute.

This example uses the <xref:System.Xml.XmlReader.AttributeCount> property to navigate through all the attributes on an element.

:::code language="csharp" source="./snippets/System.Xml/XmlReader/Overview/csharp/XmlReader_Basic.cs" id="Snippet1":::
:::code language="vb" source="./snippets/System.Xml/XmlReader/Overview/vb/xmlreader_basic.vb" id="Snippet1":::

This example uses the <xref:System.Xml.XmlReader.MoveToNextAttribute%2A> method in a `while` loop to navigate through the attributes.

:::code language="csharp" source="./snippets/System.Xml/XmlReader/Overview/csharp/XmlReader_Basic.cs" id="Snippet6":::
:::code language="vb" source="./snippets/System.Xml/XmlReader/Overview/vb/xmlreader_basic.vb" id="Snippet6":::

**Reading attributes on XML declaration nodes**

When the XML reader is positioned on an XML declaration node, the <xref:System.Xml.XmlReader.Value> property returns the version, standalone, and encoding information as a single string. <xref:System.Xml.XmlReader> objects created by the <xref:System.Xml.XmlReader.Create%2A> method, the <xref:System.Xml.XmlTextReader> class, and the <xref:System.Xml.XmlValidatingReader> class expose the version, standalone, and encoding items as attributes.

**Reading attributes on document type nodes**

When the XML reader is positioned on a document type node, the <xref:System.Xml.XmlReader.GetAttribute%2A> method and <xref:System.Xml.XmlReader.Item%2A> property can be used to return the values for the SYSTEM and PUBLIC literals. For example, calling `reader.GetAttribute("PUBLIC")` returns the PUBLIC value.

**Reading attributes on processing instruction nodes**

When the <xref:System.Xml.XmlReader> is positioned on a processing instruction node, the <xref:System.Xml.XmlReader.Value> property returns the entire text content. Items in the processing instruction node aren't treated as attributes. They can't be read with the <xref:System.Xml.XmlReader.GetAttribute%2A> or <xref:System.Xml.XmlReader.MoveToAttribute%2A> method.

## Read XML content

The XmlReader class includes the following members that read content from an XML file and return the content as string values. (To return CLR types, see [Convert to CLR types](#convert-to-clr-types).)

|Use this <xref:System.Xml.XmlReader> member|To|
|---------------------------------------------------------------------------------------------------------------------------------------------------|--------|
|<xref:System.Xml.XmlReader.Value> property|Get the text content of the current node. The value returned depends on the node type; see the <xref:System.Xml.XmlReader.Value%2A> reference page for details.|
|<xref:System.Xml.XmlReader.ReadString%2A> method|Get the content of an element or text node as a string. This method stops on processing instructions and comments.<br /><br />For details on how this method handles specific node types, see the <xref:System.Xml.XmlReader.ReadString%2A> reference page.|
|<xref:System.Xml.XmlReader.ReadInnerXml%2A> and <xref:System.Xml.XmlReader.ReadInnerXmlAsync%2A> methods|Get all the content of the current node, including the markup, but excluding start and end tags. For example, for:<br /><br />`<node>this<child id="123"/></node>`<br /><br /><xref:System.Xml.XmlReader.ReadInnerXml%2A> returns:<br /><br />`this<child id="123"/>`|
|<xref:System.Xml.XmlReader.ReadOuterXml%2A> and <xref:System.Xml.XmlReader.ReadOuterXmlAsync%2A> methods|Get all the content of the current node and its children, including markup and start/end tags. For example, for:<br /><br />`<node>this<child id="123"/></node>`<br /><br /><xref:System.Xml.XmlReader.ReadOuterXml%2A> returns:<br /><br />`<node>this<child id="123"/></node>`|

## Convert to CLR types

You can use the members of the <xref:System.Xml.XmlReader> class (listed in the following table) to read XML data and return values as common language runtime (CLR) types instead of strings. These members enable you to get values in the representation that is most appropriate for your coding task without having to manually parse or convert string values.

- The **ReadElementContentAs** methods can only be called on element node types. These methods cannot be used on elements that contain child elements or mixed content. When called, the <xref:System.Xml.XmlReader> object reads the start tag, reads the element content, and then moves past the end element tag. Processing instructions and comments are ignored and entities are expanded.

- The **ReadContentAs** methods read the text content at the current reader position, and if the XML data doesn't have any schema or data type information associated with it, convert the text content to the requested return type. Text, white space, significant white space and CDATA sections are concatenated. Comments and processing instructions are skipped, and entity references are automatically resolved.

The <xref:System.Xml.XmlReader> class uses the rules defined by the [W3C XML Schema Part 2: Datatypes](https://www.w3.org/TR/xmlschema-2/) recommendation.

|Use this <xref:System.Xml.XmlReader> method|To return this CLR type|
|--------------------------------------------------------------------------------------------------------------------------------------------------|-----------------------------|
|<xref:System.Xml.XmlReader.ReadContentAsBoolean%2A> and <xref:System.Xml.XmlReader.ReadElementContentAsBoolean%2A>|<xref:System.Boolean>|
|<xref:System.Xml.XmlReader.ReadContentAsDateTime%2A> and <xref:System.Xml.XmlReader.ReadElementContentAsDateTime%2A>|<xref:System.DateTime>|
|<xref:System.Xml.XmlReader.ReadContentAsDouble%2A> and <xref:System.Xml.XmlReader.ReadElementContentAsDouble%2A>|<xref:System.Double>|
|<xref:System.Xml.XmlReader.ReadContentAsLong%2A> and <xref:System.Xml.XmlReader.ReadElementContentAsLong%2A>|<xref:System.Int64>|
|<xref:System.Xml.XmlReader.ReadContentAsInt%2A> and <xref:System.Xml.XmlReader.ReadElementContentAsInt%2A>|<xref:System.Int32>|
|<xref:System.Xml.XmlReader.ReadContentAsString%2A> and <xref:System.Xml.XmlReader.ReadElementContentAsString%2A>|<xref:System.String>|
|<xref:System.Xml.XmlReader.ReadContentAs%2A> and <xref:System.Xml.XmlReader.ReadElementContentAs%2A>|The type you specify with the `returnType` parameter|
|<xref:System.Xml.XmlReader.ReadContentAsObject%2A> and <xref:System.Xml.XmlReader.ReadElementContentAsObject%2A>|The most appropriate type, as specified by the <xref:System.Xml.XmlReader.ValueType?displayProperty=nameWithType> property. See [Type Support in the System.Xml Classes](../../standard/data/xml/type-support-in-the-system-xml-classes.md) for mapping information.|

If an element can't easily be converted to a CLR type because of its format, you can use a schema mapping to ensure a successful conversion. The following example uses an .xsd file to convert the `hire-date` element to the `xs:date` type, and then uses the <xref:System.Xml.XmlReader.ReadElementContentAsDateTime%2A> method to return the element as a <xref:System.DateTime> object.

**Input (hireDate.xml):**

:::code language="xml" source="./snippets/System.Xml/XmlReader/Overview/xml/hireDate.xml" id="Snippet9":::

**Schema (hireDate.xsd):**

:::code language="xml" source="./snippets/System.Xml/XmlReader/Overview/xml/hireDate.xsd" id="Snippet10":::

**Code:**

:::code language="csharp" source="./snippets/System.Xml/XmlReader/Overview/csharp/readElementContentAs.cs" id="Snippet13":::
:::code language="vb" source="./snippets/System.Xml/XmlReader/Overview/vb/readElementContentAs.vb" id="Snippet13":::

**Output:**

```
Six Month Review Date:  7/8/2003 12:00:00 AM
```

## Asynchronous programming

Most of the <xref:System.Xml.XmlReader> methods have asynchronous counterparts that have "Async" at the end of their method names. For example, the asynchronous equivalent of <xref:System.Xml.XmlReader.ReadContentAsObject%2A> is <xref:System.Xml.XmlReader.ReadContentAsObjectAsync%2A>.

The following methods can be used with asynchronous method calls:

- <xref:System.Xml.XmlReader.GetAttribute%2A>
- <xref:System.Xml.XmlReader.MoveToAttribute%2A>
- <xref:System.Xml.XmlReader.MoveToFirstAttribute%2A>
- <xref:System.Xml.XmlReader.MoveToNextAttribute%2A>
- <xref:System.Xml.XmlReader.MoveToElement%2A>
- <xref:System.Xml.XmlReader.ReadAttributeValue%2A>
- <xref:System.Xml.XmlReader.ReadSubtree%2A>
- <xref:System.Xml.XmlReader.ResolveEntity%2A>

The following sections describe asynchronous usage for methods that don't have asynchronous counterparts.

**ReadStartElement method**

:::code language="csharp" source="./snippets/System.Xml/XmlReader/Overview/csharp/program.cs" id="Snippet1":::
:::code language="vb" source="./snippets/System.Xml/XmlReader/Overview/vb/module1.vb" id="Snippet1":::

**ReadEndElement method**

:::code language="csharp" source="./snippets/System.Xml/XmlReader/Overview/csharp/program.cs" id="Snippet2":::
:::code language="vb" source="./snippets/System.Xml/XmlReader/Overview/vb/module1.vb" id="Snippet2":::

**ReadToNextSibling method**

:::code language="csharp" source="./snippets/System.Xml/XmlReader/Overview/csharp/program.cs" id="Snippet3":::
:::code language="vb" source="./snippets/System.Xml/XmlReader/Overview/vb/module1.vb" id="Snippet3":::

**ReadToFollowing method**

:::code language="csharp" source="./snippets/System.Xml/XmlReader/Overview/csharp/program.cs" id="Snippet4":::
:::code language="vb" source="./snippets/System.Xml/XmlReader/Overview/vb/module1.vb" id="Snippet4":::

**ReadToDescendant method**

:::code language="csharp" source="./snippets/System.Xml/XmlReader/Overview/csharp/program.cs" id="Snippet5":::
:::code language="vb" source="./snippets/System.Xml/XmlReader/Overview/vb/module1.vb" id="Snippet5":::

## Security considerations

Consider the following when working with the <xref:System.Xml.XmlReader> class:

- Exceptions thrown from the <xref:System.Xml.XmlReader> can disclose path information that you might not want bubbled up to your app. Your app must catch exceptions and process them appropriately.

- Do not enable DTD processing if you're concerned about denial of service issues or if you're dealing with untrusted sources. DTD processing is disabled by default for <xref:System.Xml.XmlReader> objects created by the <xref:System.Xml.XmlReader.Create%2A> method.

  If you have DTD processing enabled, you can use the <xref:System.Xml.XmlSecureResolver> to restrict the resources that the <xref:System.Xml.XmlReader> can access. You can also design your app so that the XML processing is memory and time constrained. For example, you can configure time-out limits in your ASP.NET app.

- XML data can include references to external resources such as a schema file. By default, external resources are resolved by using an <xref:System.Xml.XmlUrlResolver> object with no user credentials. You can secure this further by doing one of the following:

  - Restrict the resources that the <xref:System.Xml.XmlReader> can access by setting the <xref:System.Xml.XmlReaderSettings.XmlResolver?displayProperty=nameWithType> property to an <xref:System.Xml.XmlSecureResolver> object.

  - Do not allow the <xref:System.Xml.XmlReader> to open any external resources by setting the <xref:System.Xml.XmlReaderSettings.XmlResolver?displayProperty=nameWithType> property to `null`.

- The <xref:System.Xml.Schema.XmlSchemaValidationFlags.ProcessInlineSchema> and <xref:System.Xml.Schema.XmlSchemaValidationFlags.ProcessSchemaLocation> validation flags of an <xref:System.Xml.XmlReaderSettings> object aren't set by default. This helps to protect the <xref:System.Xml.XmlReader> against schema-based attacks when it is processing XML data from an untrusted source. When these flags are set, the <xref:System.Xml.XmlReaderSettings.XmlResolver%2A> of the <xref:System.Xml.XmlReaderSettings> object is used to resolve schema locations encountered in the instance document in the <xref:System.Xml.XmlReader>. If the <xref:System.Xml.XmlReaderSettings.XmlResolver> property is set to `null`, schema locations aren't resolved even if the <xref:System.Xml.Schema.XmlSchemaValidationFlags.ProcessInlineSchema> and <xref:System.Xml.Schema.XmlSchemaValidationFlags.ProcessSchemaLocation> validation flags are set.

  Schemas added during validation add new types and can change the validation outcome of the document being validated. As a result, external schemas should only be resolved from trusted sources.

  We recommend disabling the <xref:System.Xml.Schema.XmlSchemaValidationFlags.ProcessIdentityConstraints> flag when validating untrusted, large XML documents in high availability scenarios against a schema that has identity constraints over a large part of the document. This flag is enabled by default.

- XML data can contain a large number of attributes, namespace declarations, nested elements and so on that require a substantial amount of time to process. To limit the size of the input that is sent to the <xref:System.Xml.XmlReader>, you can:

  - Limit the size of the document by setting the <xref:System.Xml.XmlReaderSettings.MaxCharactersInDocument> property.

  - Limit the number of characters that result from expanding entities by setting the <xref:System.Xml.XmlReaderSettings.MaxCharactersFromEntities> property.

  - Create a custom `IStream` implementation for the <xref:System.Xml.XmlReader>.

- The <xref:System.Xml.XmlReader.ReadValueChunk%2A> method can be used to handle large streams of data. This method reads a small number of characters at a time instead of allocating a single string for the whole value.

- When reading an XML document with a large number of unique local names, namespaces, or prefixes, a problem can occur. If you are using a class that derives from <xref:System.Xml.XmlReader>, and you call the <xref:System.Xml.XmlReader.LocalName%2A>, <xref:System.Xml.XmlReader.Prefix%2A>, or <xref:System.Xml.XmlReader.NamespaceURI> property for each item, the returned string is added to a <xref:System.Xml.NameTable>. The collection held by the <xref:System.Xml.NameTable> never decreases in size, creating a virtual memory leak of the string handles. One mitigation for this is to derive from the <xref:System.Xml.NameTable> class and enforce a maximum size quota. (There is no way to prevent the use of a <xref:System.Xml.NameTable>, or to switch the <xref:System.Xml.NameTable> when it is full). Another mitigation is to avoid using the properties mentioned and instead use the <xref:System.Xml.XmlReader.MoveToAttribute%2A> method with the <xref:System.Xml.XmlReader.IsStartElement%2A> method where possible; those methods don't return strings and thus avoid the problem of overfilling the <xref:System.Xml.NameTable> collection.

- <xref:System.Xml.XmlReaderSettings> objects can contain sensitive information such as user credentials. An untrusted component could use the <xref:System.Xml.XmlReaderSettings> object and its user credentials to create <xref:System.Xml.XmlReader> objects to read data. Be careful when caching <xref:System.Xml.XmlReaderSettings> objects, or when passing the <xref:System.Xml.XmlReaderSettings> object from one component to another.

- Do not accept supporting components, such as <xref:System.Xml.NameTable>, <xref:System.Xml.XmlNamespaceManager>, and <xref:System.Xml.XmlResolver> objects, from an untrusted source.
