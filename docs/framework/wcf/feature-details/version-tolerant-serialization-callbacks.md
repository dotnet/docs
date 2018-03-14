---
title: "Version-Tolerant Serialization Callbacks"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "OnDeserializedAttribute [WCF]"
  - "OnDeserializingAttribute [WCF]"
  - "OnSerializingAttribute [WCF]"
  - "serialization [WCF], setting default values"
  - "OnSerializedAttribute [WCF]"
ms.assetid: aa4a3a6f-05ec-4efd-bdbf-2181e13e6468
caps.latest.revision: 17
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Version-Tolerant Serialization Callbacks
The data contract programming model fully supports the version-tolerant serialization callback methods that the <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter> and <xref:System.Runtime.Serialization.Formatters.Soap.SoapFormatter> classes support.  
  
## Version-Tolerant Attributes  
 There are four callback attributes. Each attribute can be applied to a method that the serialization/deserialization engine calls at various times. The table below explains when to use each attribute.  
  
|Attribute|When the corresponding method is called|  
|---------------|---------------------------------------------|  
|<xref:System.Runtime.Serialization.OnSerializingAttribute>|Called before serializing the type.|  
|<xref:System.Runtime.Serialization.OnSerializedAttribute>|Called after serializing the type.|  
|<xref:System.Runtime.Serialization.OnDeserializingAttribute>|Called before deserializing the type.|  
|<xref:System.Runtime.Serialization.OnDeserializedAttribute>|Called after deserializing the type.|  
  
 The methods must accept a <xref:System.Runtime.Serialization.StreamingContext> parameter.  
  
 These methods are primarily intended for use with versioning or initialization. During deserialization, no constructors are called. Therefore, data members may not be correctly initialized (to intended default values) if the data for these members is missing in the incoming stream, for example, if the data comes from a previous version of a type that is missing some data members. To correct this, use the callback method marked with the <xref:System.Runtime.Serialization.OnDeserializingAttribute>, as shown in the following example.  
  
 You can mark only one method per type with each of the preceding callback attributes.  
  
### Example  
 [!code-csharp[C_DataContract#9](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_datacontract/cs/source.cs#9)]
 [!code-vb[C_DataContract#9](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_datacontract/vb/source.vb#9)]  
  
## See Also  
 <xref:System.Runtime.Serialization.OnSerializingAttribute>  
 <xref:System.Runtime.Serialization.OnSerializedAttribute>  
 <xref:System.Runtime.Serialization.OnDeserializingAttribute>  
 <xref:System.Runtime.Serialization.OnDeserializedAttribute>  
 <xref:System.Runtime.Serialization.StreamingContext>  
 [Version Tolerant Serialization](../../../../docs/standard/serialization/version-tolerant-serialization.md)
