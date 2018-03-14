---
title: "Data Contract Schema Reference"
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
  - "data contracts [WCF], schema reference"
ms.assetid: 9ebb0ebe-8166-4c93-980a-7c8f1f38f7c0
caps.latest.revision: 24
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Data Contract Schema Reference
This topic describes the subset of the XML Schema (XSD) used by <xref:System.Runtime.Serialization.DataContractSerializer> to describe common language runtime (CLR) types for XML serialization.  
  
## DataContractSerializer Mappings  
 The `DataContractSerializer` maps CLR types to XSD when metadata is exported from a [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] service using a metadata endpoint or the [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md). [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Data Contract Serializer](../../../../docs/framework/wcf/feature-details/data-contract-serializer.md).  
  
 The `DataContractSerializer` also maps XSD to CLR types when Svcutil.exe is used to access Web Services Description Language (WSDL) or XSD documents and generate data contracts for services or clients.  
  
 Only XML Schema instances that conform to requirements stated in this document can be mapped to CLR types using `DataContractSerializer`.  
  
### Support Levels  
 The `DataContractSerializer` provides the following levels of support for a given XML Schema feature:  
  
-   **Supported**. There is explicit mapping from this feature to CLR types or attributes (or both) using `DataContractSerializer`.  
  
-   **Ignored**. The feature is allowed in schemas imported by the `DataContractSerializer`, but has no effect on code generation.  
  
-   **Forbidden**. The `DataContractSerializer` does not support importing a schema using the feature. For example, Svcutil.exe, when accessing a WSDL with a schema that uses such a feature, falls back to using the <xref:System.Xml.Serialization.XmlSerializer> instead. This is by default.  
  
## General Information  
  
