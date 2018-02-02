---
title: "Types Supported by the Data Contract Serializer"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "serialization [WCF], supported types"
ms.assetid: 7381b200-437a-4506-9556-d77bf1bc3f34
caps.latest.revision: 24
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Types Supported by the Data Contract Serializer
[!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] uses the <xref:System.Runtime.Serialization.DataContractSerializer> as its default serialization engine to convert data into XML and to convert XML back into data. The <xref:System.Runtime.Serialization.DataContractSerializer> is designed to serialize *data contract* types. However, it supports many other types, which can be thought of as having an implicit data contract. The following is a complete list of types that can be serialized:  
  
-   All publicly visible types that have a constructor that does not have parameters.  
  
-   Data contract types. These are types to which the <xref:System.Runtime.Serialization.DataContractAttribute> attribute has been applied. New custom types that represent business objects should normally be created as data contract types. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Using Data Contracts](../../../../docs/framework/wcf/feature-details/using-data-contracts.md) and [Serializable Types](../../../../docs/framework/wcf/feature-details/serializable-types.md).  
  
-   Collection types. These are types that represent lists of data. These can be regular arrays of types, or collection types, such as <xref:System.Collections.ArrayList> and <xref:System.Collections.Generic.Dictionary%602>. The <xref:System.Runtime.Serialization.CollectionDataContractAttribute> attribute can be used to customize the serialization of these types, but is not required. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Collection Types in Data Contracts](../../../../docs/framework/wcf/feature-details/collection-types-in-data-contracts.md).  
  
-   Enumeration types. Enumerations, including flag enumerations, are serializable. Optionally, enumeration types can be marked with the <xref:System.Runtime.Serialization.DataContractAttribute> attribute, in which case every member that participates in serialization must be marked with the <xref:System.Runtime.Serialization.EnumMemberAttribute> attribute. Members that are not marked are not serialized. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Enumeration Types in Data Contracts](../../../../docs/framework/wcf/feature-details/enumeration-types-in-data-contracts.md).  
  
-   .NET Framework primitive types. The following types built into the .NET Framework can all be serialized and are considered to be primitive types: <xref:System.Byte>, <xref:System.SByte>, <xref:System.Int16>, <xref:System.Int32>, <xref:System.Int64>, <xref:System.UInt16>, <xref:System.UInt32>, <xref:System.UInt64>, <xref:System.Single>, <xref:System.Double>, <xref:System.Boolean>, <xref:System.Char>, <xref:System.Decimal>, <xref:System.Object>, and <xref:System.String>.  
  
-   Other primitive types. These types are not primitives in the .NET Framework but are treated as primitives in the serialized XML form. These types are <xref:System.DateTime>, <xref:System.DateTimeOffset>, <xref:System.TimeSpan>, <xref:System.Guid>, <xref:System.Uri>, <xref:System.Xml.XmlQualifiedName>, and arrays of <xref:System.Byte>.  
  
    > [!NOTE]
    >  Unlike other primitive types, <xref:System.DateTimeOffset> is not a known type by default. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Data Contract Known Types](../../../../docs/framework/wcf/feature-details/data-contract-known-types.md)).  
  
-   Types marked with the <xref:System.SerializableAttribute> attribute. Many types included in the [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] base class library fall into this category. The <xref:System.Runtime.Serialization.DataContractSerializer> fully supports this serialization programming model that was used by .NET Framework remoting, the <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter>, and the <xref:System.Runtime.Serialization.Formatters.Soap.SoapFormatter>, including support for the <xref:System.Runtime.Serialization.ISerializable> interface.  
  
-   Types that represent raw XML or types that represent [!INCLUDE[vstecado](../../../../includes/vstecado-md.md)] relational data. The <xref:System.Xml.XmlElement> and array of <xref:System.Xml.XmlNode> types are supported as a way of representing XML directly. Additionally, types that implement the <xref:System.Xml.Serialization.IXmlSerializable> interface are supported, including the related <xref:System.Xml.Serialization.XmlSchemaProviderAttribute> attribute, and the <xref:System.Xml.Linq.XDocument> and <xref:System.Xml.Linq.XElement> types. The [!INCLUDE[vstecado](../../../../includes/vstecado-md.md)]<xref:System.Data.DataTable> type and the <xref:System.Data.DataSet> type (as well as its typed derived classes) all implement the <xref:System.Xml.Serialization.IXmlSerializable> interface, and therefore fit into this category. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [XML and ADO.NET Types in Data Contracts](../../../../docs/framework/wcf/feature-details/xml-and-ado-net-types-in-data-contracts.md).  
  
