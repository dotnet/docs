---
title: System.Xml.XmlTextReader class
description: Learn about the System.Xml.XmlTextReader class.
ms.date: 12/31/2023
ms.topic: article
---
# System.Xml.XmlTextReader class

[!INCLUDE [context](includes/context.md)]

> [!NOTE]
> We recommend that you create <xref:System.Xml.XmlReader> instances by using the <xref:System.Xml.XmlReader.Create%2A?displayProperty=nameWithType> method to take advantage of new functionality.

<xref:System.Xml.XmlTextReader> provides forward-only, read-only access to a stream of XML data. The current node refers to the node on which the reader is positioned. The reader is advanced using any of the read methods and properties reflect the value of the current node.

This class implements <xref:System.Xml.XmlReader> and conforms to the W3C Extensible Markup Language (XML) 1.0 and the Namespaces in XML recommendations. `XmlTextReader` provides the following functionality:

- Enforces the rules of well-formed XML.

- `XmlTextReader` does not provide data validation.

- Checks that `DocumentType` nodes are well-formed. `XmlTextReader` checks the DTD for well-formedness, but does not validate using the DTD.

- For nodes where <xref:System.Xml.XmlTextReader.NodeType%2A> is `XmlNodeType.EntityReference`, a single empty `EntityReference` node is returned (that is, the <xref:System.Xml.XmlTextReader.Value> property is `String.Empty`).

> [!NOTE]
> The actual declarations of entities in the DTD are called `Entity` nodes. When you refer to these nodes in your data, they are called `EntityReference` nodes.

- Does not expand default attributes.

Because the `XmlTextReader` does not perform the extra checks required for data validation, it provides a fast well-formedness parser.

To perform data validation, use a validating <xref:System.Xml.XmlReader>.

To read XML data from an <xref:System.Xml.XmlDocument>, use <xref:System.Xml.XmlNodeReader>.

`XmlTextReader` throws an <xref:System.Xml.XmlException> on XML parse errors. After an exception is thrown the state of the reader is not predictable. For example, the reported node type may be different than the actual node type of the current node. Use the <xref:System.Xml.XmlTextReader.ReadState> property to check whether a reader is in error state.

## Security considerations

The following are things to consider when using the <xref:System.Xml.XmlTextReader> class.

- Exceptions thrown the <xref:System.Xml.XmlTextReader> can disclose path information that you do not want bubbled up to the application. Your applications must catch exceptions and process them appropriately.

- DTD processing is enabled by default. Disable DTD processing if you are concerned about Denial of Service issues or if you are dealing with untrusted sources. Set the <xref:System.Xml.XmlTextReader.DtdProcessing> property to <xref:System.Xml.DtdProcessing.Prohibit> to disable DTD processing.

  If you have DTD processing enabled, you can use the <xref:System.Xml.XmlSecureResolver> to restrict the resources that the <xref:System.Xml.XmlTextReader> can access. You can also design your application so that the XML processing is memory and time constrained. For example, configure time-out limits in your ASP.NET application.

- XML data can include references to external resources such as a DTD file. By default external resources are resolved using an <xref:System.Xml.XmlUrlResolver> object with no user credentials. You can secure this further by doing one of the following:

  - Restrict the resources that the <xref:System.Xml.XmlTextReader> can access by setting the <xref:System.Xml.XmlTextReader.XmlResolver> property to an <xref:System.Xml.XmlSecureResolver> object.

  - Do not allow the <xref:System.Xml.XmlReader> to open any external resources by setting the <xref:System.Xml.XmlTextReader.XmlResolver> property to `null`.

- XML data can contain a large number of attributes, namespace declarations, nested elements and so on that require a substantial amount of time to process. To limit the size of the input that is sent to the <xref:System.Xml.XmlTextReader>, create a custom IStream implementation and supply it the <xref:System.Xml.XmlTextReader>.

- The <xref:System.Xml.XmlReader.ReadValueChunk%2A> method can be used to handle large streams of data. This method reads a small number of characters at a time instead of allocating a single string for the whole value.

- By default general entities are not expanded. General entities are expanded when you call the <xref:System.Xml.XmlTextReader.ResolveEntity%2A> method.
