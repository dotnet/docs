---
title: "Serializable Types"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: f1c8539a-6a79-4413-b294-896f0957b2cd
caps.latest.revision: 9
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Serializable Types
By default, the <xref:System.Runtime.Serialization.DataContractSerializer> serializes all publicly visible types. All public read/write properties and fields of the type are serialized.  
  
 You can change the default behavior by applying the <xref:System.Runtime.Serialization.DataContractAttribute> and <xref:System.Runtime.Serialization.DataMemberAttribute> attributes to the types and members This feature can be useful in situations in which you have types that are not under your control and cannot be modified to add attributes. The <xref:System.Runtime.Serialization.DataContractSerializer> recognizes such "unmarked" types.  
  
## Serialization Defaults  
 You can apply the <xref:System.Runtime.Serialization.DataContractAttribute> and <xref:System.Runtime.Serialization.DataMemberAttribute> attributes to explicitly control or customize the serialization of types and members. In addition, you can apply these attributes to private fields. However, even types that are not marked with these attributes are serialized and deserialized. The following rules and exceptions apply:  
  
-   The <xref:System.Runtime.Serialization.DataContractSerializer> infers a data contract from types without attributes using the default properties of the newly created types.  
  
-   All public fields, and properties with public `get` and `set` methods are serialized, unless you apply the <xref:System.Runtime.Serialization.IgnoreDataMemberAttribute> attribute to that member.  
  
-   The serialization semantics are similar to those of the <xref:System.Xml.Serialization.XmlSerializer>.  
  
-   In unmarked types, only public types with constructors that do not have parameters are serialized. The exception to this rule is <xref:System.Runtime.Serialization.ExtensionDataObject> used with the <xref:System.Runtime.Serialization.IExtensibleDataObject> interface.  
  
-   Read-only fields, properties without a `get` or `set` method, and properties with internal or private `set` or `get` methods are not serialized. Such properties are ignored and no exception is thrown, except in the case of get-only collections.  
  
-   <xref:System.Xml.Serialization.XmlSerializer> attributes (such as `XmlElement`, `XmlAttribute`, `XmlIgnore`, `XmlInclude`, and so on) are ignored.  
  
-   If you do not apply the <xref:System.Runtime.Serialization.DataContractAttribute> attribute to a given type, the serializer ignores any member in that type to which the <xref:System.Runtime.Serialization.DataMemberAttribute> attribute is applied.  
  
-   The <xref:System.Runtime.Serialization.DataContractSerializer.KnownTypes%2A> property is supported in types not marked with the <xref:System.Runtime.Serialization.DataContractAttribute> attribute. This includes support for the <xref:System.Runtime.Serialization.KnownTypeAttribute> attribute on unmarked types.  
  
-   To "opt out" of the serialization process for public members, properties, or fields, apply the <xref:System.Runtime.Serialization.IgnoreDataMemberAttribute> attribute to that member.  
  
## Inheritance  
 Unmarked types (types without the <xref:System.Runtime.Serialization.DataContractAttribute> attribute) can inherit from types that do have this attribute; however, the reverse is not permitted: types with the attribute cannot inherit from unmarked types. This rule is enforced primarily to ensure backward compatibility with code written in earlier versions of [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)].  
  
## See Also  
 <xref:System.Runtime.Serialization.IgnoreDataMemberAttribute>  
 <xref:System.Runtime.Serialization.DataContractAttribute>  
 <xref:System.Runtime.Serialization.DataMemberAttribute>  
 <xref:System.Xml.Serialization.XmlSerializer>  
 [Types Supported by the Data Contract Serializer](../../../../docs/framework/wcf/feature-details/types-supported-by-the-data-contract-serializer.md)
