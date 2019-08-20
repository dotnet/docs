---
title: "<knownType>"
ms.date: "03/30/2017"
ms.assetid: ee2b7be3-7148-4a3a-b861-48e7330615e5
---
# \<knownType>
Specifies a type to be used by <xref:System.Runtime.Serialization.DataContractSerializer> during deserialization. The element specifies a "known type" that is returned by a field or property of a "declared type." For more information, see [Data Contract Known Types](../../feature-details/data-contract-known-types.md).  
  
 \<system.runtime.serialization>  
\<dataContractSerializer>  
\<declaredTypes> Element  
\<add> of \<declaredTypes>  
\<knownType> Element  
  
## Syntax  
  
```xml  
<knownType type="String">
  <parameter index="Integer"
             type="String" />
</knownType>
```  
  
## Type  
 `string`  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|type|Specifies the type (including namespace), assembly name, version, culture, and public key token.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<parameter>](parameter.md)|Specifies a parameter index when the declared type is a generic type.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<add>](add-of-declaredtypes-element.md)|Adds a declared type to the collection of declared types.|  
  
## Remarks  
 For more information about known types, see [Data Contract Known Types](../../feature-details/data-contract-known-types.md) and <xref:System.Runtime.Serialization.DataContractSerializer>.  
  
 See the [\<dataContractSerializer>](datacontractserializer-element.md) for an example of using this element.  
  
## Example  
  
```xml  
<add type="MyCompany.Library.Shape,
           MyAssembly, Version=2.0.0.0, Culture=neutral,
           PublicKeyToken=XXXXXX, processorArchitecture=MSIL">
  <knownType type="MyCompany.Library.Circle,
                   MyAssembly, Version=2.0.0.0, Culture=neutral,
                   PublicKeyToken=XXXXXX,
                   processorArchitecture=MSIL"/>
</add>
```  
  
## See also

- <xref:System.Runtime.Serialization.DataContractSerializer>
- [Data Contract Known Types](../../feature-details/data-contract-known-types.md)
- [\<dataContractSerializer>](datacontractserializer-element.md)
- [\<add>](add-of-declaredtypes-element.md)
