---
title: "Data Member Order"
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
  - "data contracts [WCF], ordering members"
ms.assetid: 0658a47d-b6e5-4ae0-ba72-ababc3c6ff33
caps.latest.revision: 17
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Data Member Order
In some applications, it is useful to know the order in which data from the various data members is sent or is expected to be received (such as the order in which data appears in the serialized XML). Sometimes it may be necessary to change this order. This topic explains the ordering rules.  
  
## Basic Rules  
 The basic rules for data ordering include:  
  
-   If a data contract type is a part of an inheritance hierarchy, data members of its base types are always first in the order.  
  
-   Next in order are the current type’s data members that do not have the <xref:System.Runtime.Serialization.DataMemberAttribute.Order%2A> property of the <xref:System.Runtime.Serialization.DataMemberAttribute> attribute set, in alphabetical order.  
  
-   Next are any data members that have the <xref:System.Runtime.Serialization.DataMemberAttribute.Order%2A> property of the <xref:System.Runtime.Serialization.DataMemberAttribute> attribute set. These are ordered by the value of the `Order` property first and then alphabetically if there is more than one member of a certain `Order` value. Order values may be skipped.  
  
 Alphabetical order is established by calling the <xref:System.String.CompareOrdinal%2A> method.  
  
## Examples  
 Consider the following code.  
  
 [!code-csharp[C_DataContractNames#4](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_datacontractnames/cs/source.cs#4)]
 [!code-vb[C_DataContractNames#4](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_datacontractnames/vb/source.vb#4)]  
  
 The XML produced is similar to the following.  
  
```xml  
<DerivedType>  
    <!-- Zebra is a base data member, and appears first. -->  
    <zebra/>   
  
    <!-- Cat has no Order, appears alphabetically first. -->  
    <cat/>  
  
   <!-- Dog has no Order, appears alphabetically last. -->  
    <dog/>   
  
    <!-- Bird is the member with the smallest Order value -->  
    <bird/>  
  
    <!-- Albatross has the next Order value, alphabetically first. -->  
    <albatross/>  
  
    <!-- Parrot, with the next Order value, alphabetically last. -->  
     <parrot/>  
  
    <!-- Antelope is the member with the highest Order value. Note that   
    Order=2 is skipped -->  
     <antelope/>   
</DerivedType>  
```  
  
## See Also  
 <xref:System.Runtime.Serialization.DataContractAttribute>  
 [Data Contract Equivalence](../../../../docs/framework/wcf/feature-details/data-contract-equivalence.md)  
 [Using Data Contracts](../../../../docs/framework/wcf/feature-details/using-data-contracts.md)
