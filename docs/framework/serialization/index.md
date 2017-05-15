---
title: "Serialization in the .NET Framework | Microsoft Docs"
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
  - "XML serialization, defined"
  - "binary serialization"
  - "serializing objects"
  - "serialization"
  - "objects, serializing"
ms.assetid: 4d1111c0-9447-4231-a997-96a2b74b3453
caps.latest.revision: 6
author: "Erikre"
ms.author: "erikre"
manager: "erikre"
---
# Serialization in the .NET Framework
Serialization is the process of converting the state of an object into a form that can be persisted or transported. The complement of serialization is deserialization, which converts a stream into an object. Together, these processes allow data to be easily stored and transferred.  
  
 The .NET Framework features two serializing technologies:  
  
-   Binary serialization preserves type fidelity, which is useful for preserving the state of an object between different invocations of an application. For example, you can share an object between different applications by serializing it to the Clipboard. You can serialize an object to a stream, to a disk, to memory, over the network, and so forth. Remoting uses serialization to pass objects "by value" from one computer or application domain to another.  
  
-   XML serialization serializes only public properties and fields and does not preserve type fidelity. This is useful when you want to provide or consume data without restricting the application that uses the data. Because XML is an open standard, it is an attractive choice for sharing data across the Web. SOAP is likewise an open standard, which makes it an attractive choice.  
  
## In This Section  
 [Serialization How-to Topics](../../../docs/framework/serialization/serialization-how-to-topics.md)  
 Lists links to How-to topics contained in this section.  
  
 [Binary Serialization](../../../docs/framework/serialization/binary-serialization.md)  
 Describes the binary serialization mechanism that is included with the common language runtime.  
  
 [XML and SOAP Serialization](../../../docs/framework/serialization/xml-and-soap-serialization.md)  
 Describes the XML and SOAP serialization mechanism that is included with the common language runtime.  
  
 [Serialization Tools](../../../docs/framework/serialization/serialization-tools.md)  
 These tools help develop serialization code.  
  
 [Serialization Samples](../../../docs/framework/serialization/serialization-samples.md)  
 The samples demonstrate how to do serialization.  
  
## Reference  
 <xref:System.Runtime.Serialization>  
 Contains classes that can be used for serializing and deserializing objects.  
  
 <xref:System.Xml.Serialization>  
 Contains classes that can be used to serialize objects into XML format documents or streams.  
  
## Related Sections