---
title: System.Xml.Schema.XmlSchemaSet class
description: Learn about the System.Xml.Schema.XmlSchemaSet class.
ms.date: 12/31/2023
dev_langs:
  - CSharp
  - VB
ms.topic: article
---
# System.Xml.Schema.XmlSchemaSet class

[!INCLUDE [context](includes/context.md)]

> [!IMPORTANT]
>
> - Do not use schemas from unknown or untrusted sources or locations. Doing so will compromise the security of your code.
> - XML schemas (including inline schemas) are inherently vulnerable to denial of service attacks; do not accept them in untrusted scenarios.
> - Schema validation error messages and exceptions may expose sensitive information about the content model or URI paths to the schema file. Be careful not to expose this information to untrusted callers.
> - Additional security considerations are covered in the "Security Considerations" section.

<xref:System.Xml.Schema.XmlSchemaSet> is a cache or library where you can store XML Schema definition language (XSD) schemas. <xref:System.Xml.Schema.XmlSchemaSet> improves performance by caching schemas in memory instead of accessing them from a file or a URL. Each schema is identified by the namespace URI and location that was specified when the schema was added to the set. You use the <xref:System.Xml.XmlReaderSettings.Schemas?displayProperty=nameWithType> property to assign the <xref:System.Xml.Schema.XmlSchemaSet> object an XML reader should use for data validation.

## Security considerations

- Do not use schemas from unknown or untrusted sources. Doing so will compromise the security of your code. External namespaces or locations referenced in include, import, and redefine elements of a schema are resolved with respect to the base URI of the schema that includes or imports them. For example, if the base URI of the including or importing schema is empty or `null`, the external locations are resolved with respect to the current directory. The <xref:System.Xml.XmlUrlResolver> class is used to resolve external schemas by default. To disable resolution of include, import, and redefine elements of a schema, set the <xref:System.Xml.Schema.XmlSchemaSet.XmlResolver?displayProperty=nameWithType> property to `null`.

- The <xref:System.Xml.Schema.XmlSchemaSet> class uses the <xref:System.Text.RegularExpressions.Regex?displayProperty=nameWithType> class to parse and match regular expressions in an XML schema. Validation of pattern facets with regular expressions in an XML schema may involve increased CPU usage and should be avoided in high availability scenarios.

- Exceptions raised as a result of using the <xref:System.Xml.Schema.XmlSchemaSet> class, such as the <xref:System.Xml.Schema.XmlSchemaException> class may contain sensitive information that should not be exposed in untrusted scenarios. For example, the <xref:System.Xml.Schema.XmlSchemaException.SourceUri> property of an <xref:System.Xml.Schema.XmlSchemaException> returns the URI path to the schema file that caused the exception. The <xref:System.Xml.Schema.XmlSchemaException.SourceUri> property should not be exposed in untrusted scenarios. Exceptions should be properly handled so that this sensitive information is not exposed in untrusted scenarios.

## Examples

The following example validates an XML file using schemas stored in the <xref:System.Xml.Schema.XmlSchemaSet>. The namespace in the XML file, `urn:bookstore-schema`, identifies which schema in the <xref:System.Xml.Schema.XmlSchemaSet> to use for validation. Output from the example shows that the XML file has two schema violations:

- The first \<book> element contains an \<author> element but no \<title> or \<price> element.

- The \<author> element in the last \<book> element is missing a \<first-name> and \<last-name> element and instead has an invalid \<name> element.

:::code language="csharp" source="./snippets/System.Xml/XmlReaderSettings/ValidationType/csharp/validschemaset.cs" id="Snippet1":::
:::code language="vb" source="./snippets/System.Xml.Schema/XmlSchemaSet/Overview/vb/validschemaset.vb" id="Snippet1":::

## Input

The sample uses the following two input files.

**booksSchemaFail.xml:**

:::code language="xml" source="./snippets/System.Xml.Schema/XmlSchemaSet/Overview/xml/booksschemafail.xml" id="Snippet2":::

**books.xsd:**

:::code language="xml" source="./snippets/System.Xml.Schema/XmlSchemaSet/Overview/xml/books.xsd" id="Snippet3":::