-   The schema namespace is described at [XML Schema](http://go.microsoft.com/fwlink/?LinkId=95475). The prefix "xs" is used in this document.  
  
-   Any attributes with a non-schema namespace are ignored.  
  
-   Any annotations (except for those described in this document) are ignored.  
  
### \<xs:schema>: attributes  
  
|Attribute|DataContract|  
|---------------|------------------|  
|`attributeFormDefault`|Ignored.|  
|`blockDefault`|Ignored.|  
|`elementFormDefault`|Must be qualified. All elements must be qualified for a schema to be supported by `DataContractSerializer`. This can be accomplished by either setting xs:schema/@elementFormDefault to "qualified" or by setting xs:element/@form to "qualified" on each individual element declaration.|  
|`finalDefault`|Ignored.|  
|`Id`|Ignored.|  
|`targetNamespace`|Supported and mapped to the data contract namespace. If this attribute is not specified, the blank namespace is used. Cannot be the reserved namespace http://schemas.microsoft.com/2003/10/Serialization/.|  
|`version`|Ignored.|  
  
### \<xs:schema>: contents  
  
|Contents|Schema|  
|--------------|------------|  
|`include`|Supported. `DataContractSerializer` supports xs:include and xs:import. However, Svcutil.exe restricts following `xs:include/@schemaLocation` and `xs:import/@location` references when metadata is loaded from a local file. The list of schema files must be passed through an out-of-band mechanism and not through `include` in this case; `include`d schema documents are ignored.|  
|`redefine`|Forbidden. The use of `xs:redefine` is forbidden by `DataContractSerializer` for security reasons: `x:redefine` requires `schemaLocation` to be followed. In certain circumstances, Svcutil.exe using DataContract restricts use of `schemaLocation`.|  
|`import`|Supported. `DataContractSerializer` supports `xs:include` and `xs:import`. However, Svcutil.exe restricts following `xs:include/@schemaLocation` and `xs:import/@location` references when metadata is loaded from a local file. The list of schema files must be passed through an out-of-band mechanism and not through `include` in this case; `include`d schema documents are ignored.|  
|`simpleType`|Supported. See the `xs:simpleType` section.|  
|`complexType`|Supported, maps to data contracts. See the `xs:complexType` section.|  
|`group`|Ignored. `DataContractSerializer` does not support use of `xs:group`, `xs:attributeGroup`, and `xs:attribute`. These declarations are ignored as children of `xs:schema`, but cannot be referenced from within `complexType` or other supported constructs.|  
|`attributeGroup`|Ignored. `DataContractSerializer` does not support use of `xs:group`, `xs:attributeGroup`, and `xs:attribute`. These declarations are ignored as children of `xs:schema`, but cannot be referenced from within `complexType` or other supported constructs.|  
|`element`|Supported. See Global Element Declaration (GED).|  
|`attribute`|Ignored. `DataContractSerializer` does not support use of `xs:group`, `xs:attributeGroup`, and `xs:attribute`. These declarations are ignored as children of `xs:schema`, but cannot be referenced from within `complexType` or other supported constructs.|  
|`notation`|Ignored.|  
  
## Complex Types – \<xs:complexType>  
  
### General Information  
 Each complex type \<xs:complexType> maps to a data contract.  
  
### \<xs:complexType>: attributes  
  
|Attribute|Schema|  
|---------------|------------|  
|`abstract`|Must be false (default).|  
|`block`|Forbidden.|  
|`final`|Ignored.|  
|`id`|Ignored.|  
|`mixed`|Must be false (default).|  
|`name`|Supported and mapped to the data contract name. If there are periods in the name, an attempt is made to map the type to an inner type. For example, a complex type named `A.B` maps to a data contract type that is an inner type of a type with the data contract name `A`, but only if such a data contract type exists. More than one level of nesting is possible: for example, `A.B.C` can be an inner type, but only if `A` and `A.B` both exist.|  
  
### \<xs:complexType>: contents  
  
|Contents|Schema|  
|--------------|------------|  
|`simpleContent`|Extensions are forbidden.<br /><br /> Restriction is allowed only from `anySimpleType`.|  
|`complexContent`|Supported. See "Inheritance".|  
|`group`|Forbidden.|  
|`all`|Forbidden.|  
|`choice`|Forbidden|  
|`sequence`|Supported, maps to data members of a data contract.|  
|`attribute`|Forbidden, even if use="prohibited" (with one exception). Only optional attributes from the Standard Serialization Schema namespace are supported. They do not map to data members in the data contract programming model. Currently, only one such attribute has meaning and is discussed in the ISerializable section. All others are ignored.|  
|`attributeGroup`|Forbidden. In the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] v1 release, `DataContractSerializer` ignores the presence of `attributeGroup` inside `xs:complexType`.|  
|`anyAttribute`|Forbidden.|  
|(empty)|Maps to a data contract with no data members.|  
  
### \<xs:sequence> in a complex type: attributes  
  
|Attribute|Schema|  
|---------------|------------|  
|`id`|Ignored.|  
|`maxOccurs`|Must be 1 (default).|  
|`minOccurs`|Must be 1 (default).|  
  
### \<xs:sequence> in a complex type: contents  
  
|Contents|Schema|  
|--------------|------------|  
|`element`|Each instance maps to a data member.|  
|`group`|Forbidden.|  
|`choice`|Forbidden.|  
|`sequence`|Forbidden.|  
|`any`|Forbidden.|  
|(empty)|Maps to a data contract with no data members.|  
  
## Elements – \<xs:element>  
  
### General Information  
 `<xs:element>` can occur in the following contexts:  
  
-   It can occur within an `<xs:sequence>`, which describes a data member of a regular (non-collection) data contract. In this case, the `maxOccurs` attribute must be 1. (A value of 0 is not allowed).  
  
-   It can occur within an `<xs:sequence>`, which describes a data member of a collection data contract. In this case, the `maxOccurs` attribute must be greater than 1 or "unbounded".  
  
-   It can occur within an `<xs:schema>` as a Global Element Declaration (GED).  
  
### \<xs:element> with maxOccurs=1 within an \<xs:sequence> (Data Members)  
  
