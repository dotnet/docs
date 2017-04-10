---
title: "Marshal by Value | Microsoft Docs"
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
  - "marshal-by-value objects"
  - "binary serialization, marshal-by-value"
  - "serialization, marshal-by-value"
ms.assetid: ee91e8f0-92e0-4732-8015-d17dee154be1
caps.latest.revision: 6
author: "Erikre"
ms.author: "erikre"
manager: "erikre"
---
# Marshal by Value
Objects are valid only in the application domain where they are created. Any attempt to pass the object as a parameter or return it as a result will fail unless the object derives from `MarshalByRefObject` or is marked as `Serializable`. If the object is marked as `Serializable`, the object will automatically be serialized, transported from the one application domain to the other, and then deserialized to produce an exact copy of the object in the second application domain. This process is typically referred to as marshal-by-value.  
  
 When an object derives from `MarshalByRefObject`, an object reference is passed from one application domain to another, rather than the object itself. You can also mark an object that derives from `MarshalByRefObject` as `Serializable`. When this object is used with remoting, the formatter responsible for serialization, which has been preconfigured with a surrogate selector (`SurrogateSelector`), takes control of the serialization process, and replaces all objects derived from `MarshalByRefObject` with a proxy. Without the `SurrogateSelector` in place, the serialization architecture follows the standard serialization rules described in [Steps in the Serialization Process](../../../docs/framework/serialization/steps-in-the-serialization-process.md).  
  
## See Also  
 [Serialization Concepts](../../../docs/framework/serialization/serialization-concepts.md)   
 [XML and SOAP Serialization](../../../docs/framework/serialization/xml-and-soap-serialization.md)