---
title: "Serialization Concepts | Microsoft Docs"
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
ms.assetid: e1ff4740-20a1-4c76-a8ad-d857db307054
caps.latest.revision: 4
author: "Erikre"
ms.author: "erikre"
manager: "erikre"
---
# Serialization Concepts
Why would you want to use serialization? The two most important reasons are to persist the state of an object to a storage medium so an exact copy can be re-created at a later stage, and to send the object by value from one application domain to another. For example, serialization is used to save session state in ASP.NET and to copy objects to the Clipboard in Windows Forms. It is also used by remoting to pass objects by value from one application domain to another.  
  
## In This Section  
 [Persistent Storage](../../../docs/framework/serialization/persistent-storage.md)  
 Describes the need for serializing an object.  
  
 [Marshal by Value](../../../docs/framework/serialization/marshal-by-value.md)  
 Describes the marshal-by-value process.  
  
## Related Sections  
 [Binary Serialization](../../../docs/framework/serialization/binary-serialization.md)  
 Describes the binary serialization mechanism that is included with the common language runtime.  
  
 [Remote Objects](http://msdn.microsoft.com/en-us/515686e6-0a8d-42f7-8188-73abede57c58)  
 Describes the various communications methods available in the .NET Framework for remote communications.  
  
 [XML and SOAP Serialization](../../../docs/framework/serialization/xml-and-soap-serialization.md)  
 Describes the XML and SOAP serialization mechanism that is included with the common language runtime.