## Limitations of Using Certain Types in Partial Trust Mode  
 The following is a list of limitations when using certain types in partial trust mode scenarios:  
  
-   To serialize or deserialize a type that implements <xref:System.Runtime.Serialization.ISerializable> in partially-trusted code using the <xref:System.Runtime.Serialization.DataContractSerializer> requires the <xref:System.Security.Permissions.SecurityPermissionAttribute.SerializationFormatter%2A> and <xref:System.Security.Permissions.SecurityPermissionAttribute.UnmanagedCode%2A> permissions.  
  
-   When running [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] code in [Partial Trust](../../../../docs/framework/wcf/feature-details/partial-trust.md) mode, the serialization and deserialization of `readonly` fields (both `public` and `private`) is not supported. This is because the generated IL is unverifiable and therefore requires elevated permissions.  
  
-   Both the <xref:System.Runtime.Serialization.DataContractSerializer> and the <xref:System.Xml.Serialization.XmlSerializer> are supported in a partial trust environment. However, use of the <xref:System.Runtime.Serialization.DataContractSerializer> is subject to the following conditions:  
  
    -   All serializable `[DataContract]` types must be public.  
  
    -   All serializable `[DataMember]` fields or properties in a `[DataContract]` type must be public and read/write. The serialization and deserialization of `readonly` fields is not supported when running [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] in a partially-trusted application.  
  
    -   The `[Serializable]`/`ISerializable]` programming model is not supported in a partial trust environment.  
  
    -   Known types must be specified in code or machine-level configuration (`Machine.config`). Known types cannot be specified in application-level configuration for security reasons.  
  
-   Types that implement <xref:System.Runtime.Serialization.IObjectReference> throw an exception in a partially-trusted environment because the <xref:System.Runtime.Serialization.IObjectReference.GetRealObject%2A> method requires the security permission `[SecurityPermission(SecurityAction.LinkDemand, Flags=SecurityPermissionFlag.SerializationFormatter)]`.  
  
## Additional Notes on Serialization  
 The following rules also apply to types supported by the Data Contract Serializer:  
  
-   Generic types are fully supported by the data contract serializer.  
  
-   Nullable types are fully supported by the data contract serializer.  
  
-   Interface types are treated either as <xref:System.Object> or, in the case of collection interfaces, as collection types.  
  
-   Both structures and classes are supported.  
  
-   The <xref:System.Runtime.Serialization.DataContractSerializer> does not support the programming model used by the <xref:System.Xml.Serialization.XmlSerializer> and [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] Web services. In particular, it does not support attributes like <xref:System.Xml.Serialization.XmlElementAttribute> and <xref:System.Xml.Serialization.XmlAttributeAttribute>. To enable support for this programming model, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] must be switched to use the <xref:System.Xml.Serialization.XmlSerializer> instead of the <xref:System.Runtime.Serialization.DataContractSerializer>.  
  
-   The <xref:System.DBNull> type is treated in a special way. It is a singleton type, and upon deserialization the deserializer respects the singleton constraint and points all `DBNull` references to the singleton instance. Because `DBNull` is a serializable type, it demands <xref:System.Security.Permissions.SecurityPermissionAttribute.SerializationFormatter%2A> permission.  
  
## See Also  
 [XML and ADO.NET Types in Data Contracts](../../../../docs/framework/wcf/feature-details/xml-and-ado-net-types-in-data-contracts.md)  
 [Using Data Contracts](../../../../docs/framework/wcf/feature-details/using-data-contracts.md)  
 [Serializable Types](../../../../docs/framework/wcf/feature-details/serializable-types.md)  
 [Collection Types in Data Contracts](../../../../docs/framework/wcf/feature-details/collection-types-in-data-contracts.md)  
 [Enumeration Types in Data Contracts](../../../../docs/framework/wcf/feature-details/enumeration-types-in-data-contracts.md)
