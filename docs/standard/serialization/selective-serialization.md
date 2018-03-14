---
title: "Selective serialization"
ms.date: "08/07/2017"
ms.prod: ".net"
ms.topic: "article"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "serialization, selective serialization"
  - "binary serialization, selective serialization"
ms.assetid: 39c56635-95d2-4afd-aff1-b022e7649bb3
caps.latest.revision: 6
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Selective serialization
A class often contains fields that shouldn't be serialized. For example, assume a class stores a thread ID in a member variable. When the class is deserialized, the thread stored the ID for when the class was serialized might no longer be running; so serializing this value doesn't make sense. You can prevent member variables from being serialized by marking them with the [NonSerialized](xref:System.NonSerializedAttribute) attribute as follows.  
  
```csharp  
[Serializable]  
public class MyObject   
{  
  public int n1;  
  [NonSerialized] public int n2;  
  public String str;  
}  
```

If possible, make an object that could contain security-sensitive data nonserializable. If the object must be serialized, apply the `NonSerialized` attribute to specific fields that store sensitive data. If you don't exclude these fields from serialization, be aware that the data they store are exposed to any code that has permission to serialize. For more information about writing secure serialization code, see [Security and Serialization](../../../docs/framework/misc/security-and-serialization.md).

[!INCLUDE [binary-serialization-warning](../../../includes/binary-serialization-warning.md)]
  
## See also  
 [Binary Serialization](binary-serialization.md)  
 [XML and SOAP Serialization](xml-and-soap-serialization.md)  
 [Security and Serialization](../../../docs/framework/misc/security-and-serialization.md)