|Attribute|Schema|  
|---------------|------------|  
|`ref`|Forbidden.|  
|`name`|Supported, maps to the data member name.|  
|`type`|Supported, maps to the data member type. For more information, see Type/primitive mapping. If not specified (and the element does not contain an anonymous type), `xs:anyType` is assumed.|  
|`block`|Ignored.|  
|`default`|Forbidden.|  
|`fixed`|Forbidden.|  
|`form`|Must be qualified. This attribute can be set through `elementFormDefault` on `xs:schema`.|  
|`id`|Ignored.|  
|`maxOccurs`|1|  
|`minOccurs`|Maps to the <xref:System.Runtime.Serialization.DataMemberAttribute.IsRequired%2A> property of a data member (`IsRequired` is true when `minOccurs` is 1).|  
|`nillable`|Affects type mapping. See Type/primitive mapping.|  
  
### \<xs:element> with maxOccurs>1 within an \<xs:sequence> (Collections)  
  
-   Maps to a <xref:System.Runtime.Serialization.CollectionDataContractAttribute>.  
  
-   In collection types, only one xs:element is allowed within an xs:sequence.  
  
 Collections can be of the following types:  
  
-   Regular collections (for example, arrays).  
  
-   Dictionary collections (mapping one value to another; for example, a <xref:System.Collections.Hashtable>).  
  
-   The only difference between a dictionary and an array of a key/value pair type is in the generated programming model. There is a schema annotation mechanism that can be used to indicate that a given type is a dictionary collection.  
  
 The rules for the `ref`, `block`, `default`, `fixed`, `form`, and `id` attributes are the same as for the non-collection case. Other attributes include those in the following table.  
  
|Attribute|Schema|  
|---------------|------------|  
|`name`|Supported, maps to the <xref:System.Runtime.Serialization.CollectionDataContractAttribute.ItemName%2A> property in the `CollectionDataContractAttribute` attribute.|  
|`type`|Supported, maps to the type stored in the collection.|  
|`maxOccurs`|Greater than 1 or "unbounded". The DC schema should use "unbounded".|  
|`minOccurs`|Ignored.|  
|`nillable`|Affects type mapping. This attribute is ignored for dictionary collections.|  
  
### \<xs:element> within an \<xs:schema> Global Element Declaration  
  
-   A Global Element Declaration (GED) that has the same name and namespace as a type in schema, or that defines an anonymous type inside itself, is said to be associated with the type.  
  
-   Schema export: associated GEDs are generated for every generated type, both simple and complex.  
  
-   Deserialization/serialization: associated GEDs are used as root elements for the type.  
  
-   Schema import: associated GEDs are not required and are ignored if they follow the following rules (unless they define types).  
  
|Attribute|Schema|  
|---------------|------------|  
|`abstract`|Must be false for associated GEDs.|  
|`block`|Forbidden in associated GEDs.|  
|`default`|Forbidden in associated GEDs.|  
|`final`|Must be false for associated GEDs.|  
|`fixed`|Forbidden in associated GEDs.|  
|`id`|Ignored.|  
|`name`|Supported. See the definition of associated GEDs.|  
|`nillable`|Must be true for associated GEDs.|  
|`substitutionGroup`|Forbidden in associated GEDs.|  
|`type`|Supported, and must match the associated type for associated GEDs (unless the element contains an anonymous type).|  
  
### \<xs:element>: contents  
  
|Contents|Schema|  
|--------------|------------|  
|`simpleType`|Supported.*|  
|`complexType`|Supported.*|  
|`unique`|Ignored.|  
|`key`|Ignored.|  
|`keyref`|Ignored.|  
|(blank)|Supported.|  
  
 \* When using the `simpleType` and `complexType,` mapping for anonymous types is the same as for non-anonymous types, except that there is no anonymous data contracts, and so a named data contract is created, with a generated name derived from the element name. The rules for anonymous types are in the following list:  
  
-   [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] implementation detail: If the `xs:element` name does not contain periods, the anonymous type maps to an inner type of the outer data contract type. If the name contains periods, the resulting data contract type is independent (not an inner type).  
  
-   The generated data contract name of the inner type is the data contract name of the outer type followed by a period, the name of the element, and the string "Type".  
  
-   If a data contract with such a name already exists, the name is made unique by appending "1", "2", "3", and so on until a unique name is created.  
  
## Simple Types - \<xs:simpleType>  
  
### \<xs:simpleType>: attributes  
  
