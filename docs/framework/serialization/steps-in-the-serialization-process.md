---
title: "Steps in the Serialization Process | Microsoft Docs"
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
  - "binary serialization, steps"
  - "serialization, steps"
ms.assetid: 4bcbc883-2a91-418f-b968-6c86a25e9737
caps.latest.revision: 6
author: "Erikre"
ms.author: "erikre"
manager: "erikre"
---
# Steps in the Serialization Process
When the `Serialize` method is called on a `formatter]`, object serialization proceeds according to the following sequence of rules:  
  
-   A check is made to determine whether the formatter has a surrogate selector. If the formatter does, check whether the surrogate selector handles objects of the given type. If the selector handles the object type, `ISerializable.GetObjectData` is called on the surrogate selector.  
  
-   If there is no surrogate selector or if it does not handle the object type, a check is made to determine whether the object is marked with the `Serializable` attribute. If the object is not, a `SerializationException` is thrown.  
  
-   If the object is marked appropriately, check whether the object implements the `ISerializabl` interface. If the object does, `GetObjectData` is called on the object.  
  
-   If the object does not implement `ISerializable`, the default serialization policy is used, serializing all fields not marked as `NonSerialized`.  
  
## See Also  
 [Binary Serialization](../../../docs/framework/serialization/binary-serialization.md)   
 [XML and SOAP Serialization](../../../docs/framework/serialization/xml-and-soap-serialization.md)