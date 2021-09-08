---
title: "Attributes That Control Encoded SOAP Serialization"
description: This article lists a special set of attributes found in the System.Xml.Serialization namespace needed to conform to the SOAP specification.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "SOAP, XML serialization"
  - "XML serialization, SOAP"
  - "XML serialization, attributes"
  - "attributes [.NET], XML serialization"
  - "serialization, attributes"
ms.topic: reference
---
# Attributes That Control Encoded SOAP Serialization

The World Wide Web Consortium (W3C) document named [Simple Object Access Protocol (SOAP) 1.1](https://www.w3.org/TR/2000/NOTE-SOAP-20000508/) contains an optional section (section 5) that describes how SOAP parameters can be encoded. To conform to section 5 of the specification, you must use a special set of attributes found in the <xref:System.Xml.Serialization> namespace. Apply those attributes as appropriate to classes and members of classes, and then use the <xref:System.Xml.Serialization.XmlSerializer> to serialize instances of the class or classes.

The following table shows the attributes, where they can be applied, and what they do. For more information about using these attributes to control XML serialization, see [How to: Serialize an Object as a SOAP-Encoded XML Stream](how-to-serialize-an-object-as-a-soap-encoded-xml-stream.md) and [How to: Override Encoded SOAP XML Serialization](how-to-override-encoded-soap-xml-serialization.md).

For more information about attributes, see [Attributes](../attributes/index.md).

|Attribute|Applies to|Specifies|
|---------------|----------------|---------------|
|<xref:System.Xml.Serialization.SoapAttributeAttribute>|Public field, property, parameter, or return value.|The class member will be serialized as an XML attribute.|
|<xref:System.Xml.Serialization.SoapElementAttribute>|Public field, property, parameter, or return value.|The class will be serialized as an XML element.|
|<xref:System.Xml.Serialization.SoapEnumAttribute>|Public field that is an enumeration identifier.|The element name of an enumeration member.|
|<xref:System.Xml.Serialization.SoapIgnoreAttribute>|Public properties and fields.|The property or field should be ignored when the containing class is serialized.|
|<xref:System.Xml.Serialization.SoapIncludeAttribute>|Public-derived class declarations and public methods for Web Services Description Language (WSDL) documents.|The type should be included when generating schemas (to be recognized when serialized).|
|<xref:System.Xml.Serialization.SoapTypeAttribute>|Public class declarations.|The class should be serialized as an XML type.|

## See also

- [XML and SOAP Serialization](xml-and-soap-serialization.md)
- [How to: Serialize an Object as a SOAP-Encoded XML Stream](how-to-serialize-an-object-as-a-soap-encoded-xml-stream.md)
- [How to: Override Encoded SOAP XML Serialization](how-to-override-encoded-soap-xml-serialization.md)
- [Attributes](../attributes/index.md)
- <xref:System.Xml.Serialization.XmlSerializer>
- [How to: Serialize an Object](how-to-serialize-an-object.md)
- [How to: Deserialize an Object](how-to-deserialize-an-object.md)