|Attribute|Schema|  
|---------------|------------|  
|`final`|Ignored.|  
|`id`|Ignored.|  
|`name`|Supported, maps to the data contract name.|  
  
### \<xs:simpleType>: contents  
  
|Contents|Schema|  
|--------------|------------|  
|`restriction`|Supported. Maps to enumeration data contracts. This attribute is ignored if it does not match the enumeration pattern. See the `xs:simpleType` restrictions section.|  
|`list`|Supported. Maps to flag enumeration data contracts. See the `xs:simpleType` lists section.|  
|`union`|Forbidden.|  
  
### \<xs:restriction>  
  
-   Complex type restrictions are supported only for base="`xs:anyType`".  
  
-   Simple type restrictions of `xs:string` that do not have any restriction facets other than `xs:enumeration` are mapped to enumeration data contracts.  
  
-   All other simple type restrictions are mapped to the types they restrict. For example, a restriction of `xs:int` maps to an integer, just as `xs:int` itself does. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] primitive type mapping, see Type/primitive mapping.  
  
### \<xs:restriction>: attributes  
  
|Attribute|Schema|  
|---------------|------------|  
|`base`|Must be a supported simple type or `xs:anyType`.|  
|`id`|Ignored.|  
  
### \<xs:restriction> for all other cases: contents  
  
|Contents|Schema|  
|--------------|------------|  
|`simpleType`|If present, must be derived from a supported primitive type.|  
|`minExclusive`|Ignored.|  
|`minInclusive`|Ignored.|  
|`maxExclusive`|Ignored.|  
|`maxInclusive`|Ignored.|  
|`totalDigits`|Ignored.|  
|`fractionDigits`|Ignored.|  
|`length`|Ignored.|  
|`minLength`|Ignored.|  
|`maxLength`|Ignored.|  
|`enumeration`|Ignored.|  
|`whiteSpace`|Ignored.|  
|`pattern`|Ignored.|  
|(blank)|Supported.|  
  
## Enumeration  
  
### \<xs:restriction> for enumerations: attributes  
  
|Attribute|Schema|  
|---------------|------------|  
|`base`|If present, must be `xs:string`.|  
|`id`|Ignored.|  
  
### \<xs:restriction> for enumerations: contents  
  
|Contents|Schema|  
|--------------|------------|  
|`simpleType`|If present, must be an enumeration restriction supported by the data contract (this section).|  
|`minExclusive`|Ignored.|  
|`minInclusive`|Ignored.|  
|`maxExclusive`|Ignored.|  
|`maxInclusive`|Ignored.|  
|`totalDigits`|Ignored.|  
|`fractionDigits`|Ignored.|  
|`length`|Forbidden.|  
|`minLength`|Forbidden.|  
|`maxLength`|Forbidden.|  
|`enumeration`|Supported. Enumeration "id" is ignored, and "value" maps to the value name in the enumeration data contract.|  
|`whiteSpace`|Forbidden.|  
|`pattern`|Forbidden.|  
|(empty)|Supported, maps to empty enumeration type.|  
  
 The following code shows a C# enumeration class.  
  
```  
public enum MyEnum  
{  
   first = 3,  
   second = 4,  
   third =5  
```  
  
 }  
  
 This class maps to the following schema by the `DataContractSerializer`. If enumeration values start from 1, `xs:annotation` blocks are not generated.  
  
```xml  
<xs:simpleType name="MyEnum">  
<xs:restriction base="xs:string">  
 <xs:enumeration value="first">  
  <xs:annotation>  
   <xs:appinfo>  
    <EnumerationValue   
     xmlns="http://schemas.microsoft.com/2003/10/Serialization/">  
     3  
    </EnumerationValue>  
   </xs:appinfo>  
  </xs:annotation>  
 </xs:enumeration>  
 <xs:enumeration value="second">  
  <xs:annotation>  
   <xs:appinfo>  
    <EnumerationValue   
     xmlns="http://schemas.microsoft.com/2003/10/Serialization/">  
     4  
    </EnumerationValue>  
   </xs:appinfo>  
  </xs:annotation>  
 </xs:enumeration>  
</xs:restriction>  
</xs:simpleType>  
```  
  
