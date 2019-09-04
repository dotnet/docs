---
title: "Serialization in .NET"
ms.date: "09/02/2019"
helpviewer_keywords: 
  - "JSON serialization"
  - "XML serialization, defined"
  - "binary serialization"
  - "serializing objects"
  - "serialization"
  - "objects, serializing"
ms.assetid: 4d1111c0-9447-4231-a997-96a2b74b3453
---

# Serialization in .NET

Serialization is the process of converting the state of an object into a form that can be persisted or transported. The complement of serialization is deserialization, which converts a stream into an object. Together, these processes allow data to be stored and transferred.  
  
.NET features the following serialization technologies:  
  
- [Binary serialization](binary-serialization.md) preserves type fidelity, which is useful for preserving the state of an object between different invocations of an application. For example, you can share an object between different applications by serializing it to the Clipboard. You can serialize an object to a stream, to a disk, to memory, over the network, and so forth. Remoting uses serialization to pass objects "by value" from one computer or application domain to another.  
  
- [XML and SOAP serialization](xml-and-soap-serialization.md) serializes only public properties and fields and does not preserve type fidelity. This is useful when you want to provide or consume data without restricting the application that uses the data. Because XML is an open standard, it is an attractive choice for sharing data across the Web. SOAP is likewise an open standard, which makes it an attractive choice.  
  
- [JSON serialization](xml-and-soap-serialization.md) serializes only public properties and does not preserve type fidelity. JSON is an open standard that is an attractive choice for sharing data across the Web.

## Reference

<xref:System.Runtime.Serialization> 
Contains classes that can be used for serializing and deserializing objects.
  
<xref:System.Xml.Serialization>  
Contains classes that can be used to serialize objects into XML format documents or streams.

<xref:System.Text.Json>  
Contains classes that can be used to serialize objects into JSON format documents or streams.
