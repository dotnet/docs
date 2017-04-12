---
title: "Attributes That Control Encoded SOAP Serialization | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "VB"
  - "CSharp"
  - "C++"
  - "jsharp"
helpviewer_keywords: 
  - "SOAP, XML serialization"
  - "XML serialization, SOAP"
  - "XML serialization, attributes"
  - "attributes [.NET Framework], XML serialization"
  - "serialization, attributes"
ms.assetid: 93ee258c-9c0f-4a08-897c-c10db7a00f91
caps.latest.revision: 8
author: "Erikre"
ms.author: "erikre"
manager: "erikre"
---
# Attributes That Control Encoded SOAP Serialization
The World Wide Web Consortium (www.w3.org) document named "Simple Object Access Protocol (SOAP) 1.1" contains an optional section (section 5) that describes how SOAP parameters can be encoded. To conform to section 5 of the specification, you must use a special set of attributes found in the <xref:System.Xml.Serialization> namespace. Apply those attributes as appropriate to classes and members of classes, and then use the [XmlSerializer](https://msdn.microsoft.com/en-us/library/system.xml.serialization.xmlserializer.aspx) to serialize instances of the class or classes.  
  
 The following table shows the attributes, where they can be applied, and what they do. For more information about using these attributes to control XML serialization, see [How to: Serialize an Object as a SOAP-Encoded XML Stream](../../../docs/framework/serialization/how-to-serialize-an-object-as-a-soap-encoded-xml-stream.md) and [How to: Override Encoded SOAP XML Serialization](../../../docs/framework/serialization/how-to-override-encoded-soap-xml-serialization.md).  
  
 For more information about attributes, see [Attributes](../../../docs/standard/attributes/index.md).  
  
|Attribute|Applies to|Specifies|  
|---------------|----------------|---------------|  
|<xref:System.Xml.Serialization.SoapAttributeAttribute>|Public field, property, parameter, or return value.|The class member will be serialized as an XML attribute.|  
|<xref:System.Xml.Serialization.SoapElementAttribute>|Public field, property, parameter, or return value.|The class will be serialized as an XML element.|  
|<xref:System.Xml.Serialization.SoapEnumAttribute>|Public field that is an enumeration identifier.|The element name of an enumeration member.|  
|<xref:System.Xml.Serialization.SoapIgnoreAttribute>|Public properties and fields.|The property or field should be ignored when the containing class is serialized.|  
|<xref:System.Xml.Serialization.SoapIncludeAttribute>|Public-derived class declarations and public methods for Web Services Description Language (WSDL) documents.|The type should be included when generating schemas (to be recognized when serialized).|  
|<xref:System.Xml.Serialization.SoapTypeAttribute>|Public class declarations.|The class should be serialized as an XML type.|  
  
## See Also  
 [XML and SOAP Serialization](../../../docs/framework/serialization/xml-and-soap-serialization.md)   
 [How to: Serialize an Object as a SOAP-Encoded XML Stream](../../../docs/framework/serialization/how-to-serialize-an-object-as-a-soap-encoded-xml-stream.md)   
 [How to: Override Encoded SOAP XML Serialization](../../../docs/framework/serialization/how-to-override-encoded-soap-xml-serialization.md)   
 [Attributes](../../../docs/standard/attributes/index.md)   
 [XmlSerializer](https://msdn.microsoft.com/en-us/library/system.xml.serialization.xmlserializer.aspx)   
 [How to: Serialize an Object](../../../docs/framework/serialization/how-to-serialize-an-object.md)   
 [How to: Deserialize an Object](../../../docs/framework/serialization/how-to-deserialize-an-object.md)