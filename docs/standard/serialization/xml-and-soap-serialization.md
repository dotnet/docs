---
title: "XML and SOAP Serialization"
description: This overview discusses XML serialization, which can be used to serialize objects into XML streams that conform to the SOAP specification.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "SOAP, XML serialization"
  - "XML serialization, SOAP"
  - "serialization, SOAP"
  - "serialization, about serialization"
  - "XML serialization"
  - "serialization"
ms.assetid: 832ac524-21bc-419a-a27b-ca8bfc45840f
---
# XML and SOAP serialization

XML serialization converts (serializes) the public fields and properties of an object, and the parameters and return values of methods, into an XML stream that conforms to a specific XML Schema definition language (XSD) document. XML serialization results in strongly typed classes with public properties and fields that are converted to a serial format (in this case, XML) for storage or transport.

Because XML is an open standard, the XML stream can be processed by any application, as needed, regardless of platform. For example, XML Web services created using ASP.NET use the <xref:System.Xml.Serialization.XmlSerializer> class to create XML streams that pass data between XML Web service applications throughout the Internet or on intranets. Conversely, deserialization takes such an XML stream and reconstructs the object.

XML serialization can also be used to serialize objects into XML streams that conform to the SOAP specification. SOAP is a protocol based on XML, designed specifically to transport procedure calls using XML.

To serialize or deserialize objects, use the <xref:System.Xml.Serialization.XmlSerializer> class. To create the classes to be serialized, use the XML Schema Definition tool.

## See also

- [Binary Serialization](/previous-versions/dotnet/fundamentals/serialization/binary/binary-serialization)
- [XML Web Services created using ASP.NET and XML Web Service clients](/previous-versions/dotnet/netframework-4.0/7bkzywba(v=vs.100))
