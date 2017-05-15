---
title: "Binary Serialization | Microsoft Docs"
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
  - "binary serialization"
  - "serialization, about serialization"
  - "deserialization"
  - "binary serialization, about serialization"
ms.assetid: 2b1ea3be-1152-4032-b2b3-07794054c405
caps.latest.revision: 5
author: "Erikre"
ms.author: "erikre"
manager: "erikre"
---
# Binary Serialization
Serialization can be defined as the process of storing the state of an object to a storage medium. During this process, the public and private fields of the object and the name of the class, including the assembly containing the class, are converted to a stream of bytes, which is then written to a data stream. When the object is subsequently deserialized, an exact clone of the original object is created.  
  
 When implementing a serialization mechanism in an object-oriented environment, you have to make a number of tradeoffs between ease of use and flexibility. The process can be automated to a large extent, provided you are given sufficient control over the process. For example, situations may arise where simple binary serialization is not sufficient, or there might be a specific reason to decide which fields in a class need to be serialized. The following sections examine the robust serialization mechanism provided with the .NET Framework and highlight a number of important features that allow you to customize the process to meet your needs.  
  
> [!NOTE]
>  The state of a UTF-8 or UTF-7 encoded object is not preserved if the object is serialized and deserialized using different .NET Framework versions.  
  
## In This Section  
 [Serialization Concepts](../../../docs/framework/serialization/serialization-concepts.md)  
 Discusses two scenarios where serialization is useful: when persisting data to storage and when passing objects across application domains.  
  
 [Basic Serialization](../../../docs/framework/serialization/basic-serialization.md)  
 Describes how to use the binary and SOAP formatters to serialize objects.  
  
 [Selective Serialization](../../../docs/framework/serialization/selective-serialization.md)  
 Describes how to prevent some members of a class from being serialized.  
  
 [Custom Serialization](../../../docs/framework/serialization/custom-serialization.md)  
 Describes how to customize serialization for a class by using the <xref:System.Runtime.Serialization.ISerializable> interface.  
  
 [Steps in the Serialization Process](../../../docs/framework/serialization/steps-in-the-serialization-process.md)  
 Describes the course of action serialization takes when the <xref:System.Runtime.Serialization.Formatter.Serialize%2A> method is called on a formatter.  
  
 [Version Tolerant Serialization](../../../docs/framework/serialization/version-tolerant-serialization.md)  
 Explains how to create serializable types that can be modified over time without causing applications to throw exceptions.  
  
 [Serialization Guidelines](../../../docs/framework/serialization/serialization-guidelines.md)  
 Provides some general guidelines for deciding when to serialize an object.  
  
## Reference  
 <xref:System.Runtime.Serialization>  
 Contains classes that can be used for serializing and deserializing objects.  
  
## Related Sections  
 [XML and SOAP Serialization](../../../docs/framework/serialization/xml-and-soap-serialization.md)  
 Describes the XML serialization mechanism that is included with the common language runtime.  
  
 [Security and Serialization](../../../docs/framework/misc/security-and-serialization.md)  
 Describes the secure coding guidelines to follow when writing code that performs serialization.  
  
 [Remote Objects](http://msdn.microsoft.com/en-us/515686e6-0a8d-42f7-8188-73abede57c58)  
 Describes the various communications methods available in the .NET Framework for remote communications.  
  
 [XML Web Services Created Using ASP.NET and XML Web Service Clients](http://msdn.microsoft.com/en-us/1e64af78-d705-4384-b08d-591a45f4379c)  
 Provides topics that describe and explain how to program XML Web services created using ASP.NET.