---
description: "Learn more about: <declaredTypes>"
title: "<declaredTypes>"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "dataContractSerializer element"
  - "declaredTypes element"
  - "DataContractSerializer"
  - "KnownTypes"
  - "<declaredTypes> element"
ms.assetid: f35184e4-9d9e-4d37-8fb4-d5b58220eb3e
---
# \<declaredTypes>

Contains the known types that the <xref:System.Runtime.Serialization.DataContractSerializer> uses when deserializing.  
  
 For more information about data contracts and known types, see [Data Contract Known Types](../../../wcf/feature-details/data-contract-known-types.md).  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.runtime.serialization>**](system-runtime-serialization.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<dataContractSerializer>**](datacontractserializer.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<declaredTypes>**  
  
## Syntax  
  
```xml  
<configuration>
  <system.runtime.serialization>
    <dataContractSerializer>
      <declaredTypes>
        <add type="String ">
          <knownType type="String">
            <parameter index="Integer"/>
          </knownType>
        </add>
      </declaredTypes>
    <dataContractSerializer>
  </system.runtime.serialization>
</configuration>
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  

 None.  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<add>](add-of-declaredtypes-element.md)|Adds types that require known types.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<dataContractSerializer>](datacontractserializer-of-system-runtime-serialization.md)|Contains configuration data for the <xref:System.Runtime.Serialization.DataContractSerializer>.|  
  
## Remarks  

 For more information about known types, see [Data Contract Known Types](../../../wcf/feature-details/data-contract-known-types.md) and <xref:System.Runtime.Serialization.DataContractSerializer>.  
  
## Example  

 The following XML code shows declared types and known types added to a `DataContractSerializer` element. The example shows three types being added. The first is a custom type named "Orders" that uses a known type named "Item". The second declared type is a <xref:System.Collections.Generic.List%601> that uses `Item` as a known type. Finally the third declared type is a <xref:System.Collections.Generic.Dictionary%602>. The <xref:System.Collections.Generic.Dictionary%602> class type is a generic type, with two type parameters. The first represents the key and the second represents the value. The following example adds a <xref:System.Collections.Generic.List%601> of the second type (the value) to the list of known types. You must use the `index` attribute to specify which type parameter to use in the known type. In this case, the value type is indicated by the index attribute set to "1" (the collection is zero-based).  
  
```xml  
<configuration>
  <system.runtime.serialization>
    <dataContractSerializer>
      <declaredTypes>
        <add type="Examples.Types.Orders, SerializationTypes, Version = 2.0.0.0, Culture = neutral, PublicKeyToken=null">
          <knownType type="Examples.Types.Item, SerializationTypes, Version=2.0.0.0, Culture=neutral, PublicKey=null" />
        </add>
        <add type="System.Collections.Generic.List`1, SerializationTypes, Version = 2.0.0.0, Culture = neutral, PublicKeyToken=null">
          <knownType type="Examples.Types.Item, SerializationTypes, Version=2.0.0.0, Culture=neutral, PublicKey=null" />
        </add>
        <add type="System.Collections.Generic.Dictionary`2, SerializationTypes, Version = 2.0.0.0, Culture = neutral, PublicKeyToken=null">
          <knownType type="System.Collections.Generic.List`1, SerializationTypes, Version = 2.0.0.0, Culture = neutral, PublicKeyToken=null">
            <parameter index="1"/>
          </knownType>
        </add>
      </declaredTypes>
    <dataContractSerializer>
  </system.runtime.serialization>
</configuration>
```  
  
## See also

- <xref:System.Runtime.Serialization.DataContractSerializer>
- [\<dataContractSerializer>](datacontractserializer-element.md)
- [Data Contract Known Types](../../../wcf/feature-details/data-contract-known-types.md)
- [\<add>](add-of-declaredtypes-element.md)
