---
title: "Selective Serialization | Microsoft Docs"
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
  - "serialization, selective serialization"
  - "binary serialization, selective serialization"
ms.assetid: 39c56635-95d2-4afd-aff1-b022e7649bb3
caps.latest.revision: 6
author: "Erikre"
ms.author: "erikre"
manager: "erikre"
---
# Selective Serialization
A class often contains fields that should not be serialized. For example, assume a class stores a thread ID in a member variable. When the class is deserialized, the thread stored the ID for when the class was serialized might no longer be running; so serializing this value does not make sense. You can prevent member variables from being serialized by marking them with the `NonSerialized` attribute as follows.  
  
```csharp  
[Serializable]  
public class MyObject   
{  
  public int n1;  
  [NonSerialized] public int n2;  
  public String str;  
}  
```  
  
 If possible, make an object that could contain security-sensitive data nonserializable. If the object must be serialized, apply the `NonSerialized` attribute to specific fields that store sensitive data. If you do not exclude these fields from serialization, be aware that the data they store will be exposed to any code that has permission to serialize. For more information about writing secure serialization code, see [Security and Serialization](../../../docs/framework/misc/security-and-serialization.md).  
  
## See Also  
 [Binary Serialization](../../../docs/framework/serialization/binary-serialization.md)   
 [XML and SOAP Serialization](../../../docs/framework/serialization/xml-and-soap-serialization.md)   
 [Security and Serialization](../../../docs/framework/misc/security-and-serialization.md)