### \<xs:list>  
 `DataContractSerializer` maps enumeration types marked with `System.FlagsAttribute` to `xs:list` derived from `xs:string`. No other `xs:list` variations are supported.  
  
### \<xs:list>: attributes  
  
|Attribute|Schema|  
|---------------|------------|  
|`itemType`|Forbidden.|  
|`id`|Ignored.|  
  
### \<xs:list>: contents  
  
|Contents|Schema|  
|--------------|------------|  
|`simpleType`|Must be restriction from `xs:string` using `xs:enumeration` facet.|  
  
 If enumeration value does not follow a power of 2 progression (default for Flags), the value is stored in the `xs:annotation/xs:appInfo/ser:EnumerationValue` element.  
  
 For example, the following code flags an enumeration type.  
  
```  
[Flags]  
public enum AuthFlags  
{    
  AuthAnonymous = 1,  
  AuthBasic = 2,  
  AuthNTLM = 4,  
  AuthMD5 = 16,  
  AuthWindowsLiveID = 64,  
}  
```  
  
 This type maps to the following schema.  
  
```xml  
<xs:simpleType name="AuthFlags">  
    <xs:list>  
      <xs:simpleType>  
        <xs:restriction base="xs:string">  
          <xs:enumeration value="AuthAnonymous" />  
          <xs:enumeration value="AuthBasic" />  
          <xs:enumeration value="AuthNTLM" />  
          <xs:enumeration value="AuthMD5">  
            <xs:annotation>  
              <xs:appinfo>  
                <EnumerationValue xmlns="http://schemas.microsoft.com/2003/10/Se  
rialization/">16</EnumerationValue>  
              </xs:appinfo>  
            </xs:annotation>  
          </xs:enumeration>  
          <xs:enumeration value="AuthWindowsLiveID">  
            <xs:annotation>  
              <xs:appinfo>  
                <EnumerationValue xmlns="http://schemas.microsoft.com/2003/10/Se  
rialization/">64</EnumerationValue>  
              </xs:appinfo>  
            </xs:annotation>  
          </xs:enumeration>  
        </xs:restriction>  
      </xs:simpleType>  
    </xs:list>  
  </xs:simpleType>  
```  
  
## Inheritance  
  
### General rules  
 A data contract can inherit from another data contract. Such data contracts map to a base and are derived by extension types using the `<xs:extension>` XML Schema construct.  
  
 A data contract cannot inherit from a collection data contract.  
  
 For example, the following code is a data contract.  
  
```  
[DataContract]  
public class Person  
{  
  [DataMember]  
  public string Name;  
}  
[DataContract]  
public class Employee : Person   
{      
  [DataMember]  
  public int ID;  
}  
```  
  
 This data contract maps to the following XML Schema type declaration.  
  
```xml  
<xs:complexType name="Employee">  
 <xs:complexContent mixed="false">  
  <xs:extension base="tns:Person">  
   <xs:sequence>  
    <xs:element minOccurs="0" name="ID" type="xs:int"/>  
   </xs:sequence>  
  </xs:extension>  
 </xs:complexContent>  
</xs:complexType>  
<xs:complexType name="Person">  
 <xs:sequence>  
  <xs:element minOccurs="0" name="Name"   
    nillable="true" type="xs:string"/>  
 </xs:sequence>  
</xs:complexType>  
```  
  
### \<xs:complexContent>: attributes  
  
|Attribute|Schema|  
|---------------|------------|  
|`id`|Ignored.|  
|`mixed`|Must be false.|  
  
### \<xs:complexContent>: contents  
  
|Contents|Schema|  
|--------------|------------|  
|`restriction`|Forbidden, except when base="`xs:anyType`". The latter is equivalent to placing the content of the `xs:restriction` directly under the container of the `xs:complexContent`.|  
|`extension`|Supported. Maps to data contract inheritance.|  
  
### \<xs:extension> in \<xs:complexContent>: attributes  
  
|Attribute|Schema|  
|---------------|------------|  
|`id`|Ignored.|  
|`base`|Supported. Maps to the base data contract type that this type inherits from.|  
  
