---
title: System.Xml.XmlReaderSettings.DtdProcessing property
description: Learn about the System.Xml.XmlReaderSettings.DtdProcessing property.
ms.date: 01/24/2024
---
# System.Xml.XmlReaderSettings.DtdProcessing property

[!INCLUDE [context](includes/context.md)]

Document type definition (DTD) validation is implemented by using the validity constraints defined in the W3C [Extensible Markup Language (XML) 1.0 (fourth edition) recommendation](https://www.w3.org/TR/2006/REC-xml-20060816/). DTDs use a formal grammar to describe the structure and syntax of compliant XML documents; they specify the content and values allowed for the XML document.

The <xref:System.Xml.XmlReaderSettings.DtdProcessing> property can have one of the following values:

- <xref:System.Xml.DtdProcessing.Parse?displayProperty=nameWithType> to enable DTD processing.
- <xref:System.Xml.DtdProcessing.Prohibit?displayProperty=nameWithType> to throw an <xref:System.Xml.XmlException> exception when a DTD is encountered.
- <xref:System.Xml.DtdProcessing.Ignore?displayProperty=nameWithType> to disable DTD processing without warnings or exceptions.

To perform validation against a DTD, the <xref:System.Xml.XmlReader> uses the DTD defined in the DOCTYPE declaration of an XML document. The DOCTYPE declaration can either point to an inline DTD or can be a reference to an external DTD file. To validate an XML file against a DTD:

- Set the <xref:System.Xml.XmlReaderSettings.DtdProcessing%2A?displayProperty=nameWithType> property to `DtdProcessing.Parse`.
- Set the <xref:System.Xml.XmlReaderSettings.ValidationType%2A?displayProperty=nameWithType> property to `ValidationType.DTD`.
- If the DTD is an external file stored on a network resource that requires authentication, pass an <xref:System.Xml.XmlResolver> object with the necessary credentials to the <xref:System.Xml.XmlReader.Create%2A> method.

> [!IMPORTANT]
> If the <xref:System.Xml.XmlReaderSettings.DtdProcessing> property is set to <xref:System.Xml.DtdProcessing.Ignore?displayProperty=nameWithType>, the <xref:System.Xml.XmlReader> will not report the DTDs. This means that the DTD/DOCTYPE will be lost on output.
