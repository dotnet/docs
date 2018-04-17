---
title: "XML and SOAP Serialization"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "SOAP, XML serialization"
  - "XML serialization, SOAP"
  - "serialization, SOAP"
  - "serialization, about serialization"
  - "XML serialization"
  - "serialization"
ms.assetid: 832ac524-21bc-419a-a27b-ca8bfc45840f
caps.latest.revision: 4
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# XML and SOAP Serialization
XML serialization converts (serializes) the public fields and properties of an object, or the parameters and return values of methods, into an XML stream that conforms to a specific XML Schema definition language (XSD) document. XML serialization results in strongly typed classes with public properties and fields that are converted to a serial format (in this case, XML) for storage or transport.  
  
 Because XML is an open standard, the XML stream can be processed by any application, as needed, regardless of platform. For example, XML Web services created using ASP.NET use the <xref:System.Xml.Serialization.XmlSerializer> class to create XML streams that pass data between XML Web service applications throughout the Internet or on intranets. Conversely, deserialization takes such an XML stream and reconstructs the object.  
  
 XML serialization can also be used to serialize objects into XML streams that conform to the SOAP specification. SOAP is a protocol based on XML, designed specifically to transport procedure calls using XML.  
  
 To serialize or deserialize objects, use the <xref:System.Xml.Serialization.XmlSerializer> class. To create the classes to be serialized, use the XML Schema Definition tool.  
  
## In This Section  
 [Introducing XML Serialization](../../../docs/standard/serialization/introducing-xml-serialization.md)  
 Provides a general definition of serialization, particularly XML serialization.  
  
 [How to: Serialize an Object](../../../docs/standard/serialization/how-to-serialize-an-object.md)  
 Provides step-by-step instructions for serializing an object.  
  
 [How to: Deserialize an Object](../../../docs/standard/serialization/how-to-deserialize-an-object.md)  
 Provides step-by-step instructions for deserializing an object.  
  
 [Examples of XML Serialization](../../../docs/standard/serialization/examples-of-xml-serialization.md)  
 Provides examples that demonstrate the basics of XML serialization.  
  
 [The XML Schema Definition Tool and XML Serialization](../../../docs/standard/serialization/the-xml-schema-definition-tool-and-xml-serialization.md)  
 Describes how to use the XML Schema Definition tool to create classes that adhere to a particular XML Schema definition language (XSD) schema, or to generate an XML Schema from a .dll file.  
  
 [Controlling XML Serialization Using Attributes](../../../docs/standard/serialization/controlling-xml-serialization-using-attributes.md)  
 Describes how to control serialization by using attributes.  
  
 [Attributes That Control XML Serialization](../../../docs/standard/serialization/attributes-that-control-xml-serialization.md)  
 Lists the attributes that are used to control XML serialization.  
  
 [How to: Specify an Alternate Element Name for an XML Stream](../../../docs/standard/serialization/how-to-specify-an-alternate-element-name-for-an-xml-stream.md)  
 Presents an advanced scenario showing how to generate multiple XML streams by overriding the serialization.  
  
 [How to: Control Serialization of Derived Classes](../../../docs/standard/serialization/how-to-control-serialization-of-derived-classes.md)  
 Provides an example of how to control the serialization of derived classes.  
  
 [How to: Qualify XML Element and XML Attribute Names](../../../docs/standard/serialization/how-to-qualify-xml-element-and-xml-attribute-names.md)  
 Describes how to define and control the way in which XML namespaces are used in the XML stream.  
  
 [XML Serialization with XML Web Services](../../../docs/standard/serialization/xml-serialization-with-xml-web-services.md)  
 Explains how XML serialization is used in XML Web services.  
  
 [How to: Serialize an Object as a SOAP-Encoded XML Stream](../../../docs/standard/serialization/how-to-serialize-an-object-as-a-soap-encoded-xml-stream.md)  
 Describes how to use the <xref:System.Xml.Serialization.XmlSerializer> class to create encoded SOAP XML streams that conform to section 5 of the World Wide Web Consortium (www.w3.org) document titled "Simple Object Access Protocol (SOAP) 1.1."  
  
 [How to: Override Encoded SOAP XML Serialization](../../../docs/standard/serialization/how-to-override-encoded-soap-xml-serialization.md)  
 Describes the process for overriding XML serialization of objects as SOAP messages.  
  
 [Attributes That Control Encoded SOAP Serialization](../../../docs/standard/serialization/attributes-that-control-encoded-soap-serialization.md)  
 Lists the attributes that are used to control SOAP-encoded serialization.  
  
 [\<system.xml.serialization> Element](../../../docs/standard/serialization/system-xml-serialization-element.md)  
 The top-level configuration element for controlling XML serialization.  
  
 [\<dateTimeSerialization> Element](../../../docs/standard/serialization/datetimeserialization-element.md)  
 Controls the serialization mode of <xref:System.DateTime> objects.  
  
 [\<schemaImporterExtensions> Element](../../../docs/standard/serialization/schemaimporterextensions-element.md)  
 Contains types that are used by the <xref:System.Xml.Serialization.XmlSchemaImporter> class.  
  
 [\<add> Element for \<xmlSchemaImporterExtensions>](../../../docs/standard/serialization/add-element-for-xmlschemaimporterextensions.md)  
 Adds types that are used by the <xref:System.Xml.Serialization.XmlSchemaImporter> class.  
  
## Related Sections  
 [Advanced Development Technologies](https://msdn.microsoft.com/library/c4a7e341-f0c6-4df4-a74f-223387ac6e4e)  
 Provides links to more information on sophisticated development tasks and techniques in the .NET Framework.  
  
 [XML Web Services Created Using ASP.NET and XML Web Service Clients](https://msdn.microsoft.com/library/1e64af78-d705-4384-b08d-591a45f4379c)  
 Provides topics that describe and explain how to program XML Web services using ASP.NET.  
  
## See Also  
 [Binary Serialization](../../../docs/standard/serialization/binary-serialization.md)