### \<xs:extension> in \<xs:complexContent>: contents  
 The rules are the same as for `<xs:complexType>` contents.  
  
 If an `<xs:sequence>` is provided, its member elements map to additional data members that are present in the derived data contract.  
  
 If a derived type contains an element with the same name as an element in a base type, the duplicate element declaration maps to a data member with a name that is generated to be unique. Positive integer numbers are added to the data member name ("member1", "member2", and so on) until a unique name is found. Conversely:  
  
-   If a derived data contract has a data member with the same name and type as a data member in a base data contract, `DataContractSerializer` generates this corresponding element in the derived type.  
  
-   If a derived data contract has a data member with the same name as a data member in a base data contract but a different type, the `DataContractSerializer` imports a schema with an element of the type `xs:anyType` in both base type and derived type declarations. The original type name is preserved in `xs:annotations/xs:appInfo/ser:ActualType/@Name`.  
  
 Both variations may lead to a schema with an ambiguous content model, which depends on the order of the respective data members.  
  
## Type/primitive mapping  
 The `DataContractSerializer` uses the following mapping for XML Schema primitive types.  
  
|XSD type|.NET type|  
|--------------|---------------|  
|`anyType`|<xref:System.Object>.|  
|`anySimpleType`|<xref:System.String>.|  
|`duration`|<xref:System.TimeSpan>.|  
|`dateTime`|<xref:System.DateTime>.|  
|`dateTimeOffset`|<xref:System.DateTime> and <xref:System.TimeSpan> for the offset. See DateTimeOffset Serialization below.|  
|`time`|<xref:System.String>.|  
|`date`|<xref:System.String>.|  
|`gYearMonth`|<xref:System.String>.|  
|`gYear`|<xref:System.String>.|  
|`gMonthDay`|<xref:System.String>.|  
|`gDay`|<xref:System.String>.|  
|`gMonth`|<xref:System.String>.|  
|`boolean`|<xref:System.Boolean>|  
|`base64Binary`|<xref:System.Byte> array.|  
|`hexBinary`|<xref:System.String>.|  
|`float`|<xref:System.Single>.|  
|`double`|<xref:System.Double>.|  
|`anyURI`|<xref:System.Uri>.|  
|`QName`|<xref:System.Xml.XmlQualifiedName>.|  
|`string`|<xref:System.String>.|  
|`normalizedString`|<xref:System.String>.|  
|`token`|<xref:System.String>.|  
|`language`|<xref:System.String>.|  
|`Name`|<xref:System.String>.|  
|`NCName`|<xref:System.String>.|  
|`ID`|<xref:System.String>.|  
|`IDREF`|<xref:System.String>.|  
|`IDREFS`|<xref:System.String>.|  
|`ENTITY`|<xref:System.String>.|  
|`ENTITIES`|<xref:System.String>.|  
|`NMTOKEN`|<xref:System.String>.|  
|`NMTOKENS`|<xref:System.String>.|  
|`decimal`|<xref:System.Decimal>.|  
|`integer`|<xref:System.Int64>.|  
|`nonPositiveInteger`|<xref:System.Int64>.|  
|`negativeInteger`|<xref:System.Int64>.|  
|`long`|<xref:System.Int64>.|  
|`int`|<xref:System.Int32>.|  
|`short`|<xref:System.Int16>.|  
|`Byte`|<xref:System.SByte>.|  
|`nonNegativeInteger`|<xref:System.Int64>.|  
|`unsignedLong`|<xref:System.UInt64>.|  
|`unsignedInt`|<xref:System.UInt32>.|  
|`unsignedShort`|<xref:System.UInt16>.|  
|`unsignedByte`|<xref:System.Byte>.|  
|`positiveInteger`|<xref:System.Int64>.|  
  
## ISerializable types mapping  
 In [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] version 1.0, `ISerializable` was introduced as a general mechanism to serialize objects for persistence or data transfer. There are many [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] types that implement `ISerializable` and that can be passed between applications. `DataContractSerializer` naturally provides support for `ISerializable` classes. The `DataContractSerializer` maps `ISerializable` implementation schema types that differ only by the QName (qualified name) of the type and are effectively property collections. For example, the `DataContractSerializer` maps <xref:System.Exception> to the following XSD type in the http://schemas.datacontract.org/2004/07/System namespace.  
  
