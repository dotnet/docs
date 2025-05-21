---
title: System.Xml.XmlReaderSettings.Schemas property
description: Learn about the System.Xml.XmlReaderSettings.Schemas property.
ms.date: 01/24/2024
ms.topic: article
---
# System.Xml.XmlReaderSettings.Schemas property

[!INCLUDE [context](includes/context.md)]

This article pertains to the <xref:System.Xml.XmlReaderSettings.Schemas> property.

> [!IMPORTANT]
>
> - Do not use schemas from unknown or untrusted sources or locations. Doing so compromises the security of your code.
> - XML schemas (including inline schemas) are inherently vulnerable to denial of service attacks; do not accept them in untrusted scenarios.
> - Schema validation error messages and exceptions may expose sensitive information about the content model or URI paths to the schema file. Be careful not to expose this information to untrusted callers.
> - For additional information, see the "Security considerations" section.

The <xref:System.Xml.Schema.XmlSchemaSet> class only supports XML Schema definition language (XSD) schemas. <xref:System.Xml.XmlReader> instances created by the <xref:System.Xml.XmlReader.Create%2A> method cannot be configured to enable XML-Data Reduced (XDR) schema validation.

## Security considerations

- Do not use schemas from unknown or untrusted sources. Doing so will compromise the security of your code. The <xref:System.Xml.XmlUrlResolver> class is used to resolve external schemas by default. To disable resolution of include, import, and redefine elements of a schema, set the <xref:System.Xml.Schema.XmlSchemaSet.XmlResolver%2A?displayProperty=nameWithType> property to `null`.

- Exceptions raised as a result of using the <xref:System.Xml.Schema.XmlSchemaSet> class, such as the <xref:System.Xml.Schema.XmlSchemaException> class may contain sensitive information that should not be exposed in untrusted scenarios. For example, the <xref:System.Xml.Schema.XmlSchemaException.SourceUri> property of an <xref:System.Xml.Schema.XmlSchemaException> returns the URI path to the schema file that caused the exception. The <xref:System.Xml.Schema.XmlSchemaException.SourceUri> property should not be exposed in untrusted scenarios. Exceptions should be properly handled so that this sensitive information is not exposed in untrusted scenarios.
