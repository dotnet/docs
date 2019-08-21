---
title: "<add> of <declaredTypes> Element"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "data contracts"
  - "dataContractSerializer element"
  - "DataContractSerializer"
  - "DataContractAttribute"
ms.assetid: c3d37ae4-8f1c-463f-b195-658c5a7e90a1
---
# \<add> of \<declaredTypes> Element
Adds a type used by the <xref:System.Runtime.Serialization.DataContractSerializer> during deserialization. Each declared type includes the known types that will be returned as a field or property of the declared type.  
  
 system.runtime.serialization  
\<dataContractSerializer>  
\<declaredTypes>  
\<add> of \<declaredTypes>  
  
## Syntax  
  
```xml  
<add type="String">
  <knownType type="String">
    <parameter index="Integer"
               type="String" />
  </knownType>
</add>
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|type|Required string attribute.<br /><br /> Specifies the type name (including namespace), assembly name, version number, culture, and public key token.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<knownType>](knowntype.md)|Specifies the known type for the declared type that is being added. If the declared type is a generic type, then you must also add a parameter element to the `<knownType>` element to specify which generic parameter is used to return the known type.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<declaredTypes>](declaredtypes.md)|Contains the types that require known types during deserialization by the <xref:System.Runtime.Serialization.DataContractSerializer>.|  
  
## Remarks  
 For more information about known types, see [Data Contract Known Types](../../../wcf/feature-details/data-contract-known-types.md) and <xref:System.Runtime.Serialization.DataContractSerializer>.  
  
 See the [\<dataContractSerializer>](datacontractserializer-element.md) for an example of using this element.  
  
> [!NOTE]
> If you add the <xref:System.Object> type as a `<declaredType>`, a <xref:System.Configuration.ConfigurationErrorsException> is thrown. This is because the <xref:System.Object> type cannot be used as a declared type in configuration.  
  
## Example  
  
```xml  
<add type="MyCompany.Library.Shape,
           MyAssembly, Version=2.0.0.0, Culture=neutral,
           PublicKeyToken=XXXXXX, processorArchitecture=MSIL">
  <knownType type="MyCompany.Library.Circle,
                   MyAssembly, Version=2.0.0.0, Culture=neutral,
                   PublicKeyToken=XXXXXX,
                   processorArchitecture=MSIL" />
</add>
```  
  
## See also

- <xref:System.Runtime.Serialization.DataContractSerializer>
- [Data Contract Known Types](../../../wcf/feature-details/data-contract-known-types.md)
- [\<dataContractSerializer>](datacontractserializer-element.md)
- [\<add> of \<declaredTypes>](add-of-declaredtypes-element.md)