```xml  
<xs:complexType name="Exception">  
 <xs:sequence>  
  <xs:any minOccurs="0" maxOccurs="unbounded"   
      namespace="##local" processContents="skip"/>  
 </xs:sequence>  
 <xs:attribute ref="ser:FactoryType"/>  
</xs:complexType>  
```  
  
 The optional attribute `ser:FactoryType` declared in the Data Contract Serialization schema references a factory class that can deserialize the type. The factory class must be part of the known types collection of the `DataContractSerializer` instance being used. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] known types, see [Data Contract Known Types](../../../../docs/framework/wcf/feature-details/data-contract-known-types.md).  
  
## DataContract Serialization Schema  
 A number of schemas exported by the `DataContractSerializer` use types, elements, and attributes from a special Data Contract Serialization namespace:  
  
 http://schemas.microsoft.com/2003/10/Serialization  
  
 The following is a complete Data Contract Serialization schema declaration.  
  
```xml  
<xs:schema attributeFormDefault="qualified"          
   elementFormDefault="qualified"        
   targetNamespace =   
    "http://schemas.microsoft.com/2003/10/Serialization/"   
   xmlns:xs="http://www.w3.org/2001/XMLSchema"        
   xmlns:tns="http://schemas.microsoft.com/2003/10/Serialization/">  
  
 <!-- Top-level elements for primitive types. -->  
 <xs:element name="anyType" nillable="true" type="xs:anyType"/>  
 <xs:element name="anyURI" nillable="true" type="xs:anyURI"/>  
 <xs:element name="base64Binary"  
       nillable="true" type="xs:base64Binary"/>  
 <xs:element name="boolean" nillable="true" type="xs:boolean"/>  
 <xs:element name="byte" nillable="true" type="xs:byte"/>  
 <xs:element name="dateTime" nillable="true" type="xs:dateTime"/>  
 <xs:element name="decimal" nillable="true" type="xs:decimal"/>  
 <xs:element name="double" nillable="true" type="xs:double"/>  
 <xs:element name="float" nillable="true" type="xs:float"/>  
 <xs:element name="int" nillable="true" type="xs:int"/>  
 <xs:element name="long" nillable="true" type="xs:long"/>  
 <xs:element name="QName" nillable="true" type="xs:QName"/>  
 <xs:element name="short" nillable="true" type="xs:short"/>  
 <xs:element name="string" nillable="true" type="xs:string"/>  
 <xs:element name="unsignedByte"  
       nillable="true" type="xs:unsignedByte"/>  
 <xs:element name="unsignedInt"  
       nillable="true" type="xs:unsignedInt"/>  
 <xs:element name="unsignedLong"  
       nillable="true" type="xs:unsignedLong"/>  
 <xs:element name="unsignedShort"  
       nillable="true" type="xs:unsignedShort"/>  
  
 <!-- Primitive types introduced for certain .NET simple types. -->  
 <xs:element name="char" nillable="true" type="tns:char"/>  
 <xs:simpleType name="char">  
  <xs:restriction base="xs:int"/>  
 </xs:simpleType>  
  
 <!-- xs:duration is restricted to an ordered value space,  
    to map to System.TimeSpan -->  
 <xs:element name="duration" nillable="true" type="tns:duration"/>  
 <xs:simpleType name="duration">  
  <xs:restriction base="xs:duration">  
   <xs:pattern   
     value="\-?P(\d*D)?(T(\d*H)?(\d*M)?(\d*(\.\d*)?S)?)?"/>  
   <xs:minInclusive value="-P10675199DT2H48M5.4775808S"/>  
   <xs:maxInclusive value="P10675199DT2H48M5.4775807S"/>  
  </xs:restriction>  
 </xs:simpleType>  
  
 <xs:element name="guid" nillable="true" type="tns:guid"/>  
 <xs:simpleType name="guid">  
  <xs:restriction base="xs:string">  
   <xs:pattern value="[\da-fA-F]{8}-[\da-fA-F]{4}-[\da-fA-F]{4}-[\da-fA-F]{4}-[\da-fA-F]{12}"/>  
  </xs:restriction>  
 </xs:simpleType>  
  
 <!-- This is used for schemas exported from ISerializable type. -->  
 <xs:attribute name="FactoryType" type="xs:QName"/>  
</xs:schema>  
```  
  
 The following should be noted:  
  
