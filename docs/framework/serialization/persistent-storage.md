---
title: "Persistent Storage | Microsoft Docs"
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
  - "persistent storage"
  - "binary serialization, persistent storage"
  - "serialization, persistent storage"
ms.assetid: b112c0dd-93e2-4eef-908d-5963f80bab65
caps.latest.revision: 6
author: "Erikre"
ms.author: "erikre"
manager: "erikre"
---
# Persistent Storage
It is often necessary to store the value of the fields of an object to disk and then, later, retrieve this data. Although this is easy to achieve without relying on serialization, this approach is often cumbersome and error prone, and becomes progressively more complex when you need to track a hierarchy of objects. Imagine writing a large business application, that contains thousands of objects, and having to write code to save and restore the fields and properties to and from disk for each object. Serialization provides a convenient mechanism for achieving this objective.  
  
 The common language runtime manages how objects are stored in memory and provides an automated serialization mechanism by using [reflection](../../../docs/framework/reflection-and-codedom/reflection.md). When an object is serialized, the name of the class, the assembly, and all the data members of the class instance are written to storage. Objects often store references to other instances in member variables. When the class is serialized, the serialization engine tracks referenced objects, already serialized, to ensure that the same object is not serialized more than once. The serialization architecture provided with the [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)] correctly handles object graphs and circular references automatically. The only requirement placed on object graphs is that all objects, referenced by the serialized object, must also be marked as `Serializable` (for more information, see [Basic Serialization](../../../docs/framework/serialization/basic-serialization.md)). If this is not done, an exception will be thrown when the serializer attempts to serialize the unmarked object.  
  
 When the serialized class is deserialized, the class is recreated  and the values of all the data members are automatically restored.  
  
## See Also  
 [Serialization Concepts](../../../docs/framework/serialization/serialization-concepts.md)   
 [XML and SOAP Serialization](../../../docs/framework/serialization/xml-and-soap-serialization.md)