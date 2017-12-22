---
title: "Data Member Default Values"
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
  - "data members [WCF], default values"
  - "data members [WCF]"
ms.assetid: 53a3b505-4b27-444b-b079-0eb84a97cfd8
caps.latest.revision: 10
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Data Member Default Values
In the [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)], types have a concept of *default values*. For example, for any reference type the default value is `null`, and for an integer type it is zero. It is occasionally desirable to omit a data member from serialized data when it is set to its default value. Because the member has a default value, an actual value need not be serialized; this has a performance advantage.  
  
 To omit a member from serialized data, set the <xref:System.Runtime.Serialization.DataMemberAttribute.EmitDefaultValue%2A> property of the <xref:System.Runtime.Serialization.DataMemberAttribute> attribute to `false` (the default is `true`).  
  
> [!NOTE]
>  You should set the <xref:System.Runtime.Serialization.DataMemberAttribute.EmitDefaultValue%2A> property to `false` if there is a specific need to do so, such as for interoperability or data size reduction.  
  
## Example  
 The following code has several members with the <xref:System.Runtime.Serialization.DataMemberAttribute.EmitDefaultValue%2A> set to `false`.  
  
 [!code-csharp[DataMemberAttribute#4](../../../../samples/snippets/csharp/VS_Snippets_CFX/datamemberattribute/cs/overview.cs#4)]
 [!code-vb[DataMemberAttribute#4](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/datamemberattribute/vb/overview.vb#4)]  
  
 If an instance of this class is serialized, the result is as follows: `employeeName` and `employeeID` is serialized. The null value for `employeeName` and the zero value for `employeeID` is explicitly part of the serialized data. However, the `position`, `salary`, and `bonus` members are not serialized. Finally, `targetSalary` is serialized as usual, even though the <xref:System.Runtime.Serialization.DataMemberAttribute.EmitDefaultValue%2A> property is set to `false`, because 57800 does not match the .NET default value for an integer, which is zero.  
  
### XML Representation  
 If the previous example is serialized to XML, the representation is similar to the following.  
  
```xml  
<Employee>  
   <employeeName xsi:nil="true" />  
   <employeeID>0</employeeID>  
<targetSalary>57800</targetSalary>  
</Employee>  
```  
  
 The `xsi:nil` attribute is a special attribute in the World Wide Web Consortium (W3C) XML Schema instance namespace that provides an interoperable way to explicitly represent a null value. Note that there is no information at all in the XML about position, salary, and bonus data members. The receiving end can interpret these as `null`, zero, and `null`, respectively. There is no guarantee that a third-party deserializer can make the correct interpretation, which is why this pattern is not recommended. The <xref:System.Runtime.Serialization.DataContractSerializer> class always selects the correct interpretation for missing values.  
  
### Interaction with IsRequired  
 As discussed in [Data Contract Versioning](../../../../docs/framework/wcf/feature-details/data-contract-versioning.md), the <xref:System.Runtime.Serialization.DataMemberAttribute> attribute has an <xref:System.Runtime.Serialization.DataMemberAttribute.IsRequired%2A> property (the default is `false`). The property indicates whether a given data member must be present in the serialized data when it is being deserialized. If `IsRequired` is set to `true`, (which indicates that a value must be present) and <xref:System.Runtime.Serialization.DataMemberAttribute.EmitDefaultValue%2A> is set to `false` (indicating that the value must not be present if it is set to its default value), default values for this data member cannot be serialized because the results would be contradictory. If such a data member is set to its default value (usually `null` or zero) and a serialization is attempted, a <xref:System.Runtime.Serialization.SerializationException> is thrown.  
  
### Schema Representation  
 The details of the XML Schema definition language (XSD) schema representation of data members when the `EmitDefaultValue` property is set to `false` are discussed in [Data Contract Schema Reference](../../../../docs/framework/wcf/feature-details/data-contract-schema-reference.md). However, the following is a brief overview:  
  
-   When the <xref:System.Runtime.Serialization.DataMemberAttribute.EmitDefaultValue%2A> is set to `false`, it is represented in the schema as an annotation specific to [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)]. There is no interoperable way to represent this information. In particular, the "default" attribute in the schema is not used for this purpose, the `minOccurs` attribute is affected only by the <xref:System.Runtime.Serialization.DataMemberAttribute.IsRequired%2A> setting, and the `nillable` attribute is affected only by the type of the data member.  
  
-   The actual default value to use is not present in the schema. It is up to the receiving endpoint to appropriately interpret a missing element.  
  
 On schema import, the <xref:System.Runtime.Serialization.DataMemberAttribute.EmitDefaultValue%2A> property is automatically set to `false` whenever the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]-specific annotation mentioned previously is detected. It is also set to `false` for reference types that have the `nillable` property set to `false` to support specific interoperability scenarios that commonly occur when consuming [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] Web services.  
  
## See Also  
 <xref:System.Runtime.Serialization.DataMemberAttribute.EmitDefaultValue%2A>  
 <xref:System.Runtime.Serialization.DataMemberAttribute>