-   `ser:char` is introduced to represent Unicode characters of type <xref:System.Char>.  
  
-   The `valuespace` of `xs:duration` is reduced to an ordered set so that it can be mapped to a <xref:System.TimeSpan>.  
  
-   `FactoryType` is used in schemas exported from types that are derived from <xref:System.Runtime.Serialization.ISerializable>.  
  
## Importing non-DataContract schemas  
 `DataContractSerializer` has the `ImportXmlTypes` option to allow import of schemas that do not conform to the `DataContractSerializer` XSD profile (see the <xref:System.Runtime.Serialization.XsdDataContractImporter.Options%2A> property). Setting this option to `true` enables acceptance of non-conforming schema types and mapping them to the following implementation, <xref:System.Xml.Serialization.IXmlSerializable> wrapping an array of <xref:System.Xml.XmlNode> (only the class name differs).  
  
```  
[GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]  
[System.Xml.Serialization.XmlSchemaProviderAttribute("ExportSchema")]  
[System.Xml.Serialization.XmlRootAttribute(IsNullable=false)]  
public partial class Person : object, IXmlSerializable  
{    
  private XmlNode[] nodesField;    
  private static XmlQualifiedName typeName =   
new XmlQualifiedName("Person","http://Microsoft.ServiceModel.Samples");    
  public XmlNode[] Nodes  
  {  
    get {return this.nodesField;}  
    set {this.nodesField = value;}  
  }    
  public void ReadXml(XmlReader reader)  
  {  
    this.nodesField = XmlSerializableServices.ReadNodes(reader);  
  }    
  public void WriteXml(XmlWriter writer)  
  {  
    XmlSerializableServices.WriteNodes(writer, this.Nodes);  
  }    
  public System.Xml.Schema.XmlSchema GetSchema()  
  {  
    return null;  
  }    
  public static XmlQualifiedName ExportSchema(XmlSchemaSet schemas)  
  {  
    XmlSerializableServices.AddDefaultSchema(schemas, typeName);  
    return typeName;  
  }  
}  
```  
  
## DateTimeOffset Serialization  
 The <xref:System.DateTimeOffset> is not treated as a primitive type. Instead, it is serialized as a complex element with two parts. The first part represents the date time, and the second part represents the offset from the date time. An example of a serialized DateTimeOffset value is shown in the following code.  
  
```xml  
<OffSet xmlns:a="http://schemas.datacontract.org/2004/07/System">  
  <DateTime i:type="b:dateTime" xmlns=""   
    xmlns:b="http://www.w3.org/2001/XMLSchema">2008-08-28T08:00:00    
  </DateTime>   
  <OffsetMinutes i:type="b:short" xmlns=""   
   xmlns:b="http://www.w3.org/2001/XMLSchema">-480  
   </OffsetMinutes>   
</OffSet>  
```  
  
 The schema is as follows.  
  
```xml  
<xs:schema targetNamespace="http://schemas.datacontract.org/2004/07/System">  
   <xs:complexType name="DateTimeOffset">  
      <xs:sequence minOccurs="1" maxOccurs="1">  
         <xs:element name="DateTime" type="xs:dateTime"  
         minOccurs="1" maxOccurs="1" />  
         <xs:elementname="OffsetMinutes" type="xs:short"  
         minOccurs="1" maxOccurs="1" />  
      </xs:sequence>  
   </xs:complexType>  
</xs:schema>  
```  
  
## See Also  
 <xref:System.Runtime.Serialization.DataContractSerializer>  
 <xref:System.Runtime.Serialization.DataContractAttribute>  
 <xref:System.Runtime.Serialization.DataMemberAttribute>  
 <xref:System.Runtime.Serialization.XsdDataContractImporter>  
 [Using Data Contracts](../../../../docs/framework/wcf/feature-details/using-data-contracts.md)
