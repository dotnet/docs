---
title: "Steps in the serialization process"
ms.date: "08/07/2017"
ms.prod: ".net"
ms.topic: "article"
helpviewer_keywords: 
  - "binary serialization, steps"
  - "serialization, steps"
ms.assetid: 4bcbc883-2a91-418f-b968-6c86a25e9737
caps.latest.revision: 6
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Steps in the serialization process
When the <xref:System.Runtime.Serialization.Formatter.Serialize*> method is called on a [formatter](xref:System.Runtime.Serialization.Formatter), object serialization proceeds according to the following sequence of rules:

- A check is made to determine whether the formatter has a surrogate selector. If the formatter does, check whether the surrogate selector handles objects of the given type. If the selector handles the object type, <xref:System.Runtime.Serialization.ISerializable.GetObjectData*?displayProperty=nameWithType> is called on the surrogate selector.

- If there is no surrogate selector or if it does not handle the object type, a check is made to determine whether the object is marked with the [Serializable](xref:System.SerializableAttribute) attribute. If the object is not, a <xref:System.Runtime.Serialization.SerializationException> is thrown.

- If the object is marked appropriately, check whether the object implements the <xref:System.Runtime.Serialization.ISerializable> interface. If the object does, <xref:System.Runtime.Serialization.ISerializable.GetObjectData*> is called on the object.
  
- If the object does not implement <xref:System.Runtime.Serialization.ISerializable>, the default serialization policy is used, serializing all fields not marked as [NonSerialized](xref:System.NonSerializedAttribute).

[!INCLUDE [binary-serialization-warning](../../../includes/binary-serialization-warning.md)]
  
## See Also  
 [Binary Serialization](binary-serialization.md)  
 [XML and SOAP Serialization](xml-and-soap-serialization.md)