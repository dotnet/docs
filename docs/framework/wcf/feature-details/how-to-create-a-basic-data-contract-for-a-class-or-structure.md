---
title: "How to: Create a Basic Data Contract for a Class or Structure"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "DataMemberAttribute"
  - "DataContractAttribute class"
  - "data contracts [WCF], creating for a class or structure"
ms.assetid: bc464889-3070-4a2f-91d2-e788a0f686a7
---
# How to: Create a Basic Data Contract for a Class or Structure
This topic shows the basic steps to create a data contract using a class or structure. For more information about data contracts and how they are used, see [Using Data Contracts](../../../../docs/framework/wcf/feature-details/using-data-contracts.md).  
  
 For a tutorial that walks through the steps of creating a basic Windows Communication Foundation (WCF) service and client, see the [Getting Started Tutorial](../../../../docs/framework/wcf/getting-started-tutorial.md). For a working sample application that consists of a basic service and client, see [Basic Data Contract](../../../../docs/framework/wcf/samples/basic-data-contract.md).  
  
### To create a basic data contract for a class or structure  
  
1. Declare that the type has a data contract by applying the <xref:System.Runtime.Serialization.DataContractAttribute> attribute to the class. Note that all public types, including those without attributes, are serializable. The <xref:System.Runtime.Serialization.DataContractSerializer> infers a data contract if the <xref:System.Runtime.Serialization.DataContractAttribute> attribute is absent. For more information, see [Serializable Types](../../../../docs/framework/wcf/feature-details/serializable-types.md).  
  
2. Define the members (properties, fields, or events) that are serialized by applying the <xref:System.Runtime.Serialization.DataMemberAttribute> attribute to each member. These members are called data members. By default, all public types are serializable. For more information, see [Serializable Types](../../../../docs/framework/wcf/feature-details/serializable-types.md).  
  
    > [!NOTE]
    > You can apply the <xref:System.Runtime.Serialization.DataMemberAttribute> attribute to private fields, causing the data to be exposed to others. Be sure that the member does not contain sensitive data.  
  
## Example  
 The following example shows how to create a data contract for the `Person` type by applying the <xref:System.Runtime.Serialization.DataContractAttribute> and <xref:System.Runtime.Serialization.DataMemberAttribute> attributes to the class and its members.  
  
 [!code-csharp[DataContractAttribute#2](../../../../samples/snippets/csharp/VS_Snippets_CFX/datacontractattribute/cs/overview.cs#2)]
 [!code-vb[DataContractAttribute#2](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/datacontractattribute/vb/overview.vb#2)]  
  
## See also

- <xref:System.Runtime.Serialization.DataContractAttribute>
- <xref:System.Runtime.Serialization.DataMemberAttribute>
- [Using Data Contracts](../../../../docs/framework/wcf/feature-details/using-data-contracts.md)
- [Getting Started Tutorial](../../../../docs/framework/wcf/getting-started-tutorial.md)
- [Getting Started](../../../../docs/framework/wcf/samples/getting-started-sample.md)
