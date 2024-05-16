---
title: System.Xml.XmlReaderSettings class
description: Learn about the System.Xml.XmlReaderSettings class.
ms.date: 12/31/2023
---
# System.Xml.XmlReaderSettings class

[!INCLUDE [context](includes/context.md)]

You use the <xref:System.Xml.XmlReader.Create%2A> method to obtain <xref:System.Xml.XmlReader> instances. This method uses the <xref:System.Xml.XmlReaderSettings> class to specify which features to implement in the <xref:System.Xml.XmlReader> object it creates.

See the Remarks sections of the <xref:System.Xml.XmlReader> and <xref:System.Xml.XmlReader.Create%2A> reference pages for information about which settings to use for conformance checks, validation, and other common scenarios. See the <xref:System.Xml.XmlReaderSettings.%23ctor> constructor for a list of default settings.

## Security considerations

Consider the following when using the <xref:System.Xml.XmlReaderSettings> class.

- The <xref:System.Xml.Schema.XmlSchemaValidationFlags.ProcessInlineSchema> and <xref:System.Xml.Schema.XmlSchemaValidationFlags.ProcessSchemaLocation> validation flags of an <xref:System.Xml.XmlReaderSettings> object are not set by default. When these flags are set, the <xref:System.Xml.XmlReaderSettings.XmlResolver%2A> of the <xref:System.Xml.XmlReaderSettings> object is used to resolve schema locations encountered in the instance document in the <xref:System.Xml.XmlReader>. If the <xref:System.Xml.XmlReaderSettings.XmlResolver%2A> object is `null`, schema locations are not resolved even if the <xref:System.Xml.Schema.XmlSchemaValidationFlags.ProcessInlineSchema> and <xref:System.Xml.Schema.XmlSchemaValidationFlags.ProcessSchemaLocation> validation flags are set.

- Schemas added during validation add new types and can change the validation outcome of the document being validated. As a result, external schemas should only be resolved from trusted sources.

- Validation error messages may expose sensitive content model information. Validation error and warning messages are handled using the <xref:System.Xml.Schema.ValidationEventHandler> delegate, or are exposed as an <xref:System.Xml.Schema.XmlSchemaValidationException> if no event handler is provided to the <xref:System.Xml.XmlReaderSettings> object (validation warnings do not cause an <xref:System.Xml.Schema.XmlSchemaValidationException> to be thrown). This content model information should not be exposed in untrusted scenarios. Validation warning messages are suppressed by default and can be reported by setting the <xref:System.Xml.Schema.XmlSchemaValidationFlags.ReportValidationWarnings> flag.

- The <xref:System.Xml.Schema.XmlSchemaException.SourceUri> property of an <xref:System.Xml.Schema.XmlSchemaValidationException> returns the URI path to the schema file that caused the exception. The <xref:System.Xml.Schema.XmlSchemaException.SourceUri> property should not be exposed in untrusted scenarios.

- Disabling the <xref:System.Xml.Schema.XmlSchemaValidationFlags.ProcessIdentityConstraints> flag (enabled by default) is recommended when validating, untrusted, large XML documents in high availability scenarios against a schema with identity constraints over a large part of the document.

- <xref:System.Xml.XmlReaderSettings> objects can contain sensitive information such as user credentials. You should be careful when caching <xref:System.Xml.XmlReaderSettings> objects, or when passing the <xref:System.Xml.XmlReaderSettings> object from one component to another.

- DTD processing is disabled by default. If you enable DTD processing, you need to be aware of including DTDs from untrusted sources and possible denial of service attacks. Use the <xref:System.Xml.XmlSecureResolver> to restrict the resources that the <xref:System.Xml.XmlReader> can access.

- Do not accept supporting components, such as <xref:System.Xml.NameTable>, <xref:System.Xml.XmlNamespaceManager>, and <xref:System.Xml.XmlResolver> objects, from an untrusted source.

- Memory usage of an application that uses <xref:System.Xml.XmlReader> may have a correlation to the size of the parsed XML document. One form of denial of service attack is when excessively large XML documents are submitted to be parsed. You can limit the size of the document that can be parsed by setting the <xref:System.Xml.XmlReaderSettings.MaxCharactersInDocument> property and then limit the number of characters that result from expanding entities by setting the <xref:System.Xml.XmlReaderSettings.MaxCharactersFromEntities> property.
