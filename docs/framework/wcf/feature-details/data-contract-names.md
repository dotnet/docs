---
title: "Data Contract Names"
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
  - "data contracts [WCF], naming"
ms.assetid: 31f87e6c-247b-48f5-8e94-b9e1e33d8d09
caps.latest.revision: 27
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Data Contract Names
Sometimes a client and a service do not share the same types. They can still pass data to each other as long as the data contracts are equivalent on both sides. [Data Contract Equivalence](../../../../docs/framework/wcf/feature-details/data-contract-equivalence.md) is based on data contract and data member names, and therefore a mechanism is provided to map types and members to those names. This topic explains the rules for naming data contracts as well as the default behavior of the [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] infrastructure when creating names.  
  
## Basic Rules  
 Basic rules regarding naming data contracts include:  
  
-   A fully-qualified data contract name consists of a namespace and a name.  
  
-   Data members have only names, but no namespaces.  
  
-   When processing data contracts, the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] infrastructure is case-sensitive to both the namespaces and the names of data contracts and data members.  
  
## Data Contract Namespaces  
 A data contract namespace takes the form of a Uniform Resource Identifier (URI). The URI can be either absolute or relative. By default, data contracts for a particular type are assigned a namespace that comes from the common language runtime (CLR) namespace of that type.  
  
 By default, any given CLR namespace (in the format *Clr.Namespace*) is mapped to the namespace "http://schemas.datacontract.org/2004/07/Clr.Namespace". To override this default, apply the <xref:System.Runtime.Serialization.ContractNamespaceAttribute> attribute to the entire module or assembly. Alternatively, to control the data contract namespace for each type, set the <xref:System.Runtime.Serialization.DataContractAttribute.Namespace%2A> property of the <xref:System.Runtime.Serialization.DataContractAttribute>.  
  
> [!NOTE]
>  The "http://schemas.microsoft.com/2003/10/Serialization"namespace is reserved and cannot be used as a data contract namespace.  
  
> [!NOTE]
>  You cannot override the default namespace in data contract types that contain `delegate` declarations.  
  
## Data Contract Names  
 The default name of a data contract for a given type is the name of that type. To override the default, set the <xref:System.Runtime.Serialization.DataContractAttribute.Name%2A> property of the <xref:System.Runtime.Serialization.DataContractAttribute> to an alternative name. Special rules for generic types are described in "Data Contract Names for Generic Types" later in this topic.  
  
## Data Member Names  
 The default name of a data member for a given field or property is the name of that field or property. To override the default, set the <xref:System.Runtime.Serialization.DataMemberAttribute.Name%2A> property of the <xref:System.Runtime.Serialization.DataMemberAttribute> to an alternative value.  
  
### Examples  
 The following example shows how you can override the default naming behavior of data contracts and data members.  
  
 [!code-csharp[C_DataContractNames#1](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_datacontractnames/cs/source.cs#1)]
 [!code-vb[C_DataContractNames#1](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_datacontractnames/vb/source.vb#1)]  
  
## Data Contract Names for Generic Types  
 Special rules exist for determining data contract names for generic types. These rules help avoid data contract name collisions between two closed generics of the same generic type.  
  
 By default, the data contract name for a generic type is the name of the type, followed by the string "Of", followed by the data contract names of the generic parameters, followed by a *hash* computed using the data contract namespaces of the generic parameters. A hash is the result of a mathematical function that acts as a "fingerprint" that uniquely identifies a piece of data. When all of the generic parameters are primitive types, the hash is omitted.  
  
 For example, see the types in the following example.  
  
 [!code-csharp[C_DataContractNames#2](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_datacontractnames/cs/source.cs#2)]
 [!code-vb[C_DataContractNames#2](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_datacontractnames/vb/source.vb#2)]  
  
 In this example, the type `Drawing<Square,RegularRedBrush>` has the data contract name "DrawingOfSquareRedBrush5HWGAU6h", where "5HWGAU6h" is a hash of the "urn:shapes" and "urn:default" namespaces. The type `Drawing<Square,SpecialRedBrush>` has the data contract name "DrawingOfSquareRedBrushjpB5LgQ_S", where "jpB5LgQ_S" is a hash of the "urn:shapes" and the "urn:special" namespaces. Note that if the hash is not used, the two names are identical, and thus a name collision occurs.  
  
## Customizing Data Contract Names for Generic Types  
 Sometimes, the data contract names generated for generic types, as described previously, are unacceptable. For example, you may know in advance that you will not run into name collisions and may want to remove the hash. In this case, you can use the <xref:System.Runtime.Serialization.DataContractAttribute.Name%2A> property of the `DataContractAttribute` attribute to specify a different way to generate names. You can use numbers in curly braces inside of the `Name` property to refer to data contract names of the generic parameters. (0 refers to the first parameter, 1 refers to the second, and so on.) You can use a number (#) sign inside curly braces to refer to the hash. You can use each of these references multiple times or not at all.  
  
 For example, the preceding generic `Drawing` type could have been declared as shown in the following example.  
  
 [!code-csharp[c_DataContractNames#3](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_datacontractnames/cs/source.cs#3)]
 [!code-vb[c_DataContractNames#3](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_datacontractnames/vb/source.vb#3)]  
  
 In this case, the type `Drawing<Square,RegularRedBrush>` has the data contract name "Drawing_using_RedBrush_brush_and_Square_shape". Note that because there is a "{#}" in the <xref:System.Runtime.Serialization.DataContractAttribute.Name%2A> property, the hash is not a part of the name, and thus the type is susceptible to naming collisions; for example, the type `Drawing<Square,SpecialRedBrush>` would have exactly the same data contract name.  
  
## See Also  
 <xref:System.Runtime.Serialization.DataContractAttribute>  
 <xref:System.Runtime.Serialization.DataMemberAttribute>  
 <xref:System.Runtime.Serialization.ContractNamespaceAttribute>  
 [Using Data Contracts](../../../../docs/framework/wcf/feature-details/using-data-contracts.md)  
 [Data Contract Equivalence](../../../../docs/framework/wcf/feature-details/data-contract-equivalence.md)  
 [Data Contract Names](../../../../docs/framework/wcf/feature-details/data-contract-names.md)  
 [Data Contract Versioning](../../../../docs/framework/wcf/feature-details/data-contract-versioning.md)
