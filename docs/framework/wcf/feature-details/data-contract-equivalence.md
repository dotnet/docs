---
title: "Data Contract Equivalence"
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
  - "data contracts [WCF], equivalence"
ms.assetid: f06f3c7e-c235-4ec1-b200-68142edf1ed1
caps.latest.revision: 16
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Data Contract Equivalence
For a client to successfully send data of a certain type to a service, or a service to successfully send data to a client, the sent type does not necessarily have to exist on the receiving end. The only requirement is that the data contracts of both types be equivalent. (Sometimes, strict equivalence is not required, as discussed in [Data Contract Versioning](../../../../docs/framework/wcf/feature-details/data-contract-versioning.md).)  
  
 For data contracts to be equivalent, they must have the same namespace and name. Additionally, each data member on one side must have an equivalent data member on the other side.  
  
 For data members to be equivalent, they must have the same name. Additionally, they must represent the same type of data; that is, their data contracts must be equivalent.  
  
> [!NOTE]
>  Note that data contract names and namespaces, as well as data member names, are case-sensitive.  
  
 [!INCLUDE[crabout](../../../../includes/crabout-md.md)] data contract names and namespaces, as well as data member names, see [Data Contract Names](../../../../docs/framework/wcf/feature-details/data-contract-names.md).  
  
 If two types exist on the same side (sender or receiver) and their data contracts are not equivalent (for example, they have different data members), you should not give them the same name and namespace. Doing so may cause exceptions to be thrown.  
  
 The data contracts for the following types are equivalent:  
  
 [!code-csharp[C_DataContractNames#5](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_datacontractnames/cs/source.cs#5)]
 [!code-vb[C_DataContractNames#5](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_datacontractnames/vb/source.vb#5)]  
  
## Data Member Order and Data Contract equivalence  
 Using the <xref:System.Runtime.Serialization.DataMemberAttribute.Order%2A> property of the <xref:System.Runtime.Serialization.DataMemberAttribute> class may affect data contract equivalence. The data contracts must have members that appear in the same order to be equivalent. The default order is alphabetical. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Data Member Order](../../../../docs/framework/wcf/feature-details/data-member-order.md).  
  
 For example, the following code results in equivalent data contracts.  
  
 [!code-csharp[C_DataContractNames#6](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_datacontractnames/cs/source.cs#6)]
 [!code-vb[C_DataContractNames#6](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_datacontractnames/vb/source.vb#6)]  
  
 However, the following does not result in an equivalent data contract.  
  
 [!code-csharp[C_DataContractNames#7](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_datacontractnames/cs/source.cs#7)]
 [!code-vb[C_DataContractNames#7](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_datacontractnames/vb/source.vb#7)]  
  
## Inheritance, Interfaces, and Data Contract Equivalence  
 When determining equivalence, a data contract that inherits from another data contract is treated as if it is just one data contract that includes all of the data members from the base type. Keep in mind that the order of the data members must match and that base type members precede derived type members in the order. Furthermore, if, as in the following code example, two data members have the same order value, the ordering for those data members is alphabetical. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Data Member Order](../../../../docs/framework/wcf/feature-details/data-member-order.md).  
  
 In the following example, the data contract for type `Employee` is equivalent to the data contract for the type `Worker`.  
  
 [!code-csharp[C_DataContractNames#8](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_datacontractnames/cs/source.cs#8)]
 [!code-vb[C_DataContractNames#8](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_datacontractnames/vb/source.vb#8)]  
  
 When passing parameters and return values between a client and a service, a data contract from a base class cannot be sent when the receiving endpoint expects a data contract from a derived class. This is in accordance with object-oriented programming tenets. In the previous example, an object of type `Person` cannot be sent when an `Employee` is expected.  
  
 A data contract from a derived class can be sent when a data contract from a base class is expected, but only if the receiving endpoint "knows" of the derived type using the <xref:System.Runtime.Serialization.KnownTypeAttribute>. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Data Contract Known Types](../../../../docs/framework/wcf/feature-details/data-contract-known-types.md). In the previous example, an object of type `Employee` can be sent when a `Person` is expected, but only if the receiver code employs the <xref:System.Runtime.Serialization.KnownTypeAttribute> to include it in the list of known types.  
  
 When passing parameters and return values between applications, if the expected type is an interface, it is equivalent to the expected type being of type <xref:System.Object>. Because every type ultimately derives from <xref:System.Object>, every data contract ultimately derives from the data contract for <xref:System.Object>. Thus, any data contract type can be passed when an interface is expected. Additional steps are required to successfully work with interfaces; for more information, see [Data Contract Known Types](../../../../docs/framework/wcf/feature-details/data-contract-known-types.md).  
  
## See Also  
 <xref:System.Runtime.Serialization.DataContractAttribute>  
 <xref:System.Runtime.Serialization.DataMemberAttribute>  
 [Data Member Order](../../../../docs/framework/wcf/feature-details/data-member-order.md)  
 [Data Contract Known Types](../../../../docs/framework/wcf/feature-details/data-contract-known-types.md)  
 [Data Contract Names](../../../../docs/framework/wcf/feature-details/data-contract-names.md)
